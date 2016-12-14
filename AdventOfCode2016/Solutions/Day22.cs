using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day22 : Base
    {

        public Day22(string dayInput)
        {
            Init(dayInput);
        }

        public Day22(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day22.testData);
            }
            else
            {
                Init(Inputs.Day22.realData);
            }
        }

        public override void Run()
        {
            base.Run();

        }
    }
}