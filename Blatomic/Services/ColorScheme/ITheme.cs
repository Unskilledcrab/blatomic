namespace Blatomic.Services.ColorScheme
{
    public interface ITheme
    {
        string Primary { get; }
        string Light { get; }
        string Secondary { get; }
        string Success { get; }
        string Danger { get; }
        string Warning { get; }
        string Info { get; }
        string Dark { get; }
    }
}