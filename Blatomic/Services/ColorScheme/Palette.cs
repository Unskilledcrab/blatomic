namespace Blatomic.Services.ColorScheme
{
    public class Palette
    {
        public ColorPair Text { get; set; } = new();
        public ColorPair Background { get; set; } = new();
        public ColorPair Border { get; set; } = new();
        public ColorPair Outline { get; set; } = new();
        public ColorPair Ring { get; set; } = new();
        public ColorPair Accent { get; set; } = new();
        public ColorPair Decoration { get; set; } = new("b-decoration-sky-500");
        public Dictionary<string, ColorPair> Custom { get; set; } = new();

        public IEnumerable<ColorPair> GetColorPairs()
        {
            yield return Text;
            yield return Background;
            yield return Border;
            yield return Outline;
            yield return Ring;
            yield return Accent;
            yield return Decoration;
            foreach (var colorPair in Custom)
            {
                yield return colorPair.Value;
            }
        }

        public string All => $"{ToString()}";
        public override string ToString()
        {
            return $"{string.Join(' ',GetColorPairs())}";
        }
    }

    public static class PaletteExtensions
    {
        public static string GetPaletteCode(this Palette? palette, ITheme theme)
        {
            if (palette == null)
            {
                return string.Empty;
            }

            return $"Palette=\"Theme.{theme.GetPaletteName(palette)}\"";
        }
    }
}
