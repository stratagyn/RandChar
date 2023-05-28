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

namespace RandomCharGenerator;

internal static partial class CharSet
{
    private static readonly ISet<UnicodeCategory> UnicodeCategories = new HashSet<UnicodeCategory>
    {
        UnicodeCategory.Control, 
        UnicodeCategory.Format,
        UnicodeCategory.LowercaseLetter,
        UnicodeCategory.ModifierLetter,
        UnicodeCategory.OtherLetter,
        UnicodeCategory.TitlecaseLetter,
        UnicodeCategory.UppercaseLetter,
        UnicodeCategory.SpacingCombiningMark,
        UnicodeCategory.EnclosingMark,
        UnicodeCategory.NonSpacingMark,
        UnicodeCategory.DecimalDigitNumber,
        UnicodeCategory.LetterNumber,
        UnicodeCategory.OtherNumber,
        UnicodeCategory.ConnectorPunctuation,
        UnicodeCategory.DashPunctuation,
        UnicodeCategory.ClosePunctuation,
        UnicodeCategory.FinalQuotePunctuation,
        UnicodeCategory.InitialQuotePunctuation,
        UnicodeCategory.OtherPunctuation,
        UnicodeCategory.OpenPunctuation,
        UnicodeCategory.CurrencySymbol,
        UnicodeCategory.ModifierSymbol,
        UnicodeCategory.MathSymbol,
        UnicodeCategory.OtherSymbol,
        UnicodeCategory.LineSeparator,
        UnicodeCategory.ParagraphSeparator,
        UnicodeCategory.SpaceSeparator
    };

    private static readonly Lazy<IDictionary<UnicodeCategory, int[]>> UnicodeCharacters = new(() => BuildUnicodeCharacterDictionary());

    public static IList<int> GetUIDs(params UnicodeCategory[] categories)
    {
        if (categories.Length == 0)
            return Array.Empty<int>();

        if (categories.Length == 1)
        {
            if (!UnicodeCategories.Contains(categories[0]))
                return Array.Empty<int>();

            return UnicodeCharacters.Value[categories[0]];
        }

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

       return combinedUIDs.ToArray();
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
