using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Solutions
{
    public class Day15 : Base
    {

        public Day15(string dayInput)
        {
            Init(dayInput);
        }

        public Day15(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day15.testData);
            }
            else
            {
                Init(Inputs.Day15.realData);
            }
        }
        
        public int CountDiscRotations(string[] lines)
        {
            var discs = new List<int[]>();
            var pattern = @"Disc #[0-9]+ has (?<maxPosition>[0-9]+) positions; at time=0, it is at position (?<startPosition>[0-9]+).";
            var rgx = new Regex(pattern);
            foreach (var line in lines) {
                Match match = rgx.Match(line);
                if (match.Success) {
                    discs.Add(new int[2] { int.Parse(match.Groups["startPosition"].Value), int.Parse(match.Groups["maxPosition"].Value) - 1 });
                }
            }

            var passCount = 0;
            var rotations = -1;
            while (passCount < discs.Count) {
                passCount = 0;
                rotations++;
                var j = 0;
                foreach (var disc in discs) {
                    j++;

                    var actualSteps = ((rotations + j) % (disc[1] + 1));
                    var currentPos = disc[0] + actualSteps;
                    if (currentPos > disc[1]) {
                        currentPos -= disc[1] + 1;
                    }
                    if (currentPos == 0) {
                        passCount++;
                    }
                }
            }
            return rotations;
        }

        public override void Run()
        {
            base.Run();

            firstResult = CountDiscRotations(inputs).ToString();

            var newInputs = (input + "\nDisc #7 has 11 positions; at time=0, it is at position 0.").Split('\n');

            secondResult = CountDiscRotations(newInputs).ToString();  
        }
    }
}