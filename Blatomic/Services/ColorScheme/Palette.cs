namespace Blatomic.Services.ColorScheme
{
    public class Palette
    {
        public Palette(ColorPair text, ColorPair background)
        {
            Text = text;
            Background = background;
        }
        public ColorPair Text { get; set; }
        public ColorPair Background { get; set; }

        public override string ToString()
        {
            return $"{Text} {Background}";
        }
    }
}
