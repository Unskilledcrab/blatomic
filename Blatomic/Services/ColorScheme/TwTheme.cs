namespace Blatomic.Services.ColorScheme;

public class TwTheme : ITheme
{
    public virtual Palette Primary { get; set; } = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Blue_600,
        Border = TwColors.Bg_Blue_500,
        Outline = TwColors.Bg_Blue_500,
        Ring = TwColors.Bg_Blue_500        
    };
    public virtual Palette Secondary {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Gray_600,
        Border = TwColors.Bg_Gray_500,
        Outline = TwColors.Bg_Gray_500,
        Ring = TwColors.Bg_Gray_500
    };
    public virtual Palette Success {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Green_600,
        Border = TwColors.Bg_Green_500,
        Outline = TwColors.Bg_Green_500,
        Ring = TwColors.Bg_Green_500
    };
    public virtual Palette Danger {get;set;} = new Palette()
    {
        Text = TwColors.Text_White,
        Background = TwColors.Bg_Red_600,
        Border = TwColors.Bg_Red_500,
        Outline = TwColors.Bg_Red_500,
        Ring = TwColors.Bg_Red_500
    };
    public virtual Palette Warning {get;set;} = new Palette()
    {
        Text = TwColors.Text_Black,
        Background = TwColors.Bg_Yellow_600,
        Border = TwColors.Bg_Yellow_500,
        Outline = TwColors.Bg_Yellow_500,
        Ring = TwColors.Bg_Yellow_500
    };
    public virtual Palette Info {get;set;} = new Palette()
    {
        Text = TwColors.Text_Black,
        Background = TwColors.Bg_Sky_400,
        Border = TwColors.Bg_Sky_500,
        Outline = TwColors.Bg_Sky_500,
        Ring = TwColors.Bg_Sky_500
    };
    public virtual Palette Light {get;set;} = new Palette()
    {
        Text = TwColors.Text_Slate_800,
        Background = TwColors.Bg_Slate_200,
        Border = TwColors.Bg_Slate_400,
        Outline = TwColors.Bg_Slate_400,
        Ring = TwColors.Bg_Slate_400
    };
    public virtual Palette Dark {get;set;} = new Palette()
    {
        Text = TwColors.Text_Slate_200,
        Background = TwColors.Bg_Slate_800,
        Border = TwColors.Bg_Slate_600,
        Outline = TwColors.Bg_Slate_600,
        Ring = TwColors.Bg_Slate_600
    };
    public virtual Palette Accent {get;set;} = new Palette()
    {
        Text = TwColors.Text_Slate_200,
        Background = TwColors.Bg_Slate_800,
        Border = TwColors.Bg_Slate_600,
        Outline = TwColors.Bg_Slate_600,
        Ring = TwColors.Bg_Slate_600
    };
    public virtual CustomTheme Custom { get; set; } = new();
}

public class CustomTheme
{
    private Dictionary<string, Palette> themes = new();

    public bool Add(string themeName, Palette themePalette)
    {
        return themes.TryAdd(themeName, themePalette);
    }

    public Palette? Get(string themeName)
    {
        if (themes.TryGetValue(themeName, out var theme))
        {
            return theme;
        }
        return null;
    }
}

public static class CustomThemeExtensions
{
    public static CustomTheme Add(this CustomTheme customTheme, string themeName, Palette themePalette)
    {
        customTheme.Add(themeName, themePalette);
        return customTheme;
    }
}
