using System.Text;

namespace Blatomic.Components.CodeBlock
{
    public class LanguageParser
    {
        public bool ShowLineNumbers { get; set; } = true;
        public string NewLineClass { get; set; } = "inline-block select-none w-8 mr-6 text-right min-w-4";

        private int lineNumber = 1;
        private int wordLength = 1;
        private StringBuilder html = new();
        private (int start, int length) previousTokenIndex = (0, 0);

        public string ParseCode(ReadOnlySpan<char> code, ILanguage syntax)
        {
            lineNumber = 1;
            html.Clear();
            foreach (var line in code.EnumerateLines())
            {
                HandleLineNumber();
                Parse(line, syntax);
                html.AppendLine();
            }
            return html.ToString();
        }

        private string Parse(ReadOnlySpan<char> code, ILanguage syntax)
        {
            int index = 0;
            wordLength = 1;
            previousTokenIndex = (0, 0);
            while (index + wordLength < code.Length + 1)
            {
                var word = code.Slice(index, wordLength);
                var lastToken = code.Slice(previousTokenIndex.start, previousTokenIndex.length);
                var nextCharacter = code.Peek(index + wordLength);

                if (lastToken.IsLookBehindToken(syntax, out var color))
                {
                    var foundEnd = false;

                    while (!foundEnd)
                    {
                        nextCharacter = code.Peek(index + wordLength);
                        if (nextCharacter.IsSymbol(syntax, out _) || nextCharacter.IsBreak(syntax))
                        {
                            break;
                        }
                        else if (index + wordLength == code.Length)
                        {
                            break;
                        }
                        wordLength++;
                    }
                    word = code.Slice(index, wordLength);

                    ColorSyntax(color, word);
                    index = UpdateIndex(index);
                    continue;
                }

                if (word.IsStringLiteral(syntax, out color))
                {
                    var foundEnd = false;

                    while (!foundEnd)
                    {
                        nextCharacter = code.Peek(index + wordLength);
                        if (nextCharacter.IsStringLiteral(syntax, out _))
                        {
                            foundEnd = true;
                        }
                        else if (index + wordLength == code.Length)
                        {
                            break;
                        }
                        wordLength++;
                    }
                    word = code.Slice(index, wordLength);

                    ColorSyntax(color, word);
                    index = UpdateIndex(index);
                    continue;
                }

                if (!(index + wordLength == code.Length) && wordLength == 1)
                {
                    if (code.Slice(index, wordLength + 1).IsComment(syntax, out color))
                    {
                        var comment = code.Slice(index, code.Length - index);

                        ColorSyntax(color, comment);
                        index = UpdateIndex(code.Length);
                        continue;
                    }
                }

                if (word.IsBreak(syntax))
                {
                    AddContent(word);
                    index = UpdateIndex(index);
                    continue;
                }

                if (word.IsSymbol(syntax, out color))
                {
                    ColorSyntax(color, word);
                    index = UpdateIndex(index);
                    continue;
                }

                if (word.IsKeyword(syntax, out color) && (nextCharacter.IsBreak(syntax) || nextCharacter.IsSymbol(syntax, out _)))
                {
                    ColorSyntax(color, word);
                    index = UpdateIndex(index);
                    continue;
                }

                if (nextCharacter.IsSymbol(syntax, out _))
                {
                    if (nextCharacter.IsLookAheadToken(syntax, out color))
                    {
                        ColorSyntax(color, word);
                    }
                    else
                    {
                        AddContent(word);
                    }
                    index = UpdateIndex(index);
                    continue;
                }

                if (nextCharacter.IsBreak(syntax) || index + wordLength == code.Length)
                {
                    AddContent(word);
                    index = UpdateIndex(index);
                    continue;
                }

                wordLength++;
            }

            return string.Empty;
        }

        private int UpdateIndex(int index)
        {
            previousTokenIndex = (index, wordLength);
            index = index + wordLength;
            wordLength = 1;
            return index;
        }

        private void HandleLineNumber()
        {
            if (ShowLineNumbers)
            {
                html.Append($"<span class=\"{NewLineClass}\">{lineNumber}</span>");
                lineNumber++;
            }
        }

        private void AddContent(ReadOnlySpan<char> content)
        {
            html.Append(content);
        }

        private void ColorSyntax(string? color, ReadOnlySpan<char> content)
        {
            if (color is null)
            {
                AddContent(content);
            }
            else
            {
                html.Append($"<span class=\"{color}\">{content}</span>");
            }
        }

    }
}
