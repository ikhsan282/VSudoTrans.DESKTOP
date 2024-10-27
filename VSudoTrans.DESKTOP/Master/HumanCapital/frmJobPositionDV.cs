using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmJobPositionDV : frmBaseDV
    {
        JobPosition _JobPosition;
        public frmJobPositionDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeSearchLookup();
            InitializeComponentAfter<JobPosition>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.JobTitlePopUp, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (JobPositionPopUp.EditValue != null && _JobPosition != null)
            {
                var JobPosition = JobPositionPopUp.EditValue as JobPosition;
                if (JobPosition != null)
                {
                    if (_JobPosition.Id == JobPosition.Id)
                    {
                        MessageHelper.ShowMessageError(this, "Tidak dapat memilih induk organisasi ke diri sendiri!");
                        result = false;
                    }
                }
            }

            return result;
        }
        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _JobPosition = OdataEntity as JobPosition;

            if (_JobPosition != null)
            {
                var parent = HelperRestSharp.GetOdata<JobPosition>("/JobPositions", "Id,ParentId,Code,Name,Level", fFilter: $"Id eq {_JobPosition.ParentId}");
                if (parent != null)
                    _JobPosition.Parent = parent;
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp, JobTitlePopUp);
            PopupEditHelper.General<JobPosition>(fEndPoint: "/JobPositions", fTitle: "Posisi", fControl: JobPositionPopUp, fExpand: "JobTitle($select=id,code,name)", fDisplaycolumn: "Code;Name;Level;JobTitle.Code;JobTitle.Name", fCaptionColumn: "Kode;Nama;Tingkat;Kode Jabatan;Nama Jabatan");
            PopupEditHelper.General<JobTitle>(fEndPoint: "/JobTitles", fTitle: "Jabatan", fControl: JobTitlePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Level", fCaptionColumn: "Kode;Nama;Tingkat");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<JobPosition>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<JobPosition>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<JobPosition>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _JobPosition = new JobPosition()
            {
                Id = _JobPosition.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                JobTitleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(JobTitlePopUp.EditValue, "Id")),
                Level = _JobPosition.Level
            };

            var parent = JobPositionPopUp.EditValue as JobPosition;
            if (parent != null)
                _JobPosition.ParentId = parent.Id;
            else
                _JobPosition.ParentId = null;

            OdataEntity = _JobPosition;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<JobPosition>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<JobPosition>();
        }
    }
}
