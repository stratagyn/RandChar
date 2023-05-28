using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RandChar;

public static class RandChar
{
    private const int AdjustedCharacterMax = 0x10F800;
    private const int SurrogateSpaceSize = 0x0800;

    #region Fill
    public static void Fill(char[] chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(char[] chars, CharSet characterSet)
    {
        var characters = CharacterSet.GetUIDs(characterSet);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(char[] chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        for (var i = 0; i < count; i++)
            chars[at + i] = GetCharacter();
    }

    public static void Fill(char[] chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var characters = CharacterSet.GetUIDs(characterSet);

        for (var i = 0; i < count; i++)
            chars[at + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(Span<char> chars, CharSet characterSet)
    {
        var characters = CharacterSet.GetUIDs(characterSet);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        for (var i = 0; i < count; i++)
            chars[at + i] = GetCharacter();
    }

    public static void Fill(Span<char> chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var characters = CharacterSet.GetUIDs(characterSet);

        for (var i = 0; i < count; i++)
            chars[at + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }
    #endregion Fill

    #region FillUnique
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

    public static void FillUnique(char[] chars, CharSet characterSet)
    {
        if (chars.Length == 0)
            return;

        var characters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];

        for (var i = 0; i < chars.Length; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = (char)characters[index];
            }

            chars[i] = nextChar;
        }
    }

    public static void FillUnique(char[] chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[at + i] = nextChar;
        }
    }

    public static void FillUnique(char[] chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        if (chars.Length == 0)
            return;

        var characters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = (char)characters[index];
            }

            chars[at + i] = nextChar;
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

    public static void FillUnique(Span<char> chars, CharSet characterSet)
    {
        if (chars.Length == 0)
            return;

        var characters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];

        for (var i = 0; i < chars.Length; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = (char)characters[index];
            }

            chars[i] = nextChar;
        }
    }

    public static void FillUnique(Span<char> chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        if (chars.Length == 0)
            return;

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[at + i] = nextChar;
        }
    }

    public static void FillUnique(Span<char> chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        if (chars.Length == 0)
            return;

        var characters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = (char)characters[index];
            }

            chars[at + i] = nextChar;
        }
    }
    #endregion FillUnique

    #region GetCharacter
    public static char GetCharacter()
    {
        var index = RandomNumberGenerator.GetInt32(AdjustedCharacterMax);

        if (index > 0xD7FF)
            index += SurrogateSpaceSize;

        return (char)(index);
    }

    public static char GetCharacter(CharSet characterSet)
    {
        var characters = CharacterSet.GetUIDs(characterSet);
        var index = RandomNumberGenerator.GetInt32(characters.Count);

        return (char)(characters[index]);
    }
    #endregion GetCharacter

    #region GetCharacters
    public static char[] GetCharacters(int count) 
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var chars = new char[count];

        for (var i = 0; i < count; ++i)
            chars[i] = GetCharacter();

        return chars;
    }

    public static char[] GetCharacters(int count, CharSet characterSet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var unicodeCharacters = CharacterSet.GetUIDs(characterSet);
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(unicodeCharacters.Count);
            chars[i] = (char)unicodeCharacters[index];
        }

        return chars;
    }
    #endregion GetCharacters

    #region GetUniqueCharacters
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

    public static char[] GetUniqueCharacters(int count, CharSet characterSet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var unicodeCharacters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(unicodeCharacters.Count);
        var nextChar = (char)unicodeCharacters[index];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(unicodeCharacters.Count);
                nextChar = (char)unicodeCharacters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }

        return chars;
    }
    #endregion GetUniqueCharacters

    #region GetString
    public static string GetString(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var str = new StringBuilder();

        for (var i = 0; i < length; ++i)
            str.Append(GetCharacter());

        return str.ToString();
    }

    public static string GetString(int length, CharSet characterSet)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var characters = CharacterSet.GetUIDs(characterSet);
        var str = new StringBuilder();

        for (var i = 0; i < length; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            str.Append((char)characters[index]);
        }

        return str.ToString();
    }
    #endregion GetString

    #region GetUniqueString
    public static string GetUniqueString(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var charset = new HashSet<char>();
        var nextChar = GetCharacter();
        var str = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            str.Append(nextChar);
            charset.Add(nextChar);
        }

        return str.ToString();
    }

    public static string GetUniqueString(int length, CharSet characterSet)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var characters = CharacterSet.GetUIDs(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = (char)characters[index];
            }

            str.Append(nextChar);
            charset.Add(nextChar);
        }

        return str.ToString();
    }
    #endregion GetUniqueString
}