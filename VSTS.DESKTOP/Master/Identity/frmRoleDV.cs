using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using Domain.Entities.Attendance;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using Newtonsoft.Json;
using Domain.Entities.HumanResource;
using PopUpUtils;

namespace VSTS.DESKTOP.Master.Identity
{
    public partial class frmRoleDV : frmBaseDV
    {
        ApplicationRole _Role;
        List<ApplicationControllerMethod> _DataApplicationControllerMethod = new List<ApplicationControllerMethod>();
        List<Navigation> _Navigation = new List<Navigation>();
        List<ApplicationControllerMethod> _ApplicationControllerMethod = new List<ApplicationControllerMethod>();
        public frmRoleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            _TreeListNavigation.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            _TreeListNavigation.OptionsBehavior.AllowRecursiveNodeChecking = true;
            colName.OptionsColumn.AllowEdit = false;

            _TreeListNavigation.HierarchyColumn = colName;
            _TreeListNavigation.HierarchyFieldName = "Name";
            _TreeListNavigation.KeyFieldName = "Code";
            _TreeListNavigation.ParentFieldName = "ParentCode";

            InitializeComponentAfter<ApplicationRole>();

            InitializeSearchLookup();

            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            // Audit Trail
            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            GridHelper.GridViewInitializeLayout(_GridViewController);
            //_GridViewController.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridViewInitializeLayout(_GridViewControllerSelect);
            //_GridViewControllerSelect.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlController, fNext: true, fPrev: true);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlControllerSelect, fNext: true, fPrev: true);

            colControllerName.Group();
            _GridViewController.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewController.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewController.ExpandAllGroups();
            colId.Visible = false;
            colName.Visible = true;
            colControllerName.Visible = true;
            _GridViewController.OptionsView.ShowIndicator = false;
            _GridViewController.OptionsFind.AllowFindPanel = false;
            _GridViewController.OptionsView.ShowGroupPanel = false;
            _GridViewController.OptionsView.ColumnAutoWidth = false;
            _GridViewController.OptionsSelection.MultiSelect = true;
            _GridViewController.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewController.SelectionChanged += _GridViewControllerSelect_SelectionChanged;


            colControllerNameSelect.Group();
            _GridViewControllerSelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewControllerSelect.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewControllerSelect.ExpandAllGroups();
            colIdSelect.Visible = false;
            colNameSelect.Visible = true;
            colControllerNameSelect.Visible = true;
            _GridViewControllerSelect.OptionsView.ShowIndicator = false;
            _GridViewControllerSelect.OptionsDetail.EnableMasterViewMode = false;
            _GridViewControllerSelect.OptionsView.ColumnAutoWidth = false;
            _GridViewControllerSelect.OptionsBehavior.Editable = false;
            _GridViewControllerSelect.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            _GridViewControllerSelect.OptionsSelection.MultiSelect = true;
            _GridViewControllerSelect.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewControllerSelect.SelectionChanged += _GridViewControllerSelect_SelectionChanged;

            _btnAddController.Click += _btnAddController_Click;
            _btnRemoveController.Click += _btnRemoveController_Click;

            _BindingSourceControllerSelect.DataSource = _DataApplicationControllerMethod;

            _GridViewController.OptionsView.ShowViewCaption = true;
            _GridViewController.ViewCaption = "Daftar Akses Kontrol";
            _GridViewControllerSelect.OptionsView.ShowViewCaption = true;
            _GridViewControllerSelect.ViewCaption = "Data Akses Kontrol Terpilih";

            // Digunakan agar set node check treelist berfungsi
            btnTemp.Click += BtnTemp_Click;
            timerTemp.Tick += Timer_Tick;
            timerTemp.Start();
        }

