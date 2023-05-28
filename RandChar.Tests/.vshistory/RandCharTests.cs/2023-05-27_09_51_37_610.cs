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

            var charset = new HashSet<int>(CharSet.GetUIDs(ASCIICategory.UppercaseLetter));

            foreach (var c in chars)
                Assert.Contains((int)c, charset);
        }
    }
}