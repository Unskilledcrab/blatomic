namespace Blatomic.Services.ColorScheme
{
    public class ColorPair
    {
        public ColorPair()
        {

        }

        public ColorPair(string light, string dark)
        {
            Light = light;
            Dark = dark;
        }

        public string Light { get; set; } = string.Empty;
        public string Dark { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Light} {Dark}";
        }
    }
}
