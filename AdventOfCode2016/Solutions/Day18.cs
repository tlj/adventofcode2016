using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day18 : Base
    {
        const char TrapCharacter = '^';
        const char SafeCharacter = '.';

        public Day18(string dayInput)
        {
            Init(dayInput);
        }

        public Day18(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day18.testData);
            }
            else
            {
                Init(Inputs.Day18.realData);
            }
        }

        public static string GetRow(string previousRow)
        {
            var newRow = "";

            for (var i = 0; i < previousRow.Length; i++)
            {
                bool leftTileTrap = (i > 0) && previousRow[i - 1] == TrapCharacter;
                bool centerTileTrap = previousRow[i] == TrapCharacter;
                bool rightTileTrap = (i < previousRow.Length - 1) && previousRow[i + 1] == TrapCharacter;

                if (
                    (leftTileTrap && centerTileTrap && !rightTileTrap) || 
                    (centerTileTrap && rightTileTrap && !leftTileTrap) ||
                    (leftTileTrap && !centerTileTrap && !rightTileTrap) ||
                    (rightTileTrap && !centerTileTrap && !leftTileTrap))
                {
                    newRow += TrapCharacter;
                } else
                {
                    newRow += SafeCharacter;
                }

            }

            return newRow;
        }

        public static int GetSafeCount(string startRow, int rows)
        {
            var safeCount = startRow.Split('.').Length - 1;
            var row = startRow;
            for (var i = 1; i < rows; i++)
            {
                row = GetRow(row);
                safeCount += row.Split('.').Length - 1;
            }
            return safeCount;
        }

        public override void Run()
        {
            base.Run();

            firstResult = GetSafeCount(input, 40).ToString();
            secondResult = GetSafeCount(input, 400000).ToString();
        }
    }
}