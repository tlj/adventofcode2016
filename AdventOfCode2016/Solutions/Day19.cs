using System;
using System.Collections.Generic;
using System.Linq;

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
            if (elf >= elfCount) {
                elf = 0;
            }
            return elf;
        }

        public static int GetElfWithPresentPart1(int elfCount)
        {
            var elfs = new int[elfCount];
            for (var i = 0; i < elfCount; i++) {
                elfs[i] = 1;
            }
            var end = false;
            while (!end) {
                for (var i = 0; i < elfCount; i++) {
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

            for (var i = 0; i < elfs.Length; i++) {
                if (elfs[i] > 0) return i + 1;
            }
            return 0;
        }

        public static int GetElfWithPresentPart2(int elfCount)
        {
            var elfs = new List<int>();
            for (var i = 0; i < elfCount; i++) {
                elfs.Add(i + 1);
            }

            while (elfs.Count > 1) {
                for (var i = 0; i < elfs.Count; i++) {
                    int elfAcross = i + (int)Math.Floor((decimal)(elfs.Count / 2));
                    if (elfAcross >= elfs.Count) {
                        elfAcross = elfAcross - elfs.Count;
                    }

                    elfs.RemoveAt(elfAcross);
                    if (elfAcross < i) {
                        i--;
                    }

                    if (elfs.Count % 10000 == 0) {
                        Console.WriteLine(elfs.Count);
                    }
                }
            }
            return elfs[0];
        }

        public override void Run()
        {
            base.Run();

            firstResult = GetElfWithPresentPart1(int.Parse(input)).ToString();
            secondResult = GetElfWithPresentPart2(int.Parse(input)).ToString();
        }
    }
}