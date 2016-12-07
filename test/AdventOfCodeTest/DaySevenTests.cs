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

    [Fact]
    public void IsTlsTest()
    {
        var day = new Seven("");
        Assert.True(day.IsTls("abba[mnop]qrst"));
        Assert.False(day.IsTls("abcd[bddb]xyyx"));
        Assert.False(day.IsTls("aaaa[qwer]tyui"));
        Assert.True(day.IsTls("ioxxoj[asdfgh]zxcvbn"));
        Assert.True(day.IsTls("ipseqmdzbeeqjsnvo[qxgatjiqzhwulhgkjm]syofcufklnbeobppx[lbmkistwoiolecjh]qpznlrllrkhxrnyvf[zbhzvyjqzywdpvh]thlrfwmziexkhxgp"));
    }

    [Fact]
    public void IsSslTest()
    {
        var day = new Seven("");
        Assert.Equal(true, day.IsSsl("aba[bab]xyz"));
        Assert.Equal(false, day.IsSsl("xyx[xyx]xyx"));
        Assert.Equal(true, day.IsSsl("aaa[kek]eke"));
        Assert.Equal(true, day.IsSsl("zazbz[bzb]cdb"));
    }

    [Fact]
    public void Example1Test()
    {
        var day = new Seven(@"abba[mnop]qrst
abcd[bddb]xyyx
aaaa[qwer]tyui
ioxxoj[asdfgh]zxcvbn");
        day.Run();
        Assert.Equal("2", day.GetFirstResult());        
    }

    [Fact]
    public void RealDataTest()
    {
        string input = System.IO.File.ReadAllText("../../input/DaySeven.txt");
 
        var day = new Seven(input);
        day.Run();

        Assert.Equal("118", day.GetFirstResult());
        Assert.Equal("260", day.GetSecondResult());
    }

}