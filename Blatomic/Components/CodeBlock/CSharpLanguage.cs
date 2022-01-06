using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blatomic.Components.CodeBlock
{

    public class CSharpLanguage : ILanguage
    {
        /// <summary>
        /// When the parser sees these as the next token, it will stop looking ahead to combine the previous tokens and will begin scanning again from the break point
        /// </summary>
        public HashSet<char> BreakCharacters { get; set; } = new()
        {
            '\\',
            '/',
            '"',
            ' '
        };

        /// <summary>
        /// When the parser finds these tokens, it will stop scanning the line at that index and colorize everything until the end of the line with this color
        /// </summary>
        public TokenPalette SingleLineCommentPalette { get; set; } = new()
        {
            Color = "text-green-300",
            Tokens = new HashSet<string>()
            {
                "//"
            }
        };

        /// <summary>
        /// The parse will use this token to continue scanning the line until it either reaches the end of the line, or finds another string literal token
        /// </summary>
        public TokenPalette StringLiteralPalette { get; set; } = new()
        {
            Color = "text-orange-400",
            Tokens = new HashSet<string>()
            {
               @"""",
               @"'",
            }
        };

        /// <summary>
        /// Any time these tokens are found followed by a break or symbol token, they will be colorized
        /// </summary>
        public TokenPalette[] KeywordPalette { get; set; } = new TokenPalette[] {
            new()
            {
                Color = "text-blue-500",
                Tokens = new()
                {
                    "using",
                    "namespace",

                    "class",
                    "enum",
                    "new",

                    "internal",
                    "abstract",
                    "event",
                    "as",
                    "explicit",
                    "base",
                    "extern",
                    "null",
                    "struct",
                    "object",
                    "byte",
                    "fixed",
                    "out",
                    "throw",
                    "float",
                    "override",
                    "static",
                    "public",
                    "private",
                    "protected",
                    "override",

                    "try",
                    "catch",
                    "finally",

                    "void",
                    "this",
                    "string",
                    "int",
                    "bool",
                    "true",
                    "false",
                }
            },
            new()
            {
                Color = "text-purple-400",
                Tokens = new()
                {
                    "@code",
                    "@inject",
                    "@inherit",
                    "@using",
                    "@page",

                    "for",
                    "foreach",
                    "in",
                    "switch",
                    "case",
                    "if",
                    "else",
                    "return",
                }
            },
            new()
            {
                Color = "text-emerald-600",
                Tokens = new()
                {
                    "List",
                }
            },
        };

        /// <summary>
        /// Anytime these symbols are found as the next character, the parser will combine the current scanned token and then colorize the symbol
        /// </summary>
        public TokenPalette SymbolPalette { get; set; } = new()
        {
            Color = "text-white",
            Tokens = new()
            {
                "(",
                ")",
                "{",
                "}",
                "<",
                ">",
                ";",
                "=",
                ":",
                ".",
            }
        };

        /// <summary>
        /// If the parser looks ahead and finds this symbol, it will colorize the current token
        /// </summary>
        public TokenPalette[] LookAheadPalette { get; set; } = new[]
        {
            new TokenPalette()
            {
                Color = "text-sky-300",
                Tokens = new()
                {
                    "=",
                    ".",
                }
            },
            new TokenPalette()
            {
                Color = "text-yellow-400",
                Tokens = new()
                {
                    "(",
                }
            },
        };

        /// <summary>
        /// If the parser looks behind and finds this symbol, it will colorize everything to the next symbol token or break token
        /// </summary>
        public TokenPalette[] LookBehindPalette { get; set; } = new[]
        {
            new TokenPalette()
            {
                Color = "text-green-500",
                Tokens = new()
                {
                    "<",
                }
            },
        };
    }
}
