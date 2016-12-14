using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016.Tests
{

    public class Day14Tests
    {
        [Fact]
        public void ExampleTest()
        {
            Assert.Equal(39, Day14.GenerateKey(Inputs.Day14.testData, 1, 0));
            Assert.Equal(92, Day14.GenerateKey(Inputs.Day14.testData, 2, 0));
            Assert.Equal(10, Day14.GenerateKey(Inputs.Day14.testData, 1, 2016));
        }
    }

}