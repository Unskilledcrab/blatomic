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
        public static string Style(this CordinalPosition position)
        {
            switch (position)
            {
                case CordinalPosition.Top:
                    return "b-top-0 b-inset-x-1/2";
                case CordinalPosition.TopLeft:
                    return "b-top-0 b-left-0 b-ml-1";
                case CordinalPosition.TopRight:
                    return "b-top-0 b-right-0 b-mr-1";
                case CordinalPosition.Bottom:
                    return "b-bottom-0 b-inset-x-1/2";
                case CordinalPosition.BottomLeft:
                    return "b-bottom-0 b-left-0";
                case CordinalPosition.BottomRight:
                    return "b-bottom-0 b-right-0";
                case CordinalPosition.Left:
                    return "b-left-0 b-inset-y-1/2";
                case CordinalPosition.Right:
                    return "b-right-0 b-inset-y-1/2";
                case CordinalPosition.Center:
                    return "b-inset-1/2";
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
                    return "b-top-0 b-left-0 b-right-0 b-max-h-60";
                case Position.Bottom:
                    return "b-bottom-0 b-left-0 b-right-0 b-max-h-60";
                case Position.Left:
                    return "b-top-0 b-left-0 b-bottom-0 b-max-w-xs sm:b-max-w-sm md:b-max-w-md lg:b-max-w-lg";
                case Position.Right:
                    return "b-top-0 b-bottom-0 b-right-0 b-max-w-xs sm:b-max-w-sm md:b-max-w-md lg:b-max-w-lg";
                default:
                    return string.Empty;
            }
        }


        public static string AbsoluteStyle(this Position position)
        {
            switch (position)
            {
                case Position.Top:
                    return "b-bottom-full";
                case Position.Bottom:
                    return "b-top-full";
                case Position.Left:
                    return "b-right-full b-top-0";
                case Position.Right:
                    return "b-left-full b-top-0";
                default:
                    return string.Empty;
            }
        }

        public static string MarginStyle(this Position position)
        {
            switch (position)
            {
                case Position.Top:
                    return "b-mb-4";
                case Position.Bottom:
                    return "b-mt-4";
                case Position.Left:
                    return "b-mr-4";
                case Position.Right:
                    return "b-ml-4";
                default:
                    return string.Empty;
            }
        }

        public static string ArrowStyle(this Position position)
        {
            var defaults = "after:b-absolute after:b-border-8 after:b-border-solid";
            var TB = "after:b-left-1/2 after:b--ml-2";
            var LR = "after:b-top-1/2 after:b--mt-2";
            switch (position)
            {
                case Position.Top:
                    return $"{defaults} {TB} after:b-top-full after:b-border-t-inherit after:b-border-r-transparent after:b-border-b-transparent after:b-border-l-transparent";
                case Position.Bottom:
                    return $"{defaults} {TB} after:b-bottom-full after:b-border-t-transparent after:b-border-r-transparent after:b-border-b-inherit after:b-border-l-transparent";
                case Position.Left:
                    return $"{defaults} {LR} after:b-left-full after:b-border-t-transparent after:b-border-r-transparent after:b-border-b-transparent after:b-border-l-inherit";
                case Position.Right:
                    return $"{defaults} {LR} after:b-right-full after:b-border-t-transparent after:b-border-r-inherit after:b-border-b-transparent after:b-border-l-transparent";
                default:
                    return string.Empty;
            }
        }
    }
}
