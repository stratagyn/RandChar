﻿using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RandomCharGenerator;

public class RandomChar
{
    private const int AdjustedCharacterMax = 0x10F800;
    private const int SurrogateSpaceSize = 0x0800;

    public static string Append(string str, int count) => 
        $"{str}{GetString(count)}";

    public static string Append(string str, int count, ASCIICategory category, params ASCIICategory[] categories) => 
        $"{str}{GetString(count, category, categories)}";

    public static string Append(string str, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{str}{GetString(count, category, categories)}";

    public static string AppendUnique(string str, int count) => 
        $"{str}{GetUniqueString(count)}";

    public static string AppendUnique(string str, int count, ASCIICategory category, params ASCIICategory[] categories) => 
        $"{str}{GetUniqueString(count, category, categories)}";

    public static string AppendUnique(string str, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{str}{GetUniqueString(count, category, categories)}";

    public static void Fill(char[] chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(char[] chars, ASCIICategory category, params ASCIICategory[] categories)
    {
        var characters = CharSet.GetUIDs(category, categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Length)];
    }

    public static void Fill(char[] chars, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        var characters = CharSet.GetUIDs(category, categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Length)];
    }

    public static void Fill(char[] chars, int startingAt, int count, ASCIICategory category, params ASCIICategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(category, categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Length)];
    }

    public static void Fill(char[] chars, int startingAt, int count, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(category, categories);

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Length)];
    }

    public static void Fill(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(char[] chars, int startingAt, int count)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = GetCharacter();
    }

    public static void Fill(Span<char> chars, int startingAt, int count)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = GetCharacter();
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

    public static void FillUnique(char[] chars, int startingAt, int count)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[startingAt + i] = nextChar;
        }
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

    public static void FillUnique(Span<char> chars, int startingAt, int count)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[startingAt + i] = nextChar;
        }
    }

    public static char GetCharacter()
    {
        var index = RandomNumberGenerator.GetInt32(AdjustedCharacterMax);

        if (index > 0xD7FF)
            index += SurrogateSpaceSize;

        return (char)(index);
    }

    public static char GetCharacter(ASCIICategory category, params ASCIICategory[] categories)
    {
        var characters = CharSet.GetUIDs(category, categories);
        var index = RandomNumberGenerator.GetInt32(characters.Length);

        return (char)(characters[index]);
    }

    public static char GetCharacter(UnicodeCategory category, params UnicodeCategory[] categories)
    {
        var characters = CharSet.GetUIDs(category, categories);
        var index = RandomNumberGenerator.GetInt32(characters.Length);

        return (char)(characters[index]);
    }

    public static char[] GetCharacters(int count) 
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var chars = new char[count];

        for (var i = 0; i < count; ++i)
            chars[i] = GetCharacter();

        return chars;
    }

    public static char[] GetCharacters(int count, ASCIICategory category, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var asciiCharacters = CharSet.GetUIDs(category, categories);
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(asciiCharacters.Length);
            chars[i] = (char)asciiCharacters[index];
        }

        return chars;
    }

    public static char[] GetCharacters(int count, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var unicodeCharacters = CharSet.GetUIDs(category, categories);
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(unicodeCharacters.Length);
            chars[i] = (char)unicodeCharacters[index];
        }

        return chars;
    }

    public static char[] GetUniqueCharacters(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
            charset.Add(nextChar);
        }

        return chars;
    }

    public static char[] GetUniqueCharacters(int count, ASCIICategory category, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var asciiCharacters = CharSet.GetUIDs(category, categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(asciiCharacters.Length);
        var nextChar = (char)asciiCharacters[index];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(asciiCharacters.Length);
                nextChar = (char)asciiCharacters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }

        return chars;
    }

    public static char[] GetUniqueCharacters(int count, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var unicodeCharacters = CharSet.GetUIDs(category, categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(unicodeCharacters.Length);
        var nextChar = (char)unicodeCharacters[index];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(unicodeCharacters.Length);
                nextChar = (char)unicodeCharacters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }

        return chars;
    }

    public static string GetString(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var str = new StringBuilder();

        for (var i = 0; i < count; ++i)
            str.Append(GetCharacter());

        return str.ToString();
    }

    public static string GetString(int count, ASCIICategory category, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(category, categories);
        var str = new StringBuilder();

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Length);
            str.Append((char)characters[index]);
        }

        return str.ToString();
    }

    public static string GetString(int count, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(category, categories);
        var str = new StringBuilder();

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Length);
            str.Append((char)characters[index]);
        }

        return str.ToString();
    }

    public static string GetUniqueString(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();
        var str = new StringBuilder();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            str.Append(nextChar);
            charset.Add(nextChar);
        }

        return str.ToString();
    }

    public static string GetUniqueString(int count, ASCIICategory category, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(category, categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Length);
        var nextChar = (char)characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Length);
                nextChar = (char)characters[index];
            }

            str.Append(nextChar);
            charset.Add(nextChar);
        }

        return str.ToString();
    }

    public static string GetUniqueString(int count, UnicodeCategory category, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(category, categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Length);
        var nextChar = (char)characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Length);
                nextChar = (char)characters[index];
            }

            str.Append(nextChar);
            charset.Add(nextChar);
        }

        return str.ToString();
    }

    public static string Prepend(char character, int count) =>
        $"{GetString(count)}{character}";

    public static string Prepend(char character, int count, ASCIICategory category, params ASCIICategory[] categories) =>
        $"{GetString(count, category, categories)}{character}";

    public static string Prepend(char character, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{GetString(count, category, categories)}{character}";

    public static string Prepend(string str, int count) => 
        $"{GetString(count)}{str}";

    public static string Prepend(string str, int count, ASCIICategory category, params ASCIICategory[] categories) => 
        $"{GetString(count, category, categories)}{str}";

    public static string Prepend(string str, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{GetString(count, category, categories)}{str}";

    public static string PrependUnique(char character, int count) =>
        $"{GetUniqueString(count)}{character}";

    public static string PrependUnique(char character, int count, ASCIICategory category, params ASCIICategory[] categories) => 
        $"{GetUniqueString(count, category, categories)}{character}";

    public static string PrependUnique(char character, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{GetUniqueString(count, category, categories)}{character}";

    public static string PrependUnique(string str, int count) => 
        $"{GetUniqueString(count)}{str}";

    public static string PrependUnique(string str, int count, ASCIICategory category, params ASCIICategory[] categories) =>
        $"{GetUniqueString(count, category, categories)}{str}";

    public static string PrependUnique(string str, int count, UnicodeCategory category, params UnicodeCategory[] categories) => 
        $"{GetUniqueString(count, category, categories)}{str}";
        
}