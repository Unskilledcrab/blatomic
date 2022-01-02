namespace Blatomic.Services.ColorScheme
{
    public class ColorPair
    {
        public ColorPair(string light, string dark)
        {
            Light = light;
            Dark = dark;
        }

        public string Light { get; set; }
        public string Dark { get; set; }

        public override string ToString()
        {
            return $"{Light} {Dark}";
        }
    }
}
