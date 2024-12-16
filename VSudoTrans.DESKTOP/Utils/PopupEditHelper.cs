using DevExpress.Data;
using System;
using Microsoft.OData.Client;
using DevExpress.Data.Filtering;
using DevExpress.Data.ODataLinq;
using System.Threading.Tasks;
using VSudoTrans.DESKTOP.Descendant;
using VSudoTrans.DESKTOP.Utils;
using Domain.Entities.Identity;
using Domain.Entities.Organization;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509;
using System.Linq;
using Domain.Entities.Transportation;

namespace PopUpUtils
{
    public enum EnumDataSource
    {
        VirtualMode,
        OdataInstant,
        Offline
    }

    public class PopUpParameters<T>
    {
        #region Contructor
        public PopUpParameters(DataServiceContext odatacontext, string endpoint, string expand = "", string filter = "", string select = "", string sort = "", EnumDataSource optionsDataSourceType = EnumDataSource.VirtualMode, object optionsDataSource = null)
        {
            OdataContext = odatacontext;
            OdataEndpoint = endpoint;
            OdataExpand = expand;
            OdataFilter = filter;
            OdataSelect = select;
            OdataSort = sort;

            BatchCount = 20;
            OptionsDataSourceType = optionsDataSourceType;
            OptionsDataSources = optionsDataSource;
        }
        #endregion

        private DataServiceContext OdataContext { get; }
        public string OdataEndpoint { get; }
        public string OdataSelect { get; set; }
        public string OdataExpand { get; set; }
        public string OdataFilter { get; set; }
        public string OdataSort { get; set; }
        public string OdataCascade { get; set; }
        public EnumDataSource? OptionsDataSourceType { get; }
        public string OptionsCascadeControl { get; set; }
        public string OptionsCascadeMember { get; set; } = string.Empty;
        public object OptionsDataSources { get; set; }

        public CriteriaOperator FixedCriteria { get; }

        private ODataInstantFeedbackSource _DataSourcesODataInstantFeedback;
        public ODataInstantFeedbackSource DataSourcesODataInstantFeedback
        {
            get
            {
                _DataSourcesODataInstantFeedback = new ODataInstantFeedbackSource();

                var query = OdataContext.CreateQuery<T>(OdataEndpoint);

                if (string.IsNullOrEmpty(OdataSelect) == true)
                {
                    OdataSelect = "id,code,name";
                }
                query = query.AddQueryOption("$select", OdataSelect);

                if (string.IsNullOrEmpty(OdataExpand) == false)
                {
                    query = query.AddQueryOption("$expand", OdataExpand);
                }
                if (string.IsNullOrEmpty(OdataSort) == false)
                {
                    query = query.AddQueryOption("$orderby", OdataSort);
                }

                // add event
                _DataSourcesODataInstantFeedback.GetSource += (d, e) =>
                {
                    e.KeyExpressions = new string[] { "Id" };
                    e.Query = query;
                    e.Tag = OdataContext;
                };
                _DataSourcesODataInstantFeedback.GetSource += (d, e) =>
                {
                    DataServiceContext container = (DataServiceContext)e.Tag;
                };

                //}
                return _DataSourcesODataInstantFeedback;
            }
        }

        #region Code area for VirtualServerMode        
        public int BatchCount { get; set; }
        public int CurrentCount { get; set; }

        private VirtualServerModeSource _DataSourcesVirtualServerMode;
        public VirtualServerModeSource DataSourcesVirtualServerMode
        {
            get
            {
                _DataSourcesVirtualServerMode = new VirtualServerModeSource();
                _DataSourcesVirtualServerMode.RowType = typeof(T);
                _DataSourcesVirtualServerMode.MoreRows += SourceOnMoreRows;
                _DataSourcesVirtualServerMode.ConfigurationChanged += SourceOnConfigurationChanged;

                return _DataSourcesVirtualServerMode;
            }
        }

        private void SourceOnConfigurationChanged(object sender, VirtualServerModeRowsEventArgs e)
        {
            CurrentCount = 0;
        }

