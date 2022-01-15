namespace Blatomic.Components.CodeBlock
{
    public static class ReadOnlySpanExtensions
    {
        public static ReadOnlySpan<T> Peek<T>(this ReadOnlySpan<T> span, int index)
        {
            if (span == null)
            {
                return null;
            }

            if (span.Length < index + 1)
            {
                return null;
            }

            return span.Slice(index, 1);
        }

        public static bool IsStringLiteral(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.StringLiteralPalette, out color);
        }

        public static bool IsSymbol(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.SymbolPalette, out color);
        }

        public static bool IsLookBehindToken(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.LookBehindPalette, out color);
        }


        public static bool IsLookAheadToken(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.LookAheadPalette, out color);
        }

        public static bool IsComment(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.SingleLineCommentPalette, out color);
        }

        public static bool IsKeyword(this ReadOnlySpan<char> word, ILanguage syntax, out string? color)
        {
            return word.IsToken(syntax.KeywordPalette, out color);
        }

        public static bool IsToken(this ReadOnlySpan<char> word, TokenPalette[] tokenPalettes, out string? color)
        {
            color = null;
            foreach (var tokenPalette in tokenPalettes)
            {
                if (word.IsToken(tokenPalette, out color))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsToken(this ReadOnlySpan<char> word, TokenPalette tokenPalette, out string? color)
        {
            color = null;
            foreach (var token in tokenPalette.Tokens)
            {
                if (word.IsEqual(token))
                {
                    color = tokenPalette.Color;
                    return true;
                }
            }
            return false;
        }

        public static bool IsEqual(this ReadOnlySpan<char> span, string word)
        {
            return MemoryExtensions.Equals(span, word, StringComparison.Ordinal);
        }

        public static bool IsEqual(this ReadOnlySpan<char> span, char word)
        {
            return span.IsEqual(word.ToString());
        }

        public static bool IsBreak(this ReadOnlySpan<char> word, ILanguage syntax)
        {
            foreach (var breakCharacter in syntax.BreakCharacters)
            {
                if (word.IsEqual(breakCharacter))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
