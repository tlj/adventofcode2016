using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day14 : Base
    {

        public Day14(string dayInput)
        {
            Init(dayInput);
        }

        public Day14(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day14.testData);
            }
            else
            {
                Init(Inputs.Day14.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}