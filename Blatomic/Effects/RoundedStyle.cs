namespace Blatomic.Effects
{

    public class RoundedEffect : BaseEffect<RoundedStyle>
    {
        public override string GetStyle => Effect.RoundedStyle();
    }


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
                    return "b-rounded-none";
                case Effects.RoundedStyle.XS:
                    return "b-rounded-sm";
                case Effects.RoundedStyle.S:
                    return "b-rounded";
                case Effects.RoundedStyle.M:
                    return "b-rounded-md";
                case Effects.RoundedStyle.L:
                    return "b-rounded-lg";
                case Effects.RoundedStyle.XL:
                    return "b-rounded-xl";
                case Effects.RoundedStyle.XXL:
                    return "b-rounded-2xl";
                case Effects.RoundedStyle.XXXL:
                    return "b-rounded-3xl";
                case Effects.RoundedStyle.Full:
                    return "b-rounded-full";
                default:
                    break;
            }
            return string.Empty;
        }
    }
}
