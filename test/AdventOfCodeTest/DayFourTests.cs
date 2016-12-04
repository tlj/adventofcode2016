using Xunit;
using Days;

public class DayFourTests
{
    [Fact]
    public void VerificationTest()
    {
        var day = new Four("");
        Assert.Equal(123, day.IsValidEncryption("aaaaa-bbb-z-y-x-123[abxyz]"));
        Assert.Equal(987, day.IsValidEncryption("a-b-c-d-e-f-g-h-987[abcde]"));
        Assert.Equal(404, day.IsValidEncryption("not-a-real-room-404[oarel]"));
        Assert.Equal(0, day.IsValidEncryption("totally-real-room-200[decoy]"));
    }

    [Fact]
    public void DecryptionTest()
    {
        var day = new Four("");
        Assert.Equal("very encrypted name", day.DecryptString("qzmt-zixmtkozy-ivhz", 343));
    }

    [Fact]
    public void RealDataTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DayFour.txt");
 
        var day = new Four(input);
        day.Run();

        Assert.Equal("173787", day.GetFirstResult());
        Assert.Equal("548", day.GetSecondResult());
    }

}