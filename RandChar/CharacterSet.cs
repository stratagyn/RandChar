using System.Globalization;
using System.Numerics;

namespace RandChar;

[Flags]
public enum CharSet
{
    UppercaseLetter = 1,
    LowercaseLetter = 2,
    TitlecaseLetter = 4,
    ModifierLetter = 8,
    OtherLetter = 16,
    NonSpacingMark = 32,
    SpacingCombiningMark = 64,
    EnclosingMark = 128,
    DecimalDigitNumber = 256,
    LetterNumber = 512,
    OtherNumber = 1024,
    SpaceSeparator = 2048,
    LineSeparator = 4096,
    ParagraphSeparator = 8192,
    Control = 16384,
    Format = 32768,
    ConnectorPunctuation = 65536,
    DashPunctuation = 131072,
    OpenPunctuation = 262144,
    ClosePunctuation = 524288,
    InitialQuotePunctuation = 1048576,
    FinalQuotePunctuation = 2097152,
    OtherPunctuation = 4194304,
    MathSymbol = 8388608,
    CurrencySymbol = 16777216,
    ModifierSymbol = 33554432,
    OtherSymbol = 67108864,
    ASCIILowercaseLetter = 134217728,
    ASCIIUppercaseLetter = 268435456,
    ASCIIPunctuation = 536870912,
    ASCIINumber = 1073741824
}

public static partial class Characters
{
    private static readonly IDictionary<UnicodeCategory, CharSet> UnicodeCategories = new Dictionary<UnicodeCategory, CharSet>
    {
        [UnicodeCategory.Control] = CharSet.Control,
        [UnicodeCategory.Format] = CharSet.Format,
        [UnicodeCategory.LowercaseLetter] = CharSet.LowercaseLetter,
        [UnicodeCategory.ModifierLetter] = CharSet.ModifierLetter,
        [UnicodeCategory.OtherLetter] = CharSet.OtherLetter,
        [UnicodeCategory.TitlecaseLetter] = CharSet.TitlecaseLetter,
        [UnicodeCategory.UppercaseLetter] = CharSet.UppercaseLetter,
        [UnicodeCategory.SpacingCombiningMark] = CharSet.SpacingCombiningMark,
        [UnicodeCategory.EnclosingMark] = CharSet.EnclosingMark,
        [UnicodeCategory.NonSpacingMark] = CharSet.NonSpacingMark,
        [UnicodeCategory.DecimalDigitNumber] = CharSet.DecimalDigitNumber,
        [UnicodeCategory.LetterNumber] = CharSet.LetterNumber,
        [UnicodeCategory.OtherNumber] = CharSet.OtherNumber,
        [UnicodeCategory.ConnectorPunctuation] = CharSet.ConnectorPunctuation,
        [UnicodeCategory.DashPunctuation] = CharSet.DashPunctuation,
        [UnicodeCategory.ClosePunctuation] = CharSet.ClosePunctuation,
        [UnicodeCategory.FinalQuotePunctuation] = CharSet.FinalQuotePunctuation,
        [UnicodeCategory.InitialQuotePunctuation] = CharSet.InitialQuotePunctuation,
        [UnicodeCategory.OtherPunctuation] = CharSet.OtherPunctuation,
        [UnicodeCategory.OpenPunctuation] = CharSet.OpenPunctuation,
        [UnicodeCategory.CurrencySymbol] = CharSet.CurrencySymbol,
        [UnicodeCategory.ModifierSymbol] = CharSet.ModifierSymbol,
        [UnicodeCategory.MathSymbol] = CharSet.MathSymbol,
        [UnicodeCategory.OtherSymbol] = CharSet.OtherSymbol,
        [UnicodeCategory.LineSeparator] = CharSet.LineSeparator,
        [UnicodeCategory.ParagraphSeparator] = CharSet.ParagraphSeparator,
        [UnicodeCategory.SpaceSeparator] = CharSet.SpaceSeparator
    };

    private static readonly Lazy<IDictionary<CharSet, IList<char>>> CharacterSets = new(() => BuildCharacterSets());

    public static IList<char> GetCharacterSet(CharSet characterSet)
    {
        var characters = CharacterSets.Value;
        var combinedUIDs = new List<char>();
        var characterGroup = GetCharacterGroup(characterSet);

        foreach (var charSet in characterGroup)
            combinedUIDs.AddRange(characters[charSet]);

        return combinedUIDs;
    }

    private static IDictionary<CharSet, IList<char>> BuildCharacterSets()
    {
        var characterSets = new Dictionary<CharSet, IList<char>>(30)
        {
            [CharSet.ASCIILowercaseLetter] = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 
                'f', 'g', 'h', 'i', 'j', 
                'k', 'l', 'm', 'n', 'o', 
                'p', 'q', 'r', 's', 't', 
                'u', 'v', 'w', 'x', 'y', 'z',
            },

            [CharSet.ASCIINumber] = new char[]
            {
                '0', '1', '2', '3', '4', 
                '5', '6', '7', '8', '9'
            },

            [CharSet.ASCIIPunctuation] = new char[]
            {
                '!', '"', '#', '$', '%', 
                '&', '\'', '(', ')', '*', 
                '+', ',', '-', '.', '/', 
                ':', ';', '<', '=', '>', 
                '?', '@', '[', '\\', ']', 
                '^', '_', '`', '{', '|',
                '}', '~'
            },

            [CharSet.ASCIIUppercaseLetter] = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 
                'F', 'G', 'H', 'I', 'J', 
                'K', 'L', 'M', 'N', 'O', 
                'P', 'Q', 'R', 'S', 'T', 
                'U', 'V', 'W', 'X', 'Y', 'Z'
            }
        };

        for (var i = 0x0000; i < 0xD800; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.TryGetValue(category, out var charset))
            {
                if (!characterSets.ContainsKey(charset))
                    characterSets[charset] = new List<char>();

                characterSets[charset].Add((char)i);
            }
        }

        for (var i = 0xE000; i < 0x10FFFF; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.TryGetValue(category, out var charset))
                characterSets[charset].Add((char)i);
        }

        return characterSets;
    }

    private static IEnumerable<CharSet> GetCharacterGroup(CharSet characterSet)
    {
        var group = (int)characterSet;
        var offset = 0;

        while (group > 0)
        {
            var ctz = BitOperations.TrailingZeroCount(group);
            offset += ctz;

            yield return (CharSet)(1 << offset);

            group >>= (ctz + 1);
            offset++;
        }
    }
}