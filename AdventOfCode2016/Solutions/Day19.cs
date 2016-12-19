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

        public class Elf
        {
            public int Number { get; set; }
            public int Presents { get; set; }
            public Elf Next { get; set; }
            public Elf Previous { get; set; }
        }

        public int GetElfWithPresentsPart2(int elfCount)
        {
            Elf first = new Elf { Number = 1 };
            Elf across = null;

            var elf = first;
            for (var i = 1; i <= elfCount; i++) {
                if (i == elfCount) {
                    // Last elf must link to the first elf
                    elf.Next = first;
                } else {
                    // Create a new elf as the next one
                    elf.Next = new Elf { Number = i + 1, Previous = elf };
                }
                elf = elf.Next;  
                if (i == Math.Floor((decimal)(elfCount / 2))) {
                    // this is the elf across from the first elf
                    across = elf;
                }      
            }
            // First elf needs to link back to the last elf
            first.Previous = elf;

            int count = elfCount;
            while (elf.Next != elf) {
                // for the elf across, link the previous elf to the elf next to the one across
                across.Previous.Next = across.Next;
                // for the elf across, link the next elf to the elf before the one across, obliterating the 
                // one across from the ring, since no elf links to it anymore.
                across.Next.Previous = across.Previous;

                // update the across-elf
                across = (--count % 2) == 1 ? across.Next.Next : across.Next;

                elf = elf.Next;
            }

            return elf.Number;
        }

        public override void Run()
        {
            base.Run();

            firstResult = GetElfWithPresentPart1(int.Parse(input)).ToString();
            secondResult = GetElfWithPresentsPart2(int.Parse(input)).ToString();
        }
    }
}