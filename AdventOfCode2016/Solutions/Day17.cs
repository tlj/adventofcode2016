using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode2016.Solutions
{
    public class Day17 : Base
    {
        
        public static MD5 md5;

        public Day17(string dayInput)
        {
            Init(dayInput);
        }

        public Day17(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day17.testData);
            }
            else
            {
                Init(Inputs.Day17.realData);
            }
        }

        public class Path
        {
            public int X;
            public int Y;
            public string Directions;
            private string Input;
            public int Steps;

            public Path(int x, int y, string directions, string input, int steps)
            {
                X = x;
                Y = y;
                Directions = directions;
                Input = input;
                Steps = steps;
            }

            public List<Path> Neighbours()
            {
                var ret = new List<Path>();

                if (X == 3 && Y == 3)
                {
                    return ret;
                }

                var openDoor = new char[] { 'b', 'c', 'd', 'e', 'f' };
                var hash = Utils.MD5.CalculateMd5(Input + Directions, Day17.md5).ToLower();

                if (Y > 0 && openDoor.Contains(hash[0]))
                {
                    ret.Add(new Solutions.Day17.Path(X, Y - 1, Directions + 'U', Input, Steps + 1));
                }
                if (Y < 3 && openDoor.Contains(hash[1]))
                {
                    ret.Add(new Solutions.Day17.Path(X, Y + 1, Directions + 'D', Input, Steps + 1));
                }
                if (X > 0 && openDoor.Contains(hash[2]))
                {
                    ret.Add(new Solutions.Day17.Path(X - 1, Y, Directions + 'L', Input, Steps + 1));
                }
                if (X < 3 && openDoor.Contains(hash[3]))
                {
                    ret.Add(new Solutions.Day17.Path(X + 1, Y, Directions + 'R', Input, Steps + 1));
                }

                return ret;
            }

        }

        public override void Run()
        {
            base.Run();

            md5 = MD5.Create();

            var path = new Path(0, 0, "", input, 0);
            var checkNext = new Queue<Path>();
            checkNext.Enqueue(path);

            Path longest = new Solutions.Day17.Path(0, 0, "", input, 0);
            Path shortest = new Solutions.Day17.Path(0, 0, "", input, -1);

            var count = 0;
            while (checkNext.Count > 0)
            {
                path = checkNext.Dequeue();
                if (path.X == 3 && path.Y == 3)
                {
                    if (shortest.Steps == -1)
                    {
                        shortest = path;
                    }
                    if (path.Steps > longest.Steps)
                    {
                        longest = path;
                    }
                }
                else
                {
                    var newPaths = path.Neighbours();
                    foreach (var np in newPaths)
                    {
                        checkNext.Enqueue(np);
                    }
                }
            }

            firstResult = shortest.Directions;
            secondResult = longest.Steps.ToString();
        }
    }
}