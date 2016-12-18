using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{

    public class Day18Tests
    {
        [Fact]
        public void ExampleTest()
        {
            var input       = @"..^^.";
            var expected    = @".^^^^";
            var actual = Day18.GetRow(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2Test()
        {
            var input = @".^^^^";
            var expected = @"^^..^";
            var actual = Day18.GetRow(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TenRowColTest()
        {
            Assert.Equal(38, Day18.GetSafeCount(AdventOfCode2016.Inputs.Day18.testData, 10));
        }
    }

}