using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day23 : Base
    {

        public Day23(string dayInput)
        {
            Init(dayInput);
        }

        public Day23(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day23.testData);
            }
            else
            {
                Init(Inputs.Day23.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}