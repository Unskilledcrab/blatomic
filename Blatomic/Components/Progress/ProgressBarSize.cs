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
        Small,
        Medium,
        Large,
        XL
    }

    public static class ProgressBarSizeExtensions
    {
        public static string GetStyle(this ProgressBarSize size)
        {
            switch (size)
            {
                case ProgressBarSize.Tiny:
                    return "h-1";
                case ProgressBarSize.Small:
                    return "h-2";
                case ProgressBarSize.Medium:
                    return "h-3";
                case ProgressBarSize.Large:
                    return "h-4";
                case ProgressBarSize.XL:
                    return "h-5";
                default:
                    return string.Empty;
            }
        }
    }
}
