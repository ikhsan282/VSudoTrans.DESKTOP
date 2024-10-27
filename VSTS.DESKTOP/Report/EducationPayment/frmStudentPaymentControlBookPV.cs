using DevExpress.XtraEditors.DXErrorProvider;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;
using Domain.Entities.SQLView.EducationPayment;
using Domain.Entities.EducationResource;

namespace VSTS.DESKTOP.Report.EducationPayment
{
    public partial class frmStudentPaymentControlBookPV : frmBasePV
    {
        public frmStudentPaymentControlBookPV()
        {
            InitializeComponent();

            this.EndPoint = "/SQLViews/ArrearStudentEducationPaymentViews";
            this.FormTitle = "Buku Kontrol Pembayaran Biaya Pendidikan (Pivot Table)";

            this.OdataSelect = "*";
            //this.OdataSelect += "CompanyId,CompanyCode,CompanyName,";
            //this.OdataSelect += "Type,IndexType,IndexTotal";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            HelperConvert.FormatDateTextEdit(YearTextEdit, "yyyy");
            HelperConvert.FormatDateTextEdit(MonthTextEdit, "MMMM");

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<ArrearStudentEducationPaymentView>();
            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            pivotGridFieldClassName.BestFit();
            pivotGridFieldIndex.BestFit();
            pivotGridFieldBill.BestFit();
            pivotGridFieldPaidBill.BestFit();

            //_pivotGridControl.CustomCellDisplayText += _pivotGridControl_CustomCellDisplayText;
            //_pivotGridControl.FieldValueDisplayText += _pivotGridControl_FieldValueDisplayText;

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

        //private void _pivotGridControl_FieldValueDisplayText(object sender, DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs e)
        //{
        //    if (e.ValueType == PivotGridValueType.Value && e.Field != null && e.Field.Caption == "Sistem Pendeteksi")
        //    {
        //        if (e.Value != null)
        //        {
        //            e.DisplayText = EnumHelper.EnumRecognitionToString((EnumRecognition)e.Value);
        //        }
        //    }
        //}

        //private void _pivotGridControl_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        //{
        //    if (e.Value == null)
        //    {
        //        e.DisplayText = "0";
        //    }
        //}

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Kelas";
            PopupEditHelper.General<Class>(fEndPoint: "/Classes", fTitle: "Kelas", fControl: FilterPopUp4, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Jurusan";
            PopupEditHelper.General<Major>(fEndPoint: "/Majors", fTitle: "Jurusan", fControl: FilterPopUp5, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "TypeEducation;Code;Name", fCaptionColumn: "Tipe Pendidikan;Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "TypeEducation;Code;Name");

            _LayoutControlItemFilter6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter6.Text = "Angkatan";
            PopupEditHelper.General<ForceYear>(fEndPoint: "/ForceYears", fTitle: "Angkatan", fControl: FilterPopUp6, fDisplaycolumn: "Name", fCaptionColumn: "Nama", fWidthColumn: "100", fDisplayText: "Name");

            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter7.Text = "Murid";
            PopupEditHelper.General<Student>(fEndPoint: "/Students", fTitle: "Murid", fControl: FilterPopUp7, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Class.Name;Major.Name;Rombel.Name;JoinDate;PhoneNumber;Email", fCaptionColumn: "Kode;Nama;Kelas;Jurusan;Rombel;Tanggal Masuk;Nomor Telepon;Email", fWidthColumn: "120;250;60;170;65;120;120;120", fDisplayText: "Code;Name", fExpand: "Class($select=name),Major($select=name),Rombel($select=name)");

            _LayoutControlItemFilter8.Text = "Tahun";
            _LayoutControlItemFilter9.Text = "Bulan";
        }

        protected override void ActionRefresh<T>()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;
            
            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            if (FilterPopUp4.EditValue != null)
                this.OdataFilter += $"and ClassId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

            if (FilterPopUp5.EditValue != null)
                this.OdataFilter += $"and MajorId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

            if (FilterPopUp6.EditValue != null)
                this.OdataFilter += $"and ForceYearId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp6.EditValue, "Id"))} ";
            
            if (FilterPopUp7.EditValue != null)
                this.OdataFilter += $"and StudentId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp7.EditValue, "Id"))} ";

            if (YearTextEdit.EditValue != null)
                this.OdataFilter += $"and Year eq {HelperConvert.Date(YearTextEdit.EditValue).Year} ";

            if (MonthTextEdit.EditValue != null)
                this.OdataFilter += $"and Month eq {HelperConvert.Date(MonthTextEdit.EditValue).Month} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<ArrearStudentEducationPaymentView>();
        }
    }
}
