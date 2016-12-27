using AdventOfCode2016.Utils;
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

            var firstProgram = new Assembunny(new Dictionary<string, int>() { { "a", 7 }, { "b", 0 }, { "c", 0 }, { "d", 0 } });
            firstProgram.Execute((string[])inputs.Clone());
            firstResult = firstProgram.GetRegisterValue("a").ToString();

            var secondProgram = new Assembunny(new Dictionary<string, int>() { { "a", 12 }, { "b", 0 }, { "c", 0 }, { "d", 0 } });
            secondProgram.Execute((string[])inputs.Clone(), true);
            secondResult = secondProgram.GetRegisterValue("a").ToString();
        }
    }
}