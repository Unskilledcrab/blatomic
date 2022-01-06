using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Components.CodeBlock
{
    public enum Language
    {
        HTML,
        Razor,
        CSharp
    }

    public static class LanguageExtensions
    {
        public static ILanguage GetLanguage(this Language language)
        {
            switch (language)
            {
                case Language.HTML:
                    break;
                case Language.Razor:
                    break;
                case Language.CSharp:
                    return new CSharpLanguage();
                    break;
                default:
                    break;
            }
            return new CSharpLanguage();
        }
    }

}
