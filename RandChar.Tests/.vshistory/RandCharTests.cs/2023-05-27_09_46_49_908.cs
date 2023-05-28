using RandChar;

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

        [Fact]
        public void FillASCII()
        {
            var empty = new char[10];
            var chars = new char[10];

            RandChar.Fill(chars, new[] { ASCIICategory.UppercaseLetter });

            var charset = new HashSet<char>(chars);

            for (var i = (int)'A'; i < (int)
        }
    }
}