using DevExpress.XtraBars;
using DevExpress.Drawing;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System.Drawing;
using VSudoTrans.DESKTOP.Utils;
using System;
using PopUpUtils;
using DevExpress.XtraEditors.DXErrorProvider;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseFilterDVV : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public frmBaseFilterDVV()
        {
            InitializeComponent();
        }

        protected object ObjectBaseClass { get; set; }
        protected string EndPoint { get; set; }
        protected string OdataSelect { get; set; }
        protected string OdataFilter { get; set; }
        protected string FormTitle { get; set; }

        protected virtual void InitializeComponentAfter<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                this.Text = "Laporan " + this.FormTitle;
                this.ObjectBaseClass = new BaseClass<T>(this.EndPoint);

                InitializeParameter();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        public void SetTextWatermark(XtraReport report)
        {
            Watermark textWatermark = new Watermark();
            textWatermark.Text = "VSudoTrans";
            textWatermark.TextDirection = DirectionMode.ForwardDiagonal;
            textWatermark.Font = new DXFont(textWatermark.Font.Name, 40);
            textWatermark.ShowBehind = false;
            report.Watermark.CopyFrom(textWatermark);
        }

        public void SetPictureWatermark(XtraReport report, ImageSource imageSource)
        {
            Watermark pictureWatermark = new Watermark();
            pictureWatermark.ImageSource = imageSource;
            pictureWatermark.ImageAlign = ContentAlignment.BottomRight;
            pictureWatermark.ImageTiling = false;
            pictureWatermark.ImageViewMode = ImageViewMode.Clip;
            pictureWatermark.ImageTransparency = 150;
            pictureWatermark.ShowBehind = true;
            pictureWatermark.PageRange = "1,2,3,4,5";
            report.Watermark.CopyFrom(pictureWatermark);
        }

        protected virtual void ActionRefresh()
        {

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

        protected virtual void InitializeDefaultValidation()
        {

        }

        protected virtual bool InitializeAdditionalValidation()
        {
            return true;
        }

        protected virtual void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }
    }
}