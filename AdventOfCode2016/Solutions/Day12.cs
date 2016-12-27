using AdventOfCode2016.Utils;
using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day12 : Base
    {

        public Day12(string inputString)
        {
            Init(inputString);
        }

        public Day12(bool useTestData)
        {
            if (useTestData)
            {
                Init(Inputs.Day12.testData);
            } else
            {
                Init(Inputs.Day12.realData);
            }
        }

        public override void Run()
        {
            base.Run();

            // First Part
            var firstProgram = new Assembunny();
            firstProgram.Execute(inputs);
            firstResult = firstProgram.GetRegisterValue("a").ToString();

            // Second Part
            var secondProgram = new Assembunny(new Dictionary<string, int>() { { "a", 0 }, { "b", 0 }, { "c", 1 }, { "d", 0 } });
            secondProgram.Execute(inputs);
            secondResult = secondProgram.GetRegisterValue("a").ToString();
        }
    }
}