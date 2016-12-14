using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{

    public class Day04Tests
    {
        [Fact]
        public void VerificationTest()
        {
            var day = new Day04("");
            Assert.Equal(123, day.IsValidEncryption("aaaaa-bbb-z-y-x-123[abxyz]"));
            Assert.Equal(987, day.IsValidEncryption("a-b-c-d-e-f-g-h-987[abcde]"));
            Assert.Equal(404, day.IsValidEncryption("not-a-real-room-404[oarel]"));
            Assert.Equal(0, day.IsValidEncryption("totally-real-room-200[decoy]"));
        }

        [Fact]
        public void DecryptionTest()
        {
            var day = new Day04("");
            Assert.Equal("very encrypted name", day.DecryptString("qzmt-zixmtkozy-ivhz", 343));
        }

        [Fact]
        public void RealDataTest()
        {
            string input = AdventOfCode2016.Inputs.Day04.realData;

            var day = new Day04(input);
            day.Run();

            Assert.Equal("173787", day.GetFirstResult());
            Assert.Equal("548", day.GetSecondResult());
        }

    }
}