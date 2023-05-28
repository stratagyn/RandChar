using System.Globalization;
using System.Security.Cryptography;
using System.Text;

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
        var characters = Character.GetUIDs(category, categories);
        var index = RandomNumberGenerator.GetInt32(characters.Length);

        return (char)(characters[index]);
    }

    public static char GetCharacter(UnicodeCategory category, params UnicodeCategory[] categories)
    {
        var characters = Character.GetUIDs(category, categories);
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
        }

        return str.ToString();
    }
}