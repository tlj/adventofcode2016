using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day19 : Base
    {

        public Day19(string dayInput)
        {
            Init(dayInput);
        }

        public Day19(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day19.testData);
            }
            else
            {
                Init(Inputs.Day19.realData);
            }
        }

        public static int GetNextElf(int currentElf, int elfCount)
        {
            var elf = currentElf + 1;
            if (elf > elfCount) {
                elf = 1;
            }
            return elf;
        }

        public static int GetElfWithPresentPart1(int elfCount)
        {
            var elfs = new Dictionary<int, int>();
            for (var i = 1; i <= elfCount; i++) {
                elfs.Add(i, 1);
            }
            var end = false;
            while (!end) {
                for (var i = 1; i <= elfCount; i++) {
                    if (elfs[i] == 0) continue;
                    var nextElf = GetNextElf(i, elfCount);
                    while (nextElf != i) {
                        if (elfs[nextElf] > 0) {
                            elfs[i] += elfs[nextElf];
                            elfs[nextElf] = 0;
                            break;
                        }
                        nextElf = GetNextElf(nextElf, elfCount);
                    }
                    if (nextElf == i) {
                        end = true;
                    }
                }
            }

            foreach (var elf in elfs) {
                if (elf.Value > 0) {
                    return elf.Key;
                }
            }
            return 0;
        }

        public override void Run()
        {
            base.Run();

            firstResult = GetElfWithPresentPart1(int.Parse(input)).ToString();
        }
    }
}