using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSX.Strings.RandomTextGenerator;
internal static class CharacterProvider
{
    static CharacterProvider()
    {
        NonVowelCharacters = new List<char>(25)
        {
            'b','c','d','f','g','h','j','k','l','m','n','p','q',
            'r','s','t','v','w','x','y','z'
        };
        VowelCharacters = new List<char>(6)
        {
            'a','e','i','o','u'
        };
        ExtraCharacters = new List<char>(10)
        {
            '!','.',',','?',';',':'
        };
    }
    internal static IReadOnlyList<char> NonVowelCharacters { get; }
    internal static IReadOnlyList<char> VowelCharacters { get; }
    internal static IReadOnlyList<char> ExtraCharacters { get; }
}

