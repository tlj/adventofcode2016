using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day18 : Base
    {

        public Day18(string dayInput)
        {
            Init(dayInput);
        }

        public Day18(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day18.testData);
            }
            else
            {
                Init(Inputs.Day18.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}