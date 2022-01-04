namespace Blatomic.Services.ColorScheme
{
    public interface ITheme
    {
        Palette Primary { get; set; }
        Palette Light { get; set; }
        Palette Secondary { get; set; }
        Palette Success { get; set; }
        Palette Danger { get; set; }
        Palette Warning { get; set; }
        Palette Info { get; set; }
        Palette Dark { get; set; }
        CustomTheme Custom { get; set; }
    }

    public static class ThemeExtensions
    {
        public static Palette? Get(this ITheme theme, string themeName)
        {
            return theme.Custom.Get(themeName);
        }
        public static ITheme Add(this ITheme theme, string themeName, Palette themePalette)
        {
            theme.Custom.Add(themeName, themePalette);
            return theme;
        }
    }
}