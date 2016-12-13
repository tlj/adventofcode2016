using System;
using System.Collections.Generic;

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

        public override void Run()
        {
            base.Run();

        }
    }
}