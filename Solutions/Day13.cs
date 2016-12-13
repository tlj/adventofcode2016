using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2016.Solutions
{
    public class PathState
    {
        private int d;
        private int[] coordinates;

        public PathState(int x, int y, int depth)
        {
            coordinates = new int[2] { x, y };
            d = depth;
        }

        public string Normalize()
        {
            return coordinates[0] + "x" + coordinates[1];
        }

        public int X()
        {
            return coordinates[0];
        }

        public int Y()
        {
            return coordinates[1];
        }

        public int Depth()
        {
            return d;
        }

        public bool Valid()
        {
            return (X() >= 0 && X() < 100 && Y() >= 0 && Y() < 100);
        }
    }

    public class Day13 : Base
    {
        private int favoriteNumber;
        private Queue<PathState> possiblePaths;
        private Dictionary<string, int> pathsDiscovered;
        private int lessThanFifty = 0;

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
            pathsDiscovered = new Dictionary<string, int>();
            possiblePaths = new Queue<PathState>();
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

        public List<int[]> FindPossiblePaths(PathState startState)
        {
            if (startState.X() == 31 && startState.Y() == 39)
            {
                firstResult = startState.Depth().ToString();
            }
            if (startState.Depth() <= 50)
            {
                lessThanFifty++;
            }

            var ret = new List<int[]>();
            var directions = new int[2] { 1, -1 };
            PathState state;
            foreach (var dir in directions)
            {
                state = new PathState(startState.X() + dir, startState.Y(), startState.Depth() + 1);
                if (state.Valid() && IsOpen(state.X(), state.Y(), favoriteNumber) && !pathsDiscovered.ContainsKey(state.Normalize()))
                {
                    possiblePaths.Enqueue(state);
                    pathsDiscovered.Add(state.Normalize(), 0);
                }
                state = new PathState(startState.X(), startState.Y() + dir, startState.Depth() + 1);
                if (state.Valid() && IsOpen(state.X(), state.Y(), favoriteNumber) && !pathsDiscovered.ContainsKey(state.Normalize()))
                {
                    possiblePaths.Enqueue(state);
                    pathsDiscovered.Add(state.Normalize(), 0);
                }
            }
            return ret;
        }

        public override void Run()
        {
            base.Run();

            int xs = 1;
            int ys = 1;
            PathState initialState = new Solutions.PathState(xs, ys, 0);

            FindPossiblePaths(initialState);
            pathsDiscovered.Add(initialState.Normalize(), 0);

            while (possiblePaths.Count > 0)
            {
                FindPossiblePaths(possiblePaths.Dequeue());
            }

            secondResult = lessThanFifty.ToString();
        }
    }
}
