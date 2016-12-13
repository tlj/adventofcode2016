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

        public override void Run()
        {
            base.Run();

        }
    }
}