using Xunit;
using Days;

public class DaySevenTests
{
    [Fact]
    public void IsAbbaTest()
    {
        var day = new Seven("");
        Assert.True(day.IsAbba("abba"));
        Assert.True(day.IsAbba("eweabbaasff"));
        Assert.True(day.IsAbba("kjbddbksd"));
    }

    public void IsTlsTest()
    {
        var day = new Seven("");
        Assert.True(day.IsTls("abba[mnop]qrst"));
        Assert.False(day.IsTls("abcd[bddb]xyyx"));
        Assert.False(day.IsTls("aaaa[qwer]tyui"));
        Assert.True(day.IsTls("ioxxoj[asdfgh]zxcvbn"));
        Assert.True(day.IsTls("ipseqmdzbeeqjsnvo[qxgatjiqzhwulhgkjm]syofcufklnbeobppx[lbmkistwoiolecjh]qpznlrllrkhxrnyvf[zbhzvyjqzywdpvh]thlrfwmziexkhxgp"));

    }

    public void Example1Test()
    {
        var day = new Seven(@"abba[mnop]qrst
abcd[bddb]xyyx
aaaa[qwer]tyui
ioxxoj[asdfgh]zxcvbn
ipseqmdzbeeqjsnvo[qxgatjiqzhwulhgkjm]syofcufklnbeobppx[lbmkistwoiolecjh]qpznlrllrkhxrnyvf[zbhzvyjqzywdpvh]thlrfwmziexkhxgp");
        day.Run();
        Assert.Equal("3", day.GetFirstResult());        
    }

    [Fact]
    public void RealDataTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DaySeven.txt");
 
        var day = new Seven(input);
        day.Run();

        Assert.Equal("118", day.GetFirstResult());
        //Assert.Equal("548", day.GetSecondResult());
    }

}