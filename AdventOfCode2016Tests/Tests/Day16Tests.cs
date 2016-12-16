using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{

    public class Day16Tests
    {
        [Fact]
        public void DragonTest()
        {
            Assert.Equal("001", Day16.Dragon("0", 0));
            Assert.Equal("100", Day16.Dragon("1", 0));
            Assert.Equal("11111000000", Day16.Dragon("11111", 0));
            Assert.Equal("1111000010100101011110000", Day16.Dragon("111100001010", 0));
            Assert.Equal("111100001010", Day16.Dragon("111100001010", 12));
        }

        [Fact]
        public void ChecksumTest()
        {
            Assert.Equal("100", Day16.Checksum("110010110100"));
        }

        [Fact]
        public void ExampleTest()
        {
            var disc = Day16.Dragon("10000", 20);
            var checksum = Day16.Checksum(disc);
            Assert.Equal("01100", checksum);
        }
    }

}