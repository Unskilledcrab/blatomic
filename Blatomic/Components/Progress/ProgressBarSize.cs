using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Components.Progress
{
    public enum ProgressBarSize
    {
        Tiny,
        XXS,
        XS,
        Small,
        Medium,
        Large,
        XL,
        XXL,
    }

    public static class ProgressBarSizeExtensions
    {
        public static string GetStyle(this ProgressBarSize size)
        {
            switch (size)
            {
                case ProgressBarSize.Tiny:
                    return "h-1";
                case ProgressBarSize.XXS:
                    return "h-2";
                case ProgressBarSize.XS:
                    return "h-3";
                case ProgressBarSize.Small:
                    return "h-4";
                case ProgressBarSize.Medium:
                    return "h-5";
                case ProgressBarSize.Large:
                    return "h-6";
                case ProgressBarSize.XL:
                    return "h-7";
                case ProgressBarSize.XXL:
                    return "h-8";
                default:
                    return string.Empty;
            }
        }
    }
}
