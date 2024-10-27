using DevExpress.CodeParser;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace VSTS.DESKTOP.Utils
{
    public static class GridHelper
    {
        public static void GetPropertyInfo(string fieldName, System.Reflection.PropertyInfo propertyInfo = null)
        {

        }

        public static void ResolveTypeAndValue(Type fType, string search)
        {

            foreach (System.Reflection.PropertyInfo property in fType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine(property.Name + ": " + property.PropertyType + ": " + property.MemberType);
                if (property.PropertyType.IsClass == true)
                {
                    ResolveTypeAndValue(property.PropertyType, search);
                }
            }
        }



        public static void GridColumnInitializeLayout
        (
            GridColumn fColumn, Type fType, string fFormatString = "",
            HorzAlignment fHorzAlignment = HorzAlignment.Default, VertAlignment fVertAlignment = VertAlignment.Default,
            bool fReadOnly = false, DefaultBoolean fAllowMerge = DefaultBoolean.Default, bool fFixedWidth = false, bool fTotal = false, bool fAllowfocus = true
        )
        {
            if (fColumn.Tag == null)
            {
                if (fType == typeof(DateTimeOffset) || fType == typeof(DateTime))
                {
                    fColumn.DisplayFormat.FormatType = FormatType.Custom;

                    if (fFormatString != "") fColumn.DisplayFormat.FormatString = fFormatString; else fColumn.DisplayFormat.FormatString = "dd-MMM-yyyy";

                    fHorzAlignment = HorzAlignment.Center;
                    fVertAlignment = VertAlignment.Center;
                }
                else if (fType == typeof(TimeSpan))
                {
                    fColumn.DisplayFormat.FormatType = FormatType.Custom;

                    if (fFormatString != "") fColumn.DisplayFormat.FormatString = fFormatString; else fColumn.DisplayFormat.FormatString = "hh:mm";

                    fHorzAlignment = HorzAlignment.Center;
                    fVertAlignment = VertAlignment.Center;
                }
                if (fType == typeof(Decimal) || fType == typeof(Double) || fType == typeof(Double))
                {
                    fColumn.DisplayFormat.FormatType = FormatType.Numeric;
                    if (fFormatString == "")
                    {
                        fFormatString = "n0";
                    }
                    fColumn.DisplayFormat.FormatString = fFormatString; //else fColumn.DisplayFormat.FormatString = "n0";
                    if (fHorzAlignment != HorzAlignment.Far)
                    {
                        fHorzAlignment = HorzAlignment.Far;
                    }
                }
                if (fType == typeof(bool) || fType.BaseType == typeof(Enum))
                {
                    fHorzAlignment = HorzAlignment.Center;
                    fVertAlignment = VertAlignment.Center;
                }

                fColumn.AppearanceHeader.TextOptions.HAlignment = fHorzAlignment;
                fColumn.AppearanceHeader.TextOptions.VAlignment = fVertAlignment;
                fColumn.AppearanceCell.TextOptions.HAlignment = fHorzAlignment;
                fColumn.AppearanceCell.TextOptions.VAlignment = fVertAlignment;

                if (fReadOnly == true)
                {
                    fColumn.OptionsColumn.ReadOnly = true;
                    fColumn.AppearanceCell.Options.UseBackColor = true;
                    fColumn.AppearanceCell.BackColor = ApplicationSettings.Instance.CurrentSkin.Colors.GetColor(DevExpress.Skins.CommonColors.ReadOnly);
                }
                fColumn.OptionsColumn.AllowMerge = fAllowMerge;
                fColumn.OptionsColumn.FixedWidth = fFixedWidth;

                fColumn.OptionsColumn.AllowFocus = fAllowfocus;
                if (fTotal == true)
                {
                    fColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, fColumn.FieldName, "∑ = {0:" + fFormatString + "}") }); //∑={0:0.##}
                }
            }
        }
        public static void GridColumnInitializeLayout(
            BandedGridColumn fColumn, Type fType, string fFormatString = "",
            HorzAlignment fHorzAlignment = HorzAlignment.Near, VertAlignment fVertAlignment = VertAlignment.Center,
            bool fReadOnly = false, DefaultBoolean fAllowMerge = DefaultBoolean.False, bool fFixedWidth = false, bool fTotal = false, bool fAllowfocus = true
            )
        {
            if (fColumn.Tag == null)
            {
                if (fType == typeof(DateTimeOffset) || fType == typeof(DateTime))
                {
                    fColumn.DisplayFormat.FormatType = FormatType.Custom;

                    if (fFormatString != "") fColumn.DisplayFormat.FormatString = fFormatString; else fColumn.DisplayFormat.FormatString = "dd-MM-yyyy";

                    fHorzAlignment = HorzAlignment.Center;
                    fVertAlignment = VertAlignment.Center;
                }
                if (fType == typeof(Decimal) || fType == typeof(Double) || fType == typeof(Double))
                {
                    fColumn.DisplayFormat.FormatType = FormatType.Custom;
                    if (fFormatString != "") fColumn.DisplayFormat.FormatString = fFormatString; else fColumn.DisplayFormat.FormatString = "n0";
                }
                if (fType == typeof(bool) || fType.BaseType == typeof(Enum))
                {
                    fHorzAlignment = HorzAlignment.Center;
                    fVertAlignment = VertAlignment.Center;
                }

                fColumn.AppearanceHeader.TextOptions.HAlignment = fHorzAlignment;
                fColumn.AppearanceHeader.TextOptions.VAlignment = fVertAlignment;
                fColumn.AppearanceCell.TextOptions.HAlignment = fHorzAlignment;
                fColumn.AppearanceCell.TextOptions.VAlignment = fVertAlignment;

                if (fReadOnly == true)
                {
                    fColumn.OptionsColumn.ReadOnly = true;
                    fColumn.AppearanceCell.Options.UseBackColor = true;
                    fColumn.AppearanceCell.BackColor = ApplicationSettings.Instance.CurrentSkin.Colors.GetColor(DevExpress.Skins.CommonColors.ReadOnly);
                }
                fColumn.OptionsColumn.AllowMerge = fAllowMerge;
                fColumn.OptionsColumn.FixedWidth = fFixedWidth;

                fColumn.OptionsColumn.AllowFocus = fAllowfocus;
                if (fTotal == true)
                {
                    string totalFormat = "";

                    if (fFormatString == "")
                    {
                        totalFormat = "∑ = {0:n2}";
                    }
                    else
                    {
                        totalFormat = "∑ = {0:" + fFormatString + "}";
                    }

                    fColumn.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, fColumn.FieldName, totalFormat) });
                }
            }
        }

        public static void ViewCustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            var view = sender as BaseView;
            string emptyview = "Tidak terdapat data ";
            if (view.Tag != null)
            {
                if ((string)view.Tag != "")
                    emptyview = emptyview + (string)view.Tag;
            }

            if (view.RowCount != 0) return;
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            e.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString(emptyview, e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }

        public static void GridColumnInitializeSort(GridColumn fColumn, int fSortIndex = 0, ColumnSortMode fColumnSortMode = ColumnSortMode.DisplayText)
        {
            fColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
            fColumn.OptionsColumn.AllowSort = DefaultBoolean.True;
            fColumn.SortIndex = fSortIndex;
            fColumn.SortMode = fColumnSortMode;
        }

        public static void GridColumnInitializeSort(BandedGridColumn fColumn, int fSortIndex, ColumnSortMode fColumnSortMode = ColumnSortMode.DisplayText)
        {
            fColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
            fColumn.OptionsColumn.AllowSort = DefaultBoolean.True;
            fColumn.SortIndex = fSortIndex;
            fColumn.SortMode = fColumnSortMode;
        }

        public static void GridControlInitializeEmbeddedNavigator(GridControl fGridControl, bool fEmbeddedNavigator = true, bool fAppend = false, bool fEndEdit = false, bool fEdit = false, bool fRemove = false, bool fFirst = false, bool fLast = false, bool fNext = true, bool fPrev = true, bool fNextPage = false, bool fPrevPage = false, bool fCancelEdit = false)
        {
            fGridControl.UseEmbeddedNavigator = fEmbeddedNavigator;
            fGridControl.EmbeddedNavigator.Buttons.Append.Visible = fAppend;
            fGridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = fEndEdit;
            fGridControl.EmbeddedNavigator.Buttons.Edit.Visible = fEdit;
            fGridControl.EmbeddedNavigator.Buttons.Remove.Visible = fRemove;
            fGridControl.EmbeddedNavigator.Buttons.First.Visible = fFirst;
            fGridControl.EmbeddedNavigator.Buttons.Last.Visible = fLast;
            fGridControl.EmbeddedNavigator.Buttons.Next.Visible = fNext;
            fGridControl.EmbeddedNavigator.Buttons.Prev.Visible = fPrev;
            fGridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = fPrevPage;
            fGridControl.EmbeddedNavigator.Buttons.NextPage.Visible = fNextPage;
            fGridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = fCancelEdit;
        }

        public static void GridViewInitializeLayout(GridView fGridView, string fEmptyTile = "")
        {
            if (fGridView.Columns != null)
            {
                string[] columns = {"Id", "IsActive", "IsDeleted", "CreatedDate", "CreatedUser", "ModifiedDate", "ModifiedUser", "Version" };
                foreach (var columnName in columns)
                {
                    if (fGridView.Columns[columnName] != null)
                    {
                        fGridView.Columns[columnName].Visible = false;
                    }
                }
            }

            fGridView.Tag = fEmptyTile;
            fGridView.OptionsBehavior.Editable = false;
            fGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            fGridView.OptionsCustomization.AllowFilter = false;
            fGridView.OptionsCustomization.AllowGroup = false;
            //fGridView.OptionsView.ColumnAutoWidth = true;
            fGridView.OptionsView.ShowGroupPanel = false;
            fGridView.OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;
            fGridView.OptionsFind.AllowFindPanel = false;

            fGridView.OptionsSelection.MultiSelect = true;
            fGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;

            var binding = fGridView.GridControl.DataSource;
            if (binding == null) return;

            if (binding.GetType() == typeof(System.Windows.Forms.BindingSource))
            {
                var bindingSource = binding as System.Windows.Forms.BindingSource;
                if (bindingSource.DataSource != null)
                {
                    IEnumerable<System.Reflection.PropertyInfo> properties;
                    System.Reflection.PropertyInfo propertyinfo;

                    Type classType = bindingSource.DataSource.GetType();

                    properties = classType.GetTypeInfo().DeclaredProperties;

                    if (classType.GetTypeInfo().DeclaredProperties.Where(s => s.Name == "Item").Any())
                        properties = classType.GetProperties().Where(s => s.Name == "Item").FirstOrDefault().PropertyType.GetProperties().ToList();

                    if (fGridView.GridControl.DataMember != null && fGridView.GridControl.DataMember != "")
                    {
                        // belum support untuk mencari sub leveling dari binding source
                        return;
                    }

                    foreach (GridColumn column in fGridView.Columns)
                    {
                        if (string.IsNullOrEmpty(column.FieldName) == false)
                        {
                            if (column.FieldName.Contains("."))
                            {
                                //var fields = column.FieldName.Split('.');                            
                                //propertyinfo = properties.Where(x => x.Name == fields[0]).FirstOrDefault();
                                //if (propertyinfo != null) 
                                //{
                                //    ResolveTypeAndValue(propertyinfo.PropertyType, fields[fields.Count() - 1]);
                                //}                            
                            }
                            else
                            {
                                propertyinfo = properties.Where(x => x.Name == column.FieldName).FirstOrDefault();
                                if (propertyinfo != null)
                                {
                                    if (propertyinfo.PropertyType == typeof(DateTimeOffset) || propertyinfo.PropertyType == typeof(DateTimeOffset?) || propertyinfo.PropertyType == typeof(DateTime) || propertyinfo.PropertyType == typeof(DateTime?))
                                    {
                                        column.DisplayFormat.FormatType = FormatType.Custom;
                                        column.DisplayFormat.FormatString = "dd-MMM-yyyy";
                                        column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                        column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                        column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                                        column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                    }
                                    if (propertyinfo.PropertyType == typeof(TimeSpan))
                                    {
                                        column.DisplayFormat.FormatType = FormatType.Custom;
                                        column.DisplayFormat.FormatString = "hh:mm";

                                        column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                                        column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                    }
                                    if (propertyinfo.PropertyType == typeof(decimal) || propertyinfo.PropertyType == typeof(decimal?))
                                    {
                                        column.DisplayFormat.FormatType = FormatType.Custom;
                                        column.DisplayFormat.FormatString = "n2";
                                        column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                                        column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                        column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                                        column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                    }
                                    if (propertyinfo.PropertyType == typeof(bool) || propertyinfo.PropertyType == typeof(bool?))
                                    {
                                        column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                        column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                        column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                                        column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                IEnumerable<System.Reflection.PropertyInfo> properties;
                System.Reflection.PropertyInfo propertyinfo;

                Type classType = binding.GetType();

                properties = classType.GetTypeInfo().DeclaredProperties;

                if (classType.GetTypeInfo().DeclaredProperties.Where(s => s.Name == "Item").Any())
                    properties = classType.GetProperties().Where(s => s.Name == "Item").FirstOrDefault().PropertyType.GetProperties().ToList();

                if (fGridView.GridControl.DataMember != null && fGridView.GridControl.DataMember != "")
                {
                    // belum support untuk mencari sub leveling dari binding source
                    return;
                }

                foreach (GridColumn column in fGridView.Columns)
                {
                    if (string.IsNullOrEmpty(column.FieldName) == false)
                    {
                        if (column.FieldName.Contains("."))
                        {
                            //var fields = column.FieldName.Split('.');                            
                            //propertyinfo = properties.Where(x => x.Name == fields[0]).FirstOrDefault();
                            //if (propertyinfo != null) 
                            //{
                            //    ResolveTypeAndValue(propertyinfo.PropertyType, fields[fields.Count() - 1]);
                            //}                            
                        }
                        else
                        {
                            propertyinfo = properties.Where(x => x.Name == column.FieldName).FirstOrDefault();
                            if (propertyinfo != null)
                            {
                                if (propertyinfo.PropertyType == typeof(DateTimeOffset) || propertyinfo.PropertyType == typeof(DateTimeOffset?) || propertyinfo.PropertyType == typeof(DateTime) || propertyinfo.PropertyType == typeof(DateTime?))
                                {
                                    column.DisplayFormat.FormatType = FormatType.Custom;
                                    column.DisplayFormat.FormatString = "dd-MMM-yyyy";
                                    column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                    column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                                    column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                }
                                if (propertyinfo.PropertyType == typeof(decimal) || propertyinfo.PropertyType == typeof(decimal?))
                                {
                                    column.DisplayFormat.FormatType = FormatType.Custom;
                                    column.DisplayFormat.FormatString = "n2";
                                    column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                                    column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                                    column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                }
                                if (propertyinfo.PropertyType == typeof(bool) || propertyinfo.PropertyType == typeof(bool?))
                                {
                                    column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                    column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                                    column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                                }
                            }
                        }
                    }
                }
            }



            fGridView.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(GridViewCustomDrawEmptyForeground);
        }

        public static void GridViewCustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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

    }


    public static class SearchControlHelper
    {
        public static void InitializeSearchControl(SearchControl searchControl)
        {
            searchControl.Properties.NullValuePrompt = null;
            searchControl.Properties.FindDelay = int.MaxValue;

            string nullValuePrompt = "Pencarian cepat ...";

            if (searchControl.Client != null)
            {
                // get the view
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
            }
            searchControl.QueryIsSearchColumn += new QueryIsSearchColumnEventHandler(SearchControl_QueryIsSearchColumn);
        }

        public static void SearchControl_QueryIsSearchColumn(object sender, QueryIsSearchColumnEventArgs args)
        {
            var column = sender as DevExpress.XtraEditors.Filtering.FilterColumn;

            var gridFilterColumn = sender as GridFilterColumn;
            List<string> fieldNames = gridFilterColumn.View.OptionsFind.FindFilterColumns.Split(';').ToList();
            var match = fieldNames.FirstOrDefault(x => x.Contains(column.FieldName));
            if (match == null) args.IsSearchColumn = false;
        }
    }
}
