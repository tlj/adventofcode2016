using System;
using Xunit;
using Days;

public class DayOneTests
{
    [Fact]
    public void Example1Test()
    {
        string input = "R2, L3";
        int expected = 5;
        int actual = new One(input).Run();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Example2Test()
    {
        string input = "R2, R2, R2";
        int expected = 2;
        int actual = new One(input).Run();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Example3Test()
    {
        string input = "R5, L5, R5, R3";
        int expected = 12;
        int actual = new One(input).Run();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WithLongDistanceTest()
    {
        string input = "R2, L30";
        int expected = 32;
        int actual = new One(input).Run();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WithNegativeCoordinatesTest()
    {
        string input = "L2, L2";
        int expected = 4;
        int actual = new One(input).Run();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Example1VisitTwiceTest()
    {
        string input = "R8, R4, R4, R8";
        float expected = 4.0f;
        One day = new One(input);
        day.Run();
        float actual = day.GetFirstVisitedTwice();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RealDataDistanceTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DayOne.txt");
        int expected = 288;
        var dayOne = new One(input);
        int actual = dayOne.Run();

        Assert.Equal(expected, actual);

        float expectedTwice = 111.0f;
        float actualTwice = dayOne.GetFirstVisitedTwice();

        Assert.Equal(expectedTwice, actualTwice);

    }

}