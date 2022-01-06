namespace Blatomic.Components.CodeBlock
{
    public class TokenPalette
    {
        public string Color { get; set; } = string.Empty;
        public HashSet<string> Tokens { get; set; } = new();
    }
}
