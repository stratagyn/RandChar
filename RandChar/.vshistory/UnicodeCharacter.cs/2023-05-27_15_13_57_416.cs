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

public static partial class CharSet
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

    public static IList<int> GetUIDs(params UnicodeCategory[] categories)
    {
        if (categories.Length == 0)
            return Array.Empty<int>();

        var characters = CharacterSets.Value;
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

    private static IDictionary<CharacterSet, int[]> BuildCharacterSets()
    {
        var characters = new Dictionary<CharacterSet, IList<int>>(27);

        for(var i = 0x0000; i < 0xD800; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory((char)i);

            if (UnicodeCategories.TryGetValue(category, out CharacterSet value))
            {
                var charset = value;
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
