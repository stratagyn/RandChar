using RandChar;
using System.Globalization;

namespace RandChar.Tests;

public class RandCharTests
{
    public class FillTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void Fill_Passes(int size)
        {
            var chars = new char[size];

            RandChar.Fill(chars);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > (size / 2));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillCountAt_Passes(int size)
        {
            var chars = new char[size * 2];

            RandChar.Fill(chars, size, size);

            var charsSet = new HashSet<char>(chars[size..]);

            for (var i = 0; i < size; i++)
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
        public void FillCharSetCountAt_Passes(CharSet charSet, int size)
        {
            var chars = new char[size * 2];

            RandChar.Fill(chars, size, size, charSet);

            for (var i = 0; i < size; i++)
                Assert.Equal('\0', chars[i]);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars[size..])
                Assert.Contains(c, uids);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillUnique_Passes(int size)
        {
            var chars = new char[size];

            RandChar.FillUnique(chars);

            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillUniqueCountAt_Passes(int size)
        {
            var chars = new char[size * 2];

            RandChar.FillUnique(chars, size, size);

            for (var i = 0; i < size; i++)
                Assert.Equal('\0', chars[i]);

            var charSet = new HashSet<char>(chars[size..]);

            Assert.Equal(chars[size..].Length, charSet.Count);
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
        public void FillUniqueCharSetCountAt_Passes(CharSet charSet, int size)
        {
            var chars = new char[size * 2];

            RandChar.FillUnique(chars, size, size, charSet);

            for (var i = 0; i < size; i++)
                Assert.Equal('\0', chars[i]);

            var charsSet = new HashSet<char>(chars[size..]);

            Assert.Equal(chars[size..].Length, charsSet.Count);
        }
    }

    public class GetCharactersTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetCharacters_Passes(int size)
        {
            var chars = RandChar.GetCharacters(size);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > (size / 2));
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
            var chars = RandChar.GetCharacters(size, charSet);
            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, uids);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetCharactersUnique_Passes(int size)
        {
            var chars = RandChar.GetUniqueCharacters(size);
            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetUniqueCharactersCharSet_Passes(CharSet charSet, int size)
        {
            var chars = RandChar.GetUniqueCharacters(size, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);
        }
    }
}