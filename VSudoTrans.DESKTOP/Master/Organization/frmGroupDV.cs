using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using System.Threading.Tasks;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Organization
{
    public partial class frmGroupDV : frmBaseDV
    {
        Group _Group;
        public frmGroupDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Group>();
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
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Group>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Group>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Group>();
        }
        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Group = OdataEntity as Group;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Group = new Group()
            {
                Id = _Group.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
            };
            OdataEntity = _Group;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Group>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Group>();
        }
    }
}