        private void SourceOnMoreRows(object sender, VirtualServerModeRowsEventArgs e)
           => e.RowsTask = Task.Factory.StartNew((Func<VirtualServerModeRowsTaskResult>)(() =>
           {
               try
               {
                   // Applying Filter
                   string filter = "";

                   // filter that coming from constructor
                   if (string.IsNullOrEmpty(OdataFilter) == false)
                   {
                       filter = OdataFilter;
                   }
                   // filter that coming from constructor
                   if (string.IsNullOrEmpty(OdataCascade) == false)
                   {
                       if (string.IsNullOrEmpty(filter) == false)
                       {
                           filter += $" and ({OdataCascade})";
                       }
                       else
                       {
                           filter = OdataCascade;
                       }
                   }

                   var datas = HelperRestSharp.LoadMoreDatas<T>(e.ConfigurationInfo, (string)this.OdataEndpoint, this.OdataSelect, this.OdataExpand, this.OdataFilter, this.OdataSort, BatchCount, CurrentCount, this.OdataCascade);

                   if (datas != null)
                   {
                       var list = datas.ToArray();

                       var currentBatchCount = list.Length;
                       var moreRows = currentBatchCount >= BatchCount;
                       CurrentCount += currentBatchCount;

                       return new VirtualServerModeRowsTaskResult(list, moreRows);
                   }
                   else
                   {
                       return null;
                   }
               }
               catch (Exception ex)
               {
                   MessageHelper.ShowMessageError(ex);
                   return null;
               }
           }), e.CancellationToken);

        #endregion
    }

    public static class PopupEditHelper
    {
        public static string Select { get; set; } = string.Empty;
        public static string Expand { get; set; } = string.Empty;
        public static string Collapse { get; set; } = string.Empty;
        public static string Filter { get; set; } = string.Empty;
        public static string DisplayColumn { get; set; } = string.Empty;
        public static string CaptionColumn { get; set; } = string.Empty;
        public static string WidthColumn { get; set; } = string.Empty;
        public static string FilterColumn { get; set; } = string.Empty;

        public static RepositoryItemPopupContainerEditOwn GetRepoPopUp(object fControl)
        {
            RepositoryItemPopupContainerEditOwn repo = null;
            if (fControl.GetType() == typeof(PopupContainerEditOwn))
            {
                repo = (fControl as PopupContainerEditOwn).Properties;
            }
            else
            {

                repo = fControl as RepositoryItemPopupContainerEditOwn;
            }
            return repo;
        }

        public static void General<T>(string fEndPoint, RepositoryItemPopupContainerEditOwn fControl,
                                      string fExpand = "", object fCascade = null, string fCascadeMember = "", object fChild = null,
                                      string fTitle = "", string fDisplaycolumn = "", string fCaptionColumn = "", string fWidthColumn = "",
                                      string fFilter = "", string fSelect = "", string fDisplayText = "", object fDataSource = null,
                                      string fOptionsDisplayFormat = "", string fFilterColumn = "", string fSort = "") where T : class
        {
            DataServiceContext fContext = new DataServiceContext(new Uri(ApplicationSettings.Instance.UriHelper.UrlApiDefault));
            var repo = fControl;
            repo.OptionsDisplayTitle = fTitle;
            if (fContext != null)
            {
                repo.OptionsDataSource = new PopUpParameters<T>(fContext, fEndPoint, fExpand, fFilter, fSelect, fSort);
            }
            else
            {
                if (fContext == null)
                {
                    // diasumsikan offline data                    
                    repo.OptionsDataSource = fDataSource;
                }
            }
            repo.OptionsDisplayText = fDisplayText;
            repo.OptionsChildControl = fChild;
            repo.OptionsCascadeControl = fCascade;
            repo.OptionsDisplayColumns = fDisplaycolumn;
            repo.OptionsDisplayCaption = fCaptionColumn;
            repo.OptionsCascadeMember = fCascadeMember;
            repo.OptionsDisplayWidth = fWidthColumn;
            repo.OptionsDisplayFormat = fOptionsDisplayFormat;
            repo.OptionsFilterColumns = fFilterColumn;
        }

