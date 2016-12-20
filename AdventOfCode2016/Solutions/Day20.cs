using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day20 : Base
    {

        public Day20(string dayInput)
        {
            Init(dayInput);
        }

        public Day20(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day20.testData);
            }
            else
            {
                Init(Inputs.Day20.realData);
            }
        }

        public string Part1()
        {
            uint highLow = uint.MinValue;

            var unchanged = false;
            while (!unchanged)
            {
                unchanged = true;
                foreach (var l in inputs)
                {
                    var vals = l.Split('-');
                    if (uint.Parse(vals[1]) >= highLow && uint.Parse(vals[0]) <= highLow)
                    {
                        highLow = uint.Parse(vals[1]) + 1;
                        unchanged = false;
                    }
                }
            }
            return highLow.ToString();
        }

        public string Part2()
        {
            var listInputs = new List<uint[]>();
            foreach (var l in inputs)
            {
                var vals = l.Split('-');
                listInputs.Add(new uint[2] { uint.Parse(vals[0]), uint.Parse(vals[1]) });
            }
            listInputs.Sort(delegate (uint[] x, uint[] y)
            {
                return x[0].CompareTo(y[0]);
            });

            var allowed = uint.MinValue;
            uint lastEnd = 0;

            foreach (var l in listInputs)
            {
                if (l[0] > lastEnd && lastEnd > 0) {
                    allowed += l[0] - lastEnd - 1;
                }
                if (l[1] > lastEnd) {
                    lastEnd = l[1];
                }
            }

            allowed = allowed + (uint.MaxValue - lastEnd);
            return allowed.ToString();           
        }

        public override void Run()
        {
            base.Run();

            firstResult = Part1();
            secondResult = Part2();           
        }

    }
}