
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Solutions
{
    public class Day06 : Base
    {
        public Day06(string inputString)
        {
            Init(inputString);
        }

        public Day06(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day06.testData);
            }
            else
            {
                Init(Inputs.Day06.realData);
            }
        }

        public override void Run()
        {
            for (var i = 0; i < inputs[0].Length; i++) {
                var occurances = new Dictionary<char, int>();

                foreach (var line in inputs) {
                    if (occurances.ContainsKey(line[i])) {
                        occurances[line[i]] += 1;
                    } else {
                        occurances.Add(line[i], 1);
                    }
                }
                var sortedOccurances = from entry in occurances 
                    orderby entry.Value descending                     
                    select entry;
                firstResult += sortedOccurances.First().Key;
                secondResult += sortedOccurances.Last().Key;
            }
        }
    }
}