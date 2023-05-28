﻿using System.Security.Cryptography;

namespace RandomStringGenerator;

public class RandomCharacterGenerator
{
    private const int AdjustedCharacterMax = 0x10F800;
    private const int SurrogateSpaceSize = 0x0800;

    private readonly RandomNumberGenerator _rng;

    public RandomCharacterGenerator(RandomNumberGenerator? rng) => _rng = rng ?? RandomNumberGenerator.Create();

    public static void Fill(char[] chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void FillUnique(char[] chars)
    {
        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < chars.Length; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
        }
    }

    public static void Fill(char[] chars, int startingAt, int count)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected starting index in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected count in range [0, {chars.Length - startingAt}].");

        for (var i = startingAt; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void FillUnique(char[] chars, int startingAt, int count)
    {
        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < chars.Length; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
        }
    }

    public static void Fill(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void FillUnique(Span<char> chars)
    {
        if (chars.Length == 0) 
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < chars.Length; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
        }
    }

    public static char GetCharacter()
    {
        var index = RandomNumberGenerator.GetInt32(AdjustedCharacterMax);

        if (index > 0xD7FF)
            index += SurrogateSpaceSize;

        return (char)(index);
    }
}