using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSTS.DESKTOP.BaseForm;
using System.Drawing;
using DevExpress.Utils.Drawing;

namespace VSTS.DESKTOP.Utils
{
    public class MessageHelper
    {
        public const string PathXML = "BPS.xml";
        public const string MessageAppTitle = "SKP System";
        public const string MessageFormDetailTitle = "Detail ";
        public const string MessageFormDetailTitleNew = " (New)";
        public const string MessageResponseNotExpexcted = "Failed to perform operaiton with web service with not expected response code ";

        public const string MessageSave = "Apakah anda yakin untuk menyimpan data";
        public const string MessageUnAuthorized = "Anda tidak memiliki otorisasi untuk meng-akses  ";
        public const string MessageSaveWait = "Please wait while save data to database ...";
        public const string MessageNoStock = "Tidak ditemukan stok";
        public const string MessageCheckStockSAP = @"System meminta informasi ""Stock"" dari ""SAP"" ";

        public const string MessageDCStoreCouldNotEmpty = "Silahkan untuk memilih lokasi stok, Store atau DC, karena tidak boleh kosong";
        public const string MessageSaveSuccessfully = "Sukses dalam menyimpan data";
        public const string MessageSaveFailed = "Gagal untuk menyimpan data";
        public const string MessageCouldNotEmpty = " tidak boleh kosong";
        public const string MessageWaitLoadingData = "Silahkan untuk menunggu saat memuat data dari server";
        public const string MessageSelectData = "Tidak terdapat data yang dipilih";
        public const string MessageValueMustBeBiggerThanZero = " harus lebih besar daripada nol (0)";
        public const string MessageValueMustBeBiggerOrEqualThanZero = " harus lebih besar atau sama dengan nol (0)";

        public const string MessageNoAcces = "Anda tidak memiliki akses untuk ";
        public const string MessageDelete = "Apakah anda ingin menghapus data";

        public const string MessageNew = "Apakah anda ingin menambahkan data baru";
        public const string MessageCancel = "Apakah anda ingin membatalkan";

        public const string MessageConfirm = "Apakah anda ingin melakukan proses konfirmasi";
        public const string MessageCancelation = "Apakah anda ingin melakukan pembatalan";
        public const string MessageValidationFail = "Beberapa validasi terhadap data mengalami kegagalan";
        public const string MessageDuplicateValue = "Ditemukan duplikasi data untuk ";
        public const string MessageWaitWhenConfirmation = "Harap tunggu saat sistem memproses data untuk konfirmasi ...";
        public const string MessageWaitWhenCancelation = "Harap tunggu saat sistem memproses data untuk pembatalan ...";
        public const string MessageWaitAmoment = "sistem sedang memproses data dari database ...";

        public const string MessagePleaseSelect = "Pilihlah data terlebih dahulu ...";
        public const string MessageValueInvalid = "Nilai tidak sesuai untuk ";
        public const string MessagePrivilegeRead = "Anda tidak memiliki akses untuk melakukan melihat data ...!";
        public const string MessagePrivilegeEdit = "Anda tidak memiliki akses untuk melakukan perubahan data ...!";
        public const string MessageMin2Char = "Minimal 2 char untuk memulai pencarian";

        public const string MessagePrivilegeAdmin = "Hanya user Admin Database atau user dengan role Administrator yang bisa memiliki akses";
        public const string MessageNoUserLogin = "Tidak terdapat user yang login kedalam system (atau anda login menggunakan user database)";
        public const string MessageInvalidLayout = "Gagal untuk memproses layout ";

        public const string MessagePrivilegeDelete = "Anda tidak memiliki akses untuk melakukan penghapusan data";
        public const string MessageDocumentNotBelongToYou = "Anda tidak berhak menghapus dokumen yang bukan milik anda ...!";
        public const string MessageFailedToApprove = "Gagal melakukan approval untuk dokumen dengan nomor ";
        public const string MessageFailedToDelete = "Gagal menghapus data karena dokumen telah disetujui ...!";
        public const string MessageInCurrentEditing = "Anda telah melakukan perubahan data, namun belum disimpan. Apakah anda yakin untuk keluar dari modul";
        public const string MessageZeroRecordCount = "Apakah anda yakin untuk memunculkan semua record yang ada dikarenakan akan mengakibatkan waktu proses yang lama";

