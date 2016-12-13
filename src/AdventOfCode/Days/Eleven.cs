using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System;

namespace Days
{
    public class State
    {
        public int elevatorFloor;
        public List<int[]> pairs;
        public List<string> log;
        public int depth;

        public State(int e, List<int[]> p, List<string> l, int d)
        {
            elevatorFloor = e;
            pairs = p;
            depth = d;
            log = l;
        }
    }

    public class Eleven : Base
    {

        private ulong checkedStates = 0;
        private int lowestCount = 1000000;
        private long startedAt;

        private Queue<State> possibleStates;
        private Dictionary<string, int> seenStates;

        public Eleven(string inputString)
        {
            input = inputString;
            inputs = input.Split('\n');
            possibleStates = new Queue<State>();
            startedAt = UnixTimeNow();
            seenStates = new Dictionary<string, int>();
        }

        private long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        public static List<int[]> GetPairs(string[] inputs)
        {
            var floor = 0;
            var pattern = "(?<generator>[a-z]+ generator)|(?<microchip>[a-z]+-compatible)";
            var regEx = new Regex(pattern);
            var map = new Dictionary<string, int[]>();

            foreach (var line in inputs) {
                MatchCollection matches = regEx.Matches(line);
                foreach (Match m in matches) {
                    if (m.ToString().Contains("generator")) {
                        var type = m.ToString().Split(' ');
                        if (!map.ContainsKey(type[0])) {
                            map.Add(type[0], new int[2]);
                        }
                        map[type[0]][0] = floor;
                    } else {
                        var type = m.ToString().Split('-');
                        if (!map.ContainsKey(type[0])) {
                            map.Add(type[0], new int[2]);
                        }
                        map[type[0]][1] = floor;                        
                    }
                } 
                floor++;
            }

            var pairs = new List<int[]>();
            foreach (var m in map) {
                pairs.Add(m.Value);
            }

            return pairs;
        }

        public static bool IsValid(List<int[]> pairs, int floor) 
        {
            var hasGenerator = false;
            var hasDanglingMicrochip = false;
            foreach (var p in pairs) {
                if (p[0] != floor && p[1] == floor) {
                    hasDanglingMicrochip = true;
                    if (hasGenerator) {
                        return false;
                    }
                }
                if (p[0] == floor) {
                    hasGenerator = true;
                    if (hasDanglingMicrochip) {
                        return false;
                    }
                }
            }
            return true;
        }

        private static string Normalize(List<int[]> pairs) 
        {
            var res = "";
            foreach (var p in pairs) {
                res += " " + String.Join(",", p);
            }
            return res;
        }

        private List<int[]> ClonePairs(List<int[]> pairs)
        {
            List<int[]> cloned = new List<int[]>(pairs.Count);
            pairs.ForEach((item) =>
            {
                cloned.Add((int[])item.Clone());
            });
            return cloned;
        }

        public List<List<int[]>> GetValidStates(List<int[]> pairs, int currentFloor, int newFloor, List<string> log)
        {
            checkedStates++;
            var result = new List<List<int[]>>();

            List<int[]> clonedPairs;

            for (var i = 0; i < pairs.Count; i++) {
                if (pairs[i][0] == currentFloor) {
                    clonedPairs = ClonePairs(pairs);
                    clonedPairs[i][0] = newFloor;
                    if (Validate(clonedPairs, currentFloor, newFloor)) {
                        result.Add(clonedPairs);
                    }
                }
                if (pairs[i][1] == currentFloor) {
                    clonedPairs = ClonePairs(pairs);
                    clonedPairs[i][1] = newFloor;
                    if (Validate(clonedPairs, currentFloor, newFloor)) {
                        result.Add(clonedPairs);
                    }                    
                }
                if (pairs[i][0] == currentFloor && pairs[i][1] == currentFloor) {
                    clonedPairs = ClonePairs(pairs);
                    clonedPairs[i][0] = newFloor;
                    clonedPairs[i][1] = newFloor;
                    if (Validate(clonedPairs, currentFloor, newFloor)) {
                        result.Add(clonedPairs);
                    }
                }
                
                for (var j = i + 1; j < pairs.Count; j++) {
                    if (pairs[i][0] == currentFloor && pairs[j][0] == currentFloor) {
                        clonedPairs = ClonePairs(pairs);
                        clonedPairs[i][0] = newFloor;
                        clonedPairs[j][0] = newFloor;
                        if (Validate(clonedPairs, currentFloor, newFloor)) {
                            result.Add(clonedPairs);
                        }                            
                    }
                    
                    if (pairs[i][1] == currentFloor && pairs[j][1] == currentFloor) {
                        clonedPairs = ClonePairs(pairs);
                        clonedPairs[i][1] = newFloor;
                        clonedPairs[j][1] = newFloor;
                        if (Validate(clonedPairs, currentFloor, newFloor)) {
                            result.Add(clonedPairs);
                        }                            
                    }
                    
                }
                
            }

            return result;
        }

        public bool Validate(List<int[]> pairs, int oldFloor, int newFloor)
        {
            return IsValid(pairs, oldFloor) && IsValid(pairs, newFloor);
        }

        public bool IsSolved(List<int[]> pairs)
        {
            foreach (var i in pairs) {
                if (i[0] != 3 || i[1] != 3) {
                    return false;
                }
            }
            return true;
        }

        public bool Solve(State sc)
        {
            if (sc.elevatorFloor < 0 || sc.elevatorFloor > 3) return false;

            if (checkedStates % 100000 == 0) {
                Console.WriteLine("Checked " + checkedStates + " states. " + Decimal.Divide(checkedStates, (UnixTimeNow() - startedAt) + 1) + " states/s");
            }
            int[] upDown = new int[2]{1,-1};

            foreach (var elevatorChange in upDown) {
                if (sc.elevatorFloor == 0 && elevatorChange < 0) continue; // reached the bottom
                if (sc.elevatorFloor == 3 && elevatorChange > 0) continue; // reached the top

                var newFloor = sc.elevatorFloor + elevatorChange;

                var validStates = GetValidStates(sc.pairs, sc.elevatorFloor, newFloor, sc.log);
                foreach (var vs in validStates) {
                    var normalized = Normalize(vs);
                    if (IsSolved(vs)) {
                        if (sc.depth <= lowestCount) {
                            lowestCount = sc.depth;
                            foreach (var l in sc.log) {
                                Console.WriteLine(l);
                            }
                            Console.WriteLine(normalized);
                        }
                        return true;
                    }

                    if (!seenStates.ContainsKey(normalized + newFloor))
                    {
                        var newLog = sc.log.GetRange(0, sc.log.Count);
                        newLog.Add(normalized);
                        possibleStates.Enqueue(new State(newFloor, vs, newLog, sc.depth + 1));
                        seenStates.Add(normalized + newFloor, 0);
                    }
                }
            }
            return false;
        }

        public override void Run()
        {
            var pairs = GetPairs(inputs);
            Solve(new State(0, pairs, new List<string>(), 1));

            while (possibleStates.Count > 0 && !Solve(possibleStates.Dequeue())) {
                
            }
            firstResult = lowestCount.ToString();
            //Console.WriteLine("Checked " + checkedStates + " states.");
        }

        private static void DumpPairs(List<int[]> pairs)
        {
            foreach (var fp in pairs) {
                Console.WriteLine("Pair: " + String.Join(", ", fp));
            }

        }
    }
}