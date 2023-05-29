namespace RandChar.Tests;

public class GetCharactersTests
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
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber)]
    [InlineData(CharSet.ASCIIPunctuation)]
    [InlineData(CharSet.LowercaseLetter)]
    [InlineData(CharSet.DecimalDigitNumber)]
    [InlineData(CharSet.NonSpacingMark)]
    [InlineData(CharSet.UppercaseLetter)]
    public void GetCharacterCharSet_Passes(CharSet charSet)
    {
        var c = RandChar.GetCharacter(charSet);
        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        Assert.Contains(c, uids);
    }

    [Fact]
    public void GetCharacterUDCharSet_Passes()
    {
        var c = RandChar.GetCharacter(AlphaNumeric);

        Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GetCharacters_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GetCharacters(count));

        Assert.True(chars.Count == count || chars.Count > (count / 2));
    }

    [Fact]
    public void GetCharacters_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetCharacters(-1);
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
    public void GetCharactersCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GetCharacters(count, charSet));

        Assert.True(chars.Count == count || chars.Count > (count / 2));

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
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
    public void GetCharactersCharSet_Negative_ThrowsArgumentOutOfRange(CharSet charSet)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetCharacters(-1, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GetCharactersUDCharSet_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GetCharacters(count, AlphaNumeric));

        Assert.True(chars.Count == count || chars.Count > (count / 2));

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Fact]
    public void GetCharactersUDCharSet_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetCharacters(-1, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void GetUniqueCharacters_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GetUniqueCharacters(count));

        Assert.Equal(count, chars.Count);
    }

    [Fact]
    public void GetUniqueCharacters_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetUniqueCharacters(-1);
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
    public void GetUniqueCharactersCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new HashSet<char>(RandChar.GetUniqueCharacters(count, charSet));

        Assert.Equal(count, chars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in chars)
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
    public void GetUniqueCharactersCharSet_Negative_ThrowsArgumentOutOfRange(CharSet charSet)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetUniqueCharacters(-1, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void GetUniqueCharactersUDCharSet_Passes(int count)
    {
        var chars = new HashSet<char>(RandChar.GetUniqueCharacters(count, AlphaNumeric));

        Assert.Equal(count, chars.Count);

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Fact]
    public void GetUniqueCharactersUDCharSet_Negative_ThrowsArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = RandChar.GetUniqueCharacters(-1, AlphaNumeric);
        });
    }
}