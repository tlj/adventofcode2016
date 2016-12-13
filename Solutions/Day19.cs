using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day19 : Base
    {

        public Day19(string dayInput)
        {
            Init(dayInput);
        }

        public Day19(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day19.testData);
            }
            else
            {
                Init(Inputs.Day19.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}