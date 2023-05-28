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
        [InlineData(CharSet.ASCIILowercaseLetter, 26)]
        [InlineData(CharSet.ASCIINumber, 10)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.ASCIIUppercaseLetter, 26)]
        [InlineData(UnicodeCategory.LowercaseLetter, 2233)]
        [InlineData(UnicodeCategory.DecimalDigitNumber, 680)]
        [InlineData(UnicodeCategory.NonSpacingMark, 1985)]
        [InlineData(UnicodeCategory.UppercaseLetter, 1831)]
        public void FillCharSets(ASCIICategory category, int size)
        {
            var chars = new char[size * 2];

            RandChar.Fill(chars, new[] { category });

            var charset = new HashSet<int>(Characters.GetUIDs(category));

            foreach (var c in chars)
                Assert.Contains(c, charset);
        }

        [Theory]
        
        public void FillUnicode(UnicodeCategory category, int size)
        {
            var chars = new char[size / 4];

            RandChar.Fill(chars, new[] { category });

            var charset = new HashSet<int>(Characters.GetUIDs(category));

            foreach (var c in chars)
                Assert.Contains(c, charset);
        }
    }
}