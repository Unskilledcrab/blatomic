namespace Blatomic.Effects
{
    public enum HoverEffect
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
        public static string HoverStyle(this HoverEffect hoverEffect)
        {
            switch (hoverEffect)
            {
                case 0:
                    return string.Empty;
                case HoverEffect.Shadow:
                    return "hover:shadow-2xl";
                case HoverEffect.Ring:
                    return "hover:ring hover:ring-offset-2";
            };
            return string.Empty;
        }
    }
}
