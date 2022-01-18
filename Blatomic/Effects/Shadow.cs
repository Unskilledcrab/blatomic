using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Effects
{
    public enum ShadowType
    {
        None,
        Small,
        Regular,
        Medium,
        Large,
        XL,
        XXL,
        Inner
    }

    public static class ShadowExtensions
    {
        public static string GetStyle(this ShadowType shadowType)
        {
            switch (shadowType)
            {
                case ShadowType.None:
                    return "b-shadow-none";
                case ShadowType.Small:
                    return "b-shadow-sm";
                case ShadowType.Regular:
                    return "b-shadow";
                case ShadowType.Medium:
                    return "b-shadow-md";
                case ShadowType.Large:
                    return "b-shadow-lg";
                case ShadowType.XL:
                    return "b-shadow-xl";
                case ShadowType.XXL:
                    return "b-shadow-2xl";
                case ShadowType.Inner:
                    return "b-shadow-inner";
                default:
                    return string.Empty;
            }
        }
    }
    public class Shadow
    {
        public static string Standard(ShadowType shadowType)
        {
            return $"{shadowType.GetStyle()} b-shadow-black/50 dark:b-shadow-white/25";
        }
    }
}
