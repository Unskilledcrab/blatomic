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
                    return "b-h-1";
                case ProgressBarSize.XXS:
                    return "b-h-2";
                case ProgressBarSize.XS:
                    return "b-h-3";
                case ProgressBarSize.Small:
                    return "b-h-4";
                case ProgressBarSize.Medium:
                    return "b-h-5";
                case ProgressBarSize.Large:
                    return "b-h-6";
                case ProgressBarSize.XL:
                    return "b-h-7";
                case ProgressBarSize.XXL:
                    return "b-h-8";
                default:
                    return string.Empty;
            }
        }
    }
}
