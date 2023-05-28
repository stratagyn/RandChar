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
        public void Fill_Passes(int count)
        {
            var chars = new char[count];

            RandChar.Fill(chars);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > (count / 2));
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

            var charsSet = new HashSet<char>(chars[count..]);

            for (var i = 0; i < count; i++)
                Assert.Equal('\0', chars[i]);

            Assert.True(charsSet.Count > 0);
        }

        [Theory]
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

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars[count..])
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
        public void FillCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];

                RandChar.Fill(chars, -1, count, charSet);
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
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillUnique_Passes(int count)
        {
            var chars = new char[count];

            RandChar.FillUnique(chars);

            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
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

            var charSet = new HashSet<char>(chars[count..]);

            Assert.Equal(chars[count..].Length, charSet.Count);
        }

        [Theory]
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

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);

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

            var charsSet = new HashSet<char>(chars[count..]);

            Assert.Equal(chars[count..].Length, charsSet.Count);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars[count..])
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
        public void FillUniqueCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];

                RandChar.FillUnique(chars, -1, count, charSet);
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

    public class FillSpanTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillSpan_Passes(int count)
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandChar.Fill(span);
            var charsSet = new HashSet<char>();

            foreach (var c in span)
                charsSet.Add(c);

            Assert.True(charsSet.Count > (count / 2));
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

            RandChar.Fill(span, count, count);

            var charsSet = new HashSet<char>(span.Slice(count));

            for (var i = 0; i < count; i++)
                Assert.Equal('\0', span[i]);

            Assert.True(charsSet.Count > 0);
        }

        [Theory]
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

                RandChar.Fill(span, -1, count);
            });
        }

        [Theory]
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

                RandChar.Fill(span, count, count);
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

                RandChar.Fill(span, 1, count);
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
        public void FillSpanCharSet_Passes(CharSet charSet, int count)
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandChar.Fill(span, charSet);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

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

            RandChar.Fill(span, count, count, charSet);

            for (var i = 0; i < count; i++)
                Assert.Equal('\0', span[i]);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in span.Slice(count))
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
        public void FillSpanCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];
                var span = new Span<char>(chars);

                RandChar.Fill(span, -1, count, charSet);
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
        public void FillSpanCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];
                var span = new Span<char>(chars);

                RandChar.Fill(span, count, count, charSet);
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

                RandChar.Fill(span, 1, count, charSet);
            });
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void FillSpanUnique_Passes(int count)
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandChar.FillUnique(span);

            var charSet = new HashSet<char>(span);

            Assert.Equal(chars.Length, charSet.Count);
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

            RandChar.FillUnique(span, count, count);

            for (var i = 0; i < count; i++)
                Assert.Equal('\0', span[i]);

            var charSet = new HashSet<char>(span.Slice(count));

            Assert.Equal(span.Slice(count).Length, charSet.Count);
        }

        [Theory]
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

                RandChar.FillUnique(span, -1, count);
            });
        }

        [Theory]
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

                RandChar.FillUnique(span, count, count);
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

                RandChar.FillUnique(span, 1, count);
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
        public void FillSpanUniqueCharSet_Passes(CharSet charSet, int count)
        {
            var chars = new char[count];
            var span = new Span<char>(chars);

            RandChar.FillUnique(span, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

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

            RandChar.FillUnique(span, count, count, charSet);

            for (var i = 0; i < count; i++)
                Assert.Equal('\0', span[i]);

            var charsSet = new HashSet<char>(span.Slice(count));

            Assert.Equal(span.Slice(count).Length, charsSet.Count);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in span.Slice(count))
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
        public void FillSpanUniqueCharSetCountAt_Negative_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];
                var span = new Span<char>(chars);

                RandChar.FillUnique(span, -1, count, charSet);
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
        public void FillSpanUniqueCharSetCountAt_Count_ThrowsIndexOutOfRange(CharSet charSet, int count)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var chars = new char[count];
                var span = new Span<char>(chars);

                RandChar.FillUnique(span, count, count, charSet);
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

                RandChar.FillUnique(span, 1, count, charSet);
            });
        }
    }
    public class GetCharacterTests
    {
        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber)]
        [InlineData(CharSet.ASCIIPunctuation)]
        [InlineData(CharSet.LowercaseLetter)]
        [InlineData(CharSet.DecimalDigitNumber)]
        [InlineData(CharSet.NonSpacingMark)]
        [InlineData(CharSet.UppercaseLetter)]
        public void GetCharacterCharSet_Passes(CharSet charSet)
        {
            var c = RandChar.GetCharacter(charSet);
            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            Assert.Contains(c, uids);
        }
    }
    public class GetCharactersTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetCharacters_Passes(int count)
        {
            var chars = RandChar.GetCharacters(count);

            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > (count / 2));
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetCharactersCharSet_Passes(CharSet charSet, int count)
        {
            var chars = RandChar.GetCharacters(count, charSet);
            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, uids);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetCharactersUnique_Passes(int count)
        {
            var chars = RandChar.GetUniqueCharacters(count);
            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetUniqueCharactersCharSet_Passes(CharSet charSet, int count)
        {
            var chars = RandChar.GetUniqueCharacters(count, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, uids);
        }
    }

    public class GetStringTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetString_Passes(int count)
        {
            var chars = RandChar.GetString(count);
            var charsSet = new HashSet<char>(chars);

            Assert.True(charsSet.Count > (count / 2));
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 52)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 62)]
        [InlineData(CharSet.ASCIIPunctuation, 33)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetStringCharSet_Passes(CharSet charSet, int count)
        {
            var chars = RandChar.GetString(count, charSet);
            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, uids);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void GetStringUnique_Passes(int count)
        {
            var chars = RandChar.GetUniqueString(count);
            var charSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charSet.Count);
        }

        [Theory]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter, 26)]
        [InlineData(CharSet.ASCIILowercaseLetter | CharSet.UppercaseLetter | CharSet.ASCIINumber, 31)]
        [InlineData(CharSet.ASCIIPunctuation, 16)]
        [InlineData(CharSet.LowercaseLetter, 100)]
        [InlineData(CharSet.DecimalDigitNumber, 100)]
        [InlineData(CharSet.NonSpacingMark, 100)]
        [InlineData(CharSet.UppercaseLetter, 100)]
        public void GetUniqueStringCharSet_Passes(CharSet charSet, int count)
        {
            var chars = RandChar.GetUniqueString(count, charSet);

            var charsSet = new HashSet<char>(chars);

            Assert.Equal(chars.Length, charsSet.Count);

            var uids = new HashSet<int>(Characters.GetUIDs(charSet));

            foreach (var c in chars)
                Assert.Contains(c, uids);
        }
    }
}