        Button btnTemp = new Button();
        Timer timerTemp = new Timer();

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnTemp.PerformClick();
            timerTemp.Stop();
        }

        private void BtnTemp_Click(object sender, EventArgs e)
        {
            var roles = OdataEntity as ApplicationRole;

            if (roles == null)
                roles = JsonConvert.DeserializeObject<ApplicationRole>(OdataEntity.ToString());

            if (roles != null)
            {
                var navs = roles.NavigationRoles;
                foreach (NavigationRole navigationRole in navs)
                {
                    var node = _TreeListNavigation.FindNodeByKeyID(navigationRole.Navigation.Code);
                    if (node != null)
                        _TreeListNavigation.SetNodeCheckState(node, CheckState.Checked);
                }

                var navtreeListNodes = _TreeListNavigation.Nodes.Where(n => n.Checked).ToList();
                foreach (var treeListNode in navtreeListNodes)
                {
                    CheckStateTreeListNode(treeListNode);
                }
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Name");
        }

        private void _GridViewControllerSelect_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _GridViewController)
            {
                _GridViewControllerSelect.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _GridViewControllerSelect)
            {
                _GridViewController.ClearSelection();
            }
        }

        private void _btnRemoveController_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewControllerSelect.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Akses Kontrol belum ada yang terpilih !");
                return;
            }

            _GridViewControllerSelect.DeleteSelectedRows();
            _GridViewControllerSelect.BestFitColumns(true);

            _GridViewControllerSelect.RefreshData();
            _GridViewController.RefreshData();
        }

        private void _btnAddController_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewController.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;
            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Akses Kontrol belum ada yang terpilih !");
                return;

            }

            foreach (var item in selectedEmployee)
            {
                var dataRow = _GridViewController.GetRow(item) as ApplicationControllerMethod;
                if (!_DataApplicationControllerMethod.Any(x => x.Id == dataRow.Id))
                {
                    _DataApplicationControllerMethod.Add(dataRow);
                };
            }

            _GridViewControllerSelect.BestFitColumns(true);
            _GridViewController.ClearSelection();
            _GridViewControllerSelect.RefreshData();
            _GridViewController.RefreshData();
        }

        protected override void DisplayEntity<T>()
        {
            _ApplicationControllerMethod = HelperRestSharp.GetListOdata<ApplicationControllerMethod>("/ControllerMethods", "id,name,ControllerId", "Controller($select=name)", msgLoading: "Memuat Akses Kontrol...");//List Navigasi Detail

            _Navigation = HelperRestSharp.GetListOdata<Navigation>("/Navigations", "id,code,name,ParentCode,ControllerId", msgLoading: "Memuat Navigasi...");//List Navigasi Detail

            base.DisplayEntity<T>();

            _Role = OdataEntity as ApplicationRole;

            if (_Role != null)
            {
                _TreeListNavigation.DataSource = _Navigation;
                _TreeListNavigation.Refresh();
                _TreeListNavigation.RefreshDataSource();

                _DataApplicationControllerMethod = new List<ApplicationControllerMethod>();
                _BindingSourceController.DataSource = _ApplicationControllerMethod;
                var controllerMethodIds = (OdataEntity as ApplicationRole).Claims.Select(s => s.ControllerMethodId).ToList();
                _DataApplicationControllerMethod.AddRange(_ApplicationControllerMethod.Where(s => controllerMethodIds.Contains(s.Id)));
                _GridViewControllerSelect.RefreshData();
                _GridViewController.RefreshData();
            }
        }

        private void CheckStateTreeListNode(TreeListNode treeListNode)
        {
            if (treeListNode.Nodes.Count == 0)
                return;
            else if (treeListNode.Nodes.Where(s => s.Checked == true).Count() == treeListNode.Nodes.Count)
                treeListNode.CheckState = CheckState.Checked;
            else if (treeListNode.Nodes.Where(s => s.Checked == false).Count() == treeListNode.Nodes.Count)
                treeListNode.CheckState = CheckState.Unchecked;
            else if (treeListNode.Nodes.Where(s => s.Checked == false).Any())
                treeListNode.CheckState = CheckState.Indeterminate;

            foreach (TreeListNode item in treeListNode.Nodes)
            {
                CheckStateTreeListNode(item);
            }
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (NameTextEdit.EditValue != null)
            {
                if (HelperConvert.String(NameTextEdit.EditValue) == "Super Administrator")
                {
                    MessageHelper.ShowMessageError(this, "Nama tersebut dilarang digunakan!");
                    result = false;
                }
            }

            return result;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<ApplicationRole>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<ApplicationRole>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<ApplicationRole>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_Role == null)
            {
                _Role = new ApplicationRole()
                {
                    Name = HelperConvert.String(NameTextEdit.EditValue),
                };
            }
            else
                _Role.Name = HelperConvert.String(NameTextEdit.EditValue);

            _Role.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));

            _Role.NavigationRoles.Clear();
            foreach (Navigation navigation in _Navigation)
            {
                TreeListNode node = _TreeListNavigation.FindNodeByKeyID(navigation.Code);
                if (node != null)
                {
                    var nav = _Role.NavigationRoles.Where(s => s.NavigationId == navigation.Id).FirstOrDefault();
                    if (nav != null)
                    {
                        if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                        {
                            _Role.NavigationRoles.Add(new NavigationRole()
                            {
                                Id = 0,
                                RoleId = _Role.Id,
                                NavigationId = navigation.Id,
                            });
                        }
                        else
                            _Role.NavigationRoles.Remove(nav);
                    }
                    else
                    {
                        if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                        {
                            _Role.NavigationRoles.Add(new NavigationRole()
                            {
                                Id = 0,
                                RoleId = _Role.Id,
                                NavigationId = navigation.Id,
                            });
                        }
                    }
                }
            }

            _Role.Claims.Clear();
            List<ApplicationControllerMethod> applicationControllerMethods = _BindingSourceControllerSelect.DataSource as List<ApplicationControllerMethod>;
            foreach (ApplicationControllerMethod m in applicationControllerMethods)
            {
                _Role.Claims.Add(new ApplicationRoleClaim()
                {
                    Id = 0,
                    RoleId = _Role.Id,
                    ControllerMethodId = m.Id,
                });
            }

            OdataEntity = _Role;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<ApplicationRole>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<ApplicationRole>();
        }
    }
}
