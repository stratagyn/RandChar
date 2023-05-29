namespace RandChar.Tests;

public class GetStringTests
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
    public void GetString_Passes(int length)
    {
        var @string = RandChar.GetString(length);
        var chars = new HashSet<char>(@string);

        Assert.True(chars.Count == length || chars.Count > (length / 2));
    }

    [Fact]
    public void GetString_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetString(-1);
        });
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
    public void GetStringCharSet_Passes(CharSet charSet, int length)
    {
        var @string = RandChar.GetString(length, charSet);
        var chars = new HashSet<char>(@string);

        Assert.True(chars.Count == length || chars.Count > (length / 2));

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in @string)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber)]
    [InlineData(CharSet.ASCIIPunctuation)]
    [InlineData(CharSet.LowercaseLetter)]
    [InlineData(CharSet.DecimalDigitNumber)]
    [InlineData(CharSet.NonSpacingMark)]
    [InlineData(CharSet.UppercaseLetter)]
    public void GetStringCharSet_Negative_ThrowsArgumentOutOfRange(CharSet charSet)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetString(-1, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GetStringUDCharSet_Passes(int length)
    {
        var @string = RandChar.GetString(length, AlphaNumeric);
        var chars = new HashSet<char>(@string);

        Assert.True(chars.Count == length || chars.Count > (length / 2));

        foreach (var c in @string)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Fact]
    public void GetStringUDCharSet_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetString(-1, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GetStringUnique_Passes(int length)
    {
        var @string = RandChar.GetUniqueString(length);
        var chars = new HashSet<char>(@string);

        Assert.Equal(length, chars.Count);
    }

    [Fact]
    public void GetUniqueString_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetUniqueString(-1);
        });
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
    public void GetUniqueStringCharSet_Passes(CharSet charSet, int length)
    {
        var @string = RandChar.GetUniqueString(length, charSet);
        var chars = new HashSet<char>(@string);

        Assert.Equal(length, chars.Count);

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in @string)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber)]
    [InlineData(CharSet.ASCIIPunctuation)]
    [InlineData(CharSet.LowercaseLetter)]
    [InlineData(CharSet.DecimalDigitNumber)]
    [InlineData(CharSet.NonSpacingMark)]
    [InlineData(CharSet.UppercaseLetter)]
    public void GetUniqueStringCharSet_Negative_ThrowsArgumentOutOfRange(CharSet charSet)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetUniqueString(-1, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GetUniqueStringUDCharSet_Passes(int length)
    {
        var @string = RandChar.GetUniqueString(length, AlphaNumeric);
        var chars = new HashSet<char>(@string);

        Assert.Equal(length, chars.Count);

        foreach (var c in @string)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Fact]
    public void GetUniqueStringUDCharSet_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var @string = RandChar.GetUniqueString(-1, AlphaNumeric);
        });
    }
}