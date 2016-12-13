using AdventOfCode2016.Solutions;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Example1Test()
        {
            string input = "R2, L3";

            var day = new Day01(input);
            day.Run();

            string expected = "5";
            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2Test()
        {
            string input = "R2, R2, R2";

            var day = new Day01(input);
            day.Run();

            string expected = "2";
            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example3Test()
        {
            string input = "R5, L5, R5, R3";

            var day = new Day01(input);
            day.Run();

            string expected = "12";
            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WithLongDistanceTest()
        {
            string input = "R2, L30";
            string expected = "32";

            var day = new Day01(input);
            day.Run();

            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WithNegativeCoordinatesTest()
        {
            string input = "L2, L2";
            string expected = "4";

            var day = new Day01(input);
            day.Run();

            string actual = day.GetFirstResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example1VisitTwiceTest()
        {
            string input = "R8, R4, R4, R8";
            string expected = "4";

            Day01 day = new Day01(input);
            day.Run();

            string actual = day.GetSecondResult();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RealDataDistanceTest()
        {
            string input = Inputs.Day01.realData;
            string expected = "288";

            var dayOne = new Day01(input);
            dayOne.Run();

            string actual = dayOne.GetFirstResult();

            Assert.Equal(expected, actual);

            string expectedTwice = "111";
            string actualTwice = dayOne.GetSecondResult();

            Assert.Equal(expectedTwice, actualTwice);

        }
    }
}