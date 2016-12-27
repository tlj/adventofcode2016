using AdventOfCode2016.Utils;
using System;
using System.Collections.Generic;
using static AdventOfCode2016.Utils.Astar;
using System.Linq;

namespace AdventOfCode2016.Solutions
{
    public class Day24 : Base
    {

        public Day24(string dayInput)
        {
            Init(dayInput);
        }

        public Day24(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day24.testData);
            }
            else
            {
                Init(Inputs.Day24.realData);
            }
        }

        public override void Run()
        {
            base.Run();

            MapSquare[,] map = new MapSquare[inputs.Length, inputs[0].Length];
            Dictionary<int, int[]> waypoints = new Dictionary<int, int[]>();
            int[] startPosition =  new int[2];
            for (var y = 0; y < inputs.Length; y++)
            {
                for (var x = 0; x < inputs[y].Length; x++)
                {
                    map[y, x] = new MapSquare(x, y, 0, inputs[y][x] != '#');
                    int pos;
                    if (int.TryParse(inputs[y][x].ToString(), out pos))
                    {
                        if (pos == 0)
                        {
                            startPosition = new int[2] { x, y };
                        }
                        waypoints.Add(pos, new int[2] { x, y });                        
                    }
                }
            }

            var distances = new Dictionary<int, Dictionary<int, int>>();
            foreach (var wp in waypoints)
            {
                distances.Add(wp.Key, new Dictionary<int, int>());
            }

            foreach (var wp in waypoints)
            {
                foreach (var target in waypoints)
                {
                    if (wp.Key == target.Key)
                    {
                        continue;
                    }
                    if (!distances[target.Key].ContainsKey(wp.Key))
                    {
                        var astar = new Astar(map);
                        var path = astar.GetPathFromTo(map[wp.Value[1], wp.Value[0]], map[target.Value[1], target.Value[0]]);
                        distances[wp.Key].Add(target.Key, (int)path.Cost);
                    } else
                    {
                        distances[wp.Key].Add(target.Key, distances[target.Key][wp.Key]);
                    }
                }
            }
            firstResult = Cost(distances, new List<int>(), 0, 0).ToString();
            secondResult = Cost(distances, new List<int>(), 0, 0, true).ToString();
        }

        public int Cost(Dictionary<int, Dictionary<int, int>> distances, List<int> visited, int key, int cost, bool backToStart = false)
        {
            var lowest = 0;

            visited.Add(key);

            var count = 0;
            foreach (var d in distances)
            {
                if (d.Key == key) continue;

                if (!visited.Contains(d.Key))
                {
                    count++;
                    var c = Cost(distances, visited.GetRange(0, visited.Count()), d.Key, distances[key][d.Key], backToStart);
                    if (lowest == 0 || c < lowest)
                    {
                        lowest = c;
                    }
                }
            }
            if (count == 0 && backToStart)
            {
                lowest = distances[key][0];
            }

            return cost + lowest;
        }
    }
}