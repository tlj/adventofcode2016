using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day25 : Base
    {

        public Day25(string dayInput)
        {
            Init(dayInput);
        }

        public Day25(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day25.testData);
            }
            else
            {
                Init(Inputs.Day25.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}