        public static void General<T>(string fEndPoint, PopupContainerEditOwn fControl,
                                      string fExpand = "", object fCascade = null, string fCascadeMember = "", object fChild = null,
                                      string fTitle = "", string fDisplaycolumn = "", string fCaptionColumn = "", string fWidthColumn = "",
                                      string fFilter = "", string fSelect = "", string fDisplayText = "", object fDataSource = null,
                                      string fOptionsDisplayFormat = "", string fFilterColumn = "", string fSort = "") where T : class
        {
            DataServiceContext fContext = new DataServiceContext(new Uri(ApplicationSettings.Instance.UriHelper.UrlApiDefault));
            RepositoryItemPopupContainerEditOwn repo = fControl.Properties;
            repo.OptionsDisplayTitle = fTitle;
            if (fContext != null)
            {
                repo.OptionsDataSource = new PopUpParameters<T>(fContext, fEndPoint, fExpand, fFilter, fSelect, fSort);
            }
            repo.OptionsDisplayText = fDisplayText;
            repo.OptionsChildControl = fChild;
            repo.OptionsCascadeControl = fCascade;
            repo.OptionsDisplayColumns = fDisplaycolumn;
            repo.OptionsDisplayCaption = fCaptionColumn;
            repo.OptionsCascadeMember = fCascadeMember;
            repo.OptionsDisplayWidth = fWidthColumn;
            repo.OptionsDisplayFormat = fOptionsDisplayFormat;
            repo.OptionsFilterColumns = fFilterColumn;

            if (fDataSource != null)
            {
                // tidak menggunakan OdataContext
                // so assumsi meenggunakan internal data source
                repo.OptionsDataSource = fDataSource;
            }

        }

        public static void Company(PopupContainerEditOwn fControl, PopupContainerEditOwn fChild = null)
        {
            //PopupEditHelper.General<Company>(fEndPoint: "/Companys", fTitle: "Perusahaan", fControl: fControl, fChild: fChild, fDisplaycolumn: "Code;Name;PhoneNumber", fCaptionColumn: "Kode;Nama;Nomor Telepon", fWidthColumn: "100;400;300");

            RepositoryItemPopupContainerEditOwn repo = GetRepoPopUp(fControl);
            //repo.OptionsDataType = EnumDataSource.Offline;

            var roleNames = ApplicationSettings.Instance.UserRoles.Select(s => s.Name);
            if (roleNames.FirstOrDefault(s => s == "Super Administrator") != null)
                repo.OptionsDataSource = HelperRestSharp.GetListOdata<Company>("/Companys");
            else
                repo.OptionsDataSource = ApplicationSettings.Instance.UserCompanys;

            //munculkan di popup, untuk first data company yang dimiliki oleh user login
            if (ApplicationSettings.Instance.UserCompanys.Count > 0)
            {
                (fControl as PopupContainerEditOwn).EditValue = ApplicationSettings.Instance.UserCompanys[0];
            }

            repo.OptionsChildControl = fChild;
            repo.OptionsCascadeControl = null;
            repo.OptionsDisplayCaption = "Kode Perusahaan;Nama Perusahaan";
            repo.OptionsDisplayText = "Code;Name";
            repo.OptionsDisplayColumns = "Code;Name;PhoneNumber";
            repo.OptionsDisplayCaption = "Kode;Nama;Nomor Telepon";
            repo.OptionsDisplayWidth = "100;400;300";
        }

        public static void Passenger(PopupContainerEditOwn fControl, PopupContainerEditOwn fCascade = null, string fCascadeMember = "", PopupContainerEditOwn fChild = null)
        {
            General<Passenger>(fEndPoint: "/Passengers", fTitle: "Pelanggan", fControl: fControl, fCascade: fCascade, fCascadeMember: fCascadeMember, fChild: fChild, fSelect: "Id,Code,Name,PhoneNumber", fDisplayText: "Code;Name;PhoneNumber", fDisplaycolumn: "Code;Name;PhoneNumber", fCaptionColumn: "Kode;Nama;Nomor Telepon", fWidthColumn: "150;400;300");
        }
    }
}
