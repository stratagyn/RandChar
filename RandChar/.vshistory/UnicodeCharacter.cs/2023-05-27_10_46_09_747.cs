using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RandChar;

[Flags]
public enum UnicodeSet
{
    UppercaseLetter = 0,
    //
    // Summary:
    //     Lowercase letter. Signified by the Unicode designation "Ll" (letter, lowercase).
    //     The value is 1.
    LowercaseLetter = 1,
    //
    // Summary:
    //     Titlecase letter. Signified by the Unicode designation "Lt" (letter, titlecase).
    //     The value is 2.
    TitlecaseLetter = 2,
    //
    // Summary:
    //     Modifier letter character, which is free-standing spacing character that indicates
    //     modifications of a preceding letter. Signified by the Unicode designation "Lm"
    //     (letter, modifier). The value is 3.
    ModifierLetter = 3,
    //
    // Summary:
    //     Letter that is not an uppercase letter, a lowercase letter, a titlecase letter,
    //     or a modifier letter. Signified by the Unicode designation "Lo" (letter, other).
    //     The value is 4.
    OtherLetter = 4,
    //
    // Summary:
    //     Nonspacing character that indicates modifications of a base character. Signified
    //     by the Unicode designation "Mn" (mark, nonspacing). The value is 5.
    NonSpacingMark = 5,
    //
    // Summary:
    //     Spacing character that indicates modifications of a base character and affects
    //     the width of the glyph for that base character. Signified by the Unicode designation
    //     "Mc" (mark, spacing combining). The value is 6.
    SpacingCombiningMark = 6,
    //
    // Summary:
    //     Enclosing mark character, which is a nonspacing combining character that surrounds
    //     all previous characters up to and including a base character. Signified by the
    //     Unicode designation "Me" (mark, enclosing). The value is 7.
    EnclosingMark = 7,
    //
    // Summary:
    //     Decimal digit character, that is, a character in the range 0 through 9. Signified
    //     by the Unicode designation "Nd" (number, decimal digit). The value is 8.
    DecimalDigitNumber = 8,
    //
    // Summary:
    //     Number represented by a letter, instead of a decimal digit, for example, the
    //     Roman numeral for five, which is "V". The indicator is signified by the Unicode
    //     designation "Nl" (number, letter). The value is 9.
    LetterNumber = 9,
    //
    // Summary:
    //     Number that is neither a decimal digit nor a letter number, for example, the
    //     fraction 1/2. The indicator is signified by the Unicode designation "No" (number,
    //     other). The value is 10.
    OtherNumber = 10,
    //
    // Summary:
    //     Space character, which has no glyph but is not a control or format character.
    //     Signified by the Unicode designation "Zs" (separator, space). The value is 11.
    SpaceSeparator = 11,
    //
    // Summary:
    //     Character that is used to separate lines of text. Signified by the Unicode designation
    //     "Zl" (separator, line). The value is 12.
    LineSeparator = 12,
    //
    // Summary:
    //     Character used to separate paragraphs. Signified by the Unicode designation "Zp"
    //     (separator, paragraph). The value is 13.
    ParagraphSeparator = 13,
    //
    // Summary:
    //     Control code character, with a Unicode value of U+007F or in the range U+0000
    //     through U+001F or U+0080 through U+009F. Signified by the Unicode designation
    //     "Cc" (other, control). The value is 14.
    Control = 14,
    //
    // Summary:
    //     Format character that affects the layout of text or the operation of text processes,
    //     but is not normally rendered. Signified by the Unicode designation "Cf" (other,
    //     format). The value is 15.
    Format = 15,
    //
    // Summary:
    //     High surrogate or a low surrogate character. Surrogate code values are in the
    //     range U+D800 through U+DFFF. Signified by the Unicode designation "Cs" (other,
    //     surrogate). The value is 16.
    Surrogate = 16,
    //
    // Summary:
    //     Private-use character, with a Unicode value in the range U+E000 through U+F8FF.
    //     Signified by the Unicode designation "Co" (other, private use). The value is
    //     17.
    PrivateUse = 17,
    //
    // Summary:
    //     Connector punctuation character that connects two characters. Signified by the
    //     Unicode designation "Pc" (punctuation, connector). The value is 18.
    ConnectorPunctuation = 18,
    //
    // Summary:
    //     Dash or hyphen character. Signified by the Unicode designation "Pd" (punctuation,
    //     dash). The value is 19.
    DashPunctuation = 19,
    //
    // Summary:
    //     Opening character of one of the paired punctuation marks, such as parentheses,
    //     square brackets, and braces. Signified by the Unicode designation "Ps" (punctuation,
    //     open). The value is 20.
    OpenPunctuation = 20,
    //
    // Summary:
    //     Closing character of one of the paired punctuation marks, such as parentheses,
    //     square brackets, and braces. Signified by the Unicode designation "Pe" (punctuation,
    //     close). The value is 21.
    ClosePunctuation = 21,
    //
    // Summary:
    //     Opening or initial quotation mark character. Signified by the Unicode designation
    //     "Pi" (punctuation, initial quote). The value is 22.
    InitialQuotePunctuation = 22,
    //
    // Summary:
    //     Closing or final quotation mark character. Signified by the Unicode designation
    //     "Pf" (punctuation, final quote). The value is 23.
    FinalQuotePunctuation = 23,
    //
    // Summary:
    //     Punctuation character that is not a connector, a dash, open punctuation, close
    //     punctuation, an initial quote, or a final quote. Signified by the Unicode designation
    //     "Po" (punctuation, other). The value is 24.
    OtherPunctuation = 24,
    //
    // Summary:
    //     Mathematical symbol character, such as "+" or "= ". Signified by the Unicode
    //     designation "Sm" (symbol, math). The value is 25.
    MathSymbol = 25,
    //
    // Summary:
    //     Currency symbol character. Signified by the Unicode designation "Sc" (symbol,
    //     currency). The value is 26.
    CurrencySymbol = 26,
    //
    // Summary:
    //     Modifier symbol character, which indicates modifications of surrounding characters.
    //     For example, the fraction slash indicates that the number to the left is the
    //     numerator and the number to the right is the denominator. The indicator is signified
    //     by the Unicode designation "Sk" (symbol, modifier). The value is 27.
    ModifierSymbol = 27,
    //
    // Summary:
    //     Symbol character that is not a mathematical symbol, a currency symbol or a modifier
    //     symbol. Signified by the Unicode designation "So" (symbol, other). The value
    //     is 28.
    OtherSymbol = 28,
    //
    // Summary:
    //     Character that is not assigned to any Unicode category. Signified by the Unicode
    //     designation "Cn" (other, not assigned). The value is 29.
    OtherNotAssigned = 29
}
public static partial class CharSet
{
    private static readonly ISet<UnicodeCategory> UnicodeCategories = new HashSet<UnicodeCategory>
    {
        Control, 
        Format,
        LowercaseLetter,
        ModifierLetter,
        OtherLetter,
        TitlecaseLetter,
        UppercaseLetter,
        SpacingCombiningMark,
        EnclosingMark,
        NonSpacingMark,
        DecimalDigitNumber,
        LetterNumber,
        OtherNumber,
        ConnectorPunctuation,
        DashPunctuation,
        ClosePunctuation,
        FinalQuotePunctuation,
        InitialQuotePunctuation,
        OtherPunctuation,
        OpenPunctuation,
        CurrencySymbol,
        ModifierSymbol,
        MathSymbol,
        OtherSymbol,
        LineSeparator,
        ParagraphSeparator,
        UnicodeCategory.SpaceSeparator
    };

