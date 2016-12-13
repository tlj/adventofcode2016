using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void IsAbbaTest()
        {
            Assert.True(Day07.IsAbba("abba"));
            Assert.True(Day07.IsAbba("eweabbaasff"));
            Assert.True(Day07.IsAbba("kjbddbksd"));
        }

        [Fact]
        public void IsTlsTest()
        {
            Assert.True(Day07.IsTls("abba[mnop]qrst"));
            Assert.False(Day07.IsTls("abcd[bddb]xyyx"));
            Assert.False(Day07.IsTls("aaaa[qwer]tyui"));
            Assert.True(Day07.IsTls("ioxxoj[asdfgh]zxcvbn"));
            Assert.True(Day07.IsTls("ipseqmdzbeeqjsnvo[qxgatjiqzhwulhgkjm]syofcufklnbeobppx[lbmkistwoiolecjh]qpznlrllrkhxrnyvf[zbhzvyjqzywdpvh]thlrfwmziexkhxgp"));
        }

        [Fact]
        public void IsSslTest()
        {
            Assert.True(Day07.IsSsl("aba[bab]xyz"));
            Assert.False(Day07.IsSsl("xyx[xyx]xyx"));
            Assert.True(Day07.IsSsl("aaa[kek]eke"));
            Assert.True(Day07.IsSsl("zazbz[bzb]cdb"));
        }

        [Fact]
        public void FromAbaToBabTest()
        {
            Assert.Equal("bab", Day07.FromAbaToBab("aba"));
        }

        [Fact]
        public void GetAbaStringsTest()
        {
            Assert.Equal(2, Day07.GetAbaStrings("zazbz").Count);
        }

        [Fact]
        public void Example1Test()
        {
            var day = new Day07(Inputs.Day07.testData);
            day.Run();
            Assert.Equal("2", day.GetFirstResult());
        }

        [Fact]
        public void RealDataTest()
        {
            string input = Inputs.Day07.realData;

            var day = new Day07(input);
            day.Run();

            Assert.Equal("118", day.GetFirstResult());
            Assert.Equal("260", day.GetSecondResult());
        }

    }
}