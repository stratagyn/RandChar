﻿using System.Security.Cryptography;

namespace RandomStringGenerator;

public class RandomCharacterGenerator
{
    private const int AdjustedCharacterMax = 0x10F800;
    private const int SurrogateSpaceSize = 0x0800;

    private readonly RandomNumberGenerator _rng;

    public RandomCharacterGenerator(RandomNumberGenerator? rng) => _rng = rng ?? RandomNumberGenerator.Create();

    public static void Fill(Span<char>)
    public static char GetCharacter()
    {
        var index = RandomNumberGenerator.GetInt32(AdjustedCharacterMax);

        if (index > 0xD7FF)
            index += SurrogateSpaceSize;

        return (char)(index);
    }
}