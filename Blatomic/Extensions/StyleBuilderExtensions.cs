using Blatomic.Base;

namespace Blatomic.Extensions;

public static class StyleBuilderExtensions
{
    public static StyleBuilder Add(this StyleBuilder builder, params string[] styles)
    {
        foreach (var style in styles)
        {
            builder.AddStyle(style);
        }
        return builder;
    }

    public static StyleBuilder Remove(this StyleBuilder builder, params string[] styles)
    {
        foreach (var style in styles)
        {
            builder.RemoveStyle(style);
        }
        return builder;
    }
}
