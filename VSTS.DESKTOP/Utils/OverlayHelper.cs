using DevExpress.Utils.Extensions;
using DevExpress.XtraSplashScreen;
using System.Drawing;

namespace VSTS.DESKTOP.Utils
{
    public class OverlayTextPainterTwoLevelEx : OverlayTextPainter
    {
        OverlayTextPainterTwoLevelTextPosition _pos;
        public OverlayTextPainterTwoLevelEx(OverlayTextPainterTwoLevelTextPosition pos)
        {
            _pos = pos;
        }

        protected override Rectangle CalcTextBounds(OverlayLayeredWindowObjectInfoArgs drawArgs)
        {
            Size textSz = CalcTextSize(drawArgs);
            int Y = 0;
            switch (_pos)
            {
                case OverlayTextPainterTwoLevelTextPosition.Title:
                    Y = drawArgs.ImageBounds.Top - textSz.Height - 10;
                    break;

                case OverlayTextPainterTwoLevelTextPosition.Percentage:
                    Y = drawArgs.ImageBounds.Bottom + textSz.Height;
                    break;
            }
            return textSz.AlignWith(drawArgs.Bounds).WithY(Y);
        }
    }

    public enum OverlayTextPainterTwoLevelTextPosition
    {
        Title,
        Percentage
    }

}
