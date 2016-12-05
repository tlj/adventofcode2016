using Xunit;
using Days;

public class DayFiveTests
{
    [Fact]
    public void FirstExampleTest()
    {
        var day = new Five("");
        Assert.Equal("18f47a30", day.FindPassword("abc"));
        Assert.Equal("05ace8e3", day.FindSecondPassword("abc"));
    }

}