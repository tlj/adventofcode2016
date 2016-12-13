using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day24 : Base
    {

        public Day24(string dayInput)
        {
            Init(dayInput);
        }

        public Day24(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day24.testData);
            }
            else
            {
                Init(Inputs.Day24.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}