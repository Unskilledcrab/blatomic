
namespace Blatomic.Components.CodeBlock
{
    public interface ILanguage
    {
        HashSet<char> BreakCharacters { get; set; }
        TokenPalette[] KeywordPalette { get; set; }
        TokenPalette[] LookAheadPalette { get; set; }
        TokenPalette[] LookBehindPalette { get; set; }
        TokenPalette SingleLineCommentPalette { get; set; }
        TokenPalette StringLiteralPalette { get; set; }
        TokenPalette SymbolPalette { get; set; }
    }
}