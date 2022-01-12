using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Utils
{
    public enum Position
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public enum CordinalPosition
    {
        Top,
        TopLeft,
        TopRight,
        Bottom,
        BottomLeft,
        BottomRight,
        Left,
        Right,
        Center,
    }

    public static class CordinalPositionExtensions
    {
        public static string ToastStyle(this CordinalPosition position)
        {
            switch (position)
            {
                case CordinalPosition.Top:
                    return "top-0 inset-x-1/2 mt-4";
                case CordinalPosition.TopLeft:
                    return "top-0 left-0 ml-4 mt-4";
                case CordinalPosition.TopRight:
                    return "top-0 right-0 mr-4 mt-4";
                case CordinalPosition.Bottom:
                    return "bottom-0 inset-x-1/2 mb-4";
                case CordinalPosition.BottomLeft:
                    return "bottom-0 left-0 ml-4 mb-4";
                case CordinalPosition.BottomRight:
                    return "bottom-0 right-0 mr-4 mb-4";
                case CordinalPosition.Left:
                    return "left-0 inset-y-1/2 ml-4";
                case CordinalPosition.Right:
                    return "right-0 inset-y-1/2 mr-4";
                case CordinalPosition.Center:
                    return "inset-1/2";
                default:
                    return string.Empty;
            }
        }
    }

    public static class PositionExtensions
    {
        public static string PanelStyle(this Position position)
        {
            switch (position)
            {
                case Position.Top:
                    return "top-0 left-0 right-0 max-h-60";
                case Position.Bottom:
                    return "bottom-0 left-0 right-0 max-h-60";
                case Position.Left:
                    return "top-0 left-0 bottom-0 max-w-lg";
                case Position.Right:
                    return "top-0 bottom-0 right-0 max-w-lg";
                default:
                    return string.Empty;
            }
        }


        public static string AbsoluteStyle(this Position position)
        {
            switch (position)
            {
                case Position.Top:
                    return "bottom-full";
                case Position.Bottom:
                    return "top-full";
                case Position.Left:
                    return "right-full top-0";
                case Position.Right:
                    return "left-full top-0";
                default:
                    return string.Empty;
            }
        }

        public static string MarginStyle(this Position position)
        {
            switch (position)
            {
                case Position.Top:
                    return "mb-4";
                case Position.Bottom:
                    return "mt-4";
                case Position.Left:
                    return "mr-4";
                case Position.Right:
                    return "ml-4";
                default:
                    return string.Empty;
            }
        }
    }

    public static class Tooltip
    {
        public static string ArrowStyle(this Position position)
        {
            var defaults = "after:absolute after:border-8 after:border-solid";
            var TB = "after:left-1/2 after:-ml-2";
            var LR = "after:top-1/2 after:-mt-2";
            switch (position)
            {
                case Position.Top:
                    return $"{defaults} {TB} after:top-full after:border-t-inherit after:border-r-transparent after:border-b-transparent after:border-l-transparent";
                case Position.Bottom:
                    return $"{defaults} {TB} after:bottom-full after:border-t-transparent after:border-r-transparent after:border-b-inherit after:border-l-transparent";
                case Position.Left:
                    return $"{defaults} {LR} after:left-full after:border-t-transparent after:border-r-transparent after:border-b-transparent after:border-l-inherit";
                case Position.Right:
                    return $"{defaults} {LR} after:right-full after:border-t-transparent after:border-r-inherit after:border-b-transparent after:border-l-transparent";
                default:
                    return string.Empty;
            }
        }
    }
}