        public const string MessageCustomerCantBeEmpty = @"Silahkan untuk memilih ""Customer"" atau ""Customer"" tidak boleh kosong";

        public static bool ShowDialogResult(DialogResult parameter) { return (parameter == DialogResult.OK) || (parameter == DialogResult.Cancel); }
        public static bool ShowDialogNoClose(DialogResult parameter) { return (parameter != DialogResult.Cancel); }
        public static void ShowMessageError(Exception fException, TrackError fCallMethod = null, bool fLogError = false)
        {
            string messageexception = "";
            string messagefull = "";

            if (fException.InnerException == null)
                messageexception = fException.Message.ToString();
            else
                messageexception = fException.InnerException.Message.ToString();

            messagefull = "Error with exception : " + messageexception;

            if (fCallMethod != null)
            {
                messagefull = messagefull + Environment.NewLine + Environment.NewLine;

                messagefull = string.Format("{0}Technical Spesification{1}", messagefull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Method Name : {2}{3}", messagefull, "\t", fCallMethod.MethodName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name : {2}{3}", messagefull, "\t", fCallMethod.TypeName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name Full : {2}{3}", messagefull, "\t", fCallMethod.TypeNameFull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Line Number : {2}{3}", messagefull, "\t", fCallMethod.LineNumber, Environment.NewLine);
            }

            WaitFormClose();
            XtraMessageBox.Show(messagefull, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (fLogError == true)
            {
            }
        }
        public static void ShowMessageError(IWin32Window owner, Exception fException, TrackError fCallMethod, bool fLogError = false)
        {
            string messageexception = "";
            string messagefull = "";

            if (fException.InnerException == null)
                messageexception = fException.Message.ToString();
            else
                messageexception = fException.InnerException.Message.ToString();

            messagefull = "Error with exception : " + messageexception;

            if (fCallMethod != null)
            {
                messagefull = messagefull + Environment.NewLine + Environment.NewLine;

                messagefull = string.Format("{0}Technical Spesification{1}", messagefull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Method Name : {2}{3}", messagefull, "\t", fCallMethod.MethodName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name : {2}{3}", messagefull, "\t", fCallMethod.TypeName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name Full : {2}{3}", messagefull, "\t", fCallMethod.TypeNameFull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Line Number : {2}{3}", messagefull, "\t", fCallMethod.LineNumber, Environment.NewLine);
            }

            WaitFormClose();
            XtraMessageBox.Show(owner, messagefull, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (fLogError == true)
            {
            }
        }

        public static void ShowMessageError(IWin32Window owner, Exception fException, bool fLogError = false)
        {
            string message = fException.Message;//MessageHelper.GetDetailMessageError(fException);
            message = message + " ... !";
            WaitFormClose();
            if (owner == null)
            {
                XtraMessageBox.Show(message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form tf = Application.OpenForms.OfType<Form>().Where((t) => t.TopMost).FirstOrDefault();
                XtraMessageBox.Show(tf ?? (owner), message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fLogError == true)
            {
            }
        }

        public static void ShowMessageError(IWin32Window owner, string fMessage, bool fLogError = false)
        {
            string message = fMessage + " ... !";
            WaitFormClose();
            if (owner == null)
            {
                XtraMessageBox.Show(message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form tf = Application.OpenForms.OfType<Form>().Where((t) => t.TopMost).FirstOrDefault();
                XtraMessageBox.Show(tf ?? (owner), message,
                       MessageAppTitle,
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (fLogError == true)
            {
            }
        }

        public static void ShowMessageError(Form owner, Exception fException, bool fLogError = false)
        {
            string message = fException.Message;//MessageHelper.GetDetailMessageError(fException);
            if (true)
            {

            }

            WaitFormClose();
            if (owner == null)
            {
                XtraMessageBox.Show(message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form tf = Application.OpenForms.OfType<Form>().Where((t) => t.TopMost).FirstOrDefault();
                XtraMessageBox.Show(tf ?? (owner), message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fLogError == true)
            {
            }
        }

        public static void ShowMessageError(Form owner, string fMessage, bool fLogError = false)
        {
            string message = fMessage;
            WaitFormClose();
            if (owner == null)
            {
                XtraMessageBox.Show(message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form tf = Application.OpenForms.OfType<Form>().Where((t) => t.TopMost).FirstOrDefault();
                XtraMessageBox.Show(tf ?? (owner), message, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fLogError == true)
            {
            }
        }

        public static void ShowMessageWarning(IWin32Window owner, string fMessage)
        {
            WaitFormClose();
            XtraMessageBox.Show(owner, fMessage, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowMessageInformation(IWin32Window owner, string fMessage)
        {
            WaitFormClose();
            XtraMessageBox.Show(owner, fMessage, MessageAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowMessageQuestion(string fMessage, MessageBoxButtons fMessageBoxButton = MessageBoxButtons.YesNo, MessageBoxDefaultButton fMessageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        {
            DialogResult result = XtraMessageBox.Show(fMessage + " ... ?", MessageAppTitle, fMessageBoxButton, MessageBoxIcon.Question, fMessageBoxDefaultButton);
            return result;
        }

        public static DialogResult ShowMessageQuestion(IWin32Window owner, string fMessage, MessageBoxButtons fMessageBoxButton = MessageBoxButtons.YesNo, MessageBoxDefaultButton fMessageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        {
            DialogResult result = XtraMessageBox.Show(owner, fMessage + " ... ?", MessageAppTitle, fMessageBoxButton, MessageBoxIcon.Question, fMessageBoxDefaultButton);
            return result;
        }

        private static void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.MaximumSize = new System.Drawing.Size(600, 600);
        }

        //public static string GetDetailMessageError(Exception ex)
        //{
        //    if (ex.GetType().ToString() == "Microsoft.OData.Client.DataServiceQueryException")
        //    {
        //        var queryerr = ex as DataServiceQueryException;

        //        while (ex.InnerException != null) ex = ex.InnerException;
        //        var errorReader = ODataErrorReader.FromJson(ex);
        //        string errorDesc = "";
        //        if (errorReader.Error.Innererror != null)
        //            errorDesc = errorReader.Error.Innererror.Message;
        //        else
        //        {
        //            if (errorReader.Error != null)
        //            {
        //                errorDesc = errorReader.Error.Message;
        //            }
        //            else
        //                errorDesc = errorReader.Message;
        //        }
        //        return errorDesc;
        //        //return queryerr.Message + @" Response.Status Code = """ + queryerr.Response.StatusCode + @"""" + ".\n" + errorDesc;
        //    }
        //    else
        //    {
        //        if (ex.GetType().Equals(typeof(DataServiceRequestException)))
        //        {
        //            var response = (ex as DataServiceRequestException).Response.FirstOrDefault();
        //            if (response != null)
        //            {
        //                if (response.StatusCode == 422)
        //                {

        //                }
        //            }

        //            string errorDesc = ex.Message + " ";
        //            ex = ex.InnerException;
        //            var errorReader = ODataErrorReader.FromJson(ex);
        //            errorDesc = errorReader.Error.Message;

        //            if (errorDesc == "")
        //            {
        //                errorDesc = ex.Message;
        //                if (ex.InnerException != null)
        //                {
        //                    errorDesc = errorDesc + "with detail error : " + ex.InnerException.Message;
        //                }
        //            }

        //            return errorDesc;
        //        }
        //        else
        //        {
        //            string errorDesc = ex.Message + " ";
        //            while (ex.InnerException != null) ex = ex.InnerException;
        //            var errorReader = ODataErrorReader.FromJson(ex);

        //            if (errorReader.Error.Innererror != null)
        //                errorDesc = errorReader.Error.Message + @"\n with detail description : " + errorReader.Error.Innererror.Message;
        //            else
        //            {
        //                if (errorReader.Error != null)
        //                {
        //                    if (errorDesc.Trim() != errorReader.Error.Message.Trim())
        //                        errorDesc = errorDesc + errorReader.Error.Message;
        //                }
        //                else
        //                    errorDesc = errorDesc + errorReader.Message;
        //            }
        //            return errorDesc;
        //        }
        //    }

        //}

        public static void ShowFlyingError(Form formParent, Exception fException, TrackError fCallMethod, bool fLogError = false)
        {
            string fmessage = "";
            string messagefull = "";

            if (fException.InnerException == null)
                fmessage = fException.Message.ToString();
            else
                fmessage = fException.InnerException.Message.ToString();

            messagefull = "Error with exception : " + fmessage;

            if (fCallMethod != null)
            {
                messagefull = messagefull + Environment.NewLine + Environment.NewLine;

                messagefull = string.Format("{0}Technical Spesification{1}", messagefull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Method Name : {2}{3}", messagefull, "\t", fCallMethod.MethodName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name : {2}{3}", messagefull, "\t", fCallMethod.TypeName, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Type Name Full : {2}{3}", messagefull, "\t", fCallMethod.TypeNameFull, Environment.NewLine);
                messagefull = string.Format("{0}{1}- Line Number : {2}{3}", messagefull, "\t", fCallMethod.LineNumber, Environment.NewLine);
            }

            WaitFormClose();

            ShowFlyingErrorWindow(formParent, messagefull);

            if (fLogError == true)
            {
            }
        }
        public static void ShowFlyingError(Form formParent, Exception fException, bool fLogError = false)
        {
            string fmessage = "";
            if (fException.InnerException == null)
                fmessage = fException.Message.ToString();
            else
                fmessage = fException.InnerException.Message.ToString();

            WaitFormClose();

            ShowFlyingErrorWindow(formParent, fmessage);

            if (fLogError == true)
            {
            }
        }
        public static void ShowFlyingError1(Form formParent, string fMessage)
        {
            WaitFormClose();
            ShowFlyingErrorWindow(formParent, fMessage);
        }
        private static void ShowFlyingErrorWindow(Form formParent, string fMessage)
        {
            WaitFormClose();

            FlyoutAction action = new FlyoutAction();
            action.Caption = "Error";
            action.Description = fMessage;
            //action.ImageOptions.Image = Properties.Resources.Error_32px;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Close", Result = DialogResult.Yes };

            action.Commands.Add(command1);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new System.Drawing.Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;

            //properties.Appearance.BackColor = GlobalVar.BackColor1;
            //properties.Appearance.ForeColor = System.Drawing.Color.White;
            //properties.AppearanceButtons.BackColor = GlobalVar.BackColor3;

            FlyoutDialog.Show(formParent, action, properties);
        }

        public static FlyoutProperties GetFlyoutProperties()
        {
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new System.Drawing.Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;

            //properties.Appearance.Font = GlobalVar.FontOswaldRegular12;
            //properties.Appearance.BackColor = GlobalVar.BackColor1;
            //properties.Appearance.ForeColor = GlobalVar.ForeColor1;
            //properties.AppearanceButtons.BackColor = GlobalVar.BackColor3;

            return properties;
        }

        public static void ShowFlyingInformation1(Form formParent, string fMessage)
        {
            WaitFormClose();

            FlyoutAction action = new FlyoutAction();
            action.Caption = "Information";
            action.Description = fMessage;
            //action.ImageOptions.Image = Properties.Resources.Info_32px;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Close", Result = DialogResult.Yes };

            action.Commands.Add(command1);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new System.Drawing.Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;
            //properties.Appearance.BackColor = GlobalVar.BackColor1;
            //properties.Appearance.ForeColor = GlobalVar.ForeColor1;

            //properties.AppearanceButtons.BackColor = GlobalVar.BackColor3;

            FlyoutDialog.Show(formParent, action, properties);
        }
        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }
        public static DialogResult ShowFlyingQuestion1(Form formParent, string fMessage)
        {
            WaitFormClose();

            FlyoutAction action = new FlyoutAction() { Caption = "Confirmation", Description = fMessage };
            Predicate<DialogResult> predicate = canCloseFunc;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Yes", Result = DialogResult.Yes };
            FlyoutCommand command2 = new FlyoutCommand() { Text = "No", Result = DialogResult.No };

            action.Commands.Add(command1);
            action.Commands.Add(command2);
            //action.ImageOptions.Image = Properties.Resources.Ask_Question_32px;

            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new System.Drawing.Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;
            //properties.Appearance.BackColor = GlobalVar.BackColor1;
            //properties.Appearance.ForeColor = GlobalVar.ForeColor1;
            //properties.AppearanceButtons.BackColor = GlobalVar.BackColor3;

            return FlyoutDialog.Show(formParent, action, properties, predicate);
        }

        public static IOverlaySplashScreenHandle ShowOverlayWait(Form form)
        {
            return SplashScreenManager.ShowOverlayForm(form);
        }
        public static void CloseOverlayWait(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }

        public static void WaitFormShow(Form parentform, string caption = "")
        {
            // Open Wait Form
            SplashScreenManager.ShowForm(parentform, typeof(frmBaseWaitForm), true, true, false);
            if (caption != "")
                SplashScreenManager.Default.SendCommand(frmBaseWaitForm.WaitFormCommand.SetCaption, caption);
            else
                SplashScreenManager.Default.SendCommand(frmBaseWaitForm.WaitFormCommand.SetCaption, MessageHelper.MessageWaitLoadingData);
        }
        public static void WaitFormClose(Form parentform)
        {
            // Close Wait Form
            SplashScreenManager.CloseForm(false, 0, parentform);
        }
        public static void WaitFormClose()
        {
            // Close Wait Form
            SplashScreenManager.CloseForm(false);
        }

        public static void UpdateProgressWaitFormShow(string caption = "", string description = "")
        {
            if (!string.IsNullOrEmpty(caption))
                SplashScreenManager.Default?.SetWaitFormCaption(caption);

            if (!string.IsNullOrEmpty(description))
                SplashScreenManager.Default?.SetWaitFormDescription(description);
        }

    }

    public class CustomOverlayPainter : OverlayWindowPainterBase
    {
        // Defines the string’s font.
        static readonly Font drawFont;
        static CustomOverlayPainter()
        {
            drawFont = new Font("Tahoma", 18);
        }
        protected override void Draw(OverlayWindowCustomDrawContext context)
        {
            //The Handled event parameter should be set to true. 
            //to disable the default drawing algorithm. 
            context.Handled = true;
            //Provides access to the drawing surface. 
            GraphicsCache cache = context.DrawArgs.Cache;
            //Adjust the TextRenderingHint option
            //to improve the image quality.
            cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //Overlapped control bounds. 
            Rectangle bounds = context.DrawArgs.Bounds;
            //Draws the default background. 
            context.DrawBackground();
            //Specify the string that will be drawn on the Overlay Form instead of the wait indicator.
            String drawString = "Please wait...";
            //Get the system's black brush.
            Brush drawBrush = Brushes.Black;
            //Calculate the size of the message string.
            SizeF textSize = cache.CalcTextSize(drawString, drawFont);
            //A point that specifies the upper-left corner of the rectangle where the string will be drawn.
            PointF drawPoint = new PointF(
                bounds.Left + bounds.Width / 2 - textSize.Width / 2,
                bounds.Top + bounds.Height / 2 - textSize.Height / 2
                );
            //Draw the string on the screen.
            cache.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }
    }
}
