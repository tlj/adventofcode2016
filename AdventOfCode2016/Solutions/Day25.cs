using AdventOfCode2016.Utils;
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

        public class VeryLongException : System.Exception
        {
            public VeryLongException(string message) : base(message) { }
        }

        public bool ValidateOutput(string output)
        {
            if (output.Length < 2) return true;

            if (output.Substring(output.Length - 2, 2) == "01" || output.Substring(output.Length - 2, 2) == "10")
            {
                if (output.Length > 100)
                {
                    throw new VeryLongException(output);
                }
                return true;
            }
            return false;
        }

        public override void Run()
        {
            base.Run();

            var loop = false;
            var i = -1;
            while (!loop)
            {
                i++;
                var asm = new Assembunny(new Dictionary<string, int>() { { "a", i }, { "b", 0 }, { "c", 0 }, { "d", 0 } });
                try
                {
                    asm.Execute(inputs, false, ValidateOutput);
                } catch (NotSupportedException)
                {
                } catch (VeryLongException e)
                {
                    loop = true;
                }
            }
            firstResult = i.ToString();

        }
    }
}