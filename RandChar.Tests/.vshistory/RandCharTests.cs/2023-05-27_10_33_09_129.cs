using RandChar;
using System.Globalization;

namespace RandChar.Tests;

public class RandCharTests
{
    public class FillTests
    {
        [Fact]
        public void Fill()
        {
            var empty = new char[10];
            var chars = new char[10];

            RandChar.Fill(chars);

            Assert.NotEqual(empty, chars);
        }

        [Theory]
        [InlineData(ASCIICategory.LowercaseLetter, 26)]
        [InlineData(ASCIICategory.Number, 10)]
        [InlineData(ASCIICategory.Punctuation, 33)]
        [InlineData(ASCIICategory.UppercaseLetter, 26)]
        public void FillASCII(ASCIICategory category, int size)
        {
            var chars = new char[size * 2];

            RandChar.Fill(chars, new[] { category });

            var charset = new HashSet<int>(CharSet.GetUIDs(category));

            foreach (var c in chars)
                Assert.Contains(c, charset);
        }

        [Theory]
        [InlineData(UnicodeCategory.LowercaseLetter, 2233)]
        [InlineData(UnicodeCategory.DecimalDigitNumber, 10)]
        [InlineData(UnicodeCategory.InitialQuotePunctuation, 33)]
        [InlineData(UnicodeCategory.UppercaseLetter, 1831)]
        public void FillASCII(UnicodeCategory category, int size)
        {
            var chars = new char[size * 2];

            RandChar.Fill(chars, new[] { category });

            var charset = new HashSet<int>(CharSet.GetUIDs(category));

            foreach (var c in chars)
                Assert.Contains(c, charset);
        }
    }
}