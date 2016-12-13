using AdventOfCode2016.Solutions;
using System;

namespace AdventOfCode2016
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isTest = false;
            if (args.Length > 1 && args[1] == "test")
            {
                isTest = true;
            }
            if (args.Length < 1)
            {
                Console.WriteLine("Please add dayXX as param.");
                return;
            }
            switch (args[0])
            {
                case "day01":
                    new Day01(isTest).Output();
                    break;
                case "day02":
                    new Day02(isTest).Output();
                    break;
                case "day03":
                    new Day03(isTest).Output();
                    break;
                case "day04":
                    new Day04(isTest).Output();
                    break;
                case "day05":
                    new Day05(isTest).Output();
                    break;
                case "day06":
                    new Day06(isTest).Output();
                    break;
                case "day07":
                    new Day07(isTest).Output();
                    break;
                case "day08":
                    new Day08(isTest).Output();
                    break;
                case "day09":
                    new Day09(isTest).Output();
                    break;
                case "day10":
                    new Day10(isTest).Output();
                    break;
                case "day11":
                    new Day11(isTest).Output();
                    break;
                case "day12":
                    new Day12(isTest).Output();
                    break;
                case "day13":
                    new Day13(isTest).Output();
                    break;
                default:
                    Console.WriteLine("Invalid day.");
                    break;
            }
        }
    }
}
