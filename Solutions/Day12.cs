using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day12 : Base
    {
        private Dictionary<string, int> registers;

        public Day12(string inputString)
        {
            Init(inputString);
            InitRegisters();
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
            InitRegisters();
        }

        public void Cpy(string valueOrRegister, string toRegister)
        {
            int cpyNumber;
            bool cpyNumberIsNumeric;
            cpyNumberIsNumeric = int.TryParse(valueOrRegister, out cpyNumber);

            if (cpyNumberIsNumeric) {
                registers[toRegister] = cpyNumber;
            } else {
                registers[toRegister] = registers[valueOrRegister];
            }
        }

        public void Inc(string register)
        {
            registers[register]++;   
        }

        public void Dec(string register)
        {
            registers[register]--;   
        }

        public int Jnz(string condition, string steps) 
        {
            int number;
            bool isNumeric;
            isNumeric = int.TryParse(condition, out number);
            if (!isNumeric) {
                number = registers[condition];
            } 
            
            var jumpSteps = 0;
            if (number != 0) {
                jumpSteps = int.Parse(steps);
            }

            return jumpSteps;
        }

        public int GetRegister(string register)
        {
            return registers[register];
        }

        public override void Run()
        {
            base.Run();

            // First Part
            InitRegisters();
            Execute();
            firstResult = registers["a"].ToString();

            // Second Part
            InitRegisters();
            registers["c"] = 1;
            Execute();
            secondResult = registers["a"].ToString();
        }

        public void InitRegisters()
        {
            registers = new Dictionary<string, int>(){ { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 } };
        }

        public void Execute()
        {
            for (var i = 0; i < inputs.Length; i++) {
                var instructions = inputs[i].Split(' ');
                switch (instructions[0]) {
                    case "cpy":
                        Cpy(instructions[1], instructions[2]);
                        break;
                    case "inc":
                        Inc(instructions[1]);
                        break;
                    case "dec":
                        Dec(instructions[1]);
                        break;
                    case "jnz":
                        var jump = Jnz(instructions[1], instructions[2]);
                        if (jump != 0) {
                            i += jump - 1;
                        }
                        break;
                }
            }
        }
    }
}