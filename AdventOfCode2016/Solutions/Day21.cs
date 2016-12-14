using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day21 : Base
    {

        public Day21(string dayInput)
        {
            Init(dayInput);
        }

        public Day21(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day21.testData);
            }
            else
            {
                Init(Inputs.Day21.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}