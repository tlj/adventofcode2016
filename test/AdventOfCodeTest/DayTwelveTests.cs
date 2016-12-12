using Xunit;
using Days;

public class DayTwelveTest
{
    [Fact]
    public void SomeTest()
    {
        var day = new Twelve("");
        day.Cpy("0", "a");
        day.Cpy("2", "b");
        day.Cpy("0", "c");
        Assert.Equal(0, day.GetRegister("a"));
        day.Inc("a");
        Assert.Equal(1, day.GetRegister("a"));
        day.Cpy("b", "c");
        Assert.Equal(2, day.GetRegister("c"));
        Assert.Equal(2, day.Jnz("1", "2"));
        Assert.Equal(0, day.Jnz("0", "2"));
        Assert.Equal(-2, day.Jnz("c", "-2"));
        Assert.Equal(2, day.Jnz("b", "2"));
        day.Cpy("0", "c");
        Assert.Equal(0, day.Jnz("c", "2"));
    }

}