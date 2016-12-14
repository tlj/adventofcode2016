using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{

    public class Day06Tests
    {
        [Fact]
        public void ExampleTest()
        {
            var day = new Day06(AdventOfCode2016.Inputs.Day06.testData);
            day.Run();
            Assert.Equal("easter", day.GetFirstResult());
            Assert.Equal("advent", day.GetSecondResult());
        }
    }
}