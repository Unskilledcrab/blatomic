namespace Blatomic.Services.ColorScheme;

public class TwTheme : ITheme
{
    public virtual string Primary { get; set; } = new Palette(TwColors.Text_White, TwColors.Bg_Blue_600).ToString();
    public virtual string Secondary {get;set;} = new Palette(TwColors.Text_White, TwColors.Bg_Gray_600).ToString();
    public virtual string Success {get;set;} = new Palette(TwColors.Text_White, TwColors.Bg_Green_600).ToString();
    public virtual string Danger {get;set;} = new Palette(TwColors.Text_White, TwColors.Bg_Red_600).ToString();
    public virtual string Warning {get;set;} = new Palette(TwColors.Text_Black, TwColors.Bg_Yellow_600).ToString();
    public virtual string Info {get;set;} = new Palette(TwColors.Text_Black, TwColors.Bg_Sky_400).ToString();
    public virtual string Light {get;set;} = new Palette(TwColors.Text_Black, TwColors.Bg_Slate_300).ToString();
    public virtual string Dark {get;set;} = new Palette(TwColors.Text_White, TwColors.Bg_Slate_700).ToString();
}
