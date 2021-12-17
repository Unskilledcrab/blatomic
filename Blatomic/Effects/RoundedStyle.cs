namespace Blatomic.Effects
{
    public enum RoundedStyle
    {
        None,
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL,
        /// <summary>
        /// Fully rounded (will make a pill shape on rectangles [buttons] and circle for square shapes)
        /// </summary>
        Full
    }

    public static class RoundedStyleExtensions
    {
        /// <summary>
        /// Easy builder for rounded style since everything can be rounded
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="hoverEffect"></param>
        /// <returns></returns>
        public static string RoundedStyle(this RoundedStyle roundedStyle)
        {
            switch (roundedStyle)
            {
                case Effects.RoundedStyle.None:
                    return "rounded-none";
                case Effects.RoundedStyle.XS:
                    return "rounded-sm";
                case Effects.RoundedStyle.S:
                    return "rounded";
                case Effects.RoundedStyle.M:
                    return "rounded-md";
                case Effects.RoundedStyle.L:
                    return "rounded-lg";
                case Effects.RoundedStyle.XL:
                    return "rounded-xl";
                case Effects.RoundedStyle.XXL:
                    return "rounded-2xl";
                case Effects.RoundedStyle.XXXL:
                    return "rounded-3xl";
                case Effects.RoundedStyle.Full:
                    return "rounded-full";
                default:
                    break;
            }
            return string.Empty;
        }
    }
}
