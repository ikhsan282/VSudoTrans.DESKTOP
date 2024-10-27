using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Popup;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using DevExpress.XtraDataLayout;

namespace VSudoTrans.DESKTOP.Descendant
{
    public enum EnumDataSource
    {
        VirtualMode,
        OdataInstant,
        Offline
    }


    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemPopupContainerEditOwn : RepositoryItemPopupContainerEdit
    {
        public const string CustomEditName = "RepositoryItemPopupContainerEditOwn";

        static RepositoryItemPopupContainerEditOwn()
        {
            RegisterCustomEdit();
        }

        public RepositoryItemPopupContainerEditOwn()
        {
            PopupControl = InitializePopupContainer();
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.QueryResultValue += new QueryResultValueEventHandler(OwnQueryResultValue);
            this.QueryDisplayText += new QueryDisplayTextEventHandler(OwnQueryDisplayText);
            this.EditValueChanged += new EventHandler(OwnEditValueChanged);
            this.QueryPopUp += OwnQueryPopUp;
        }

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            //System.Drawing.Image img = null;
            //EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(PopupContainerEditOwnPopupForm), typeof(RepositoryItemPopupContainerEditOwn), typeof(PopupContainerEditOwnViewInfo), new PopupContainerEditOwnPainter(), true, img, typeof(PopupEditAccessible)));

            EditorRegistrationInfo.Default.Editors.Add
            (
                new EditorClassInfo(CustomEditName,
                typeof(PopupContainerEditOwn),
                typeof(RepositoryItemPopupContainerEditOwn),
                typeof(ButtonEditViewInfo), new ButtonEditPainter(), true)
            );
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemPopupContainerEditOwn source = item as RepositoryItemPopupContainerEditOwn;
                if (source == null) return;

                // Lihat di bagian link ini untuk penjelasannya
                // makanya gw bingung selama ini kenapa di repository ada, namun di actual controlnya gak pernah ada
                // https://supportcenter.devexpress.com/ticket/details/t999545/how-to-use-a-custom-property-in-a-repositoryitem

                this.OptionsCascadeControl = source.OptionsCascadeControl;
                this.OptionsCascadeMember = source.OptionsCascadeMember;
                this.OptionsChildControl = source.OptionsChildControl;
                this.OptionsDataSource = source.OptionsDataSource;
                this.OptionsDataType = source.OptionsDataType;
                this.OptionsDisplayCaption = source.OptionsDisplayCaption;
                this.OptionsDisplayColumns = source.OptionsDisplayColumns;
                this.OptionsDisplayText = source.OptionsDisplayText;
                this.OptionsDisplayTitle = source.OptionsDisplayTitle;
                this.OptionsDisplayWidth = source.OptionsDisplayWidth;
                this.OptionsDataSource = source.OptionsDataSource;
                this.OptionsDisplayFormat = source.OptionsDisplayFormat;
                this.OptionsFilterColumns = source.OptionsFilterColumns;
                this.OptionsSortColumns = source.OptionsSortColumns;
            }
            finally
            {
                EndUpdate();
            }
        }

        #region Custom properties

        private object _objectid = null;
        public object ObjectId
        {
            get
            {
                return _objectid;
            }
            set
            {
                if (_objectid != value)
                {
                    _objectid = value;
                    RaiseObjectIdChanged();
                }
            }
        }

        public event EventHandler ObjectIdChanged;
        protected void RaiseObjectIdChanged()
        {
            ObjectIdChanged?.Invoke(this, EventArgs.Empty);
        }
        public string OptionsDisplayText { get; set; } = string.Empty;
        public object OptionsChildControl { get; set; } = null;
        public object OptionsCascadeControl { get; set; } = null;
        public string OptionsCascadeMember { get; set; } = string.Empty;
        public string OptionsDisplayTitle { get; set; } = string.Empty;
        public string OptionsDisplayColumns { get; set; } = string.Empty;
        public string OptionsDisplayCaption { get; set; } = string.Empty;
        public string OptionsDisplayWidth { get; set; } = string.Empty;
        public string OptionsDisplayFormat { get; set; } = string.Empty;
        public string OptionsFilterColumns { get; set; } = string.Empty;
        public string OptionsSortColumns { get; set; } = string.Empty;

        /// <summary>
        /// object ini digunakan untuk menampung PopUp Parameter yang berhubungan dengan konfigurasi Odata
        /// bila menggunakan on memory collection juga bisa menggunakan object ini
        /// misalnya ingin mem-visualisasi Plant yang dimiliki oleh user
        /// </summary>
        public object OptionsDataSource { get; set; } = null;
        public EnumDataSource? OptionsDataType { get; set; } = EnumDataSource.VirtualMode;
        #endregion

        public PopupContainerControl InitializePopupContainer()
        {
            // define variable for return of method
            PopupContainerControl popupContainerControl = new PopupContainerControl() { Name = "PopupContainerControl" + this.Name };

            int height = 461;

            // define size of popup
            if (popupContainerControl.Width < 550)
            {
                popupContainerControl.Size = new System.Drawing.Size(750, height);
            }
            else
            {
                popupContainerControl.Size = new System.Drawing.Size(popupContainerControl.Width, height);
            }

            // add for Search Control
            SearchControl searchControl = new SearchControl() { Name = "SearchControl" + this.Name };
            searchControl.Properties.FindDelay = int.MaxValue;

            SearchControlHelper.InitializeSearchControl(searchControl);

            // add for Grid Control
            GridControl gridControl = new GridControl() { Name = "GridControl" + this.Name };
            gridControl.ViewCollection.Clear();

            LayoutControl layoutControl = new LayoutControl() { Name = "LayoutControl" + this.Name };
            layoutControl.Dock = DockStyle.Fill;

            // add layout control to container
            popupContainerControl.Controls.Add(layoutControl);

            LayoutControlItem itemSearchControl = layoutControl.Root.AddItem();
            itemSearchControl.Name = "itemSearchControl" + this.Name;
            itemSearchControl.Control = searchControl;
            itemSearchControl.Text = "Name";
            itemSearchControl.TextVisible = false;

            LayoutControlItem itemGridControl = layoutControl.Root.AddItem();
            itemGridControl.Name = "itemGridControl" + this.Name;
            itemGridControl.Control = gridControl;
            itemGridControl.Text = "Name";
            itemGridControl.TextVisible = false;

            EmptySpaceItem itemEmpty = new EmptySpaceItem();
            layoutControl.Root.AddItem(itemEmpty);

            SimpleButton btnOK = new SimpleButton() { Name = "btnOK" + this.Name, Text = "Ok" };
            btnOK.Click += new EventHandler(OKButtonClickInPopUpContainer);

            LayoutControlItem itemOK = layoutControl.Root.AddItem();
            itemOK.Name = "itemOK" + this.Name;
            itemOK.Control = btnOK;
            itemOK.Text = "Name";
            itemOK.TextVisible = false;
            itemOK.SizeConstraintsType = SizeConstraintsType.Custom;
            itemOK.MaxSize = new Size(100, 36);
            itemOK.MinSize = itemOK.MaxSize;
            itemOK.Size = itemOK.MaxSize;
            itemOK.Move(itemEmpty, InsertType.Right);

            SimpleButton btnCancel = new SimpleButton() { Name = "btnCancel" + this.Name, Text = "Cancel" };
            btnCancel.Click += new EventHandler(CancelButtonClickInPopUpContainer);

            LayoutControlItem itemCancel = layoutControl.Root.AddItem();
            itemCancel.Name = "itemCancel" + this.Name;
            itemCancel.Control = btnCancel;
            itemCancel.Text = "Name";
            itemCancel.TextVisible = false;
            itemCancel.SizeConstraintsType = SizeConstraintsType.Custom;
            itemCancel.MaxSize = new System.Drawing.Size(100, 36);
            itemCancel.MinSize = itemOK.MaxSize;
            itemCancel.Size = itemOK.MaxSize;
            itemCancel.Move(itemOK, InsertType.Right);

            SimpleButton btnClear = new SimpleButton() { Name = "btnClear" + this.Name, Text = "Clear" };
            btnClear.Click += new EventHandler(ClearButtonClickInPopUpContainer);

            LayoutControlItem itemClear = layoutControl.Root.AddItem();
            itemClear.Name = "itemClear" + this.Name;
            itemClear.Control = btnClear;
            itemClear.Text = "Name";
            itemClear.TextVisible = false;
            itemClear.SizeConstraintsType = SizeConstraintsType.Custom;
            itemClear.MaxSize = new System.Drawing.Size(100, 36);
            itemClear.MinSize = itemOK.MaxSize;
            itemClear.Size = itemOK.MaxSize;
            itemClear.Move(itemCancel, InsertType.Right);

            searchControl.Client = gridControl;

            return popupContainerControl;
        }


        void GridViewCustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            string emptyview = "No items exist in this view";
            if (view.Tag != null)
            {
                if ((string)view.Tag != "")
                    emptyview = (string)view.Tag;
            }

            if (view.RowCount != 0) return;
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            //e.Appearance.Font = new Font("Oswald Regular", 20F, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.DrawString(emptyview, e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }

        void GridViewKeyDownInPopUpContainer(object sender, KeyEventArgs e)
        {
            var view = sender as GridView;
            if (e.KeyCode == Keys.Enter)
            {
                if (view.FocusedRowObject != null)
                {
                    var popupcontainer = (view.GridControl.Parent.Parent as PopupContainerControl);
                    popupcontainer.Tag = DialogResult.OK;
                    popupcontainer.OwnerEdit.ClosePopup();
                }
            }
        }

        void GridViewDoubleClickInPopUpContainer(object sender, EventArgs e)
        {
            var ea = e as DevExpress.Utils.DXMouseEventArgs;
            var view = sender as GridView;
            var info = view.CalcHitInfo(ea.Location);
            if (info.InDataRow)
            {
                var popupcontainer = (view.GridControl.Parent.Parent as PopupContainerControl);
                popupcontainer.Tag = DialogResult.OK;
                popupcontainer.OwnerEdit.ClosePopup();
            }
        }

        void OKButtonClickInPopUpContainer(object sender, EventArgs e)
        {
            Control button = sender as Control;

            //Close the dropdown accepting the user's choice
            var popupcontainer = (button.Parent.Parent as PopupContainerControl);
            popupcontainer.Tag = DialogResult.OK;
            popupcontainer.OwnerEdit.ClosePopup();
        }

        void CancelButtonClickInPopUpContainer(object sender, EventArgs e)
        {
            Control button = sender as Control;
            //Close the dropdown accepting the user's choice

            var popupcontainer = (button.Parent.Parent as PopupContainerControl);
            popupcontainer.Tag = DialogResult.Cancel;
            popupcontainer.OwnerEdit.ClosePopup();
        }

        void ClearButtonClickInPopUpContainer(object sender, EventArgs e)
        {
            Control button = sender as Control;
            //Close the dropdown accepting the user's choice

            var popupcontainer = (button.Parent.Parent as PopupContainerControl);
            popupcontainer.Tag = DialogResult.None;
            popupcontainer.OwnerEdit.ClosePopup();
        }
        private string GetCascadeCriteria()
        {

            var cascademember = OptionsCascadeMember;
            if (string.IsNullOrEmpty(cascademember) == true) return null;

            if (OptionsCascadeControl == null) return null;
            if (OptionsCascadeControl.GetType() == typeof(PopupContainerEditOwn) || OptionsCascadeControl.GetType() == typeof(RepositoryItemPopupContainerEditOwn))
            {
                object objectid;

                if (OptionsCascadeControl.GetType() == typeof(PopupContainerEditOwn))
                {
                    objectid = (OptionsCascadeControl as PopupContainerEditOwn).Properties.ObjectId;
                }
                else
                {
                    objectid = (OptionsCascadeControl as RepositoryItemPopupContainerEditOwn).ObjectId;
                }
                if (objectid == null || string.IsNullOrEmpty(objectid.ToString()) == true) return null;

                return $"{cascademember} eq {objectid}";
            }
            else
            {
                return null;
            }
        }

        static void UpdateValueCascades(PopupContainerEditOwn popupContainerEdit)
        {

        }

        private void OwnEditValueChanged(object sender, EventArgs e)
        {
            var popupContainerEdit = sender as PopupContainerEditOwn;
            if (popupContainerEdit.EditValue != null)
            {
                this.ObjectId = AssemblyHelper.GetValueProperty(popupContainerEdit.EditValue, "Id");
            }

            if (OptionsChildControl == null) return;

            if (OptionsChildControl.GetType() == typeof(PopupContainerEditOwn))
            {
                (OptionsChildControl as PopupContainerEditOwn).EditValue = null;
            }
            else
            {
                if (OptionsChildControl.GetType() == typeof(RepositoryItemPopupContainerEditOwn))
                {
                    var parent = popupContainerEdit.Parent;
                    if (parent.GetType() == typeof(GridControl))
                    {
                        var gridview = (parent as GridControl).MainView as GridView;
                        var columnchild = gridview.Columns.Where(x => x.ColumnEdit == OptionsChildControl).FirstOrDefault();
                        gridview.SetRowCellValue(gridview.FocusedRowHandle, columnchild, null);
                    }
                }
            }
        }

        private void OwnQueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                var popupContainerEdit = sender as PopupContainerEditOwn;
                if (popupContainerEdit.Properties.ReadOnly == true)
                {
                    e.Cancel = true;
                    return;
                }

                var parameters = OptionsDataSource;

                if (OptionsCascadeControl != null)
                {
                    if (OptionsCascadeControl.GetType() == typeof(PopupContainerEditOwn))
                    {
                        var cascadecontrol = OptionsCascadeControl as PopupContainerEditOwn;
                        if (cascadecontrol != null)
                        {
                            if (cascadecontrol.EditValue == null || cascadecontrol.EditValue == DBNull.Value)
                            {
                                string captionlayout = "";
                                if (cascadecontrol.Parent.GetType() == typeof(LayoutControl) || cascadecontrol.Parent.GetType() == typeof(DataLayoutControl))
                                {
                                    if (cascadecontrol.Parent.GetType() == typeof(LayoutControl))
                                    {
                                        var parent = cascadecontrol.Parent as LayoutControl;
                                        var layoutitem = parent.GetItemByControl(cascadecontrol);
                                        captionlayout = layoutitem.Text;
                                    }
                                    else
                                    {
                                        var parent = cascadecontrol.Parent as DataLayoutControl;
                                        var layoutitem = parent.GetItemByControl(cascadecontrol);
                                        captionlayout = layoutitem.Text;
                                    }
                                }

                                cascadecontrol.ErrorText = captionlayout + MessageHelper.MessageCouldNotEmpty;
                                XtraMessageBox.Show(cascadecontrol.ErrorText, MessageHelper.MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                e.Cancel = true;

                                return;
                            }
                        }
                    }
                };

                var cascadecriteria = GetCascadeCriteria();
                AssemblyHelper.SetValueProperty(parameters, "OdataCascade", cascadecriteria);

                if (OptionsDataSource != null)
                {
                    if (OptionsDataSource.GetType().Name.Contains("PopUpParameters"))
                    {
                        OptionsDataType = (EnumDataSource)AssemblyHelper.GetValueProperty(parameters, "OptionsDataSourceType");
                    }
                    else
                    {
                        OptionsDataType = EnumDataSource.Offline;
                    }
                }
                else
                {
                    if (OptionsDataType == null) OptionsDataType = EnumDataSource.VirtualMode;
                }

                var datasourcetype = OptionsDataType;

                var popupControl = PopupControl;
                var layoutControl = popupControl.Controls.OfType<LayoutControl>().FirstOrDefault();
                if (layoutControl != null)
                {
                    var gridControl = layoutControl.Controls.OfType<GridControl>().FirstOrDefault();
                    if (gridControl != null)
                    {
                        gridControl.DataSource = null;
                        gridControl.Focus();

                        IEnumerable<PropertyInfo> properties = new List<PropertyInfo>();

                        // bind gridcontrol to data source
                        switch (datasourcetype)
                        {
                            case EnumDataSource.OdataInstant:
                                gridControl.DataSource = AssemblyHelper.GetValueProperty(parameters, "DataSourcesODataInstantFeedback");
                                //Todo check, kalau sama jadiin satu saja jangan di case
                                //var rowType = AssemblyHelper.GetValueProperty(gridControl.DataSource, "RowType");
                                //properties = (IEnumerable<PropertyInfo>)AssemblyHelper.GetValueProperty(rowType, "DeclaredProperties");
                                break;
                            case EnumDataSource.VirtualMode:
                                gridControl.DataSource = AssemblyHelper.GetValueProperty(parameters, "DataSourcesVirtualServerMode");
                                var rowType = AssemblyHelper.GetValueProperty(gridControl.DataSource, "RowType");
                                if (rowType != null && rowType.ToString() != string.Empty)
                                {
                                    properties = (IEnumerable<PropertyInfo>)AssemblyHelper.GetValueProperty(rowType, "DeclaredProperties");
                                }
                                break;
                            case EnumDataSource.Offline:
                                gridControl.DataSource = OptionsDataSource;
                                //Todo check, kalau sama jadiin satu saja jangan di case
                                //var rowType = AssemblyHelper.GetValueProperty(gridControl.DataSource, "RowType");
                                //properties = (IEnumerable<PropertyInfo>)AssemblyHelper.GetValueProperty(rowType, "DeclaredProperties");
                                break;
                        }


                        // add for Grid View in Grid Control
                        if (gridControl.MainView == null)
                        {
                            GridView gridView = new GridView() { Name = "GridView" + this.Name };
                            gridView.OptionsBehavior.AutoPopulateColumns = false;
                            gridView.Columns.Clear();

                            gridView.GridControl = gridControl;
                            gridView.OptionsView.ColumnAutoWidth = false;
                            gridView.OptionsDetail.EnableMasterViewMode = false;
                            gridView.OptionsBehavior.AutoPopulateColumns = false;
                            gridView.OptionsBehavior.Editable = false;
                            gridView.OptionsCustomization.AllowColumnMoving = false;
                            gridView.OptionsCustomization.AllowFilter = false;
                            gridView.OptionsCustomization.AllowGroup = false;
                            gridView.OptionsFilter.AllowFilterEditor = false;
                            gridView.OptionsFind.AllowFindPanel = false;
                            gridView.OptionsView.ShowGroupPanel = false;

                            gridView.KeyDown += new KeyEventHandler(GridViewKeyDownInPopUpContainer);
                            gridView.DoubleClick += new EventHandler(GridViewDoubleClickInPopUpContainer);
                            //gridView.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(GridViewCustomDrawEmptyForeground);

                            string[] tmpColumns = null;
                            string[] tmpWidths = null;
                            string[] tmpCaptions = null;
                            string[] tmpFormats = null;

                            string columns = OptionsDisplayColumns;
                            string captions = OptionsDisplayCaption;
                            string widths = OptionsDisplayWidth;
                            string formats = OptionsDisplayFormat;
                            string filtercolumns = OptionsFilterColumns;

                            if (string.IsNullOrEmpty(columns))
                            {
                                columns = "Code;Name";
                            }
                            if (string.IsNullOrEmpty(filtercolumns))
                            {
                                filtercolumns = columns;
                            }
                            if (string.IsNullOrEmpty(captions))
                            {
                                if (columns == "Code;Name")
                                {
                                    captions = "Kode;Nama";
                                }
                            }
                            if (string.IsNullOrEmpty(widths))
                            {
                                widths = "160;450";
                            }

                            tmpColumns = columns.Split(new char[] { ';' });
                            tmpWidths = widths.Split(new char[] { ';' });
                            tmpCaptions = captions.Split(new char[] { ';' });
                            if (!string.IsNullOrEmpty(formats))
                                tmpFormats = formats.Split(new char[] { ';' });

                            GridColumn gridcolumn = null;

                            if (tmpColumns != null)
                            {
                                gridView.Columns.Clear();
                                gridView.OptionsFind.FindFilterColumns = filtercolumns;

                                for (int i = 0; i <= tmpColumns.Length - 1; i++)
                                {
                                    gridcolumn = new GridColumn();
                                    {
                                        gridcolumn.FieldName = tmpColumns[i];

                                        // -- Asking to devexpress, each column must be unique, http://www.devexpress.com/Support/Center/Question/Details/Q501284                    
                                        gridcolumn.Name = gridcolumn.FieldName + this.Name;
                                        gridcolumn.Visible = true;
                                        gridcolumn.VisibleIndex = i;
                                        if (tmpWidths.Length > 0 & tmpWidths.Length > i)
                                        {
                                            if (tmpWidths[0] == "")
                                                gridcolumn.Width = gridcolumn.GetBestWidth();
                                            else
                                                try
                                                {
                                                    gridcolumn.Width = int.Parse(tmpWidths[i]);
                                                    gridcolumn.OptionsColumn.FixedWidth = true;
                                                }
                                                catch
                                                {
                                                    gridcolumn.BestFit();
                                                }
                                        }
                                        else
                                        {
                                            gridcolumn.BestFit();
                                        };

                                        if (captions == "Code;Name")
                                        {
                                            gridcolumn.Caption = tmpCaptions[i] + " " + OptionsDisplayTitle;
                                        }
                                        else
                                        {
                                            gridcolumn.Caption = tmpCaptions[i];
                                        }
                                    }

                                    var propertyinfo = properties.Where(x => x.Name == gridcolumn.FieldName).FirstOrDefault();
                                    if (propertyinfo != null)
                                    {
                                        if (propertyinfo.PropertyType.GetGenericArguments().Count() > 0)
                                        {
                                            Type x = propertyinfo.PropertyType.GetGenericArguments().Single();
                                            if (x != null)
                                            {
                                                if (tmpFormats != null)
                                                    Utils.GridHelper.GridColumnInitializeLayout(gridcolumn, x, tmpFormats[i]);
                                                else
                                                    Utils.GridHelper.GridColumnInitializeLayout(gridcolumn, x);
                                            }
                                        }
                                        else
                                        {
                                            if (tmpFormats != null)
                                                Utils.GridHelper.GridColumnInitializeLayout(gridcolumn, propertyinfo.PropertyType, tmpFormats[i]);
                                            else
                                                Utils.GridHelper.GridColumnInitializeLayout(gridcolumn, propertyinfo.PropertyType);
                                        }
                                    }

                                    gridView.Columns.Add(gridcolumn);
                                }
                            }


                            //gridView.Columns.Clear();
                            //gridView.PopulateColumns();
                            //gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
                            gridControl.ViewCollection.Add(gridView);
                            gridControl.MainView = gridView;
                        }

                        gridControl.MainView.Focus();
                        if (gridControl.MainView.GetType() == typeof(GridView))
                        {
                            (gridControl.MainView as GridView).FocusedRowHandle = GridControl.InvalidRowHandle;
                        }
                    }

                    var searchControl = layoutControl.Controls.OfType<SearchControl>().FirstOrDefault();
                    if (searchControl != null)
                    {
                        string nullValuePrompt = "";
                        var gridcontrol = searchControl.Client as GridControl;

                        if (gridcontrol != null)
                        {
                            var baseView = gridcontrol.MainView as GridView;
                            if (baseView != null)
                            {
                                searchControl.Tag = "";
                                searchControl.Tag = baseView.OptionsFind.FindFilterColumns.ToString();
                                List<string> fieldNames = searchControl.Tag.ToString().Split(';').ToList();

                                if (fieldNames.Count > 0)
                                {
                                    if (fieldNames[0] != "*")
                                    {
                                        nullValuePrompt = "Pencarian untuk : ";
                                    }
                                }

                                for (int i = 0; i < fieldNames.Count; i++)
                                {
                                    var column = baseView.Columns.Where(x => x.FieldName == fieldNames[i]).FirstOrDefault();
                                    if (column != null)
                                    {
                                        nullValuePrompt += column.Caption;
                                        if (i + 1 != fieldNames.Count)
                                        {
                                            nullValuePrompt += ",";
                                        }
                                    }
                                }

                                searchControl.Properties.NullValuePrompt = nullValuePrompt;
                            }
                        }


                        searchControl.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void OwnQueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            if (e.EditValue != null && e.EditValue != DBNull.Value)
            {
                try
                {
                    string tmpDefault = "Code;Name";
                    bool childCheck = false;
                    string[] tmpDisplays = null;
                    string[] tmpValues = null;

                    if (sender.GetType() == typeof(PopupContainerEditOwn))
                    {
                        var popupContainerEdit = sender as PopupContainerEditOwn;
                        var control = popupContainerEdit.Properties as RepositoryItemPopupContainerEditOwn;
                        tmpDefault = popupContainerEdit.Properties.OptionsDisplayText;
                    }
                    else
                    {
                        var popupContainerEdit = sender as RepositoryItemPopupContainerEditOwn;
                        tmpDefault = popupContainerEdit.OptionsDisplayText;
                    }
                    if (string.IsNullOrEmpty(tmpDefault))
                    {
                        tmpDefault = "Code;Name";
                    }

                    tmpDisplays = tmpDefault.Split(new char[] { ';' });
                    tmpValues = tmpDefault.Split(new char[] { ';' });

                    // jika mengandung char '.' maka masuk ke child property
                    if (tmpDefault.Contains('.') && tmpDisplays.Count() == 1)
                    {
                        tmpDisplays = tmpDefault.Split(new char[] { '.' });
                        childCheck = true;
                    }
                    //logic check untuk mendapatkan descendant value
                    if (childCheck)
                    {
                        object temp = e.EditValue;
                        for (int i = 0; i < tmpDisplays.Length; i++)
                        {
                            temp = AssemblyHelper.GetValueProperty(temp, tmpDisplays[i]);
                        }
                        if (temp != null)
                        {
                            tmpValues = new string[] { temp.ToString() };
                        }
                        else
                        {
                            tmpValues = new string[] { "" };
                        }
                    }
                    //logic normal + mendapatkan descendand value dari model cth(employee.jobtitle.code)
                    else
                    {
                        for (int i = 0; i < tmpDisplays.Length; i++)
                        {
                            if (tmpDisplays[i].Contains('.'))
                            {
                                var tempDotSplit = tmpDisplays[i].Split(new char[] { '.' });
                                object temp = e.EditValue;
                                for (int j = 0; j < tempDotSplit.Length; j++)
                                {
                                    temp = AssemblyHelper.GetValueProperty(temp, tempDotSplit[j]);
                                }
                                if (temp != null)
                                {
                                    tmpValues[i] = temp.ToString();
                                }
                                else
                                {
                                    tmpValues[i] = "";
                                }
                            }
                            else
                            {
                                var temp = AssemblyHelper.GetValueProperty(e.EditValue, tmpDisplays[i]);
                                if (temp != null)
                                {
                                    tmpValues[i] = AssemblyHelper.GetValueProperty(e.EditValue, tmpDisplays[i]).ToString();
                                }
                                else
                                {
                                    tmpValues[i] = "";
                                }
                            }

                        }
                    }

                    e.DisplayText = string.Join(" - ", tmpValues);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                e.DisplayText = "";
            }
        }

        private void OwnQueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            var datasourcetype = OptionsDataType;

            var popupControl = PopupControl;
            if (popupControl.Tag != null)
            {
                DialogResult result = (DialogResult)Enum.Parse(typeof(DialogResult), popupControl.Tag.ToString());

                switch (result)
                {
                    case DialogResult.None:
                        e.Value = null;
                        break;

                    case DialogResult.OK:
                        var layoutControl = popupControl.Controls.OfType<LayoutControl>().FirstOrDefault();
                        if (layoutControl != null)
                        {
                            var gridControl = layoutControl.Controls.OfType<GridControl>().FirstOrDefault();
                            if (gridControl != null)
                            {
                                var gridView = gridControl.MainView as GridView;
                                if (gridView.GetFocusedRow() != null)
                                {
                                    if (datasourcetype == EnumDataSource.VirtualMode || datasourcetype == EnumDataSource.Offline)
                                    {
                                        var datarow = gridView.GetFocusedRow();
                                        if (datarow != null)
                                        {
                                            e.Value = datarow;
                                        }
                                        else
                                        {
                                            e.Value = null;
                                        }
                                    }
                                    else
                                    {
                                        var datarow = gridView.GetFocusedRow() as DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread;
                                        if (datarow != null)
                                        {
                                            e.Value = datarow.OriginalRow;
                                        }
                                        else
                                        {
                                            e.Value = null;
                                        }
                                    }
                                }
                            }
                        }

                        break;

                    case DialogResult.Cancel:
                        break;
                    default:
                        break;
                }

                popupControl.Tag = null;
            }
            else
            {

            }
        }
    }

    [ToolboxItem(true)]
    [UserRepositoryItem("RegisterCustomEdit")]
    public class PopupContainerEditOwn : PopupContainerEdit
    {
        static PopupContainerEditOwn() { RepositoryItemPopupContainerEditOwn.RegisterCustomEdit(); }

        public PopupContainerEditOwn()
        {

        }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemPopupContainerEditOwn.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPopupContainerEditOwn Properties
        {
            get { return base.Properties as RepositoryItemPopupContainerEditOwn; }
        }

        #region Custom properties

        private object _objectid = null;
        public object ObjectId
        {
            get
            {
                return _objectid;
            }
            set
            {
                if (_objectid != value)
                {
                    _objectid = value;
                    RaiseObjectIdChanged();
                }
            }
        }

        public event EventHandler ObjectIdChanged;
        protected void RaiseObjectIdChanged()
        {
            ObjectIdChanged?.Invoke(this, EventArgs.Empty);
        }
        public string OptionsDisplayText { get; set; }
        public object OptionsChildControl { get; set; }
        public object OptionsCascadeControl { get; set; }
        public string OptionsCascadeMember { get; set; }
        public string OptionsDisplayTitle { get; set; }
        public string OptionsDisplayColumns { get; set; }
        public string OptionsDisplayCaption { get; set; }
        public string OptionsDisplayWidth { get; set; }
        public string OptionsFilterColumns { get; set; }
        public string OptionsSortColumns { get; set; }
        public object OptionsDataSource { get; set; }
        public EnumDataSource? OptionsDataType { get; set; }
        #endregion


    }

    public class PopupContainerEditOwnViewInfo : PopupContainerEditViewInfo
    {
        public PopupContainerEditOwnViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class PopupContainerEditOwnPainter : ButtonEditPainter
    {
        public PopupContainerEditOwnPainter()
        {
        }
    }

    public class PopupContainerEditOwnPopupForm : PopupContainerForm
    {
        public PopupContainerEditOwnPopupForm(PopupContainerEditOwn ownerEdit) : base(ownerEdit)
        {
        }
    }
}
