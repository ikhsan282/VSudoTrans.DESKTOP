using System;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMainMDI());


            try
            {
                // baca configurasi dari App.config
                //InitApplicationSettings();

                // DevExpress Sintaks
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ApplicationSettings.Instance.PathMyDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VSudoTrans";
                bool exists = System.IO.Directory.Exists(ApplicationSettings.Instance.PathMyDocument);
                if (!exists)
                    System.IO.Directory.CreateDirectory(ApplicationSettings.Instance.PathMyDocument);

                ApplicationSettings.Instance.UriHelper.UrlApiDefault = null;

                using (var form = new frmSetting())
                {
                    bool show = false;
                    if (form.GetUriConnection() == null)
                    {
                        show = true;
                    }

                    if (show == true)
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            ApplicationSettings.Instance.UriHelper.UrlApiDefault = form.SelectedUri.Url;
                        }
                    }
                    else
                    {
                        ApplicationSettings.Instance.UriHelper.UrlApiDefault = form.SelectedUri.Url;
                    }
                }

                if (ApplicationSettings.Instance.UriHelper.UrlApiDefault == null)
                {
                    return;
                }


                bool isLoginSuccessfull = false;

                using (var form = new frmLogin())
                {
                    form.ShowDialog();
                    isLoginSuccessfull = form.IsLogin;
                }

                if (isLoginSuccessfull == true)
                {
                    //if (Helper.InitializeDataUser() == true)
                    //{
                        Application.Run(new frmMainMDI());
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
