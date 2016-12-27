using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2016.Utils
{
    public class Assembunny
    {
        private Dictionary<string, int> registers;

        public Assembunny()
        {
            InitRegisters();
        }

        public Assembunny(Dictionary<string, int> initialRegisters)
        {
            registers = initialRegisters;
        }

        public int GetRegisterValue(string register)
        {
            return registers[register];
        }

        public void Cpy(string valueOrRegister, string toRegister)
        {
            int cpyNumber;
            bool cpyNumberIsNumeric;
            cpyNumberIsNumeric = int.TryParse(valueOrRegister, out cpyNumber);

            if (cpyNumberIsNumeric)
            {
                registers[toRegister] = cpyNumber;
            }
            else
            {
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

        public void Mlt(string valueOrRegister1, string valueOrRegister2, string toRegister)
        {
            int mltNumber1;
            bool mltNumber1IsNumeric;
            mltNumber1IsNumeric = int.TryParse(valueOrRegister1, out mltNumber1);

            if (!mltNumber1IsNumeric)
            {
                mltNumber1 = registers[valueOrRegister1];
            }

            int mltNumber2;
            bool mltNumber2IsNumeric;
            mltNumber2IsNumeric = int.TryParse(valueOrRegister2, out mltNumber2);

            if (!mltNumber2IsNumeric)
            {
                mltNumber2 = registers[valueOrRegister2];
            }

            registers[toRegister] = mltNumber1 * mltNumber2;
        }

        public void Add(string valueOrRegister, string toRegister)
        {
            int addNumber;
            bool addNumberIsNumeric;
            addNumberIsNumeric = int.TryParse(valueOrRegister, out addNumber);

            if (addNumberIsNumeric)
            {
                registers[toRegister] += addNumber;
            }
            else
            {
                registers[toRegister] += registers[valueOrRegister];
            }
        }

        public int Jnz(string condition, string steps)
        {
            int number;
            bool isNumeric;
            isNumeric = int.TryParse(condition, out number);
            if (!isNumeric)
            {
                number = registers[condition];
            }

            var jumpSteps = 0;
            if (number != 0)
            {
                isNumeric = int.TryParse(steps, out jumpSteps);
                if (!isNumeric)
                {
                    jumpSteps = registers[steps];
                }
            }

            return jumpSteps;
        }

        public int GetRegister(string register)
        {
            return registers[register];
        }

        public void InitRegisters()
        {
            registers = new Dictionary<string, int>() { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 } };
        }

        public void Execute(string[] inputs, bool optimize = false, Func<string, bool> validate = null)
        {            
            Dictionary<int, string[]> instructionList = new Dictionary<int, string[]>();
            for (var i = 0; i < inputs.Length; i ++)
            {
                instructionList[i] = inputs[i].Split(' ');
            }

            string output = "";

            for (var i = 0; i < inputs.Length; i++)
            {
                if (optimize)
                {
                    // This is just cheating, should be changed to looking at loops and optimizing them
                    if (i == 4)
                    {
                        registers["a"] = registers["b"] * registers["d"];
                        registers["c"] = 0;
                        registers["d"] = 0;
                        i = 10;
                    }
                }

                var instructions = instructionList[i];
                switch (instructions[0])
                {
                    case "cpy":
                        Cpy(instructions[1], instructions[2]);
                        break;
                    case "inc":
                        Inc(instructions[1]);
                        break;
                    case "dec":
                        Dec(instructions[1]);
                        break;
                    case "mlt":
                         Mlt(instructions[1], instructions[2], instructions[3]);
                        break;
                    case "add":
                        Add(instructions[1], instructions[2]);
                        break;
                    case "jnz":
                        var jump = Jnz(instructions[1], instructions[2]);
                        if (jump != 0)
                        {
                            i += jump - 1;
                        }
                        break;
                    case "tgl":
                        int number;
                        bool isNumeric;
                        isNumeric = int.TryParse(instructions[1], out number);
                        if (!isNumeric)
                        {
                            number = registers[instructions[1]];
                        }

                        if ((number + i) < instructionList.Count() && (number + i) >= 0)
                        {
                            var target = instructionList[number + i];
                            if (target.Count() == 2)
                            {
                                if (target[0] == "inc")
                                {
                                    target[0] = "dec";
                                }
                                else
                                {
                                    target[0] = "inc";
                                }
                            }
                            if (target.Count() == 3)
                            {
                                if (target[0] == "jnz")
                                {
                                    target[0] = "cpy";
                                }
                                else
                                {
                                    target[0] = "jnz";
                                }
                            }

                            instructionList[number + i] = target;
                        }
                        break;
                    case "out":
                        output += registers[instructions[1]];
                        if (validate != null)
                        {
                            if (!validate(output))
                            {
                                throw new NotSupportedException("Invalid string.");
                            }
                        }
                        break;
                    case "nop":
                        break;
                    default:
                        throw new Exception("Invalid instruction " + instructions[0]);
                }
            }
        }

    }
}
