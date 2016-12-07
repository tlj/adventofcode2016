using Xunit;
using Days;

public class DaySevenTests
{
    [Fact]
    public void IsAbbaTest()
    {
        Assert.True(Seven.IsAbba("abba"));
        Assert.True(Seven.IsAbba("eweabbaasff"));
        Assert.True(Seven.IsAbba("kjbddbksd"));
    }

    [Fact]
    public void IsTlsTest()
    {
        Assert.True(Seven.IsTls("abba[mnop]qrst"));
        Assert.False(Seven.IsTls("abcd[bddb]xyyx"));
        Assert.False(Seven.IsTls("aaaa[qwer]tyui"));
        Assert.True(Seven.IsTls("ioxxoj[asdfgh]zxcvbn"));
        Assert.True(Seven.IsTls("ipseqmdzbeeqjsnvo[qxgatjiqzhwulhgkjm]syofcufklnbeobppx[lbmkistwoiolecjh]qpznlrllrkhxrnyvf[zbhzvyjqzywdpvh]thlrfwmziexkhxgp"));
    }

    [Fact]
    public void IsSslTest()
    {
        Assert.True(Seven.IsSsl("aba[bab]xyz"));
        Assert.False(Seven.IsSsl("xyx[xyx]xyx"));
        Assert.True(Seven.IsSsl("aaa[kek]eke"));
        Assert.True(Seven.IsSsl("zazbz[bzb]cdb"));
    }

    [Fact]
    public void FromAbaToBabTest()
    {
        Assert.Equal("bab", Seven.FromAbaToBab("aba"));
    }

    [Fact]
    public void GetAbaStringsTest()
    {
        Assert.Equal(2, Seven.GetAbaStrings("zazbz").Count);
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