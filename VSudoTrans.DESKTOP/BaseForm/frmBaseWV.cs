using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using System.Linq;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseWV : DevExpress.XtraEditors.XtraForm
    {
        protected object EntityId { get; set; }
        protected string EndPoint { get; set; }
        protected HelperHttpClient _HttpClient;
        const string BaseTextEdit = "Detail ";
        const string BaseTextNew = "New";
        protected string BaseFieldNameToDisplay = "";
        protected enum enumFormStatus
        {
            New,
            Edit,
            ReadOnly
        }
        public string FormTitle;
        protected enumFormStatus FormStatus { get; set; }
        protected object OdataEntity { get; set; }
        protected object OdataCopyId { get; set; } = null;
        public frmBaseWV()
        {
            InitializeComponent();
        }

        protected virtual void SetGridViewCheckBoxRowSelect(GridControl gridControl, GridView gridView, SearchControl searchControl = null, string findFilterColumns = "", bool fNext = true, bool fPrev = true)
        {
            GridHelper.GridViewInitializeLayout(gridView);
            GridHelper.GridControlInitializeEmbeddedNavigator(gridControl, fNext: fNext, fPrev: fPrev);
            gridView.OptionsDetail.EnableMasterViewMode = false;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsFind.FindFilterColumns = findFilterColumns;
            gridView.OptionsView.ShowIndicator = false;
            if (searchControl != null)
            {
                searchControl.Client = gridControl;
                SearchControlHelper.InitializeSearchControl(searchControl);
            }
        }

        private void frmBaseWV_Load(object sender, EventArgs e)
        {
        }

        protected virtual void InitializeFomTitle(string fieldNames = "Code")
        {
            if (BaseFieldNameToDisplay != fieldNames) BaseFieldNameToDisplay = fieldNames;

            if (string.IsNullOrEmpty(FormTitle) == true) FormTitle = this.Text;

            if (FormStatus == enumFormStatus.Edit || FormStatus == enumFormStatus.ReadOnly)
            {
                var tmpValues = new List<string>();
                foreach (var fieldName in BaseFieldNameToDisplay.Split(';'))
                {
                    if (fieldName.Contains("."))
                    {
                        var tempExpand = AssemblyHelper.GetValueProperty(this.OdataEntity, fieldName.Split('.').First());
                        var val = AssemblyHelper.GetValueProperty(tempExpand, fieldName.Split('.').Last());
                        if (!string.IsNullOrEmpty(val.ToString()))
                            tmpValues.Add(val.ToString());
                    }
                    else
                        tmpValues.Add(AssemblyHelper.GetValueProperty(this.OdataEntity, fieldName).ToString());
                }
                this.Text = BaseTextEdit + FormTitle + " (" + string.Join(" - ", tmpValues) + ")";
            }
            else
            {
                if (OdataCopyId == null)
                    this.Text = BaseTextEdit + FormTitle + " (" + BaseTextNew + ")";
                else
                    this.Text = BaseTextEdit + FormTitle + " (" + BaseTextNew + " Copy" + ")";

            }
        }

        protected List<object> GetListDataRowSelected(GridView gridView)
        {
            List<object> result = new List<object>();
            try
            {
                var selectedRows = gridView.GetSelectedRows();

                foreach (var selectedRow in selectedRows)
                {
                    if (selectedRow >= 0)
                        result.Add(gridView.GetRow(selectedRow));
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, "Gagal untuk mendapatkan data yang dipilih dengan detail error " + ex.Message);
                return null;
            }
        }

        protected virtual object CreateEntity<T>()
        {
            object operationResponse = null;
            try
            {
                var jsonString = JsonConvert.SerializeObject(this.OdataEntity);
                var result = HelperRestSharp.Post(this.EndPoint, jsonString);
                if (!string.IsNullOrEmpty(result))
                    operationResponse = JsonConvert.DeserializeObject<T>(result.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return operationResponse;
        }

        protected virtual bool ActionValidate(DXValidationProvider _DxValidationProvider)
        {
            bool result = false;
            bool resultAddition = false;

            // validate default validation
            result = _DxValidationProvider.Validate();

            foreach (var control in _DxValidationProvider.GetInvalidControls())
            {
                var validationRuleBase = _DxValidationProvider.GetValidationRule(control);
                if (validationRuleBase.ErrorType == ErrorType.Critical)
                {
                    MessageHelper.ShowMessageError(this, "Terdapat inputan data yang tidak valid");
                    return result;
                }
            }

            resultAddition = InitializeAdditionalValidation();

            foreach (var control in _DxValidationProvider.GetInvalidControls())
            {
                var validationRuleBase = _DxValidationProvider.GetValidationRule(control);
                if (validationRuleBase.ErrorType == ErrorType.Critical)
                {
                    MessageHelper.ShowMessageError(this, "Terdapat inputan data yang tidak valid");
                    return resultAddition;
                }
            }

            //Cek validate
            if (result && resultAddition)
                return true;
            else
                return false;
        }

        protected virtual bool InitializeAdditionalValidation()
        {
            return true;
        }

        protected virtual void InitializeSearchLookup()
        {

        }

        protected virtual void InitializeComponentAfter()
        {
            this._HttpClient = new HelperHttpClient(this.EndPoint);
            this.Text = this.FormTitle;
        }


        public void BaseEdit_Enter(object sender, EventArgs e)
        {
            (sender as BaseEdit).SelectAll();
        }
    }
}
