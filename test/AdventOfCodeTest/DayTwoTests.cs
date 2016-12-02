using System;
using Xunit;
using Days;

public class DayTwoTests
{
    [Fact]
    public void Example1Test()
    {
        string input = @"ULL
RRDDD
LURDL
UUUUD";
        
        var day = new Two(input);
        day.Run();

        string expected = "1985";
        string actual = day.GetFirstResult();

        Assert.Equal(expected, actual);
    }


    [Fact]
    public void RealDataTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DayTwo.txt");
        string expected = "53255";
 
        var day = new Two(input);
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
        string input = @"ULL
RRDDD
LURDL
UUUUD";
        
        var day = new Two(input);
        day.Run();

        string expected = "5DB3";
        string actual = day.GetSecondResult();

        Assert.Equal(expected, actual);
    }
}