using AdventOfCode2016.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using static AdventOfCode2016.Utils.Astar;

namespace AdventOfCode2016.Solutions
{

    public class Day13 : Base
    {
        private int favoriteNumber;

        public Day13(string inputString)
        {
            Init(inputString);
            Setup();
        }

        public Day13(bool useTestData)
        {
            if (useTestData)
            {
                Init(Inputs.Day13.testData);
            }
            else
            {
                Init(Inputs.Day13.realData);
            }
            Setup();
        }

        private void Setup()
        {
            favoriteNumber = int.Parse(input);
        }

        public override void Run()
        {
            base.Run();

            var map = GenerateMap(45, 45);
            var astar = new Astar(map);
            var path = astar.GetPathFromTo(map[1, 1], map[39, 31]);
            firstResult = path.Cost.ToString();

            var fiftyLocations = 0;

            // lol, this is butt ugly but a consequence of astaring it.
            var secondAstar = new Astar(map);
            for (var y = 0; y < map.GetLength(0); y++)
            {
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x].IsOpen)
                    {
                        var p = secondAstar.GetPathFromTo(map[1, 1], map[y, x]);
                        if (p != null && p.Cost <= 50) fiftyLocations++;
                    }
                }
            }
            secondResult = fiftyLocations.ToString();

            Animate(map, path, astar);
        }

        public static bool IsOpen(int x, int y, int favoriteNumber)
        {
            var countOnes = 0;
            int sum = ((x * x) + (3 * x) + (2 * x * y) + (y) + (y * y)) + favoriteNumber;
            var binary = Convert.ToString(sum, 2);

            foreach (var c in binary)
            {
                if (c == '1')
                {
                    countOnes++;
                }
            }

            return (countOnes & 1) == 0;
        }

        public MapSquare[,] GenerateMap(int sizeX, int sizeY)
        {
            MapSquare[,] map = new MapSquare[sizeY, sizeX];
            for (var y = 0; y < map.GetLength(0); y++)
            {
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = new MapSquare(x, y, 0, IsOpen(x, y, favoriteNumber));
                }
            }
            return map;
        }

        public void Animate(MapSquare[,] map, Path path, Astar astar)
        {
            var successFullSquares = new List<MapSquare>();
            while (path != null)
            {
                successFullSquares.Add(path.CurrentSquare);
                path = path.ParentPath;
            }
            successFullSquares.Reverse();

            Console.Clear();
            for (var y = 0; y < map.GetLength(0); y++)
            {
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (!map[y, x].IsOpen)
                    {
                        Console.Write('#');
                    }
                }
            }

            foreach (var considered in astar.SquaresConsidered)
            {
                Console.SetCursorPosition(considered.X, considered.Y);
                if (successFullSquares.Contains(considered))
                {
                    Console.Write('O');
                }
                else
                {
                    Console.Write('.');
                }
                Thread.Sleep(10);
            }

            Console.SetCursorPosition(0, 52);
        }

    }
}
