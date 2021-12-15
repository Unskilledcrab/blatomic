using Blatomic.Base;
using Blatomic.Extensions;

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
        public static StyleBuilder AddHover(this StyleBuilder builder, HoverEffect hoverEffect)
        {
            switch (hoverEffect)
            {
                case HoverEffect.Shadow:
                    builder.Add("shadow")
                           .Add("hover:shadow-lg");
                    break;
                case HoverEffect.Ring:
                    builder.Add("hover:ring")
                           .Add("hover:ring-offset-2");
                    break;
            };
            return builder;
        }
    }
}