    private static readonly Lazy<IDictionary<UnicodeCategory, IList<int>>> UnicodeCharacters = new(() => BuildUnicodeCharacterDictionary());

    public static IList<int> GetUIDs(params UnicodeCategory[] categories)
    {
        if (categories.Length == 0)
            return Array.Empty<int>();

        var characters = UnicodeCharacters.Value;
        var combinedUIDs = new List<int>();
        var gatheredCategories = new HashSet<UnicodeCategory>();

        for (var i = 0; i < categories.Length; i++)
        {
            if (characters.TryGetValue(categories[i], out var UIDs))
            {
                combinedUIDs.AddRange(UIDs);
                gatheredCategories.Add(categories[i]);
            }
        }

        return combinedUIDs;
    }

    private static IDictionary<UnicodeCategory, int[]> BuildUnicodeCharacterDictionary()
    {
        var characters = new Dictionary<UnicodeCategory, IList<int>>(27);

        for(var i = 0x0000; i < 0xD800; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.Contains(category))
            {
                if (!characters.ContainsKey(category))
                    characters[category] = new List<int>();

                characters[category].Add(i);
            }
        }

        for (var i = 0xE000; i < 0x10FFFF; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.Contains(category))
            {
                if (!characters.ContainsKey(category))
                    characters[category] = new List<int>();

                characters[category].Add(i);
            }
        }

        return characters.ToDictionary(pair => pair.Key, pair => pair.Value.ToArray());
    }
}
