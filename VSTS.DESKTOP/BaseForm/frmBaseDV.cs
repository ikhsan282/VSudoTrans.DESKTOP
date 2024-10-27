using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using VSTS.DESKTOP.Utils;
using System.Threading.Tasks;
using Domain.Entities.Attendance;
using System.Net;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Linq;

namespace VSTS.DESKTOP.BaseForm
{
    public partial class frmBaseDV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected object EntityId { get; set; }
        protected string EndPoint { get; set; }
        const string BaseTextEdit = "Detail ";
        const string BaseTextNew = "New";
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
        public frmBaseDV()
        {
            InitializeComponent();
            bbiHeaderEnabled(true);

            this.Shown += new EventHandler(this.FormShown);
            
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

        protected virtual void InitializeBinding()
        {


        }

        protected virtual void InitializeComponentAfter<T>()
        {
            InitializeBinding();
            InitializeFilter();
            InitializeDataSource<T>();
            InitializeDefaultPropertiesAndEvent();
            InitializeDefaultValidation();
        }

        protected virtual void InitializeFilter()
        {

        }

        protected virtual void InitializeDataSource<T>()
        {
            try
            {
                MessageHelper.WaitFormShow(this);
                if (EntityId != null)
                {
                    FormStatus = enumFormStatus.Edit;

                    switch (EntityId.GetType().ToString())
                    {
                        case "System.Int32":
                            if (Convert.ToInt32(EntityId) <= 0)
                            {
                                FormStatus = enumFormStatus.New;
                            }
                            break;

                        case "System.Guid":
                            if ((Guid)EntityId == Guid.Empty)
                            {
                                FormStatus = enumFormStatus.New;
                            }
                            break;

                        default:
                            throw new Exception("OdataId is not define correctly for typeof");
                    }

                    if (FormStatus == enumFormStatus.Edit)
                    {
                        OdataEntity = GetEntity(EntityId);
                    }
                    else
                    {
                        AddEntity();
                        FormStatus = enumFormStatus.New;
                    }
                    DisplayEntity<T>();

                    InitializeFomTitle();
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

        protected virtual void DisplayEntity<T>()
        {
            _BindingSource.Clear();
            if (this.FormStatus != enumFormStatus.New)
            {
                if (OdataEntity != null)
                    OdataEntity = JsonConvert.DeserializeObject<T>(OdataEntity.ToString());

                _BindingSource.Add(OdataEntity);
            }
        }

        protected virtual object GetEntity(object id)
        {
            object result = null;
            try
            {
                result = HelperRestSharp.GetById<object>(this.EntityId, this.EndPoint);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return result;
        }

        private void InitializeDefaultPropertiesAndEvent()
        {
            foreach (BaseLayoutItem item in _DataLayoutControl.Items)
            {
                if (item is LayoutControlItem)
                {
                    LayoutControlItem controlItem = item as LayoutControlItem;
                    if (controlItem != null)
                    {
                        if (controlItem.Control is BaseEdit)
                        {
                            var basedit = (BaseEdit)controlItem.Control;

                            basedit.EnterMoveNextControl = true;
                            //basedit.Enter += new EventHandler(this.BaseEdit_Enter);
                            basedit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                            if (basedit.DataBindings.Count > 0)
                            {
                                string bindingproperties = basedit.DataBindings[0].BindingMemberInfo.BindingField.ToLower();
                                if (bindingproperties == "createduser" || bindingproperties == "createddate" || bindingproperties == "modifieduser" || bindingproperties == "modifieddate")
                                {
                                    basedit.Properties.ReadOnly = true;
                                }
                            }
                        }
                        //if (controlItem.Control is DevExpress.XtraGrid.GridControl)
                        //{
                        //    var gridcontrol = (DevExpress.XtraGrid.GridControl)controlItem.Control;
                        //    if (gridcontrol != null)
                        //    {
                        //        foreach (var view in gridcontrol.Views)
                        //        {
                        //            if (view is DevExpress.XtraGrid.Views.Grid.GridView)
                        //            {
                        //                //GridHelper.GridViewInitializeLayout(view as DevExpress.XtraGrid.Views.Grid.GridView);
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        //private void BaseEdit_Enter(object sender, EventArgs e)
        //{
        //    (sender as BaseEdit).SelectAll();
        //}

        private void FormShown(object sender, EventArgs e)
        {

        }

        protected virtual void InitializeSearchLookup()
        {

        }

        protected virtual void InitializeDefaultValidation()
        {

        }

        protected virtual bool InitializeAdditionalValidation()
        {
            return true;
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



        protected virtual void InitializeFomTitle(string fieldNames = "Code")
        {
            if (string.IsNullOrEmpty(FormTitle) == true) FormTitle = this.Text;

            if (FormStatus == enumFormStatus.Edit || FormStatus == enumFormStatus.ReadOnly)
            {
                if (fieldNames.Contains(";"))
                {
                    var tmpValues = new List<string>();
                    foreach (var fieldName in fieldNames.Split(';'))
                    {
                        if (fieldName.Contains("."))
                        {
                            var tempExpand = AssemblyHelper.GetValueProperty(this.OdataEntity, fieldName.Split('.').First());
                            var val = AssemblyHelper.GetValueProperty(tempExpand, fieldName.Split('.').Last());
                            if (!string.IsNullOrEmpty(val.ToString()))
                                tmpValues.Add(val.ToString());
                        }
                        else
                        {
                            var data = AssemblyHelper.GetValueProperty(this.OdataEntity, fieldName);
                            if (data != null)
                                tmpValues.Add(data.ToString());
                            else
                            {
                                data = AssemblyHelper.GetValueProperty(this.OdataEntity, "Id");
                                if (data != null)
                                    tmpValues.Add(data.ToString());
                            }
                        }
                    }
                    this.Text = BaseTextEdit + FormTitle + " (" + string.Join(" - ", tmpValues) + ")";
                }
                else
                {
                    var data = AssemblyHelper.GetValueProperty(this.OdataEntity, fieldNames);
                    if (data != null)
                        this.Text = BaseTextEdit + FormTitle + $" ({data})";
                    else
                    {
                        data = AssemblyHelper.GetValueProperty(this.OdataEntity, "Id");
                        this.Text = BaseTextEdit + FormTitle + $" ({data})";
                    }
                }
            }
            else
            {
                if (OdataCopyId == null)
                    this.Text = BaseTextEdit + FormTitle + " (" + BaseTextNew + ")";
                else
                    this.Text = BaseTextEdit + FormTitle + " (" + BaseTextNew + " Copy" + ")";

            }
        }

        protected virtual void AddEntity()
        {

            // set OdataObject to new instance
            var assembly = ListBindingHelper.GetListItemType(_BindingSource.DataSource);
            OdataEntity = Activator.CreateInstance(assembly);

            AddEntity_CopyFrom();

            _BindingSource.EndEdit();
        }

        protected virtual void AddEntity_CopyFrom()
        {
            // lakukan proses copy
            if (OdataCopyId != null)
            {
                object entitycopy = GetEntity(OdataCopyId);

                Type myType = entitycopy.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(entitycopy, null);

                    AssemblyHelper.SetValueProperty(OdataEntity, prop.Name, propValue);
                }
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

        protected virtual object UpdateEntity<T>()
        {
            object operationResponse = null;
            try
            {
                var jsonString = JsonConvert.SerializeObject(this.OdataEntity);
                var result = HelperRestSharp.Put(this.EntityId, this.EndPoint, jsonString);
                operationResponse = result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return operationResponse;
        }

        protected virtual bool ActionValidate()
        {
            bool result = false;
            bool resultAddition = false;

            _BindingSource.EndEdit();

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

        //protected virtual string ActionMiddleWareException(OperationResponse operationResponse)
        //{
        //    string result = "";
        //    string statuscode = operationResponse.StatusCode.ToString();


        //    if (operationResponse.StatusCode == (int)HttpStatusCode.InternalServerError &&
        //        operationResponse.Error.Message.ToLower().Contains("exceptionmiddleware") &&
        //        operationResponse.Error.Message.ToLower().Contains("sqlexception"))
        //    {
        //        string errorsql = ExceptionMiddlewareHelper.GetExceptionMiddlewareErrorMessage(operationResponse.Error.Message); 

        //        // error duplikasi
        //        if (errorsql.Contains("duplikasi"))
        //        {
        //            result = "Gagal menyimpan data. Server API mendapati duplikasi data untuk inputan dibawah ini :" + "\r\n" + "\r\n";
        //            string indexs = "";

        //            try
        //            {
        //                string searchindex = "column";
        //                int ix = errorsql.IndexOf(searchindex);
        //                string[] columns = null;

        //                if (ix != -1)
        //                {
        //                    indexs = errorsql.Substring(ix + searchindex.Length).Trim();
        //                    int pos = indexs.IndexOf(")", 1);
        //                    if (pos >= 0)
        //                    {
        //                        indexs = indexs.Substring(1, pos - 1);
        //                        columns = indexs.Split(',');
        //                    }
        //                }
        //                string columnmsg = "";
        //                foreach (var column in columns)
        //                {
        //                    var control = AssemblyHelper.GetControlByDataBinding(this._DataLayoutControl.Controls, column);
        //                    if (control != null)
        //                    {
        //                        var layout = this._DataLayoutControl.GetItemByControl(control);
        //                        if (layout != null)
        //                            columnmsg = columnmsg + layout.Text + " (" + control.Text + ")" + "\r\n";

        //                        // add error text to control
        //                        (control as BaseEdit).ErrorText = "Terdapat duplikasi data di database";
        //                    }
        //                }
        //                result = result + columnmsg + "\r\n";
        //                result = result + "Silahkan untuk melakukan pengecekan terhadap inputan anda";
        //            }
        //            catch (Exception)
        //            {
        //                result = errorsql;
        //            }
        //        }
        //    }
        //    else if (operationResponse.StatusCode == 422) //UnprocessableEntityObjectResult --> ModelValid
        //    {
        //        // error yang muncul dari ModelValid
        //        OperationResponseRoot modelvalids = JsonConvert.DeserializeObject<OperationResponseRoot>(operationResponse.Error.Message);

        //        foreach (var item in modelvalids.Error.Details)
        //        {

        //            var control = AssemblyHelper.GetControlByDataBinding(this._DataLayoutControl.Controls, item.Target);
        //            if (control != null)
        //            {
        //                var layout = this._DataLayoutControl.GetItemByControl(control);
        //                if (layout != null)
        //                    result = result + "- " + item.Message + @" untuk """ + layout.Text + @"""" + "\r\n";
        //                else
        //                    result = result + "- " + item.Message + @" untuk """ + item.Target + @"""" + "\r\n";

        //                // add error text to control
        //                (control as BaseEdit).ErrorText = item.Message;
        //            }
        //            else
        //                result = result + "- " + item.Message + @" untuk """ + item.Target + @"""" + "\r\n";

        //        }
        //        result = @"Gagal untuk menyimpan data disebabkan oleh ""Validasi"", Server API mengembalikan error dengan detail berikut ini, " + "\r\n" + "\r\n" + result + "\r\n";
        //        result = result + "Silahkan untuk melakukan pengecekan terhadap inputan anda";
        //    }
        //    else if (operationResponse.StatusCode == 409)
        //    {
        //        Error409 modelvalids = JsonConvert.DeserializeObject<Error409>(operationResponse.Error.Message);
        //        result = @"Gagal untuk menyimpan data, Server API mengembalikan error dengan detail berikut ini, " + "\r\n" + "\r\n" + modelvalids.error + "\r\n";
        //    }
        //    else
        //    {
        //        result = $"HTTP Status Code : {statuscode}, Server API mengembalikan error dengan detail sebagai berikut : {operationResponse.Error.Message}";                
        //    }

        //    string errMsg = result;

        //    return errMsg;
        //}

        protected virtual void ActionEndEdit()
        {
            _BindingSource.EndEdit();
        }

        protected virtual bool ActionSave<T>()
        {
            ActionEndEdit();
            _DataLayoutControl.Validate();

            bool success = false;
            object operationResponse = null;

            if (MessageHelper.ShowMessageQuestion(MessageHelper.MessageSave, MessageBoxButtons.YesNo) == DialogResult.No) return success;

            if (FormStatus == enumFormStatus.New)
                operationResponse = CreateEntity<T>();
            else
                operationResponse = UpdateEntity<T>();

            if (operationResponse != null)
            {
                //sukses menyimpan data
                switch (OdataEntity.GetType().GetProperty("Id").GetValue(OdataEntity, null).GetType().ToString())
                {
                    case "System.Int32":
                        EntityId = int.Parse(OdataEntity.GetType().GetProperty("Id").GetValue(OdataEntity, null).ToString());
                        break;

                    case "System.Guid":
                        EntityId = Guid.Parse(OdataEntity.GetType().GetProperty("Id").GetValue(OdataEntity, null).ToString());
                        break;
                    default:
                        throw new Exception("OdataId is not define correctly for typeof");
                }

                FormStatus = enumFormStatus.Edit;
                InitializeFomTitle();

                //marking success is true
                success = true;
            }
            else
                success = false;


            if (success)
                MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);

            return success;
        }

        protected virtual void ActionSaveClose<T>()
        {
            if (ActionSave<T>() == true)
            {
                ActionClose();
            }
        }

        protected virtual void ActionSaveNew<T>()
        {
            if (ActionSave<T>() == true)
            {
                EntityId = 0;
                InitializeDataSource<T>();
            }
        }

        //protected virtual void ActionReset()
        //{
        //    InitializeDataSource();
        //}

        protected virtual void ActionClose()
        {
            this.Close();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!ActionValidate())
            //{
            //    return;
            //}
            //ActionSave<T>();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!ActionValidate())
            //{
            //    return;
            //}
            //ActionSaveClose<T>();
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!ActionValidate())
            //{
            //    return;
            //}
            //ActionSaveNew<T>();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ActionReset();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionClose();
        }

        private void bbiValidation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ActionValidate();
        }


        protected virtual void InializeDataReadOnly()
        {
            foreach (BaseLayoutItem item in _DataLayoutControl.Items)
            {
                if (item is LayoutControlItem)
                {
                    LayoutControlItem controlItem = item as LayoutControlItem;
                    if (controlItem != null)
                    {
                        if (controlItem.Control is BaseEdit)
                        {
                            var basedit = (BaseEdit)controlItem.Control;

                            basedit.ReadOnly = true;

                            if (basedit.DataBindings.Count > 0)
                            {
                                basedit.Properties.ReadOnly = true;
                            }
                        }
                        if (controlItem.Control is DevExpress.XtraGrid.GridControl)
                        {
                            var gridcontrol = (DevExpress.XtraGrid.GridControl)controlItem.Control;
                            if (gridcontrol != null)
                            {
                                foreach (var view in gridcontrol.Views)
                                {
                                    if (view is GridView)
                                    {
                                        foreach (GridColumn column in (view as GridView).Columns)
                                        {
                                            column.OptionsColumn.ReadOnly = true;
                                            column.AppearanceCell.Options.UseBackColor = true;
                                            column.AppearanceCell.BackColor = ApplicationSettings.Instance.CurrentSkin.Colors.GetColor(DevExpress.Skins.CommonColors.ReadOnly);
                                        }
                                        GridHelper.GridViewInitializeLayout(view as GridView);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual void bbiHeaderEnabled(bool param)
        {
            this.bbiSave.Enabled = param;
            this.bbiSaveAndClose.Enabled = param;
            this.bbiSaveAndNew.Enabled = param;
            this.bbiValidation.Enabled = param;
            this.bbiReset.Enabled = param;
        }

        protected virtual void bbiHeaderVisibile(BarItemVisibility barItemVisibility)
        {
            this.bbiValidation.Visibility = barItemVisibility;
            this.bbiSave.Visibility = barItemVisibility;
            this.bbiSaveAndNew.Visibility = barItemVisibility;
            this.bbiSaveAndClose.Visibility = barItemVisibility;
            this.bbiReset.Visibility = barItemVisibility;
        }

        protected object GetIdOfDataRowSelected(GridView _GridView)
        {
            object result;
            try
            {
                var selected = _GridView.GetFocusedRow();
                if (selected == null) return null;
                result = AssemblyHelper.GetValueProperty(selected, "Id");

                if (result.GetType().Equals(typeof(int)))
                {
                    if (Convert.ToInt32(result) <= 0) return null;
                }
                else
                {
                    if (result.GetType().Equals(typeof(Guid)))
                    {
                        Guid temp = (Guid)result;
                        if (temp == Guid.Empty) return null;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, "Gagal untuk mendapatkan Id Object dengan detail error " + ex.Message);
                return null;
            }
        }
    }

}
