using DevExpress.XtraBars;
using DevExpress.Drawing;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseDVV : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public frmBaseDVV()
        {
            InitializeComponent();
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
            pictureWatermark.ImageAlign = ContentAlignment.TopRight;
            pictureWatermark.ImageTiling = false;
            pictureWatermark.ImageViewMode = ImageViewMode.Clip;
            pictureWatermark.ImageTransparency = 150;
            pictureWatermark.ShowBehind = true;
            pictureWatermark.PageRange = "1,2,3,4,5";
            report.Watermark.CopyFrom(pictureWatermark);
        }
    }
}