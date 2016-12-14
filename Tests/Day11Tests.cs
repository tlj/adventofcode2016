using Xunit;
using AdventOfCode2016.Solutions;
using System.Collections.Generic;

namespace AdventOfCode2016.Tests
{

    public class Day11Tests
    {
        [Fact]
        public void IsValidTests()
        {
            var input = new List<int[]>() { new int[2] { 0, 1 }, new int[2] { 0, 1 } };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));

            input = new List<int[]>() {
                new int[2]{0,1},
                new int[2]{0,1},
                new int[2]{1,1}
            };
            Assert.Equal(false, Day11.IsValid(input, 1));

            input = new List<int[]>() {
                new int[2]{0,0},
                new int[2]{1,1},
                new int[2]{1,1},
                new int[2]{2,2},
                new int[2]{2,2}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,2},
                new int[2]{2,0}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{1,1},
                new int[2]{2,0}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,1},
                new int[2]{2,0}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,0},
                new int[2]{2,0}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,1},
                new int[2]{2,1}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,2},
                new int[2]{2,2}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));

            input = new List<int[]>() {
                new int[2]{2,3},
                new int[2]{2,3}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));
            Assert.Equal(true, Day11.IsValid(input, 3));

            input = new List<int[]>() {
                new int[2]{2,2},
                new int[2]{2,3}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));
            Assert.Equal(true, Day11.IsValid(input, 3));

            input = new List<int[]>() {
                new int[2]{3,2},
                new int[2]{3,3}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));
            Assert.Equal(true, Day11.IsValid(input, 3));

            input = new List<int[]>() {
                new int[2]{3,2},
                new int[2]{3,3}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));
            Assert.Equal(true, Day11.IsValid(input, 3));

            input = new List<int[]>() {
                new int[2]{3,3},
                new int[2]{3,3}
            };
            Assert.Equal(true, Day11.IsValid(input, 0));
            Assert.Equal(true, Day11.IsValid(input, 1));
            Assert.Equal(true, Day11.IsValid(input, 2));
            Assert.Equal(true, Day11.IsValid(input, 3));

        }
    }
}