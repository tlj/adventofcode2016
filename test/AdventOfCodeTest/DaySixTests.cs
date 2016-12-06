using Xunit;
using Days;

public class DaySixTests
{
    [Fact]
    public void ExampleTest()
    {
        var day = new Six(@"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar");
        day.Run();
        Assert.Equal("easter", day.GetFirstResult());
        Assert.Equal("advent", day.GetSecondResult());
    }

}