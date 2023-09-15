using System.Security.Cryptography;
using System.Text;

namespace RandChar;

public static class RandomCharGenerator
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
        var characters = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(char[] chars, IList<char> characterSet)
    {
        var n = characterSet.Count;

        for (var i = 0; i < chars.Length; i++)
            chars[i] = characterSet[RandomNumberGenerator.GetInt32(n)];
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

        var characters = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i < count; i++)
            chars[at + i] = characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(char[] chars, int at, int count, IList<char> characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var n = characterSet.Count;

        for (var i = 0; i < count; i++)
            chars[at + i] = characterSet[RandomNumberGenerator.GetInt32(n)];
    }

    public static void Fill(Span<char> chars)
    {
        for (var i = 0; i < chars.Length; i++)
            chars[i] = GetCharacter();
    }

    public static void Fill(Span<char> chars, CharSet characterSet)
    {
        var characters = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i < chars.Length; i++)
            chars[i] = characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars, IList<char> characterSet)
    {
        var n = characterSet.Count;

        for (var i = 0; i < chars.Length; i++)
            chars[i] = characterSet[RandomNumberGenerator.GetInt32(n)];
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

        var characters = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i < count; i++)
            chars[at + i] = characters[RandomNumberGenerator.GetInt32(characters.Count)];
    }

    public static void Fill(Span<char> chars, int at, int count, IList<char> characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var n = characterSet.Count;

        for (var i = 0; i < count; i++)
            chars[at + i] = characterSet[RandomNumberGenerator.GetInt32(n)];
    }

    #endregion Fill

    #region FillUnique

    public static void FillUnique(char[] chars)
    {
        var charset = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var nextChar = GetCharacter();

            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(char[] chars, CharSet characterSet)
    {
        var characters = Characters.GetCharacterSet(characterSet);
        var charset = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            var nextChar = characters[index];

            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = characters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(char[] chars, IList<char> characterSet)
    {
        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            chars[i] = nextChar;
            uniqueChars.Add(nextChar);
        }
    }

    public static void FillUnique(char[] chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var charset = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var nextChar = GetCharacter();

            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[at + i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(char[] chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var characters = Characters.GetCharacterSet(characterSet);
        var n = characters.Count;
        var uniqueChars = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var nextChar = characters[RandomNumberGenerator.GetInt32(n)];

            while (uniqueChars.Contains(nextChar))
                nextChar = characters[RandomNumberGenerator.GetInt32(n)];

            chars[at + i] = nextChar;
            uniqueChars.Add(nextChar);
        }
    }

    public static void FillUnique(char[] chars, int at, int count, IList<char> characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            chars[at + i] = nextChar;
            uniqueChars.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars)
    {
        var charset = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var nextChar = GetCharacter();

            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars, CharSet characterSet)
    {
        var characters = Characters.GetCharacterSet(characterSet);
        var charset = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            var nextChar = characters[index];

            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = characters[index];
            }

            chars[i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars, IList<char> characterSet)
    {
        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();

        for (var i = 0; i < chars.Length; i++)
        {
            var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            chars[i] = nextChar;
            uniqueChars.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars, int at, int count)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var charset = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var nextChar = GetCharacter();

            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            chars[at + i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars, int at, int count, CharSet characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var characters = Characters.GetCharacterSet(characterSet);
        var charset = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            var nextChar = characters[index];

            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = characters[index];
            }

            chars[at + i] = nextChar;
            charset.Add(nextChar);
        }
    }

    public static void FillUnique(Span<char> chars, int at, int count, IList<char> characterSet)
    {
        if (at < 0 || at >= chars.Length)
            throw new IndexOutOfRangeException($"Expected {nameof(at)} in range [0, {chars.Length}].");

        if (count > chars.Length - at)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected {nameof(count)} in range [0, {chars.Length - at}].");

        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();

        for (var i = 0; i < count; i++)
        {
            var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            chars[at + i] = nextChar;
            uniqueChars.Add(nextChar);
        }
    }

    #endregion FillUnique

    #region GenerateCharacters

    public static IEnumerable<char> GenerateCharacters(int count = -1)
    {
        for (var i = 0; i != count; ++i)
            yield return GetCharacter();
    }

    public static IEnumerable<char> GenerateCharacters(CharSet characterSet, int count = -1)
    {
        var uids = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i != count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(uids.Count);

            yield return uids[index];
        }
    }

    public static IEnumerable<char> GenerateCharacters(IList<char> characterSet, int count = -1)
    {
        var n = characterSet.Count;

        for (var i = 0; i != count; ++i)
            yield return characterSet[RandomNumberGenerator.GetInt32(n)];
    }

    #endregion GenerateCharacters

    #region GenerateUniqueCharacters

    public static IEnumerable<char> GenerateUniqueCharacters(int count = -1)
    {
        var charset = new HashSet<char>();
        var nextChar = GetCharacter();

        for (var i = 0; i != count; i++)
        {
            while (charset.Contains(nextChar))
                nextChar = GetCharacter();

            yield return nextChar;

            charset.Add(nextChar);
        }
    }

    public static IEnumerable<char> GenerateUniqueCharacters(CharSet characterSet, int count = -1)
    {
        var uids = Characters.GetCharacterSet(characterSet);
        var charset = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(uids.Count);
        var nextChar = uids[index];

        for (var i = 0; i != count; i++)
        {
            while (charset.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(uids.Count);
                nextChar = uids[index];
            }

            yield return nextChar;

            charset.Add(nextChar);
        }
    }

    public static IEnumerable<char> GenerateUniqueCharacters(IList<char> characterSet, int count = -1)
    {
        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();
        var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

        for (var i = 0; i != count; i++)
        {
            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            yield return nextChar;

            uniqueChars.Add(nextChar);
        }
    }

    #endregion GenerateUniqueCharacters

    #region GenerateStrings

    public static IEnumerable<string> GenerateStrings(int length, int count = -1)
    {
        for (var i = 0; i != count; ++i)
            yield return GetString(length);
    }

    public static IEnumerable<string> GenerateStrings(int minLength, int maxLength, int count = -1)
    {
        CheckRange(minLength, maxLength);

        for (var i = 0; i != count; ++i)
            yield return GetString(RandomNumberGenerator.GetInt32(minLength, maxLength + 1));
    }

    public static IEnumerable<string> GenerateStrings(int length, CharSet characterSet, int count = -1)
    {
        var characters = Characters.GetCharacterSet(characterSet);
        var str = new StringBuilder(length);

        for (var i = 0; i != count; ++i)
        {
            for (var c = 0; c < length; ++c)
            {
                var index = RandomNumberGenerator.GetInt32(characters.Count);
                str.Append(characters[index]);
            }

            yield return str.ToString();

            str.Clear();
        }
    }

    public static IEnumerable<string> GenerateStrings(int minLength, int maxLength, CharSet characterSet, int count = -1)
    {
        CheckRange(minLength, maxLength);

        var characters = Characters.GetCharacterSet(characterSet);
        var str = new StringBuilder(minLength);

        for (var i = 0; i != count; ++i)
        {
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength + 1);

            for (var c = 0; c < length; ++c)
            {
                var index = RandomNumberGenerator.GetInt32(characters.Count);
                str.Append(characters[index]);
            }

            yield return str.ToString();

            str.Clear();
        }
    }

    public static IEnumerable<string> GenerateStrings(int length, IList<char> characterSet, int count = -1)
    {
        var n = characterSet.Count;
        var str = new StringBuilder();

        for (var i = 0; i != count; ++i)
        {
            for (var c = 0; c < length; ++c)
                str.Append(characterSet[RandomNumberGenerator.GetInt32(n)]);

            yield return str.ToString();

            str.Clear();
        }
    }

    public static IEnumerable<string> GenerateStrings(int minLength, int maxLength, IList<char> characterSet, int count = -1)
    {
        CheckRange(minLength, maxLength);

        var n = characterSet.Count;
        var str = new StringBuilder(minLength);

        for (var i = 0; i != count; ++i)
        {
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength + 1);

            for (var c = 0; c < length; ++c)
                str.Append(characterSet[RandomNumberGenerator.GetInt32(n)]);

            yield return str.ToString();

            str.Clear();
        }
    }

    #endregion GenerateStrings

    #region GenerateUniqueStrings

    public static IEnumerable<string> GenerateUniqueStrings(int length, int count = -1)
    {
        for (var i = 0; i != count; i++)
            yield return GetUniqueString(length);
    }

    public static IEnumerable<string> GenerateUniqueStrings(int minLength, int maxLength, int count = -1)
    {
        CheckRange(minLength, maxLength);

        for (var i = 0; i != count; i++)
        {
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength + 1);
            
            yield return GetUniqueString(length);
        }
    }

    public static IEnumerable<string> GenerateUniqueStrings(int length, CharSet characterSet, int count = -1)
    {
        var chars = new StringBuilder(length);
        var uids = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i != count; i++)
        { 
            yield return GetUniqueString(length, chars, uids);
            chars.Clear();
        }
    }

    public static IEnumerable<string> GenerateUniqueStrings(int minLength, int maxLength, CharSet characterSet, int count = -1)
    {
        var chars = new StringBuilder(minLength);
        var uids = Characters.GetCharacterSet(characterSet);

        for (var i = 0; i != count; i++)
        {
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength + 1);
            
            yield return GetUniqueString(length, chars, uids);

            chars.Clear();
        }
    }

    public static IEnumerable<string> GenerateUniqueStrings(int length, IList<char> characterSet, int count = -1)
    {
        var chars = new StringBuilder(length);

        for (var i = 0; i != count; i++)
        {
            yield return GetUniqueString(length, chars, characterSet);

            chars.Clear();
        }
    }

    public static IEnumerable<string> GenerateUniqueStrings(int minLength, int maxLength, IList<char> characterSet, int count = -1)
    {
        var chars = new StringBuilder(minLength);

        for (var i = 0; i != count; i++)
        {
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength + 1);
            
            yield return GetUniqueString(length, chars, characterSet);

            chars.Clear();
        }
    }
    
    #endregion GenerateUniqueStrings

    #region GetCharacter

    public static char GetCharacter()
    {
        var index = RandomNumberGenerator.GetInt32(AdjustedCharacterMax);

        if (index > 0xD7FF)
            index += SurrogateSpaceSize;

        return (char)index;
    }

    public static char GetCharacter(CharSet characterSet)
    {
        var characters = Characters.GetCharacterSet(characterSet);
        var index = RandomNumberGenerator.GetInt32(characters.Count);

        return (characters[index]);
    }

    public static char GetCharacter(IList<char> characterSet) =>
        characterSet[RandomNumberGenerator.GetInt32(characterSet.Count)];

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

    public static char[] GetCharacters(int minLength, int maxLength)
    {
        CheckRange(minLength, maxLength);

        var chars = new char[RandomNumberGenerator.GetInt32(minLength, maxLength + 1)];

        for (var i = 0; i < chars.Length; ++i)
            chars[i] = GetCharacter();

        return chars;
    }

    public static char[] GetCharacters(int count, CharSet characterSet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var uids = Characters.GetCharacterSet(characterSet);
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(uids.Count);
            chars[i] = uids[index];
        }

        return chars;
    }

    public static char[] GetCharacters(int count, IList<char> characterSet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        var n = characterSet.Count;
        var chars = new char[count];

        for (var i = 0; i < count; ++i)
            chars[i] = characterSet[RandomNumberGenerator.GetInt32(n)];

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

        var uids = Characters.GetCharacterSet(characterSet);
        var uniqueChars = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(uids.Count);
        var nextChar = uids[index];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (uniqueChars.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(uids.Count);
                nextChar = uids[index];
            }

            chars[i] = nextChar;
            uniqueChars.Add(nextChar);
        }

        return chars;
    }

    public static char[] GetUniqueCharacters(int count, IList<char> characterSet)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), $"Expected non-negative {nameof(count)}.");

        if (count == 0)
            return Array.Empty<char>();

        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();
        var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];
        var chars = new char[count];

        for (var i = 0; i < count; i++)
        {
            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            chars[i] = nextChar;
            uniqueChars.Add(nextChar);
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

        var characters = Characters.GetCharacterSet(characterSet);
        var str = new StringBuilder();

        for (var i = 0; i < length; ++i)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Count);
            str.Append(characters[index]);
        }

        return str.ToString();
    }

    public static string GetString(int length, IList<char> characterSet)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var n = characterSet.Count;
        var str = new StringBuilder();

        for (var i = 0; i < length; ++i)
            str.Append(characterSet[RandomNumberGenerator.GetInt32(n)]);

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

        var characters = Characters.GetCharacterSet(characterSet);
        var uniqueChars = new HashSet<char>();
        var index = RandomNumberGenerator.GetInt32(characters.Count);
        var nextChar = characters[index];
        var str = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            while (uniqueChars.Contains(nextChar))
            {
                index = RandomNumberGenerator.GetInt32(characters.Count);
                nextChar = characters[index];
            }

            str.Append(nextChar);
            uniqueChars.Add(nextChar);
        }

        return str.ToString();
    }

    public static string GetUniqueString(int length, IList<char> characterSet)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), $"Expected non-negative {nameof(length)}.");

        if (length == 0)
            return "";

        var n = characterSet.Count;
        var uniqueChars = new HashSet<char>();
        var nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];
        var str = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            while (uniqueChars.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(n)];

            str.Append(nextChar);
            uniqueChars.Add(nextChar);
        }

        return str.ToString();
    }

    #endregion GetUniqueString

    private static void CheckRange(int minLength, int maxLength)
    {
        if (minLength < 0)
            throw new ArgumentOutOfRangeException(nameof(minLength), $"Expected non-negative {nameof(minLength)}.");

        if (maxLength < 0)
            throw new ArgumentOutOfRangeException(nameof(maxLength), $"Expected non-negative {nameof(maxLength)}.");

        if (minLength > maxLength)
            throw new ArgumentException($"Expected {nameof(minLength)} in range [{0}, {maxLength}].");
    }

    private static string GetUniqueString(int length, StringBuilder chars, IList<char> characterSet)
    {
        var charset = new HashSet<char>();

        for (var c = 0; c < length; c++)
        {
            var nextChar = characterSet[RandomNumberGenerator.GetInt32(characterSet.Count)];

            while (charset.Contains(nextChar))
                nextChar = characterSet[RandomNumberGenerator.GetInt32(characterSet.Count)];

            chars.Append(nextChar);
            charset.Add(nextChar);
        }

        return chars.ToString();
    }
}