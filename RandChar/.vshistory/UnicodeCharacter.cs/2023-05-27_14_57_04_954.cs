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
    UppercaseLetter = 0,
    LowercaseLetter = 1,
    TitlecaseLetter = 2,
    ModifierLetter = 4,
    OtherLetter = 8,
    NonSpacingMark = 16,
    SpacingCombiningMark = 32,
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
    OpenPunctuation = 20,
    ClosePunctuation = 21,
    InitialQuotePunctuation = 22,
    FinalQuotePunctuation = 23,
    OtherPunctuation = 24,
    MathSymbol = 25,
    CurrencySymbol = 26,
    ModifierSymbol = 27,
    OtherSymbol = 28,
    OtherNotAssigned = 29,
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
