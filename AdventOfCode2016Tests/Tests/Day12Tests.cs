using Xunit;
using AdventOfCode2016.Solutions;
using AdventOfCode2016.Utils;

namespace AdventOfCode2016Tests
{
    public class Day12Test
    {
        [Fact]
        public void SomeTest()
        {
            var asm = new Assembunny();
            asm.Cpy("0", "a");
            asm.Cpy("2", "b");
            asm.Cpy("0", "c");
            Assert.Equal(0, asm.GetRegister("a"));
            asm.Inc("a");
            Assert.Equal(1, asm.GetRegister("a"));
            asm.Cpy("b", "c");
            Assert.Equal(2, asm.GetRegister("c"));
            Assert.Equal(2, asm.Jnz("1", "2"));
            Assert.Equal(0, asm.Jnz("0", "2"));
            Assert.Equal(-2, asm.Jnz("c", "-2"));
            Assert.Equal(2, asm.Jnz("b", "2"));
            asm.Cpy("0", "c");
            Assert.Equal(0, asm.Jnz("c", "2"));
        }

    }
}