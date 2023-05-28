﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStringGenerator;

public enum ASCIICategory
{
    LowercaseLetter,
    Number,
    Punctuation,
    UppercaseLetter
}

internal static partial class CharSet
{
    private static readonly IDictionary<ASCIICategory, int[]> ASCIICharacters = new Dictionary<ASCIICategory, int[]>
    {
        [ASCIICategory.LowercaseLetter] = new int[]
        {
            0x0061, 0x0062, 0x0063, 0x0064, 0x0065,
            0x0066, 0x0067, 0x0068, 0x0069, 0x006A,
            0x006B, 0x006C, 0x006D, 0x006E, 0x006F,
            0x0070, 0x0071, 0x0072, 0x0073, 0x0074,
            0x0075, 0x0076, 0x0077, 0x0078, 0x0079,
            0x007A
        },

        [ASCIICategory.Number] = new int[]
        {
            0x0030, 0x0031, 0x0032, 0x0033, 0x0034,
            0x0035, 0x0036, 0x0037, 0x0038, 0x0039
        },

        [ASCIICategory.Punctuation] = new int[]
        {
            0x0021, 0x0022, 0x0023, 0x0024, 0x0025,
            0x0026, 0x0027, 0x0028, 0x0029, 0x002A,
            0x002B, 0x002C, 0x002D, 0x002E, 0x002F,
            0x003A, 0x003B, 0x003B, 0x003C, 0x003D,
            0x003E, 0x003F, 0x0040, 0x005B, 0x005C,
            0x005D, 0x005E, 0x005F, 0x0060, 0x007B,
            0x007C, 0x007D, 0x007E
        },

        [ASCIICategory.UppercaseLetter] = new int[]
        {
            0x0041, 0x0042, 0x0043, 0x0044, 0x0045,
            0x0046, 0x0047, 0x0048, 0x0049, 0x004A,
            0x004B, 0x004C, 0x004D, 0x004E, 0x004F,
            0x0050, 0x0051, 0x0052, 0x0053, 0x0054,
            0x0055, 0x0056, 0x0057, 0x0058, 0x0059,
            0x005A
        }
    };

    public static int[] GetUIDs(ASCIICategory category, params ASCIICategory[] categories)
    {
        if (categories.Length == 0)
            return ASCIICharacters[category];

        var combinedUIDs = new List<int>();
        var gatheredCategories = new HashSet<ASCIICategory>();

        combinedUIDs.AddRange(ASCIICharacters[category]);
        gatheredCategories.Add(category);

        foreach (var extraCategory in categories)
        {
            if (!gatheredCategories.Contains(extraCategory))
            {
                combinedUIDs.AddRange(ASCIICharacters[extraCategory]);
                gatheredCategories.Add(extraCategory);
            }
        }

        return combinedUIDs.ToArray();
    }
}
