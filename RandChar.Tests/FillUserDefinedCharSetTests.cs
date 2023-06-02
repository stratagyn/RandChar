namespace RandChar.Tests;

public partial class FillTests
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
    [InlineData(31)]
    public void FillUDCharSet_Passes(int count)
    {
        var chars = new char[count];

        RandomCharGenerator.Fill(chars, AlphaNumeric);

        var uniqueChars = new HashSet<char>(chars);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUDCharSetCountAt_Passes(int count)
    {
        var chars = new char[count * 2];

        RandomCharGenerator.Fill(chars, count, count, AlphaNumeric);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        foreach (var c in chars[count..])
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUDCharSetCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.Fill(chars, -1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUDCharSetCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.Fill(chars, count, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUDCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.Fill(chars, 1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUniqueUDCharSet_Passes(int count)
    {
        var chars = new char[count];

        RandomCharGenerator.FillUnique(chars, AlphaNumeric);

        var uniqueChars = new HashSet<char>(chars);

        Assert.Equal(count, uniqueChars.Count);

        foreach (var c in chars)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUniqueUDCharSetCountAt_Passes(int count)
    {
        var chars = new char[count * 2];

        RandomCharGenerator.FillUnique(chars, count, count, AlphaNumeric);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.Equal(count, uniqueChars.Count);

        foreach (var c in chars[count..])
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUniqueUDCharSetCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.FillUnique(chars, -1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUniqueUDCharSetCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.FillUnique(chars, count, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillUniqueUDCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandomCharGenerator.FillUnique(chars, 1, count, AlphaNumeric);
        });
    }
}