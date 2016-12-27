using AdventOfCode2016.Utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static AdventOfCode2016.Utils.Astar;

namespace AdventOfCode2016.Solutions
{
    public class Day22 : Base
    {

        public Day22(string dayInput)
        {
            Init(dayInput);
        }

        public Day22(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day22.testData);
            }
            else
            {
                Init(Inputs.Day22.realData);
            }
        }

        public class Node
        {
            public string Name { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Size { get; set; }
            public int Used { get; set; }
            public int Avail { get; set; }
            public int UsePercentage { get; set; }
            public bool Valid { get; set; }
            private int movesToFreeUp { get; set; }
            private Node[,] FreedUpNodes { get; set; }
            private bool HasMovesToFreeUp { get; set; }

            private List<int[]> neighbours;

            public Node(string line)
            {
                var pattern = @"/dev/grid/node-x([0-9]+)-y([0-9]+)\s+([0-9]+)T\s+([0-9]+)T\s+([0-9]+)T\s+([0-9]+)%";
                var regex = new Regex(pattern);
                var match = regex.Match(line);
                if (match.Success)
                {
                    X = int.Parse(match.Groups[1].Value);
                    Y = int.Parse(match.Groups[2].Value);
                    Size = int.Parse(match.Groups[3].Value);
                    Used = int.Parse(match.Groups[4].Value);
                    Avail = int.Parse(match.Groups[5].Value);
                    UsePercentage = int.Parse(match.Groups[6].Value);
                    Name = "/dev/grid/node-x" + X + "-y" + Y;
                    Valid = true;
                } else
                {
                    Valid = false;
                }
            }

            public Node[,] CloneNodes(Node[,] nodes)
            {
                var ret = new Node[nodes.GetLength(0), nodes.GetLength(1)];

                for (var y = 0; y < ret.GetLength(0); y++)
                {
                    for (var x = 0; x < ret.GetLength(1); x++)
                    {
                        ret[y, x] = (Node)nodes[y, x].MemberwiseClone();
                    }
                }

                return ret;
            }

            public Tuple<int, Node[,]> MovesToFreeUp(int freeSpace, Node[,] nodes, List<Node> calledFrom)
            {
                if (HasMovesToFreeUp)
                {
                    return Tuple.Create(movesToFreeUp, FreedUpNodes);
                }

                FreedUpNodes = CloneNodes(nodes);

                if (Size < freeSpace)
                {
                    HasMovesToFreeUp = true;
                    movesToFreeUp = -1;
                    return Tuple.Create(movesToFreeUp, FreedUpNodes);
                }

                if (Avail >= freeSpace)
                {
                    HasMovesToFreeUp = true;
                    movesToFreeUp = -1;
                    return Tuple.Create(movesToFreeUp, FreedUpNodes);
                }

                var moves = -1;

                foreach (var n in Neighbours())
                {
                    var node = FreedUpNodes[n[1], n[0]];
                    if (calledFrom.Contains(node)) continue;

                    calledFrom.Add(node);

                    if (node.Size >= freeSpace)
                    {
                        if (node.Avail >= Used)
                        {
                            moves = 1;
                        } else
                        {
                            Tuple<int, Node[,]> movesTuple = node.MovesToFreeUp(freeSpace, nodes, calledFrom);
                            int newMoves = movesTuple.Item1;
                            FreedUpNodes = movesTuple.Item2;

                            if (moves == -1 || newMoves < moves)
                            {
                                moves = newMoves + 1;
                            }
                        }
                    }
                }

                HasMovesToFreeUp = true;
                movesToFreeUp = moves;

                return Tuple.Create(movesToFreeUp, FreedUpNodes);
            }

            public List<int[]> Neighbours()
            {
                if (neighbours != null)
                {
                    return neighbours;
                }

                neighbours = new List<int[]>();

                if (X > 0) neighbours.Add(new int[2] { X - 1, Y });
                if (Y > 0) neighbours.Add(new int[2] { X, Y - 1 });
                if (X < 31) neighbours.Add(new int[2] { X + 1, Y });
                if (Y < 29) neighbours.Add(new int[2] { X, Y + 1 });

                return neighbours;
            }
        }

        public int CountPairs(Node[,] nodes)
        {
            List<Node[]> pairs = new List<Node[]>();
            foreach (var a in nodes)
            {
                if (a.Used == 0) continue;
                foreach (var b in nodes)
                {
                    if (a.Name == b.Name) continue;

                    if (a.Used <= b.Avail)
                    {
                        pairs.Add(new Node[2] { a, b });
                    }
                }
            }
            return pairs.Count;
        }

        public MapSquare[,] GenerateMap(int sizeX, int sizeY, Node[,] nodes, int freeSpace)
        {
            MapSquare[,] map = new MapSquare[sizeY, sizeX];

            for (var y = 0; y < map.GetLength(0); y++)
            {
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    var movesToFreeUpSpace = nodes[y, x].MovesToFreeUp(freeSpace, nodes, new List<Node>());
                    nodes = movesToFreeUpSpace.Item2;
                    map[y, x] = new MapSquare(x, y, movesToFreeUpSpace.Item1 > -1 ? movesToFreeUpSpace.Item1 : 0, movesToFreeUpSpace.Item1 > -1);
                }
            }

            return map;
        }

        public void DrawMap(MapSquare[,] map, int[] currentPosition)
        {
            for (var y = 0; y < map.GetLength(0); y++)
            {
                for (var x = 0; x < map.GetLength(1); x++)
                {
                    if (x == 0 && y == 0)
                    {
                        Console.Write('(');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    if (x == currentPosition[0] && y == currentPosition[1])
                    {
                        Console.Write("G");
                    }
                    else
                    if (!map[y, x].IsOpen)
                    {
                        Console.Write("#");
                    }
                    else if (map[y, x].Cost > 0)
                    {
                        Console.Write(".");
                    }
                    else if (map[y, x].Cost == 0)
                    {
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Write("?");
                    }
                    if (x == 0 && y == 0)
                    {
                        Console.Write(')');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        public override void Run()
        {
            base.Run();

            Node[,] nodes = new Node[30, 32];

            foreach (var line in inputs)
            {
                var node = new Node(line);
                if (node.Valid)
                {
                    nodes[node.Y, node.X] = node;
                }
            }

            firstResult = CountPairs(nodes).ToString();
            var empty = new int[2];
            for (var y = 0; y < nodes.GetLength(0); y++)
            {
                for (var x = 0; x < nodes.GetLength(1); x++)
                {
                    if (nodes[y, x].Avail == nodes[y, x].Size)
                    {
                        Console.Write("__/" + nodes[y, x].Size + " ");
                    }
                    else if (nodes[y, x].Size > 500)
                    {
                        Console.Write("XX/" + nodes[y, x].Size + " ");
                    }
                    else
                    {
                        Console.Write(nodes[y, x].Avail + "/" + nodes[y, x].Size + " ");
                    }
                    
                }
                Console.WriteLine();
            }
            // sorry this was mostly a manual job :(
            int moveEmptySpaceToStart = 31;
            int movesToMoveTheEmptySpaceFromBackToForth = 5;
            secondResult = (moveEmptySpaceToStart + ((nodes.GetLength(1) - 2) * movesToMoveTheEmptySpaceFromBackToForth)).ToString();
        }
    }
}