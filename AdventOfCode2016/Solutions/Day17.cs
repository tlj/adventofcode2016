using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day17 : Base
    {

        public Day17(string dayInput)
        {
            Init(dayInput);
        }

        public Day17(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day17.testData);
            }
            else
            {
                Init(Inputs.Day17.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}