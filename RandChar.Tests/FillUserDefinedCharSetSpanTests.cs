namespace RandChar.Tests;

public partial class FillTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUDCharSet_Passes(int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span, AlphaNumeric);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span)
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        foreach (var c in span)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUDCharSetCountAt_Passes(int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.Fill(span, count, count, AlphaNumeric);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.True(uniqueChars.Count == count || uniqueChars.Count > (count / 2));

        foreach (var c in span[count..])
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUDCharSetCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, -1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUDCharSetCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, count, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUDCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.Fill(span, 1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUniqueUDCharSet_Passes(int count)
    {
        var chars = new char[count];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span, AlphaNumeric);

        var uniqueChars = new HashSet<char>(chars);

        Assert.Equal(count, uniqueChars.Count);

        foreach (var c in span)
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUniqueUDCharSetCountAt_Passes(int count)
    {
        var chars = new char[count * 2];
        var span = new Span<char>(chars);

        RandomCharGenerator.FillUnique(span, count, count, AlphaNumeric);

        for (var i = 0; i < count; i++)
            Assert.Equal('\0', span[i]);

        var uniqueChars = new HashSet<char>();

        foreach (var c in span[count..])
            uniqueChars.Add(c);

        Assert.Equal(count, uniqueChars.Count);

        foreach (var c in span[count..])
            Assert.Contains(c, AlphaNumericSet);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUniqueUDCharSetCountAt_Negative_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, -1, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUniqueUDCharSetCountAt_Count_ThrowsIndexOutOfRange(int count)
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, count, count, AlphaNumeric);
        });
    }

    [Theory]
    [InlineData(10)]
    [InlineData(25)]
    [InlineData(31)]
    public void FillSpanUniqueUDCharSetCountAt_NotEnoughRoom_ThrowsArgumentOutOfRange(int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandomCharGenerator.FillUnique(span, 1, count, AlphaNumeric);
        });
    }
}