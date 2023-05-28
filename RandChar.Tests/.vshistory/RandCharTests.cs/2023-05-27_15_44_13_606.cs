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
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void FillCharSets(CharSet charSet, int size)
        {
            var chars = new char[size];

            RandChar.Fill(chars, charSet);

            var charset = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, charset);
        }
    }
}