namespace RandChar.Tests;

public partial class FillTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void Fill_Passes(int count)
    {
        var chars = new char[count];

        RandChar.Fill(chars);

        var uniqueChars = new HashSet<char>(chars);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillCountAt_Passes(int count)
    {
        var chars = new char[count * 2];

        RandChar.Fill(chars, count, count);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, -1, count);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, count, count);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, 1, count);
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
    public void FillCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new char[count];

        RandChar.Fill(chars, charSet);

        var uniqueChars = new HashSet<char>(chars);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
    [InlineData(CharSet.ASCIIPunctuation, 33)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void FillCharSetCountAt_Passes(CharSet charSet, int count)
    {
        var chars = new char[count * 2];

        RandChar.Fill(chars, count, count, charSet);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in chars[count..])
            Assert.Contains(c, uids);
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
    public void FillCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, -1, count, charSet);
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
    public void FillCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, count, count, charSet);
        });
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
    [InlineData(CharSet.ASCIIPunctuation, 33)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void FillCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.Fill(chars, 1, count, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillUnique_Passes(int count)
    {
        var chars = new char[count];

        RandChar.FillUnique(chars);

        var uniqueChars = new HashSet<char>(chars);

        Assert.Equal(count, uniqueChars.Count);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillUniqueCountAt_Passes(int count)
    {
        var chars = new char[count * 2];

        RandChar.FillUnique(chars, count, count);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.Equal(count, uniqueChars.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillUniqueCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, -1, count);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillUniqueCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, count, count);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillUniqueCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, 1, count);
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
    public void FillUniqueCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new char[count];

        RandChar.FillUnique(chars, charSet);

        var uniqueChars = new HashSet<char>(chars);

        Assert.Equal(count, uniqueChars.Count);

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in chars)
            Assert.Contains(c, uids);
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
    [InlineData(CharSet.ASCIIPunctuation, 16)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void FillUniqueCharSetCountAt_Passes(CharSet charSet, int count)
    {
        var chars = new char[count * 2];

        RandChar.FillUnique(chars, count, count, charSet);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', chars[i]);

        var uniqueChars = new HashSet<char>(chars[count..]);

        Assert.Equal(count, uniqueChars.Count);

        var uids = new HashSet<int>(Characters.GetUIDs(charSet));

        foreach (var c in chars[count..])
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
    public void FillUniqueCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, -1, count, charSet);
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
    public void FillUniqueCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, count, count, charSet);
        });
    }

    [Theory]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
    [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
    [InlineData(CharSet.ASCIIPunctuation, 16)]
    [InlineData(CharSet.LowercaseLetter, 100)]
    [InlineData(CharSet.DecimalDigitNumber, 100)]
    [InlineData(CharSet.NonSpacingMark, 100)]
    [InlineData(CharSet.UppercaseLetter, 100)]
    public void FillUniqueCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];

            RandChar.FillUnique(chars, 1, count, charSet);
        });
    }
}