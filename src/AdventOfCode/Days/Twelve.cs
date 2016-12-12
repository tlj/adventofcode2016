using System;
using System.Collections.Generic;

namespace Days
{
    public class Twelve : Base
    {
        private Dictionary<string, int> registers;

        public Twelve(string inputString)
        {
            input = inputString;
            inputs = input.Split('\n');
            registers = new Dictionary<string, int>();
        }

        public int GetRegister(string register)
        {
            return registers[register];
        }

        public void Cpy(string valueOrRegister, string toRegister)
        {
            int cpyNumber;
            bool cpyNumberIsNumeric;
            cpyNumberIsNumeric = int.TryParse(valueOrRegister, out cpyNumber);

            if (!registers.ContainsKey(toRegister)) {
                registers.Add(toRegister, 0);
            }
            if (cpyNumberIsNumeric) {
                registers[toRegister] = cpyNumber;
            } else {
                registers[toRegister] = registers[valueOrRegister];
            }
        }

        public void Inc(string register)
        {
            if (!registers.ContainsKey(register)) {
                registers.Add(register, 0);
            }
            registers[register]++;   
        }

        public void Dec(string register)
        {
            if (!registers.ContainsKey(register)) {
                registers.Add(register, 0);
            }
            registers[register]--;   
        }

        public int Jnz(string condition, string steps) 
        {
            int number;
            bool isNumeric;
            isNumeric = int.TryParse(condition, out number);
            if (!isNumeric) {
                if (!registers.ContainsKey(condition)) {
                    registers.Add(condition, 0);
                }
                number = registers[condition];
            } 
            
            var jumpSteps = 0;
            if (number != 0) {
                var jnz = int.Parse(steps);
                jumpSteps = jnz;
            }

            return jumpSteps;
        }

        public override void Run()
        {
            base.Run();

            Execute();
            firstResult = registers["a"].ToString();

            registers = new Dictionary<string, int>();
            registers["c"] = 1;

            Execute();
            secondResult = registers["a"].ToString();
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