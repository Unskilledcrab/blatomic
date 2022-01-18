namespace Blatomic.Services.ColorScheme;

public class TwTheme : ITheme
{
    public string SaveKey { get; set; } = "BlatomicTwTheme";

    public virtual Palette Primary { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-white", "dark:b-text-black"),
        Background = new ColorPair("b-bg-blue-600", "dark:b-bg-blue-400"),
        Border = new ColorPair("b-border-blue-500", "dark:b-border-blue-500"),
        Outline = new ColorPair("b-outline-blue-500", "dark:b-outline-blue-500"),
        Ring = new ColorPair("b-ring-blue-400", "dark:b-ring-blue-600"),
    };
    public virtual Palette Secondary { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-white", "dark:b-text-black"),
        Background = new ColorPair("b-bg-gray-600", "dark:b-bg-gray-400"),
        Border = new ColorPair("b-border-gray-500", "dark:b-border-gray-500"),
        Outline = new ColorPair("b-outline-gray-500", "dark:b-outline-gray-500"),
        Ring = new ColorPair("b-ring-gray-400", "dark:b-ring-gray-600"),
    };
    public virtual Palette Success { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-white", "dark:b-text-black"),
        Background = new ColorPair("b-bg-green-600", "dark:b-bg-green-400"),
        Border = new ColorPair("b-border-green-500", "dark:b-border-green-500"),
        Outline = new ColorPair("b-outline-green-500", "dark:b-outline-green-500"),
        Ring = new ColorPair("b-ring-green-400", "dark:b-ring-green-600"),
    };
    public virtual Palette Danger { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-white", "dark:b-text-black"),
        Background = new ColorPair("b-bg-red-600", "dark:b-bg-red-400"),
        Border = new ColorPair("b-border-red-500", "dark:b-border-red-500"),
        Outline = new ColorPair("b-outline-red-500", "dark:b-outline-red-500"),
        Ring = new ColorPair("b-ring-red-400", "dark:b-ring-red-600"),
    };
    public virtual Palette Warning { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-black", "dark:b-text-white"),
        Background = new ColorPair("b-bg-yellow-600", "dark:b-bg-yellow-400"),
        Border = new ColorPair("b-border-yellow-500", "dark:b-border-yellow-500"),
        Outline = new ColorPair("b-outline-yellow-500", "dark:b-outline-yellow-500"),
        Ring = new ColorPair("b-ring-yellow-400", "dark:b-ring-yellow-600"),
    };
    public virtual Palette Info { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-black", "dark:b-text-white"),
        Background = new ColorPair("b-bg-sky-600", "dark:b-bg-sky-400"),
        Border = new ColorPair("b-border-sky-500", "dark:b-border-sky-500"),
        Outline = new ColorPair("b-outline-sky-500", "dark:b-outline-sky-500"),
        Ring = new ColorPair("b-ring-sky-400", "dark:b-ring-sky-600"),
    };
    public virtual Palette Light { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-black", "dark:b-text-white"),
        Background = new ColorPair("b-bg-gray-100", "dark:b-bg-gray-900"),
        Border = new ColorPair("b-border-gray-300", "dark:b-border-gray-700"),
        Outline = new ColorPair("b-outline-gray-300", "dark:b-outline-gray-700"),
        Ring = new ColorPair("b-ring-gray-400", "dark:b-ring-gray-600"),
    };
    public virtual Palette Dark { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-white", "dark:b-text-black"),
        Background = new ColorPair("b-bg-gray-900", "dark:b-bg-gray-100"),
        Border = new ColorPair("b-border-gray-700", "dark:b-border-gray-300"),
        Outline = new ColorPair("b-outline-gray-700", "dark:b-outline-gray-300"),
        Ring = new ColorPair("b-ring-gray-600", "dark:b-ring-gray-400"),
    };

