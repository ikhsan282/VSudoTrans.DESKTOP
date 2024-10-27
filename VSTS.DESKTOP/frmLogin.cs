using DevExpress.DataAccess.Native.Web;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Identity;
using Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using VSTS.DESKTOP.Utils;
using Domain.Entities.Demography;
using System.Linq;
using RestSharp;
using System.Net;

namespace VSTS.DESKTOP
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public bool IsLogin { get; set; }
        public frmLogin()
        {
            InitializeComponent();

            MyValidationHelper.SetValidation(_DxValidationProvider, this.UsernameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PasswordButtonEdit, ConditionOperator.IsNotBlank);

            bsiVersion.Caption = "Versi : " + GetAppVersion();

            bsiSetting.ItemClick += BsiSetting_ItemClick;
            btnLogin.Click += BtnLogin_Click;

            PasswordButtonEdit.Properties.UseSystemPasswordChar = true;
            lblForgotPassword.Click += LblForgotPassword_Click;

            UsernameTextEdit.EditValue = "heru@vsudotech.com";
            PasswordButtonEdit.EditValue = "P@ssw0rd";

            PasswordButtonEdit.ButtonClick += PasswordButtonEdit_ButtonClick;
        }

        private void PasswordButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (PasswordButtonEdit.Properties.UseSystemPasswordChar == true)
                PasswordButtonEdit.Properties.UseSystemPasswordChar = false;
            else
                PasswordButtonEdit.Properties.UseSystemPasswordChar = true;
        }

        private void LblForgotPassword_Click(object sender, EventArgs e)
        {
            new frmForgotPassword().ShowDialog();
        }

        private RestResponse LoginNonSSO()
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new QueryParameter("user", UsernameTextEdit.Text));
            parameters.Add(new QueryParameter("password", PasswordButtonEdit.Text));

            return HelperRestSharp.ExecuteGet("users/login", fParameters: parameters, fAuth: false, fMethod: Method.Post);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (DoValidate() == false) return;

            UsernameTextEdit.ErrorText = string.Empty;
            PasswordButtonEdit.ErrorText = string.Empty;

            MessageHelper.WaitFormShow(this);
            try
            {
                var response = LoginNonSSO();
                MessageHelper.WaitFormClose();

                if (response == null)
                {
                    MessageHelper.WaitFormClose();
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                    return;
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ApplicationSettings.Instance.UriHelper.UrlToken = response.Content.Replace(@"""", "");
                }
                else
                {
                    if (response.IsSuccessful == false && (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.InternalServerError))
                    {
                        MessageHelper.WaitFormClose();

                        UsernameTextEdit.ErrorText = "Nama Pengguna atau Kata Sandi salah.";
                        PasswordButtonEdit.ErrorText = UsernameTextEdit.ErrorText;

                        MessageHelper.ShowMessageError(this, UsernameTextEdit.ErrorText);
                        UsernameTextEdit.Focus();
                        UsernameTextEdit.SelectAll();
                        return;
                    }
                    else if (response.IsSuccessful == false || response.StatusCode == 0)
                    {
                        MessageHelper.WaitFormClose();

                        string msg = "";
                        if (response.ErrorException != null)
                        {
                            msg = response.ErrorException.Message;
                            if (response.ErrorException.InnerException != null)
                            {
                                msg = msg + " " + response.ErrorException.InnerException.Message;
                                if (response.ErrorException.InnerException.InnerException != null)
                                {
                                    msg = msg + ". " + response.ErrorException.InnerException.InnerException.Message;
                                }
                            }
                        }

                        MessageHelper.ShowMessageError(this, "Tidak dapat terhubung : " + msg);
                        return;
                    }
                }

                MessageHelper.WaitFormShow(this);
                this.IsLogin = true;
                // set default user application                
                InitializeUserInformationAsync();

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                else
                    MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }

        private void InitializeUserInformationAsync()
        {
            try
            {
                var results = HelperRestSharp.Get<ApplicationUser>("/Users/Me");

                if (results != null)
                {
                    ApplicationSettings.Instance.ApplicationUser = results;
                    ApplicationSettings.Instance.UserCompanys = new List<Company>();
                    ApplicationSettings.Instance.NavigationRoles = new List<NavigationRole>();
                    ApplicationSettings.Instance.UserRoleClaims = new List<ApplicationRoleClaim>();
                    foreach (var item in results.Companys)
                    {
                        ApplicationSettings.Instance.UserCompanys.Add(new Company() { Id = item.CompanyId, Code = item.Company.Code, PhoneNumber = item.Company.PhoneNumber, Name = item.Company.Name, Group = item.Company.Group });
                    }

                    ApplicationSettings.Instance.UserRoles = new List<ApplicationRole>();
                    foreach (var item in results.Roles)
                    {
                        ApplicationSettings.Instance.UserRoles.Add(new ApplicationRole() { Id = item.RoleId, Name = item.Role.Name });
                        ApplicationSettings.Instance.NavigationRoles.AddRange(HelperRestSharp.GetListOdata<NavigationRole>("/NavigationRoles", "id,navigationId,roleid", "navigation($select=id,code,name,controllerid)", $"roleid eq {item.RoleId}", msgLoading: $"Memuat Navigasi {item.Role.Name} ..."));
                        ApplicationSettings.Instance.UserRoleClaims.AddRange(HelperRestSharp.GetListOdata<ApplicationRoleClaim>("/RoleClaims", "id,ControllerMethodId,roleid", fFilter: $"roleid eq {item.RoleId}", fExpand: "ControllerMethod($select=Name,controllerId)", msgLoading: $"Memuat Akses {item.Role.Name} ..."));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal untuk mendapatkan data dikarenakan anda tidak mendapatkan akses ke API (" + ex.Message + ")");
            }
        }

        private void BsiSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmSetting();
            frm.ShowDialog();
        }

        private bool DoValidate()
        {
            return _DxValidationProvider.Validate();
        }

        public static string GetAppVersion()
        {
            return ApplicationDeployment.IsNetworkDeployed
                   ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                   : Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
