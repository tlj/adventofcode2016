using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day16 : Base
    {

        public Day16(string dayInput)
        {
            Init(dayInput);
        }

        public Day16(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day16.testData);
            }
            else
            {
                Init(Inputs.Day16.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}