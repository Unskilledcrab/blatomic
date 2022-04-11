using Blazored.LocalStorage;

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

        public ColorPair(string light)
        {
            Light = light;
        }

        public string Light { get; set; } = string.Empty;
        public string Dark { get; set; } = string.Empty;

        public string All => ToString();

        public override string ToString()
        {
            return $"{string.Join(' ', Light, Dark)}";
        }

        public void Copy(ColorPair colorPair)
        {
            Light = colorPair.Light;
            Dark = colorPair.Dark;
        }
    }
}
