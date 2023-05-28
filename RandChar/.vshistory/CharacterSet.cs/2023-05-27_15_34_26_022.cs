using System.Globalization;
using System.Numerics;

namespace RandChar;

[Flags]
public enum CharacterSet
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

public static partial class CharaSet
{
    private static readonly IDictionary<UnicodeCategory, CharacterSet> UnicodeCategories = new Dictionary<UnicodeCategory, CharacterSet>
    {
        [UnicodeCategory.Control] = CharacterSet.Control,
        [UnicodeCategory.Format] = CharacterSet.Format,
        [UnicodeCategory.LowercaseLetter] = CharacterSet.LowercaseLetter,
        [UnicodeCategory.ModifierLetter] = CharacterSet.ModifierLetter,
        [UnicodeCategory.OtherLetter] = CharacterSet.OtherLetter,
        [UnicodeCategory.TitlecaseLetter] = CharacterSet.TitlecaseLetter,
        [UnicodeCategory.UppercaseLetter] = CharacterSet.UppercaseLetter,
        [UnicodeCategory.SpacingCombiningMark] = CharacterSet.SpacingCombiningMark,
        [UnicodeCategory.EnclosingMark] = CharacterSet.EnclosingMark,
        [UnicodeCategory.NonSpacingMark] = CharacterSet.NonSpacingMark,
        [UnicodeCategory.DecimalDigitNumber] = CharacterSet.DecimalDigitNumber,
        [UnicodeCategory.LetterNumber] = CharacterSet.LetterNumber,
        [UnicodeCategory.OtherNumber] = CharacterSet.OtherNumber,
        [UnicodeCategory.ConnectorPunctuation] = CharacterSet.ConnectorPunctuation,
        [UnicodeCategory.DashPunctuation] = CharacterSet.DashPunctuation,
        [UnicodeCategory.ClosePunctuation] = CharacterSet.ClosePunctuation,
        [UnicodeCategory.FinalQuotePunctuation] = CharacterSet.FinalQuotePunctuation,
        [UnicodeCategory.InitialQuotePunctuation] = CharacterSet.InitialQuotePunctuation,
        [UnicodeCategory.OtherPunctuation] = CharacterSet.OtherPunctuation,
        [UnicodeCategory.OpenPunctuation] = CharacterSet.OpenPunctuation,
        [UnicodeCategory.CurrencySymbol] = CharacterSet.CurrencySymbol,
        [UnicodeCategory.ModifierSymbol] = CharacterSet.ModifierSymbol,
        [UnicodeCategory.MathSymbol] = CharacterSet.MathSymbol,
        [UnicodeCategory.OtherSymbol] = CharacterSet.OtherSymbol,
        [UnicodeCategory.LineSeparator] = CharacterSet.LineSeparator,
        [UnicodeCategory.ParagraphSeparator] = CharacterSet.ParagraphSeparator,
        [UnicodeCategory.SpaceSeparator] = CharacterSet.SpaceSeparator
    };

    private static readonly Lazy<IDictionary<CharacterSet, IList<int>>> CharacterSets = new(() => BuildCharacterSets());

    public static IList<int> GetUIDs(CharacterSet characterSet)
    {
        var characters = CharacterSets.Value;
        var combinedUIDs = new List<int>();
        var characterGroup = GetCharacterGroup(characterSet);

        foreach (var charSet in characterGroup)
            combinedUIDs.AddRange(characters[charSet]);

        return combinedUIDs;
    }

    private static IDictionary<CharacterSet, IList<int>> BuildCharacterSets()
    {
        var characterSets = new Dictionary<CharacterSet, IList<int>>(30)
        {
            [CharacterSet.ASCIILowercaseLetter] = new int[]
            {
                0x0061, 0x0062, 0x0063, 0x0064, 0x0065,
                0x0066, 0x0067, 0x0068, 0x0069, 0x006A,
                0x006B, 0x006C, 0x006D, 0x006E, 0x006F,
                0x0070, 0x0071, 0x0072, 0x0073, 0x0074,
                0x0075, 0x0076, 0x0077, 0x0078, 0x0079,
                0x007A
            },

            [CharacterSet.ASCIINumber] = new int[]
            {
                0x0030, 0x0031, 0x0032, 0x0033, 0x0034,
                0x0035, 0x0036, 0x0037, 0x0038, 0x0039
            },

            [CharacterSet.ASCIIPunctuation] = new int[]
            {
                0x0021, 0x0022, 0x0023, 0x0024, 0x0025,
                0x0026, 0x0027, 0x0028, 0x0029, 0x002A,
                0x002B, 0x002C, 0x002D, 0x002E, 0x002F,
                0x003A, 0x003B, 0x003B, 0x003C, 0x003D,
                0x003E, 0x003F, 0x0040, 0x005B, 0x005C,
                0x005D, 0x005E, 0x005F, 0x0060, 0x007B,
                0x007C, 0x007D, 0x007E
            },

            [CharacterSet.ASCIIUppercaseLetter] = new int[]
            {
                0x0041, 0x0042, 0x0043, 0x0044, 0x0045,
                0x0046, 0x0047, 0x0048, 0x0049, 0x004A,
                0x004B, 0x004C, 0x004D, 0x004E, 0x004F,
                0x0050, 0x0051, 0x0052, 0x0053, 0x0054,
                0x0055, 0x0056, 0x0057, 0x0058, 0x0059,
                0x005A
            }
        };

        for (var i = 0x0000; i < 0xD800; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.TryGetValue(category, out var charset))
            {
                if (!characterSets.ContainsKey(charset))
                    characterSets[charset] = new List<int>();

                characterSets[charset].Add(i);
            }
        }

        for (var i = 0xE000; i < 0x10FFFF; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.TryGetValue(category, out var charset))
            {
                if (!characterSets.ContainsKey(charset))
                    characterSets[charset] = new List<int>();

                characterSets[charset].Add(i);
            }
        }

        return characterSets;
    }

    private static IEnumerable<CharacterSet> GetCharacterGroup(CharacterSet characterSet)
    {
        var group = (int)characterSet;
        var offset = 0;

        while (group > 0)
        {
            var ctz = BitOperations.TrailingZeroCount(group);
            offset += ctz;

            yield return (CharacterSet)(1 << offset);

            group >>= (ctz + 1);
            offset++;
        }
    }
}