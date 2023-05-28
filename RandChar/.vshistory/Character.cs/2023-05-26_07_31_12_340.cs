﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomStringGenerator;

public static class ASCIICharacter
{
    public static readonly int[] Letter =
    {

    };

    public static readonly int[] Number =
    {
        0x0030, 0x0031, 0x0032, 0x0033, 0x0034,
        0x0035, 0x0036, 0x0037, 0x0038, 0x0039
    };

    public static readonly int[] Punctuation =
    {
        0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 
        0x0026, 0x0027, 0x0028, 0x0029, 0x002A,
        0x002B, 0x002C, 0x002D, 0x002E, 0x002F,
        0x003A, 0x003B, 0x003B, 0x003C, 0x003D,
        0x003E, 0x003F
    };
}
