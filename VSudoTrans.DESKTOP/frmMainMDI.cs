using System;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars.Navigation;
using Domain.Entities.Identity;
using System.Collections.Generic;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.Utils;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraBars;
using System.Reflection;
using System.Deployment.Application;
using DevExpress.Utils.Extensions;

namespace VSudoTrans.DESKTOP
{
    public enum LogOutStatus
    {
        None = -1,
        LogOff = 0,
        Restart = 1,
        Quit = 2
    }

    public partial class frmMainMDI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Timer _Timer = new Timer();
        bool IsForceClosed = false;
        public frmMainMDI()
        {
            InitializeComponent();
            _RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            bciNavigationTree.Checked = true;

            UpdateService = SilentUpdater.Instance;
            UpdateService.ProgressChanged += SilentUpdaterOnProgressChanged;
            UpdateService.Completed += SilentUpdaterCompleted;

            SetStatusBar();

            InitAccordion(_NavigationTreeAccordion);

            this.FormClosing += FrmMainMDI_FormClosing;

            btnRestart.ItemClick += BtnRestart_ItemClick;
            bciNavigationTree.CheckedChanged += BciNavigationTree_CheckedChanged;

            _Timer.Tick += _Timer_Tick;
            _Timer.Start();
        }

        private void BciNavigationTree_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bciNavigationTree.Checked == true)
                dockPanelNavigationTree.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            else
                dockPanelNavigationTree.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            bsiDateTime.Caption = " Tanggal : " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }


        #region Code area for silent updated        
        private SilentUpdater UpdateService { get; }

        public string UpdaterText { set { bsiVersion.Caption = value; } }

        private bool SiledntUpdateNotified;

        private void SilentUpdaterOnProgressChanged(object sender, UpdateProgressChangedEventArgs e) => UpdaterText = e.StatusString;

        private void SilentUpdaterCompleted(object sender, EventArgs e)
        {
            if (SiledntUpdateNotified) return;
            SiledntUpdateNotified = true;

            NotifyUser();
        }

        private void NotifyUser()
        {
            // Notify on UI thread...
            if (InvokeRequired)
                Invoke((MethodInvoker)(NotifyUser));
            else
            {
                // silently notify the user...
                btnRestart.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                UpdaterText = "Versi baru telah di install!";

                ////Uncomment if app needs to be more disruptive
                //MessageBox.Show(this, "Versi baru sekarang tersedia.",
                //                "VERSI BARU",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);
            }
        }
        #endregion

        private void BtnRestart_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Tutup Aplikasi, user harus jalankan ulang aplikasi
            IsForceClosed = true;
            Application.Exit();
        }

        public static string GetAppVersion()
        {
            return ApplicationDeployment.IsNetworkDeployed
                   ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                   : Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        void SetStatusBar(bool fEmpty = false)
        {
            bsiUrl.Caption = $"Url : {ApplicationSettings.Instance.UriHelper.UrlApiDefault.ToLower().Replace("https://", "").Replace("http://", "").Replace("/", "")}";
            bsiVersion.Caption = "Versi : " + GetAppVersion();

            if (ApplicationSettings.Instance.ApplicationUser != null)
            {
                bsiUser.Caption = $"Pengguna : {ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
            }
            if (ApplicationSettings.Instance.UserCompanys != null)
            {
                if (ApplicationSettings.Instance.UserCompanys.Count == 0)
                {
                    bsiCompany.Caption = "Tidak ada akses Perusahaan ";
                }
                else
                {
                    if (ApplicationSettings.Instance.UserCompanys.Count == 1)
                    {
                        bsiCompany.Caption = $"Akses Perusahaan : {ApplicationSettings.Instance.UserCompanys[0].Code} - {ApplicationSettings.Instance.UserCompanys[0].Name} ";
                    }
                    else
                    {
                        bsiCompany.Caption = "Ditugaskan Beberapa Perusahaan";
                        SuperToolTip superTipCompany = new SuperToolTip();
                        SuperToolTipSetupArgs argsCompany = new SuperToolTipSetupArgs();
                        argsCompany.Title.Text = "Akses Beberapa Perusahaan";
                        foreach (var Company in ApplicationSettings.Instance.UserCompanys)
                        {
                            argsCompany.Contents.Text += $"{Company.Code} - {Company.Name} <br>";
                        }

                        //args.ShowFooterSeparator = true;
                        //args.Footer.Text = "<a href=\"https://www.devexpress.com\">Learn more</a>";
                        superTipCompany.Setup(argsCompany);
                        superTipCompany.AllowHtmlText = DefaultBoolean.True;
                        bsiCompany.SuperTip = superTipCompany;
                    }
                }
            }

            if (ApplicationSettings.Instance.UserRoles != null)
            {
                if (ApplicationSettings.Instance.UserRoles.Count == 0)
                {
                    bsiRole.Caption = "Tidak ada peran : ";
                }
                else
                {
                    if (ApplicationSettings.Instance.UserRoles.Count == 1)
                    {
                        bsiRole.Caption = $"Peran : {ApplicationSettings.Instance.UserRoles[0].Name} ";
                    }
                    else
                    {
                        bsiRole.Caption = "Ditugaskan Beberapa Peran";
                        SuperToolTip superTipRole = new SuperToolTip();
                        SuperToolTipSetupArgs argsRole = new SuperToolTipSetupArgs();
                        argsRole.Title.Text = "Akses Beberapa Peran";
                        foreach (var role in ApplicationSettings.Instance.UserRoles)
                        {
                            argsRole.Contents.Text += $"{role.Name}<br>";
                        }
                        //args.ShowFooterSeparator = true;
                        //args.Footer.Text = "<a href=\"https://www.devexpress.com\">Learn more</a>";
                        superTipRole.Setup(argsRole);
                        superTipRole.AllowHtmlText = DefaultBoolean.True;
                        bsiRole.SuperTip = superTipRole;
                    }
                }
            }
        }

        private void LogOff()
        {
            IsForceClosed = true;
            //ResetActiveLogin();

            // Reset Tab
            this._RibbonControl.UnMergeRibbon();
            //this.tabbedView.Documents.Clear();
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }

            this.Visible = false;
            DialogResult oDialogResult = DialogResult.None;

            using (frmLogin ofrmLoginUser = new frmLogin())
            {
                ofrmLoginUser.StartPosition = FormStartPosition.CenterParent;
                oDialogResult = ofrmLoginUser.ShowDialog(this);
            }

            if (oDialogResult == DialogResult.OK)
            {
                InitAccordion(_NavigationTreeAccordion);
                this.Visible = true;
                SetStatusBar();

                //ShowMain();
            }
            else if (oDialogResult == DialogResult.Cancel)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private LogOutStatus mainClose(object sender, System.EventArgs e)
        {
            LogOutStatus logOutStatus = LogOutStatus.None;
            DialogResult dialogResult = DialogResult.None;
            using (frmLogOff ofrmLogOutUser = new frmLogOff())
            {
                dialogResult = ofrmLogOutUser.ShowDialog(this);
                logOutStatus = ofrmLogOutUser.logOutStatus;
            }
            return logOutStatus;
        }
        private void FrmMainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsForceClosed)
            {
                e.Cancel = false;
            }
            else
            {
                LogOutStatus logOutStatus = mainClose(sender, e);
                if (logOutStatus == LogOutStatus.LogOff)
                {
                    e.Cancel = true;
                    LogOff();
                    IsForceClosed = false;
                }
                else if (logOutStatus == LogOutStatus.Quit)
                {
                    e.Cancel = false;
                }
                else if (logOutStatus == LogOutStatus.Restart)
                    System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
                else
                    e.Cancel = true;
            }
        }

        List<Navigation> navs = new List<Navigation>();
        private void InitAccordion(AccordionControl accordion)
        {
            var roleNames = ApplicationSettings.Instance.UserRoles.Select(s => s.Name);

            accordion.Elements.Clear();
            navs = HelperRestSharp.GetListOdata<Navigation>("/Navigations", "*", msgLoading: $"Memuat Navigasi ...");
            foreach (var nav in navs.Where(s => s.ParentCode == null).OrderBy(s => s.Index).ToList())
            {
                if (nav.Code == "H2-MST-02-01")
                {
                    if (roleNames.FirstOrDefault(s => s == "Super Administrator") == null)
                        continue;
                }

                var anyNav = ApplicationSettings.Instance.NavigationRoles.Where(s => s.Navigation.Code == nav.Code).FirstOrDefault();
                AccordionControlElement group = new AccordionControlElement(ElementStyle.Group)
                {
                    Name = nav.Code,
                    Text = nav.Name,
                    Expanded = true
                };

                AddChild(nav.Code, group);

                if (anyNav != null)
                    accordion.Elements.Add(group);
            }
        }

        private void AddChild(string code, AccordionControlElement group)
        {
            var childs = navs.Where(s => s.ParentCode == code).OrderBy(s => s.Index).ToList();
            foreach (var c in childs)
            {
                var anyNav = ApplicationSettings.Instance.NavigationRoles.Where(s => s.Navigation.Code == c.Code).FirstOrDefault();
                var check = navs.Where(s => s.ParentCode == c.Code).OrderBy(s => s.Index).ToList();
                if (check.Any())
                {
                    AccordionControlElement item = new AccordionControlElement(ElementStyle.Group)
                    {
                        Name = c.Code,
                        Text = c.Name
                    };

                    AddChild(c.Code, item);

                    if (anyNav != null)
                        group.Elements.Add(item);
                }
                else
                {
                    AccordionControlElement item = new AccordionControlElement(ElementStyle.Item)
                    {
                        Name = c.Code,
                        Text = c.Name
                    };

                    item.Click += AccordionControl_Click;

                    if (anyNav != null)
                        group.Elements.Add(item);
                }
            }
        }

        private void AccordionControl_Click(object sender, EventArgs e)
        {
            var acc = (AccordionControlElement)sender;
            if (acc == null) return;

            var nav = navs.Where(s => s.Code == acc.Name).FirstOrDefault();
            if (nav == null) return;

            // jangan lupa ganti ini ya ke true kalau mau di deploy
            bool runWithAuthorization = true;

//#if DEBUG
//            runWithAuthorization = false;
//#else
//                        runWithAuthorization = true;
//#endif

            if (runWithAuthorization == false)
            {
                if (nav.IsPopUp)
                    FormActivatorShowDialog(nav.ObjectDesktop);
                else
                    FormActivator(nav.ObjectDesktop);
            }
            else
            {
                var accessNav = ApplicationSettings.Instance.NavigationRoles.Where(s => s.Navigation.Code == nav.Code).FirstOrDefault();
                if (accessNav == null)
                    MessageHelper.ShowMessageWarning(this, $"Anda tidak punya akses ke navigasi {nav.Name}");
                else
                {
                    ApplicationSettings.Instance.ControllerId = accessNav.Navigation.ControllerId;
                    if (nav.IsPopUp)
                        FormActivatorShowDialog(nav.ObjectDesktop);
                    else
                        FormActivator(nav.ObjectDesktop);
                }
            }
        }
        void FormActivator(string formName)
        {
            IOverlaySplashScreenHandle handle = null;
            try
            {
                handle = MessageHelper.ShowOverlayWait(this);

                var objForm = (DevExpress.XtraEditors.XtraForm)Activator.CreateInstance(Type.GetType(formName));
                objForm.MdiParent = this;
                objForm.Show();

                MessageHelper.CloseOverlayWait(handle);
            }
            catch (Exception ex)
            {
                MessageHelper.CloseOverlayWait(handle);
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        void FormActivatorShowDialog(string formName)
        {
            try
            {
                var objForm = (DevExpress.XtraEditors.XtraForm)Activator.CreateInstance(Type.GetType(formName));
                objForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private void frmMainMDI_Load(object sender, EventArgs e)
        {

        }

        private void _RibbonControl_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            _RibbonControl.SelectedPage = e.MergedChild.SelectedPage;
        }

        private void bbiExitApp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
