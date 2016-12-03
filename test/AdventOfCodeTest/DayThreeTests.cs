using Xunit;
using Days;

public class DayThreeTests
{
    [Fact]
    public void Example1Test()
    {
        string input = "";
        
        var day = new Three(input);

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

        var day = new Three(input);
        day.Run();

        Assert.Equal("4", day.GetFirstResult());
    }

    [Fact]
    public void RealDataTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DayThree.txt");
        string expected = "1050";
 
        var day = new Three(input);
        day.Run();

        string actual = day.GetFirstResult();

        Assert.Equal(expected, actual);
    }
}