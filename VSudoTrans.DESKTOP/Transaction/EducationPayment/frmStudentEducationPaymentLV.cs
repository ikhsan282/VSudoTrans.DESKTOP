using Contract.EducationPayment;
using Contract.Organization;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Newtonsoft.Json;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Master.Organization;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Transaction.EducationPayment
{
    public partial class frmStudentEducationPaymentLV : frmBaseFilterLV
    {
        public frmStudentEducationPaymentLV()
        {
            InitializeComponent();

            this.EndPoint = "/Students";
            this.FormTitle = "Penerimaan SPP";

            this.OdataSelect = "Id,Code,Name,ParentalStatus";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",Class($select=name)";
            this.OdataExpand += ",Major($select=code)";
            this.OdataExpand += ",Rombel($select=name)";
            this.OdataExpand += ",ForceYear($select=name)";

            InitializeComponentAfter<Student>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;

            _GridView.OptionsSelection.MultiSelect = true;
            _GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

            #region Code area for regiter the event that changed Student Lookup filter
            this.FilterPopUp4.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp5.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp6.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            #endregion
        }

        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/StudentEducationPayments/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryStudentEducationPaymentModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryStudentEducationPaymentModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ShowMessageError(this, ex.Message);
                    }
                    finally
                    {
                        MessageHelper.WaitFormClose();
                    }

                    if (result != null)
                    {
                        using (var form = new frmImportStudentEducationPaymentWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/StudentEducationPayments/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                    }
                                }
                            }
                            else if (resultDialog == System.Windows.Forms.DialogResult.Cancel)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void BbiTemplateImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileExcel = HelperRestSharp.DownloadFile("VSudoTrans", "import/Import Student Education Payment.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import Student Education Payment");
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
                var rombel = FilterPopUp6.EditValue as Rombel;
                if (rombel != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "RombelId eq " + rombel.Id;
                }
            }
            if (FilterPopUp7.EditValue != null)
            {
                var forceYear = FilterPopUp7.EditValue as ForceYear;
                if (forceYear != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "ForceYearId eq " + forceYear.Id;
                }
            }
            AssemblyHelper.SetValueProperty(FilterPopUp8.Properties.OptionsDataSource, "OdataFilter", filter);
        }

        #endregion

        protected override void ActionNew()
        {
            (new frmStudentEducationPaymentWV()).ShowDialog();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
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
            _LayoutControlItemFilter6.Text = "Rombel";
            PopupEditHelper.General<Rombel>(fEndPoint: "/Rombels", fTitle: "Rombel", fControl: FilterPopUp6, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");

            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter7.Text = "Angkatan";
            PopupEditHelper.General<ForceYear>(fEndPoint: "/ForceYears", fTitle: "Angkatan", fControl: FilterPopUp7, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fWidthColumn: "100", fDisplayText: "Name");

            _LayoutControlItemFilter8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter8.Text = "Murid";
            PopupEditHelper.General<Student>(fEndPoint: "/Students", fTitle: "Murid", fControl: FilterPopUp8, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Class.Name;Major.Name;Rombel.Name;JoinDate;PhoneNumber;Email", fCaptionColumn: "Kode;Nama;Kelas;Jurusan;Rombel;Tanggal Masuk;Nomor Telepon;Email", fWidthColumn: "120;250;60;180;65;120;120;120", fDisplayText: "Code;Name", fExpand: "Class($select=name),Major($select=name),Rombel($select=name)");
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            //Validasi searchLookup
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            if (FilterPopUp4.EditValue != null)
                OdataFilter += $" and ClassId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

            if (FilterPopUp5.EditValue != null)
                OdataFilter += $" and MajorId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

            if (FilterPopUp6.EditValue != null)
                OdataFilter += $" and RombelId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp6.EditValue, "Id"))} ";

            if (FilterPopUp7.EditValue != null)
                OdataFilter += $" and ForceYearId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp7.EditValue, "Id"))} ";

            if (FilterPopUp8.EditValue != null)
                OdataFilter += $" and Id eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp8.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_GridView.SelectedRowsCount == 0)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            if (MessageHelper.ShowMessageQuestion(MessageHelper.MessageDelete) == System.Windows.Forms.DialogResult.No) return;

            List<Student> students = GetListDataRowSelected(_GridView).OfType<Student>().ToList();

            List<int> studentIds = students.Select(s => s.Id).ToList();

            var studentEducationPayments = HelperRestSharp.GetListOdata<StudentEducationPayment>("/StudentEducationPayments", "Id", "", $"StudentId in ({string.Join(",", studentIds)})", fOrder: "Id");

            var jsonString = JsonConvert.SerializeObject(studentEducationPayments.Select(s => s.Id).ToList());
            var result = HelperRestSharp.DeleteRange($"/StudentEducationPayments/Multiple", jsonString);

            if (result != null)
            {
                MessageHelper.ShowMessageInformation(this, $"Data Berhasil Di Delete ");
                ActionRefresh<Student>();
            }
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Student>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmStudentEducationPaymentDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}
