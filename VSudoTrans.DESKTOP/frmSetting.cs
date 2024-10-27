using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP
{
    public partial class frmSetting : XtraForm
    {
        const string _SectionConfigName = "ApiSettings";
        BindingList<UriConnection> _UrlList = new BindingList<UriConnection>();

        public UriConnection SelectedUri { get; set; }
        public UriConnection GetUriConnection()
        {
            if (_UrlList.Count == 0)
            {
                return null;
            }
            SelectedUri = _UrlList.Where(x => x.Default == true).FirstOrDefault();
            if (SelectedUri == null )
            {
                return null;
            }

            

            return SelectedUri;
        }

        public frmSetting()
        {
            InitializeComponent();
            RefreshApiConfigurationList();

            // add event for _gvURL
            _gvURL.ValidateRow += new ValidateRowEventHandler(this._gvURL_ValidateRow);
            _gvURL.InvalidRowException += new InvalidRowExceptionEventHandler(this._gvURL_InvalidRowException);
            _gvURL.RowUpdated += new RowObjectEventHandler(this._gvURL_RowUpdated);
        }

        private void _gvURL_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void _gvURL_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (e.Row != null)
            {
                var row = e.Row as UriConnection;
                if (row != null)
                {
                    if (row.Default == true)
                    {
                        var updates = _UrlList.Where(x => x.Name != row.Name).ToList();
                        foreach (var item in updates)
                        {
                            item.Default = false;
                        }
                    }
                    else
                    {
                        if (_UrlList.Count == 1 && e.RowHandle < 0)
                        {
                            row.Default = true;
                        }
                    }
                }
            }
            _gvURL.RefreshData();
        }

        private void _gvURL_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn namecol = view.Columns["Name"];
            GridColumn uricol = view.Columns["Url"];

            if (view.GetRowCellValue(e.RowHandle, namecol) == null)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                view.SetColumnError(namecol, namecol.Caption + MessageHelper.MessageCouldNotEmpty);
                return;
            }

            if (view.GetRowCellValue(e.RowHandle, uricol) == null)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                view.SetColumnError(uricol, uricol.Caption + MessageHelper.MessageCouldNotEmpty);
                return;
            }
            else
            {
                var uriname = view.GetRowCellValue(e.RowHandle, uricol).ToString();
                Uri uriResult;
                bool result = Uri.TryCreate(uriname.ToString(), UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!string.IsNullOrEmpty(uriname))
                {
                    if (uriname.Substring(uriname.Length - 1) != @"/")
                    {
                        view.SetColumnError(uricol, MessageHelper.MessageValueInvalid + uricol.Caption + @", Pastikan ada tanda / pada akhir " + uricol.Caption);
                        e.Valid = false;
                        return;
                    }
                    else if (result == false)
                    {
                        view.SetColumnError(uricol, MessageHelper.MessageValueInvalid + uricol.Caption);
                        e.Valid = false;
                        return;
                    }
                }
                else
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(uricol, uricol.Caption + MessageHelper.MessageCouldNotEmpty);
                    return;
                }
            }

            var uriconnection = e.Row as UriConnection;
            var exist = _UrlList.Where(uri => uri.Name == uriconnection.Name).FirstOrDefault();
            if (exist != null)
            {
                if (_UrlList.IndexOf(exist) != view.GetFocusedDataSourceRowIndex())
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(namecol, "Ditemukan duplikasi untuk " + namecol.Caption);
                    return;
                }
            }

            e.Valid = true;
        }
        private XDocument CreateXmlUrls()
        {
            var XElements = new List<XElement>();
            foreach (var item in _UrlList)
            {
                var XElement = new XElement("Url",
                    new XElement("Name", item.Name),
                    new XElement("Url", item.Url),
                    new XElement("Default", item.Default));

                XElements.Add(XElement);
            }

            XDocument document = new XDocument
                (
                    new XElement("ConfigNTM",
                        new XElement("Urls", XElements)
                        )
                );

            return document;
        }

        private T ReadXml<T>(string path)
        {
            if (File.Exists(path))
            {
                XDocument loadedDocument = XDocument.Load(path);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(loadedDocument.CreateReader());
            }
            else
                return default(T);
        }

        private void RefreshApiConfigurationList()
        {
            _UrlList.Clear();

            var configVSudoTrans = ReadXml<ConfigNTM>(ApplicationSettings.Instance.PathMyDocument + "\\config.xml");
            if (configVSudoTrans != null)
            {
                foreach (var item in configVSudoTrans.Urls.Url)
                {
                    _UrlList.Add(item);
                }
            }
        }

        string AddUpdateAppSettings()
        {
            try
            {
                XDocument xmlFromPlainCode = CreateXmlUrls();
                xmlFromPlainCode.Save(ApplicationSettings.Instance.PathMyDocument + "\\config.xml");
                return "";
            }
            catch (ConfigurationErrorsException ex)
            {
                //MessageHelper.ShowMessageError(this, ex);
                return ex.Message;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_gvURL.IsEditing == true)
            {
                _gvURL.EndUpdate();
            }

            var result = AddUpdateAppSettings();
            if (result != "")
            {
                MessageHelper.ShowMessageError(this, $"Gagal untuk menyimpan {this.Text} kedalam file konfigurasi dengan detail error ({result})");
                return;
            }

            if (_gvURL.RowCount == 0)
            {
                MessageHelper.ShowMessageError(this, "Tidak terdapat Daftar Url yang bisa digunakan sebagai koneksi");
                return;
            }

            if (_gvURL.GetFocusedRow() == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            this.SelectedUri = _UrlList.Where(s => s.Default).FirstOrDefault();//_gvURL.GetFocusedRow() as UriConnection;
            this.DialogResult = DialogResult.OK;
            ApplicationSettings.Instance.UriHelper.UrlApiDefault = SelectedUri.Url;
        }

        private void frmSetting_Shown(object sender, EventArgs e)
        {
            _gcURL.DataSource = _UrlList;
        }
    }
}