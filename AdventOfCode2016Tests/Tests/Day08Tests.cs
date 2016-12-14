using Xunit;
using AdventOfCode2016.Solutions;

namespace AdventOfCode2016Tests
{
    public class Day08Tests
    {
        [Fact]
        public void DrawRectTest()
        {
            var day = new Day08("", 3, 3);
            day.DrawRect(2, 2);
            var expected = new char[3, 3]{
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { ' ', ' ', ' '}
            };
            Assert.Equal(expected, day.GetBoard());
        }

        [Fact]
        public void RotateRowTest()
        {
            var day = new Day08("", 3, 3);
            day.DrawRect(2, 2);
            day.RotateRow(0);

            var expected = new char[3, 3]{
                { ' ', day.GetLightOnChar(), day.GetLightOnChar() },
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { ' ', ' ', ' '}
            };
            Assert.Equal(expected, day.GetBoard());
        }

        [Fact]
        public void RotateRowByTest()
        {
            var day = new Day08("", 3, 3);
            day.DrawRect(2, 2);
            day.RotateRowBy(1, 2);

            var expected = new char[3, 3]{
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { day.GetLightOnChar(), ' ', day.GetLightOnChar() },
                { ' ', ' ', ' '}
            };
            Assert.Equal(expected, day.GetBoard());
        }

        [Fact]
        public void RotateColumnTest()
        {
            var day = new Day08("", 3, 3);
            day.DrawRect(2, 2);
            day.RotateColumn(0);

            var expected = new char[3, 3]{
                { ' ', day.GetLightOnChar(), ' ' },
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { day.GetLightOnChar(), ' ', ' '}
            };
            Assert.Equal(expected, day.GetBoard());
        }

        [Fact]
        public void RotateColumnByTest()
        {
            var day = new Day08("", 3, 3);
            day.DrawRect(2, 2);
            day.RotateColumnBy(0, 2);

            var expected = new char[3, 3]{
                { day.GetLightOnChar(), day.GetLightOnChar(), ' ' },
                { ' ', day.GetLightOnChar(), ' ' },
                { day.GetLightOnChar(), ' ', ' '}
            };
            Assert.Equal(expected, day.GetBoard());
        }

        [Fact]
        public void RealDataTest()
        {
            string input = AdventOfCode2016.Inputs.Day08.realData;

            var day = new Day08(input);
            day.Run();

            Assert.Equal("116", day.GetFirstResult());
        }
    }
}