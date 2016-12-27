using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{

    public class Day21Tests
    {
        [Fact]
        public void SwapPositionTest()
        {
            Assert.Equal("ebcda", Day21.SwapPosition("abcde", 0, 4));
        }
        
        [Fact]
        public void SwapLetterTest()
        {
            Assert.Equal("adcbe", Day21.SwapLetters("abcde", "b", "d"));
        }

        [Fact]
        public void RotateLeftTest()
        {
            Assert.Equal("bcdea", Day21.RotateLeft("abcde", 1));
            Assert.Equal("cdeab", Day21.RotateLeft("abcde", 12));
        }

        [Fact]
        public void RotateRightTest()
        {
            Assert.Equal("eabcd", Day21.RotateRight("abcde", 1));
            Assert.Equal("deabc", Day21.RotateRight("abcde", 12));
        }

        [Fact]
        public void RotateRightBasedOnPositionOfLetterTest()
        {
            Assert.Equal("deabc", Day21.RotateRightBasedOnPositionOfLetter("abcde", "b"));
            Assert.Equal("decab", Day21.RotateRightBasedOnPositionOfLetter("ecabd", "d"));
        }

        [Fact]
        public void ReversePositionsXThroughYTest()
        {
            Assert.Equal("adcbe", Day21.ReversePositionsXThroughY("abcde", 1, 3));
        }

        [Fact]
        public void MovePositionXToPositionYTest()
        {
            Assert.Equal("acdeb", Day21.MovePositionXToPositionY("abcde", 1, 4));
            Assert.Equal("bdeac", Day21.MovePositionXToPositionY("bcdea", 1, 4));
            Assert.Equal("abdec", Day21.MovePositionXToPositionY("bdeac", 3, 0));
            Assert.Equal("abcdgefh", Day21.MovePositionXToPositionY("abcdefgh", 6, 4));
        }
    }

}