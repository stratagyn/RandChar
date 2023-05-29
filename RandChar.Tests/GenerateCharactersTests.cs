namespace RandChar.Tests;

public class GenerateCharactersTests
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
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GenerateCharacters_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters(count));

        Assert.True(chars.Count == count || chars.Count > (count / 2));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GenerateCharacters_Negative_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters().Take(count));

        Assert.True(chars.Count == count || chars.Count > (count / 2));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GenerateCharactersUDCharSet_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters(AlphaNumeric, count));

        Assert.True(chars.Count == count || chars.Count > (count / 2));

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GenerateCharactersUDCharSet_Negative_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters(AlphaNumeric).Take(count));

        Assert.True(chars.Count == count || chars.Count > (count / 2));

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(CharSet.LowercaseLetter, 0)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
    [InlineData(CharSet.ASCIIPunctuation, 33)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void GenerateCharactersCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters(charSet, count));
        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);

        Assert.True(chars.Count == count || chars.Count > (count / 2));
    }

    [Theory]
    [InlineData(CharSet.LowercaseLetter, 0)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
    [InlineData(CharSet.ASCIIPunctuation, 33)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void GenerateCharactersCharSet_Negative_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateCharacters(charSet).Take(count));
        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);

        Assert.True(chars.Count == count || chars.Count > (count / 2));
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GenerateUniqueCharacters_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters(count));

        Assert.Equal(count, chars.Count);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GenerateUniqueCharacters_Negative_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters().Take(count));

        Assert.Equal(count, chars.Count);
    }

    [Theory]
    [InlineData(CharSet.LowercaseLetter, 0)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
    [InlineData(CharSet.ASCIIPunctuation, 16)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void GenerateUniqueCharactersCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters(charSet, count));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(CharSet.LowercaseLetter, 0)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
    [InlineData(CharSet.ASCIIPunctuation, 16)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void GenerateUniqueCharactersCharSet_Negative_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters(charSet).Take(count));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GenerateUniqueCharactersUDCharSet_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters(AlphaNumeric, count));

        Assert.Equal(count, chars.Count);

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GenerateUniqueCharactersUDCharSet_Negative_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GenerateUniqueCharacters(AlphaNumeric).Take(count));

        Assert.Equal(count, chars.Count);

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }
}