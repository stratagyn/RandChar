namespace RandChar.Tests;

public class GenerateStringsTests
{
    private static readonly char[] AlphaNumeric =
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    private static readonly HashSet<char> AlphaNumericSet = new(AlphaNumeric);

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 10)]
    [InlineData(10, 25)]
    [InlineData(10, 50)]
    [InlineData(10, 100)]
    public void GenerateStrings_Passes(int length, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length, count));

        Assert.True(strings.Count == count || strings.Count > (count / 2));
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 10)]
    [InlineData(10, 25)]
    [InlineData(10, 50)]
    [InlineData(10, 100)]
    public void GenerateStrings_Negative_Passes(int length, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length).Take(count));

        Assert.True(strings.Count == count || strings.Count > (count / 2));
    }

    [Theory]
    [InlineData(10, CharSet.LowercaseLetter, 0)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 25)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 25)]
    [InlineData(10, CharSet.ASCIIPunctuation, 25)]
    [InlineData(10, CharSet.LowercaseLetter, 25)]
    [InlineData(10, CharSet.DecimalDigitNumber, 25)]
    [InlineData(10, CharSet.NonSpacingMark, 25)]
    [InlineData(10, CharSet.UppercaseLetter, 25)]
    public void GenerateStringsCharSet_Passes(int length, CharSet charSet, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length, charSet, count));
        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        Assert.True(strings.Count == count || strings.Count > (count / 2));

        foreach (var str in strings)
            foreach (var c in str)
                Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(10, CharSet.LowercaseLetter, 0)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 25)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 25)]
    [InlineData(10, CharSet.ASCIIPunctuation, 25)]
    [InlineData(10, CharSet.LowercaseLetter, 25)]
    [InlineData(10, CharSet.DecimalDigitNumber, 25)]
    [InlineData(10, CharSet.NonSpacingMark, 25)]
    [InlineData(10, CharSet.UppercaseLetter, 25)]
    public void GenerateStringsCharSet_Negative_Passes(int length, CharSet charSet, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length, charSet).Take(count));
        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        Assert.True(strings.Count == count || strings.Count > (count / 2));

        foreach (var str in strings)
            foreach (var c in str)
                Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 25)]
    [InlineData(10, 31)]
    public void GenerateStringsUDCharSet_Passes(int length, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length, AlphaNumeric, count));

        Assert.True(strings.Count == count || strings.Count > (count / 2));

        foreach (var str in strings)
            foreach (var c in str)
                Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 25)]
    [InlineData(10, 31)]
    public void GenerateStringsUDCharSet_Negative_Passes(int length, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateStrings(length, AlphaNumeric).Take(count));

        Assert.True(strings.Count == count || strings.Count > (count / 2));

        foreach (var str in strings)
            foreach (var c in str)
                Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 10)]
    [InlineData(10, 25)]
    [InlineData(10, 50)]
    [InlineData(10, 100)]
    public void GenerateUniqueStrings_Passes(int length, int count)
    {
        var strings = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length, count));

        Assert.Equal(count, strings.Count);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 10)]
    [InlineData(10, 25)]
    [InlineData(10, 50)]
    [InlineData(10, 100)]
    public void GenerateUniqueStrings_Negative_Passes(int length, int count)
    {
        var chars = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length).Take(count));

        Assert.Equal(count, chars.Count);
    }

    [Theory]
    [InlineData(10, CharSet.LowercaseLetter, 0)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 25)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 25)]
    [InlineData(10, CharSet.ASCIIPunctuation, 25)]
    [InlineData(10, CharSet.LowercaseLetter, 25)]
    [InlineData(10, CharSet.DecimalDigitNumber, 25)]
    [InlineData(10, CharSet.NonSpacingMark, 25)]
    [InlineData(10, CharSet.UppercaseLetter, 25)]
    public void GenerateUniqueStringsCharSet_Passes(int length, CharSet charSet, int count)
    {
        var chars = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length, charSet, count));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var str in chars)
            foreach (var c in str)
                Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(10, CharSet.LowercaseLetter, 0)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 25)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 25)]
    [InlineData(10, CharSet.ASCIIPunctuation, 25)]
    [InlineData(10, CharSet.LowercaseLetter, 25)]
    [InlineData(10, CharSet.DecimalDigitNumber, 25)]
    [InlineData(10, CharSet.NonSpacingMark, 25)]
    [InlineData(10, CharSet.UppercaseLetter, 25)]
    public void GenerateUniqueStringsCharSet_Negative_Passes(int length, CharSet charSet, int count)
    {
        var chars = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length, charSet).Take(count));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var str in chars)
            foreach (var c in str)
                Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(10, CharSet.LowercaseLetter, 0)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 25)]
    [InlineData(10, CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 25)]
    [InlineData(10, CharSet.ASCIIPunctuation, 25)]
    [InlineData(10, CharSet.LowercaseLetter, 25)]
    [InlineData(10, CharSet.DecimalDigitNumber, 25)]
    [InlineData(10, CharSet.NonSpacingMark, 25)]
    [InlineData(10, CharSet.UppercaseLetter, 25)]
    public void GenerateUniqueStringsUDCharSet_Passes(int length, CharSet charSet, int count)
    {
        var chars = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length, charSet, count));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var str in chars)
            foreach (var c in str)
                Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 25)]
    [InlineData(10, 31)]
    public void GenerateUniqueStringsUDCharSet_Negative_Passes(int length, int count)
    {
        var chars = new HashSet<string>(RandomCharGenerator.GenerateUniqueStrings(length, AlphaNumeric).Take(count));

        Assert.Equal(count, chars.Count);

        foreach (var str in chars)
            foreach (var c in str)
                Assert.Contains(c, AlphaNumericSet);
    }
}