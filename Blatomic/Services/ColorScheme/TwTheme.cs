namespace Blatomic.Services.ColorScheme;

public class TwTheme : ITheme
{
    public string Primary => PrimaryPalette.ToString();
    public string Secondary => SecondaryPalette.ToString();
    public string Success => SuccessPalette.ToString();
    public string Danger => DangerPalette.ToString();
    public string Warning => WarningPalette.ToString();
    public string Info => InfoPalette.ToString();
    public string Light => LightPalette.ToString();
    public string Dark => DarkPalette.ToString();
    public virtual Palette PrimaryPalette { get; set; } = new(TwColors.Text_White, TwColors.Bg_Blue_600);
    public virtual Palette SecondaryPalette { get; set; } = new(TwColors.Text_White, TwColors.Bg_Gray_600);
    public virtual Palette SuccessPalette { get; set; } = new(TwColors.Text_White, TwColors.Bg_Green_600);
    public virtual Palette DangerPalette { get; set; } = new(TwColors.Text_White, TwColors.Bg_Red_600);
    public virtual Palette WarningPalette { get; set; } = new(TwColors.Text_Black, TwColors.Bg_Yellow_600);
    public virtual Palette InfoPalette { get; set; } = new(TwColors.Text_Black, TwColors.Bg_Sky_400);
    public virtual Palette LightPalette { get; set; } = new(TwColors.Text_Black, TwColors.Bg_Slate_300);
    public virtual Palette DarkPalette { get; set; } = new(TwColors.Text_White, TwColors.Bg_Slate_700);
}
