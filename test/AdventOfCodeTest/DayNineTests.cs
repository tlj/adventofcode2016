using Xunit;
using Days;

public class DayNineTests
{
    [Fact]
    public void Version1Tests()
    {
        var day = new Nine("");
        Assert.Equal("ADVENT", day.Decompress("ADVENT", 1, false));
        Assert.Equal("ABBBBBC", day.Decompress("A(1x5)BC", 1, false));
        Assert.Equal("XYZXYZXYZ", day.Decompress("(3x3)XYZ", 1, false));
        Assert.Equal("ABCBCDEFEFG", day.Decompress("A(2x2)BCD(2x2)EFG", 1, false));
        Assert.Equal("(1x3)A", day.Decompress("(6x1)(1x3)A", 1, false));
        Assert.Equal("X(3x3)ABC(3x3)ABCY", day.Decompress("X(8x2)(3x3)ABCY", 1, false));
    }

    [Fact]
    public void Version2Tests()
    {
        var day = new Nine("");
        day.Decompress("(3x3)XYZ", 2, false);
        Assert.Equal("9", day.GetSecondResult());

        day = new Nine("");
        day.Decompress("X(8x2)(3x3)ABCY", 2, false);
        Assert.Equal("20", day.GetSecondResult());

        day = new Nine("");
        day.Decompress("(27x12)(20x12)(13x14)(7x10)(1x12)A", 2, false);
        Assert.Equal("241920", day.GetSecondResult());

        day = new Nine("");
        day.Decompress("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 2, false);
        Assert.Equal("445", day.GetSecondResult());
    }
}