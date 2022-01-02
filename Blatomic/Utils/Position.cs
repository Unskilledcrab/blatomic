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

    public static class PositionExtensions
    {
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