    public virtual Palette PrimaryOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-blue-600 hover:b-text-white", "dark:b-text-blue-400 dark:hover:b-text-black"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-blue-600", "dark:hover:b-bg-blue-400"),
        Border = new ColorPair("b-border-2 b-border-blue-500", "dark:b-border-blue-500"),
        Outline = new ColorPair("b-outline-blue-500", "dark:b-outline-blue-500"),
        Ring = new ColorPair("b-ring-blue-400", "dark:b-ring-blue-600"),
    };
    public virtual Palette SecondaryOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-gray-600 hover:b-text-white", "dark:b-text-gray-400 dark:hover:b-text-black"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-gray-600", "dark:hover:b-bg-gray-400"),
        Border = new ColorPair("b-border-2 b-border-gray-500", "dark:b-border-gray-500"),
        Outline = new ColorPair("b-outline-gray-500", "dark:b-outline-gray-500"),
        Ring = new ColorPair("b-ring-gray-400", "dark:b-ring-gray-600"),
    };
    public virtual Palette SuccessOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-green-600 hover:b-text-white", "dark:b-text-green-400 dark:hover:b-text-black"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-green-600", "dark:hover:b-bg-green-400"),
        Border = new ColorPair("b-border-2 b-border-green-500", "dark:b-border-green-500"),
        Outline = new ColorPair("b-outline-green-500", "dark:b-outline-green-500"),
        Ring = new ColorPair("b-ring-green-400", "dark:b-ring-green-600"),
    };
    public virtual Palette DangerOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-red-600 hover:b-text-white", "dark:b-text-red-400 dark:hover:b-text-black"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-red-600", "dark:hover:b-bg-red-400"),
        Border = new ColorPair("b-border-2 b-border-red-500", "dark:b-border-red-500"),
        Outline = new ColorPair("b-outline-red-500", "dark:b-outline-red-500"),
        Ring = new ColorPair("b-ring-red-400", "dark:b-ring-red-600"),
    };
    public virtual Palette WarningOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-yellow-600 hover:b-text-black", "dark:b-text-yellow-400 dark:hover:b-text-white"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-yellow-600", "dark:hover:b-bg-yellow-400"),
        Border = new ColorPair("b-border-2 b-border-yellow-500", "dark:b-border-yellow-500"),
        Outline = new ColorPair("b-outline-yellow-500", "dark:b-outline-yellow-500"),
        Ring = new ColorPair("b-ring-yellow-400", "dark:b-ring-yellow-600"),
    };
    public virtual Palette InfoOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-sky-600 hover:b-text-black", "dark:b-text-sky-400 dark:hover:b-text-white"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-sky-600", "dark:hover:b-bg-sky-400"),
        Border = new ColorPair("b-border-2 b-border-sky-500", "dark:b-border-sky-500"),
        Outline = new ColorPair("b-outline-sky-500", "dark:b-outline-sky-500"),
        Ring = new ColorPair("b-ring-sky-400", "dark:b-ring-sky-600"),
    };
    public virtual Palette LightOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-gray-300 hover:b-text-black", "dark:b-text-gray-700 dark:hover:b-text-white"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-gray-300", "dark:hover:b-bg-gray-700"),
        Border = new ColorPair("b-border-2 b-border-gray-300", "dark:b-border-gray-700"),
        Outline = new ColorPair("b-outline-gray-300", "dark:b-outline-gray-700"),
        Ring = new ColorPair("b-ring-gray-400", "dark:b-ring-gray-600"),
    };
    public virtual Palette DarkOutline { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-gray-900 hover:b-text-white", "dark:b-text-gray-100 dark:hover:b-text-black"),
        Background = new ColorPair("b-bg-inherit hover:b-bg-gray-900", "dark:hover:b-bg-gray-100"),
        Border = new ColorPair("b-border-2 b-border-gray-700", "dark:b-border-gray-300"),
        Outline = new ColorPair("b-outline-gray-700", "dark:b-outline-gray-300"),
        Ring = new ColorPair("b-ring-gray-600", "dark:b-ring-gray-400"),
    };
    public virtual Palette Form { get; set; } = new Palette()
    {
        Text = new ColorPair("b-text-gray-700", "dark:b-text-gray-300"),
        Background = new ColorPair("b-bg-white", "dark:b-bg-black"),
        Border = new ColorPair("b-border b-border-gray-300", "dark:b-border-gray-700"),
        Outline = new ColorPair("b-outline-gray-300", "dark:b-outline-gray-700"),
        Ring = new ColorPair("b-ring-gray-400", "dark:b-ring-gray-600"),
    };
    public virtual CustomTheme Custom { get; set; } = new();

    public void Update(ITheme theme)
    {
        Primary = theme.Primary;
        PrimaryOutline = theme.PrimaryOutline;
        Secondary = theme.Secondary;
        SecondaryOutline = theme.SecondaryOutline;
        Success = theme.Success;
        SuccessOutline = theme.SuccessOutline;
        Danger = theme.Danger;
        DangerOutline = theme.DangerOutline;
        Warning = theme.Warning;
        WarningOutline = theme.WarningOutline;
        Info = theme.Info;
        InfoOutline = theme.InfoOutline;
        Light = theme.Light;
        LightOutline = theme.LightOutline;
        Dark = theme.Dark;
        DarkOutline = theme.DarkOutline;
        Form = theme.Form;
        Custom = theme.Custom;
    }
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
