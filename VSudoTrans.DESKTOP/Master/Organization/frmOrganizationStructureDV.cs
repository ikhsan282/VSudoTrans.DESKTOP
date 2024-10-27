using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.HumanResource;
using Domain.Entities.Organization;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Organization
{
    public partial class frmOrganizationStructureDV : frmBaseDV
    {
        OrganizationStructure _OrganizationStructure;
        public frmOrganizationStructureDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeSearchLookup();
            InitializeComponentAfter<OrganizationStructure>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (OrganizationStructurePopUp.EditValue != null && _OrganizationStructure != null)
            {
                var organizationStructure = OrganizationStructurePopUp.EditValue as OrganizationStructure;
                if (organizationStructure != null)
                {
                    if (_OrganizationStructure.Id == organizationStructure.Id)
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

            _OrganizationStructure = OdataEntity as OrganizationStructure;

            if (_OrganizationStructure != null)
            {
                var parent = HelperRestSharp.GetOdata<OrganizationStructure>("/OrganizationStructures", "Id,ParentId,Code,Name,Level", fFilter: $"Id eq {_OrganizationStructure.ParentId}");
                if (parent != null)
                    _OrganizationStructure.Parent = parent;
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp, OrganizationStructurePopUp);
            PopupEditHelper.General<OrganizationStructure>(fEndPoint: "/OrganizationStructures", fTitle: "Organisasi", fControl: OrganizationStructurePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Level", fCaptionColumn: "Kode;Nama;Tingkat");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<OrganizationStructure>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<OrganizationStructure>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<OrganizationStructure>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _OrganizationStructure = new OrganizationStructure()
            {
                Id = _OrganizationStructure.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Level = _OrganizationStructure.Level
            };

            var parent = OrganizationStructurePopUp.EditValue as OrganizationStructure;
            if (parent != null)
                _OrganizationStructure.ParentId = parent.Id;
            else
                _OrganizationStructure.ParentId = null;

            OdataEntity = _OrganizationStructure;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<OrganizationStructure>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<OrganizationStructure>();
        }
    }
}
