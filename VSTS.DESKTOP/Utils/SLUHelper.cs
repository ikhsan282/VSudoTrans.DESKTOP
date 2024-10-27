using DevExpress.Data.Filtering;
using DevExpress.Data.ODataLinq;
using DevExpress.DataAccess.EntityFramework;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VSTS.DESKTOP.Utils
{
    public class SLUHelper
    {
        public static void SetEnumDataSource<TEnum>(RepositoryItemSearchLookUpEdit slu, Converter<TEnum, string> displayTextConverter, string sortBy = "Value")
        {
            slu.DataSource = EnumDataSource(displayTextConverter, sortBy);
            slu.ValueMember = "Key";
            slu.DisplayMember = "Value";

            if (slu.View.Columns.Count == 0)
            {
                slu.View.Columns.AddField("Value").Visible = true;
                slu.View.Columns.AddField("Key").Visible = false;
            }

            slu.View.Columns["Value"].Caption = "Nama";
            slu.NullText = "";
        }

        public static void SetEnumDataSource<TEnum>(SearchLookUpEdit slu, Converter<TEnum, string> displayTextConverter, string sortBy = "Value")
        {
            SetEnumDataSource<TEnum>(slu.Properties, displayTextConverter, sortBy);
        }

        public static Dictionary<object, string> EnumDataSource<TEnum>(Converter<TEnum, string> displayTextConverter, string sortBy = "Value")
        {
            Dictionary<object, string> result = new Dictionary<object, string>();
            if (displayTextConverter == null)
            {
                displayTextConverter = (TEnum v) => EnumDisplayTextHelper.GetDisplayText(v);
            }

            foreach (TEnum val in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                result.Add(val, displayTextConverter(val));
            }

            if (sortBy == "Value")
                return result.Where(x => x.Value != "").OrderBy(x => x.Value).ToDictionary(s => s.Key, s => s.Value);
            else
                return result.Where(x => x.Value != "").OrderBy(x => x.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        public static void GeneralSlU(SearchLookUpEdit fSLU, object fDataSource, SearchLookUpEdit fCascading = null, string columnDefault = "Code;Name", string captionDefault = "Kode;Nama", string displayMember = "Name")
        {
            fSLU.Properties.DataSource = null;

            // assign editor tag for variable to use
            //fSLU.Tag = fDataSource;
            fSLU.CascadingOwner = fCascading;

            fSLU.Properties.DataSource = fDataSource;
            InitializeSearchLookUp(fSLU, columnDefault, captionDefault, displayMember);
        }

        public static void GeneralSlU(RepositoryItemSearchLookUpEdit fSearchLookUpEditRepo, object fDataSource, SearchLookUpEdit fCascading = null, string columnDefault = "Code;Name", string captionDefault = "Kode;Nama", string displayMember = "Name")
        {
            fSearchLookUpEditRepo.DataSource = null;

            // assign editor tag for variable to use
            //fSLU.Tag = fDataSource;
            //fSearchLookUpEditRepo.CascadingOwner = fCascading;

            fSearchLookUpEditRepo.DataSource = fDataSource;
            InitializeSearchLookUp(fSearchLookUpEditRepo, columnDefault, captionDefault, displayMember);
        }

        private static void InitializeSearchLookUp(SearchLookUpEdit fSearchLookUpEdit, string columnDefault = "Code;Name", string captionDefault = "Kode;Nama", string displayMember = "Name")
        {
            fSearchLookUpEdit.Properties.Tag = fSearchLookUpEdit.Tag;
            InitializeSearchLookUp(fSearchLookUpEdit.Properties, columnDefault, captionDefault, displayMember);
        }

        private static void InitializeSearchLookUp(RepositoryItemSearchLookUpEdit fSearchLookUpEditRepo, string columnDefault = "Code;Name", string captionDefault = "Kode;Nama", string displayMember = "Name")
        {
            //var properties = fSearchLookUpEditRepo.Tag;
            //if (properties == null) return;

            //// get datasource from properties that assign to Search Look Up
            //var dataSource = AssemblyHelper.GetValueProperty(properties, "DataSources") as ODataInstantFeedbackSource;
            //var fixedCriteria = AssemblyHelper.GetValueProperty(properties, "FixedCriteria") as CriteriaOperator;
            //var groupOperator = new GroupOperator(GroupOperatorType.And);

            //if (ReferenceEquals(fixedCriteria, null) == false)
            //{
            //    groupOperator.Operands.Add(fixedCriteria);
            //}
            //dataSource.FixedFilterCriteria = null;
            //if (groupOperator.Operands.Count > 0)
            //{
            //    dataSource.FixedFilterCriteria = groupOperator;
            //}

            var valueMember = "Id";
            if (string.IsNullOrEmpty(valueMember) == true)
            {
                valueMember = "Id";
            }

            var title = "";//"Shift"

            string columns = columnDefault;

            string widths = "160";
            string captions = captionDefault;

            var slu = fSearchLookUpEditRepo;
            var gridview = slu.View;
            //slu.DataSource = dataSource;
            slu.NullText = "";
            slu.ValueMember = valueMember;
            slu.DisplayMember = displayMember;

            //slu.Buttons[0].Kind = ButtonPredefines.Search;
            slu.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            //gridview.HorzScrollStep = 30;
            //gridview.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridview.OptionsBehavior.AutoPopulateColumns = false;
            gridview.OptionsBehavior.Editable = false;
            gridview.OptionsView.ColumnAutoWidth = true;
            gridview.OptionsDetail.EnableMasterViewMode = false;
            gridview.OptionsFilter.AllowFilterEditor = false;
            gridview.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 20;
            gridview.ViewCaption = title;
            gridview.OptionsView.ShowAutoFilterRow = false;
            gridview.OptionsView.ShowFooter = false;
            gridview.OptionsView.ShowGroupPanel = false;
            gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            GridColumn gridcolumn;
            string[] tmpDisplayableProperties = null;
            string[] tmpColumnWidth = null;
            string[] tmpColumnCaption = null;

            if (!string.IsNullOrEmpty(columns))
            {
                if (columns.Contains("Id,") == true)
                    columns = columns.Replace("Id,", "");

                if (columns.Contains("Id,") == true)
                    columns = columns.Replace("Id,", "");

                if (columns.Contains("This;") == true)
                    columns = columns.Replace("This,", "");

                tmpDisplayableProperties = columns.Split(new char[] { ';' });
            }
            if (!string.IsNullOrEmpty(widths))
            {
                tmpColumnWidth = widths.Split(new char[] { ';' });
            }
            if (!string.IsNullOrEmpty(captions))
            {
                tmpColumnCaption = captions.Split(new char[] { ';' });
            }

            if (tmpDisplayableProperties != null)
            {
                gridview.Columns.Clear();
                for (int i = 0; i <= tmpDisplayableProperties.Length - 1; i++)
                {
                    gridcolumn = new GridColumn();
                    {
                        gridcolumn.FieldName = tmpDisplayableProperties[i];

                        // -- Asking to devexpress, each column must be unique, http://www.devexpress.com/Support/Center/Question/Details/Q501284                    
                        gridcolumn.Name = Guid.NewGuid().ToString();
                        gridcolumn.Visible = true;
                        gridcolumn.VisibleIndex = i;
                        if (tmpColumnWidth.Length > 0 & tmpColumnWidth.Length > i)
                        {
                            if (tmpColumnWidth[0] == "")
                                gridcolumn.BestFit();
                            else
                                try
                                {
                                    gridcolumn.Width = int.Parse(tmpColumnWidth[i]);
                                    gridcolumn.OptionsColumn.FixedWidth = true;
                                }
                                catch
                                {
                                    gridcolumn.BestFit();
                                }
                        }
                        else
                        {
                            gridcolumn.BestFit();
                        };
                        gridcolumn.Caption = tmpColumnCaption[i];
                    }
                    gridview.Columns.Add(gridcolumn);
                }
            }

            //if (slu.OwnerEdit != null)
            //{
            //    if (slu.OwnerEdit.GetType() == typeof(SearchLookUpEdit))
            //    {
            //        slu.CustomDisplayText += CustomDisplayText;
            //    }
            //}
            //else
            //{
            //    slu.CustomDisplayText += CustomDisplayTextRepo;
            //}



            //slu.QueryPopUp += QueryPopUp;
            //slu.EditValueChanged += EditValueChanged;
        }

    }
}
