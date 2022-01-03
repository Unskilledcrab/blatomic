namespace Blatomic.Services.ColorScheme
{
    public class Palette
    {
        public ColorPair Text { get; set; } = new();
        public ColorPair Background { get; set; } = new();
        public ColorPair Border { get; set; } = new();
        public ColorPair Outline { get; set; } = new();
        public ColorPair Ring { get; set; } = new();

        public override string ToString()
        {
            return $"{Text} {Background} {Border} {Outline} {Ring}";
        }
    }
}
