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
                    return "hover:shadow-2xl";
                case Effects.HoverStyle.Ring:
                    return "hover:ring";
            };
            return string.Empty;
        }
    }
}
