namespace Blatomic.Effects
{

    public class HoverEffect : BaseEffect<HoverStyle>
    {
        public override string GetStyle => Effect.HoverStyle();
    }

    public enum HoverStyle
    {
        None,
        Shadow,
        Ring
    }

    public static class HoverEffectExtensions
    {
        /// <summary>
        /// You can not have a shadow effect and a ring effect. Use this to make sure you only use one of the other
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="hoverEffect"></param>
        /// <returns></returns>
        public static string HoverStyle(this HoverStyle hoverEffect)
        {
            switch (hoverEffect)
            {
                case 0:
                    return string.Empty;
                case Effects.HoverStyle.Shadow:
                    return "hover:b-shadow-2xl";
                case Effects.HoverStyle.Ring:
                    return "hover:b-ring";
            };
            return string.Empty;
        }
    }

    public static class Hover
    {
        public static string UnderlineAfter(bool showing = false)
        {
            var showingStyle = showing ? "after:b-scale-x-100" : "after:b-scale-x-0";
            var content = "b-relative";
            var after = $"after:b-absolute after:b-transition after:b-w-full after:b-bg-current after:b-bottom-0 after:b-left-0 after:b-h-0.5 {showingStyle}";
            return $"{content} {after}";
        }
    }
}
