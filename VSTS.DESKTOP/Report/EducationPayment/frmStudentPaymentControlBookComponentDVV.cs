using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Report.EducationPayment
{
    public partial class frmStudentPaymentControlBookComponentDVV : frmBaseFilterDVV
    {
        public frmStudentPaymentControlBookComponentDVV()
        {
            InitializeComponent();

            this.EndPoint = "/SQLViews/StudentPaymentControlBookComponentViews";
            this.FormTitle = "Buku Kontrol Penerimaan Biaya Pendidikan Per Mata Anggaran (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<StudentPaymentControlBookComponentView>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            #region Code area for regiter the event that changed Student Lookup filter
            this.FilterPopUp4.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp5.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp6.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            #endregion
        }

        #region Code area for filtering student lookup
        // Event for Class, Major, ForceYear changed
        private void ClassMajorForceYear_EditValueChanged(object sender, EventArgs e)
        {
            InitializeFilterStudent();
        }

        private void InitializeFilterStudent()
        {
            string filter = "";
            if (FilterPopUp4.EditValue != null)
            {
                var classes = FilterPopUp4.EditValue as Class;
                if (classes != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "ClassId eq " + classes.Id;
                }
            }
            if (FilterPopUp5.EditValue != null)
            {
                var major = FilterPopUp5.EditValue as Major;
                if (major != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "MajorId eq " + major.Id;
                }
            }
            if (FilterPopUp6.EditValue != null)
            {
                var forceYear = FilterPopUp6.EditValue as ForceYear;
                if (forceYear != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "ForceYearId eq " + forceYear.Id;
                }
            }
            AssemblyHelper.SetValueProperty(FilterPopUp7.Properties.OptionsDataSource, "OdataFilter", filter);
        }

        #endregion


        protected override void InitializeParameter()
        {
            base.InitializeParameter();

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Kelas";
            PopupEditHelper.General<Class>(fEndPoint: "/Classes", fTitle: "Kelas", fControl: FilterPopUp4, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Jurusan";
            PopupEditHelper.General<Major>(fEndPoint: "/Majors", fTitle: "Jurusan", fControl: FilterPopUp5, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "TypeEducation;Code;Name", fCaptionColumn: "Tipe Pendidikan;Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "TypeEducation;Code;Name");

            _LayoutControlItemFilter6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter6.Text = "Angkatan";
            PopupEditHelper.General<ForceYear>(fEndPoint: "/ForceYears", fTitle: "Angkatan", fControl: FilterPopUp6, fCascade: FilterPopUp5, fCascadeMember: "MajorId", fDisplaycolumn: "Name;Major.Name;Index", fCaptionColumn: "Nama;Jurusan;Rombel", fWidthColumn: "100;300;100", fDisplayText: "Name;Major.Name;Index", fExpand: "Major($select=name)");

            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter7.Text = "Murid";
            PopupEditHelper.General<Student>(fEndPoint: "/Students", fTitle: "Murid", fControl: FilterPopUp7, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Class.Name;Major.Name;Rombel.Name;JoinDate;PhoneNumber;Email", fCaptionColumn: "Kode;Nama;Kelas;Jurusan;Rombel;Tanggal Masuk;Nomor Telepon;Email", fWidthColumn: "120;250;60;170;65;120;120;120", fDisplayText: "Code;Name", fExpand: "Class($select=name),Major($select=name),Rombel($select=name)");

            _LayoutControlItemFilter8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter8.Text = "Mata Anggaran";
            PopupEditHelper.General<EducationComponent>(fEndPoint: "/EducationComponents", fTitle: "Mata Anggaran", fControl: FilterPopUp8, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp8, ConditionOperator.IsNotBlank);
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

                if (FilterPopUp4.EditValue != null)
                    this.OdataFilter += $"and ClassId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

                if (FilterPopUp5.EditValue != null)
                    this.OdataFilter += $"and MajorId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

                if (FilterPopUp6.EditValue != null)
                    this.OdataFilter += $"and ForceYearId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp6.EditValue, "Id"))} ";

                if (FilterPopUp7.EditValue != null)
                    this.OdataFilter += $"and StudentId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp7.EditValue, "Id"))} ";
                
                if (FilterPopUp8.EditValue != null)
                    this.OdataFilter += $"and EducationComponentId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp8.EditValue, "Id"))} ";

                var datas = HelperRestSharp.GetListOdata<StudentPaymentControlBookComponentView>("/SQLViews/StudentPaymentControlBookComponentViews", "*", "", OdataFilter, fOrder: "Id");
                if (datas.Any())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ClassName", typeof(string));
                    dt.Columns.Add("StudentCode", typeof(string));
                    dt.Columns.Add("StudentName", typeof(string));
                    dt.Columns.Add("Payment1", typeof(decimal));
                    dt.Columns.Add("Payment2", typeof(decimal));
                    dt.Columns.Add("Payment3", typeof(decimal));
                    dt.Columns.Add("Payment4", typeof(decimal));
                    dt.Columns.Add("Payment5", typeof(decimal));
                    dt.Columns.Add("Payment6", typeof(decimal));
                    dt.Columns.Add("Payment7", typeof(decimal));
                    dt.Columns.Add("Payment8", typeof(decimal));
                    dt.Columns.Add("Payment9", typeof(decimal));
                    dt.Columns.Add("Payment10", typeof(decimal));
                    dt.Columns.Add("Payment11", typeof(decimal));
                    dt.Columns.Add("Payment12", typeof(decimal));
                    dt.Columns.Add("PaymentPaid", typeof(decimal));
                    dt.Columns.Add("Arrear", typeof(decimal));
                    dt.Columns.Add("Bill", typeof(decimal));

                    foreach (var data in datas)
                    {
                        DataRow r = dt.NewRow();
                        r["ClassName"] = $"{data.ClassName} {data.MajorCode} {data.ForceYearIndex}";
                        r["StudentCode"] = data.StudentCode;
                        r["StudentName"] = data.StudentName;
                        r["Payment1"] = data.Payment1;
                        r["Payment2"] = data.Payment2;
                        r["Payment3"] = data.Payment3;
                        r["Payment4"] = data.Payment4;
                        r["Payment5"] = data.Payment5;
                        r["Payment6"] = data.Payment6;
                        r["Payment7"] = data.Payment7;
                        r["Payment8"] = data.Payment8;
                        r["Payment9"] = data.Payment9;
                        r["Payment10"] = data.Payment10;
                        r["Payment11"] = data.Payment11;
                        r["Payment12"] = data.Payment12;
                        r["PaymentPaid"] = data.PaymentPaid;
                        r["Arrear"] = data.Arrear;
                        r["Bill"] = data.Bill;

                        dt.Rows.Add(r);
                    }
                    rptPaymentControlBookComponent report = new rptPaymentControlBookComponent();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                    report.DataSource = dt;

                    //Detail
                    report.xrClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[ClassName]"));
                    report.xrStudentCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[StudentCode]"));
                    report.xrStudentName.ExpressionBindings.Add(new ExpressionBinding("Text", "[StudentName]"));
                    report.xrPayment1.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment1]"));
                    report.xrPayment2.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment2]"));
                    report.xrPayment3.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment3]"));
                    report.xrPayment4.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment4]"));
                    report.xrPayment5.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment5]"));
                    report.xrPayment6.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment6]"));
                    report.xrPayment7.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment7]"));
                    report.xrPayment8.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment8]"));
                    report.xrPayment9.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment9]"));
                    report.xrPayment10.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment10]"));
                    report.xrPayment11.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment11]"));
                    report.xrPayment12.ExpressionBindings.Add(new ExpressionBinding("Text", "[Payment12]"));
                    report.xrPaymentPaid.ExpressionBindings.Add(new ExpressionBinding("Text", "[PaymentPaid]"));
                    report.xrArrear.ExpressionBindings.Add(new ExpressionBinding("Text", "[Arrear]"));
                    report.xrBill.ExpressionBindings.Add(new ExpressionBinding("Text", "[Bill]"));

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

                    report.xrTitle.Text = "BUKU KONTROL PENERIMAAN BIAYA PENDIDIKAN";
                    EducationComponent educationComponent = FilterPopUp8.EditValue as EducationComponent;
                    if (educationComponent != null)
                        report.xrTitle.Text = $"BUKU KONTROL PENERIMAAN BIAYA {educationComponent.Name.ToUpper()}";

                    report.Name = $"BukuKontrolPenerimaanBiayaPendidikan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                    string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{report.Name}.pdf";
                    report.DisplayName = report.Name;
                    report.PrinterName = report.Name;

                    //set document source
                    _DocumentViewer.DocumentSource = report;
                    _DocumentViewer.InitiateDocumentCreation();
                }
                else
                {
                    _DocumentViewer.DocumentSource = null;
                    MessageHelper.ShowMessageError(this, "Data tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}
