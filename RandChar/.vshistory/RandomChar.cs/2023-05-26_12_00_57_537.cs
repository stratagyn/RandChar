using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RandomCharGenerator;

public class RandomChar
{
    private const int AdjustedCharacterMax = 0x10F800;
    private const int SurrogateSpaceSize = 0x0800;

    #region Append
    public static string Append(string str, int count) => 
        $"{str}{GetString(count)}";

    public static string Append(string str, int count, params ASCIICategory[] categories) => 
        $"{str}{GetString(count, categories)}";

    public static string Append(string str, int count, params UnicodeCategory[] categories) => 
        $"{str}{GetString(count, categories)}";
    #endregion Append

    #region AppendUnique
    public static string AppendUnique(string str, int count) => 
        $"{str}{GetUniqueString(count)}";

    public static string AppendUnique(string str, int count, params ASCIICategory[] categories) => 
        $"{str}{GetUniqueString(count, categories)}";

    public static string AppendUnique(string str, int count, params UnicodeCategory[] categories) => 
        $"{str}{GetUniqueString(count, categories)}";
    #endregion AppendUnique

    #region Fill
    public static void Fill(char[] chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(char[] chars, params ASCIICategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(char[] chars, params UnicodeCategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
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

    public static void Fill(char[] chars, int startingAt, int count, params ASCIICategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(char[] chars, int startingAt, int count, params UnicodeCategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(Span<char> chars, params ASCIICategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars, params UnicodeCategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
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

    public static void Fill(Span<char> chars, int startingAt, int count, params ASCIICategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars, int startingAt, int count, params UnicodeCategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        var characters = CharSet.GetUIDs(categories);

        for (var i = 0; i < count; i++)
            chars[startingAt + i] = (char)characters[RandomNumberGenerator.GetInt32(characters.Count)];
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

    public static void FillUnique(char[] chars, params ASCIICategory[] categories)
    {
        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

    public static void FillUnique(char[] chars, params UnicodeCategory[] categories)
    {
        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

    public static void FillUnique(char[] chars, int startingAt, int count, params ASCIICategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

            chars[startingAt + i] = nextChar;
        }
    }

    public static void FillUnique(char[] chars, int startingAt, int count, params UnicodeCategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

    public static void FillUnique(Span<char> chars, params ASCIICategory[] categories)
    {
        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

    public static void FillUnique(Span<char> chars, params UnicodeCategory[] categories)
    {
        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

    public static void FillUnique(Span<char> chars, int startingAt, int count, params ASCIICategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

            chars[startingAt + i] = nextChar;
        }
    }

    public static void FillUnique(Span<char> chars, int startingAt, int count, params UnicodeCategory[] categories)
    {
        if (startingAt < 0 || startingAt >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(startingAt)} in range [0, {chars.Length}].");

        if (count > chars.Length - startingAt)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - startingAt}].");

        if (chars.Length == 0)
            return;

        var characters = CharSet.GetUIDs(categories);
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

            chars[startingAt + i] = nextChar;
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

    public static char GetCharacter(params ASCIICategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);
        var index = RandomNumberGenerator.GetInt32(characters.Count);

        return (char)(characters[index]);
    }

    public static char GetCharacter(params UnicodeCategory[] categories)
    {
        var characters = CharSet.GetUIDs(categories);
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

    public static char[] GetCharacters(int count, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var asciiCharacters = CharSet.GetUIDs(categories);
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(asciiCharacters.Count);
            chars[i] = (char)asciiCharacters[index];
        }

        return chars;
    }

    public static char[] GetCharacters(int count, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var unicodeCharacters = CharSet.GetUIDs(categories);
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

    public static char[] GetUniqueCharacters(int count, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var asciiCharacters = CharSet.GetUIDs(categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(asciiCharacters.Count);
        var nextChar = (char)asciiCharacters[index];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(asciiCharacters.Count);
                nextChar = (char)asciiCharacters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }

        return chars;
    }

    public static char[] GetUniqueCharacters(int count, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var unicodeCharacters = CharSet.GetUIDs(categories);
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

    public static string GetString(int count, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(categories);
        var str = new StringBuilder();

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            str.Append((char)characters[index]);
        }

        return str.ToString();
    }

    public static string GetString(int count, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(categories);
        var str = new StringBuilder();

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            str.Append((char)characters[index]);
        }

        return str.ToString();
    }
    #endregion GetString

    #region GetUniqueString
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

    public static string GetUniqueString(int count, params ASCIICategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < count; i++)
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

    public static string GetUniqueString(int count, params UnicodeCategory[] categories)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return "";

        var characters = CharSet.GetUIDs(categories);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = (char)characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < count; i++)
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

    #region Prepend
    public static string Prepend(char character, int count) =>
        $"{GetString(count)}{character}";

    public static string Prepend(char character, int count, params ASCIICategory[] categories) =>
        $"{GetString(count, categories)}{character}";

    public static string Prepend(char character, int count, params UnicodeCategory[] categories) => 
        $"{GetString(count, categories)}{character}";

    public static string Prepend(string str, int count) => 
        $"{GetString(count)}{str}";

    public static string Prepend(string str, int count, params ASCIICategory[] categories) => 
        $"{GetString(count, categories)}{str}";

    public static string Prepend(string str, int count, params UnicodeCategory[] categories) => 
        $"{GetString(count, categories)}{str}";
    #endregion Prepend

    #region PrependUnique
    public static string PrependUnique(char character, int count) =>
        $"{GetUniqueString(count)}{character}";

    public static string PrependUnique(char character, int count, params ASCIICategory[] categories) => 
        $"{GetUniqueString(count, categories)}{character}";

    public static string PrependUnique(char character, int count, params UnicodeCategory[] categories) => 
        $"{GetUniqueString(count, categories)}{character}";

    public static string PrependUnique(string str, int count) => 
        $"{GetUniqueString(count)}{str}";

    public static string PrependUnique(string str, int count, params ASCIICategory[] categories) =>
        $"{GetUniqueString(count, categories)}{str}";

    public static string PrependUnique(string str, int count, params UnicodeCategory[] categories) => 
        $"{GetUniqueString(count, categories)}{str}";
    #endregion PrependUnique
}