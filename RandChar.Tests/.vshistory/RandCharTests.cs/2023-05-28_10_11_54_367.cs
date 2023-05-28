using RandChar;
using System.Globalization;

namespace RandChar.Tests;

public class RandCharTests
{
    public class FillTests
    {
        [Fact]
        public void Fill_Passes()
        {
            var chars = new char[10];

            RandChar.Fill(chars);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > 0);
        }

        [Fact]
        public void FillAt10_Passes()
        {
            var chars = new char[20];

            RandChar.Fill(chars, 10, 10);

            var charsSet = new HashSet<char>(chars[10..]);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            Assert.True(charsSet.Count > 0);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void FillCharSet_Passes(CharSet charSet, int size)
        {
            var chars = new char[size];

            RandChar.Fill(chars, charSet);

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
        public void FillCharSetAt10_Passes(CharSet charSet, int size)
        {
            var chars = new char[size + 10];

            RandChar.Fill(chars, 10, size, charSet);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars[10..])
                Assert.Contains(c, uids);
        }

        [Fact]
        public void FillUnique_Passes()
        {
            var chars = new char[10];

            RandChar.FillUnique(chars);

            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Fact]
        public void FillUniqueAt10_Passes()
        {
            var chars = new char[20];

            RandChar.FillUnique(chars, 10, 10);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var charSet = new HashSet<char>(chars[10..]);

            Assert.Equal(chars[10..].Length, charSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void FillUniqueCharSet_Passes(CharSet charSet, int size)
        {
            var chars = new char[size];

            RandChar.FillUnique(chars, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void FillUniqueCharSetAt10_Passes(CharSet charSet, int size)
        {
            var chars = new char[size + 10];

            RandChar.FillUnique(chars, 10, size, charSet);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var charsSet = new HashSet<char>(chars[10..]);

            Assert.Equal(chars[10..].Length, charsSet.Count);
        }
    }

    public class GetCharactersTests
    {
        [Fact]
        public void GetCharacters_Passes()
        {
            var chars = new char[10];

            RandChar.GetCharacters(chars);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > 0);
        }

        [Fact]
        public void GetCharactersAt10_Passes()
        {
            var chars = new char[20];

            RandChar.GetCharacters(chars, 10, 10);

            var charsSet = new HashSet<char>(chars[10..]);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            Assert.True(charsSet.Count > 0);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetCharactersCharSet_Passes(CharSet charSet, int size)
        {
            var chars = new char[size];

            RandChar.GetCharacters(chars, charSet);

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
        public void GetCharactersCharSetAt10_Passes(CharSet charSet, int size)
        {
            var chars = new char[size + 10];

            RandChar.GetCharacters(chars, 10, size, charSet);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars[10..])
                Assert.Contains(c, uids);
        }

        [Fact]
        public void GetCharactersUnique_Passes()
        {
            var chars = new char[10];

            RandChar.GetCharactersUnique(chars);

            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Fact]
        public void GetCharactersUniqueAt10_Passes()
        {
            var chars = new char[20];

            RandChar.GetCharactersUnique(chars, 10, 10);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var charSet = new HashSet<char>(chars[10..]);

            Assert.Equal(chars[10..].Length, charSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetCharactersUniqueCharSet_Passes(CharSet charSet, int size)
        {
            var chars = new char[size];

            RandChar.GetCharactersUnique(chars, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetCharactersUniqueCharSetAt10_Passes(CharSet charSet, int size)
        {
            var chars = new char[size + 10];

            RandChar.GetCharactersUnique(chars, 10, size, charSet);

            for (var i = 0; i < 10; i++)
                Assert.Equal('\0', chars[i]);

            var charsSet = new HashSet<char>(chars[10..]);

            Assert.Equal(chars[10..].Length, charsSet.Count);
        }
    }
}