using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.EducationResource;
using PopUpUtils;
using System;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.EducationResource
{
    public partial class frmForceYearDV : frmBaseDV
    {
        ForceYear _ForceYear;
        public frmForceYearDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<ForceYear>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            HelperConvert.FormatDateTextEdit(FromYearTextEdit, "yyyy");
            HelperConvert.FormatDateTextEdit(ToYearTextEdit, "yyyy");
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FromYearTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ToYearTextEdit, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (FromYearTextEdit.EditValue != null && ToYearTextEdit.EditValue != null)
            {
                var fromYear = HelperConvert.Date(FromYearTextEdit.EditValue).Year;
                var toYear = HelperConvert.Date(ToYearTextEdit.EditValue).Year;
                if (fromYear == toYear)
                {
                    MessageHelper.ShowMessageError(this, "Tahun1 dan Tahun2 tidak boleh sama!");
                    result = false;
                }
                else if (fromYear > toYear)
                {
                    MessageHelper.ShowMessageError(this, "Tahun1 tidak boleh lebih besar Tahun2!");
                    result = false;
                }
                else if (toYear > fromYear + 1)
                {
                    MessageHelper.ShowMessageError(this, "Tahun1 dan Tahun2 tidak boleh lebih dari 2 periode tahun!");
                    result = false;
                }
            }

            return result;
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _ForceYear = OdataEntity as ForceYear;

            if (_ForceYear != null)
            {
                FromYearTextEdit.EditValue = new DateTime(_ForceYear.FromYear, 1, 1);
                ToYearTextEdit.EditValue = new DateTime(_ForceYear.ToYear, 1, 1);
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<ForceYear>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<ForceYear>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<ForceYear>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _ForceYear = new ForceYear()
            {
                Id = _ForceYear.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                FromYear = HelperConvert.Date(FromYearTextEdit.EditValue).Year,
                ToYear = HelperConvert.Date(ToYearTextEdit.EditValue).Year
            };

            OdataEntity = _ForceYear;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<ForceYear>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<ForceYear>();
        }
    }
}
