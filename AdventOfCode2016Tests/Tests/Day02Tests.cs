using AdventOfCode2016.Solutions;
using Xunit;

namespace AdventOfCode2016Tests
{

    public class Day02Tests
    {
        [Fact]
        public void Example1Test()
        {
            string input = AdventOfCode2016.Inputs.Day02.testData;

            var day = new Day02(input);
            day.Run();

            string expected = "1985";
            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RealDataTest()
        {
            string input = AdventOfCode2016.Inputs.Day02.realData;
            string expected = "53255";

            var day = new Day02(input);
            day.Run();

            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);

            string expectedSecond = "7423A";
            string actualSecond = day.GetSecondResult();

            Assert.Equal(expectedSecond, actualSecond);
        }

        [Fact]
        public void Example1SecondResultTest()
        {
            string input = AdventOfCode2016.Inputs.Day02.testData;

            var day = new Day02(input);
            day.Run();

            string expected = "5DB3";
            string actual = day.GetSecondResult();

            Assert.Equal(expected, actual);
        }
    }
}