using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Example1Test()
        {
            string input = "";

            var day = new Day03(input);

            Assert.Equal(false, day.IsTriangle("  5  10  25"));
            Assert.Equal(false, day.IsTriangle("  5  25  10"));
            Assert.Equal(false, day.IsTriangle(" 25   5  10"));
            Assert.Equal(false, day.IsTriangle(" 15  25  10"));
            Assert.Equal(true, day.IsTriangle(" 15  25  12"));
            Assert.Equal(true, day.IsTriangle(" 35  30  44"));
            Assert.Equal(true, day.IsTriangle("102  87  35"));
        }

        [Fact]
        public void ListTest()
        {
            string input = @"   5   10   25
 10  20  11
 15  23  22
 90  70  50
 30  40  69";

            var day = new Day03(input);
            day.Run();

            Assert.Equal("4", day.GetFirstResult());
        }

        [Fact]
        public void RealDataTest()
        {
            string input = Inputs.Day03.realData;
            string expected = "1050";

            var day = new Day03(input);
            day.Run();

            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);

            Assert.Equal("1921", day.GetSecondResult());
        }

        [Fact]
        public void ColumnsExampleTest()
        {
            string input = @"101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603";

            var day = new Day03(input);
            day.Run();

            string expected = "6";
            string actual = day.GetSecondResult();

            Assert.Equal(expected, actual);
        }
    }
}