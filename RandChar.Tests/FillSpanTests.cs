namespace RandChar.Tests;

public partial class FillTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpan_Passes(int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span);
        var uniqueChars = new HashSet<char>();

        foreach (var c in span)
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanCountAt_Passes(int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span, count, count);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count > 0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, -1, count);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, count, count);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, 1, count);
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
    public void FillSpanCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span, charSet);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span)
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in span)
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
    public void FillSpanCharSetCountAt_Passes(CharSet charSet, int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span, count, count, charSet);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in span[count..])
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
    public void FillSpanCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, -1, count, charSet);
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
    public void FillSpanCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, count, count, charSet);
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
    public void FillSpanCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, 1, count, charSet);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanUnique_Passes(int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span)
            uniqueChars.Add(c);

        Assert.Equal(chars.Length, uniqueChars.Count);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanUniqueCountAt_Passes(int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span, count, count);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.Equal(count, uniqueChars.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanUniqueCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, -1, count);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanUniqueCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, count, count);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(50)]
    [InlineData(100)]
    public void FillSpanUniqueCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, 1, count);
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
    public void FillSpanUniqueCharSet_Passes(CharSet charSet, int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span, charSet);

        var uniqueChars = new HashSet<char>(chars);

        Assert.Equal(count, uniqueChars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in span)
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
    public void FillSpanUniqueCharSetCountAt_Passes(CharSet charSet, int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span, count, count, charSet);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.Equal(count, uniqueChars.Count);

        var uids = new HashSet<char>(Characters.GetCharacterSet(charSet));

        foreach (var c in span[count..])
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
    public void FillSpanUniqueCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, -1, count, charSet);
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
    public void FillSpanUniqueCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, count, count, charSet);
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
    public void FillSpanUniqueCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(CharSet charSet, int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, 1, count, charSet);
        });
    }
}