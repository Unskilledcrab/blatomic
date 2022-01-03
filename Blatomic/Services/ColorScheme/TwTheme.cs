namespace Blatomic.Services.ColorScheme;

public class TwTheme : ITheme
{
    public virtual string Primary { get; set; } = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Blue_600,
        Border = TwColors.Bg_Blue_500,
        Outline = TwColors.Bg_Blue_500,
        Ring = TwColors.Bg_Blue_500        
    }.ToString();
    public virtual string Secondary {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Gray_600,
        Border = TwColors.Bg_Gray_500,
        Outline = TwColors.Bg_Gray_500,
        Ring = TwColors.Bg_Gray_500
    }.ToString();
    public virtual string Success {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Green_600,
        Border = TwColors.Bg_Green_500,
        Outline = TwColors.Bg_Green_500,
        Ring = TwColors.Bg_Green_500
    }.ToString();
    public virtual string Danger {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Red_600,
        Border = TwColors.Bg_Red_500,
        Outline = TwColors.Bg_Red_500,
        Ring = TwColors.Bg_Red_500
    }.ToString();
    public virtual string Warning {get;set;} = new Palette()
    {
        Text = TwColors.Text_Black,
        Background = TwColors.Bg_Yellow_600,
        Border = TwColors.Bg_Yellow_500,
        Outline = TwColors.Bg_Yellow_500,
        Ring = TwColors.Bg_Yellow_500
    }.ToString();
    public virtual string Info {get;set;} = new Palette()
    {
        Text = TwColors.Text_Black,
        Background = TwColors.Bg_Sky_400,
        Border = TwColors.Bg_Sky_500,
        Outline = TwColors.Bg_Sky_500,
        Ring = TwColors.Bg_Sky_500
    }.ToString();
    public virtual string Light {get;set;} = new Palette()
    {
        Text = TwColors.Text_Slate_700,
        Background = TwColors.Bg_Slate_300,
        Border = TwColors.Bg_Slate_400,
        Outline = TwColors.Bg_Slate_400,
        Ring = TwColors.Bg_Slate_400
    }.ToString();
    public virtual string Dark {get;set;} = new Palette()
    {
        Text = TwColors.Text_Slate_300,
        Background = TwColors.Bg_Slate_700,
        Border = TwColors.Bg_Slate_600,
        Outline = TwColors.Bg_Slate_600,
        Ring = TwColors.Bg_Slate_600
    }.ToString();
    public virtual CustomTheme Custom { get; set; } = new();
}

public class CustomTheme
{
    private Dictionary<string, string> themes = new();

    public bool Add(string themeName, string themeClasses)
    {
        return themes.TryAdd(themeName, themeClasses);
    }

    public string Get(string themeName)
    {
        if (themes.TryGetValue(themeName, out var theme))
        {
            return theme.ToString();
        }
        return string.Empty;
    }
}

public static class CustomThemeExtensions
{
    public static CustomTheme Add(this CustomTheme customTheme, string themeName, string themeClasses)
    {
        customTheme.Add(themeName, themeClasses);
        return customTheme;
    }
}
