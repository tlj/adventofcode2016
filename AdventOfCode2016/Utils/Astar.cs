using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2016.Utils
{
    public class Astar
    {
        public MapSquare[,] Map { get; private set; }
        public List<MapSquare> SquaresConsidered { get; private set; }

        public class MapSquare
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Cost { get; set; }
            public bool IsOpen { get; private set; }

            public MapSquare(int x, int y, int cost, bool isOpen)
            {
                X = x;
                Y = y;
                Cost = cost;
                IsOpen = isOpen;
            }

            public int ManhattanDistance(MapSquare to)
            {
                return Math.Abs(to.X - X) + (to.Y - Y);
            }

            public double EuclideanDistance(MapSquare to)
            {
                double xd = X - to.X;
                double yd = Y - to.Y;
                return Math.Sqrt((xd * xd) + (yd * yd));
            }

            public List<MapSquare> Neighbours(MapSquare[,] map)
            {
                var ret = new List<MapSquare>();

                if (X + 1 < map.GetLength(1)) ret.Add(map[Y, X + 1]);
                if (Y + 1 < map.GetLength(0)) ret.Add(map[Y + 1, X]);

                if (X - 1 >= 0) ret.Add(map[Y, X - 1]);
                if (Y - 1 >= 0) ret.Add(map[Y - 1, X]);

                return ret;
            }
        }

        public class Path
        {
            public MapSquare CurrentSquare { get; private set; }
            public Path ParentPath { get; private set; }
            public double Cost { get; private set; }
            public double MovementCost { get; private set; }
            public double TotalCost { get; private set; }

            public Path(MapSquare currentSquare, Path parentPath, MapSquare targetSquare, double cost)
            {
                CurrentSquare = currentSquare;
                ParentPath = parentPath;
                Cost = cost + currentSquare.Cost;
                MovementCost = currentSquare.EuclideanDistance(targetSquare);
                TotalCost = Cost + MovementCost;
            }
        }

        public class CostComparer : IComparer<Path>
        {
            public int Compare(Path a, Path b)
            {
                return a.TotalCost.CompareTo(b.TotalCost);
            }
        }

        public Astar(MapSquare[,] map)
        {
            Map = map;
            SquaresConsidered = new List<MapSquare>();
        }

        public Path GetPathFromTo(MapSquare fromSquare, MapSquare toSquare)
        {
            var possiblePaths = new List<Path>();
            possiblePaths.Sort(new CostComparer());

            var seenSquares = new List<MapSquare>();
            var startPath = new Path(fromSquare, null, toSquare, 0);
            possiblePaths.Add(startPath);
            seenSquares.Add(fromSquare);

            var found = false;
            Path parentPath = startPath;
            Path currentPath = startPath;
            while (possiblePaths.Count > 0 && !found)
            {
                currentPath = possiblePaths.First();
                var currentSquare = currentPath.CurrentSquare;
                SquaresConsidered.Add(currentSquare);
                if (currentPath.CurrentSquare.X == toSquare.X && currentPath.CurrentSquare.Y == toSquare.Y)
                {
                    found = true;
                    break;
                }
                else
                {
                    foreach (var n in currentSquare.Neighbours(Map))
                    {
                        if (n.IsOpen && !seenSquares.Contains(n))
                        {
                            possiblePaths.Add(new Path(n, currentPath, toSquare, currentPath.Cost + 1.0));
                            seenSquares.Add(n);
                        }
                    }
                }
                possiblePaths.Remove(currentPath);
                possiblePaths.Sort(new CostComparer());
            }

            if (!found)
            {
                return null;
            }

            return currentPath;
        }
    }
}
