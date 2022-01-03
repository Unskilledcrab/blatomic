namespace Blatomic.Services.ColorScheme
{
    public interface ITheme
    {
        string Primary { get; set; }
        string Light { get; set; }
        string Secondary { get; set; }
        string Success { get; set; }
        string Danger { get; set; }
        string Warning { get; set; }
        string Info { get; set; }
        string Dark { get; set; }
        CustomTheme Custom { get; set; }
    }

    public static class ThemeExtensions
    {
        public static string Get(this ITheme theme, string themeName)
        {
            return theme.Custom.Get(themeName);
        }
    }
}