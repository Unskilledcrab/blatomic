namespace Blatomic.Services.ColorScheme
{
    public class Palette
    {
        public ColorPair Text { get; set; } = new();
        public ColorPair Background { get; set; } = new();
        public ColorPair Border { get; set; } = new();
        public ColorPair Outline { get; set; } = new();
        public ColorPair Ring { get; set; } = new();
        public Dictionary<string, ColorPair> Custom { get; set; } = new();

        public string All => $"{ToString()} {string.Join(" ", Custom.Values.ToList())}";
        public override string ToString()
        {
            return $"{Text} {Background} {Border} {Outline} {Ring}";
        }
    }
}
