using System;
using System.Collections.Generic;

namespace AdventOfCode2016.Solutions
{
    public class Day21 : Base
    {

        public Day21(string dayInput)
        {
            Init(dayInput);
        }

        public Day21(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day21.testData);
            }
            else
            {
                Init(Inputs.Day21.realData);
            }
        }

        /**
         * swap position X with position Y means that the letters at indexes X 
         * and Y (counting from 0) should be swapped.
         */
        public static string SwapPosition(string inputString, int x, int y)
        {
            char[] ret = inputString.ToCharArray();

            ret[x] = inputString[y];
            ret[y] = inputString[x];

            return String.Join("", ret);
        }

        /**
         * swap letter X with letter Y means that the letters X and Y should be 
         * swapped (regardless of where they appear in the string).
         */
        public static string SwapLetters(string inputString, string x, string y)
        {
            char[] ret = inputString.ToCharArray();

            for (var i = 0; i < ret.Length; i++)
            {
                if (ret[i] == x[0]) ret[i] = y[0];
                else if (ret[i] == y[0]) ret[i] = x[0];
            }

            return String.Join("", ret);
        }

        /**
         * rotate left X steps means that the whole string should be rotated; 
         * for example, one left rotation would turn abcd into bcda.
         */
        public static string RotateLeft(string inputString, int x)
        {
            char[] ret = new char[inputString.Length]; 

            var steps = x % ret.Length;
            inputString.CopyTo(steps, ret, 0, inputString.Length - steps);
            inputString.CopyTo(0, ret, inputString.Length - steps, steps);

            return String.Join("", ret);
        }

        /**
         * rotate right X steps means that the whole string should be rotated; 
         * for example, one right rotation would turn abcd into dabc.
         */
        public static string RotateRight(string inputString, int x)
        {
            char[] ret = new char[inputString.Length]; 

            var steps = x % ret.Length;
            inputString.CopyTo(inputString.Length - steps, ret, 0, steps);
            inputString.CopyTo(0, ret, steps, inputString.Length - steps);

            return String.Join("", ret);
        }

        /** 
         * rotate based on position of letter X means that the whole string should 
         * be rotated to the right based on the index of letter X (counting from 0) 
         * as determined before this instruction does any rotations. Once the index 
         * is determined, rotate the string to the right one time, plus a number of 
         * times equal to that index, plus one additional time if the index was at 
         * least 4.
         */
        public static string RotateRightBasedOnPositionOfLetter(string inputString, string x)
        {
            var pos = inputString.IndexOf(x);
            if (pos >= 4) pos += 1;
            pos += 1;

            return RotateRight(inputString, pos);
        }

        /** 
         * rotate based on position of letter X means that the whole string should 
         * be rotated to the right based on the index of letter X (counting from 0) 
         * as determined before this instruction does any rotations. Once the index 
         * is determined, rotate the string to the right one time, plus a number of 
         * times equal to that index, plus one additional time if the index was at 
         * least 4.
         */
        public static string RotateBackBasedOnPositionOfLetter(string inputString, string x)
        {
            var pos = inputString.IndexOf(x);

            pos = pos / 2 + (pos % 2 == 1 || pos == 0 ? 1 : 5);

            return RotateLeft(inputString, pos);
        }

        /**
         * reverse positions X through Y means that the span of letters at indexes X 
         * through Y (including the letters at X and Y) should be reversed in order.
         */
        public static string ReversePositionsXThroughY(string inputString, int x, int y)
        {
            var ret = inputString.ToCharArray();

            for (var i = 0; i <= y - x; i++)
            {
                ret[x + i] = inputString[y - i];
            }

            return String.Join("", ret);
        }

        /**
         * move position X to position Y means that the letter which is at index X should
         * be removed from the string, then inserted such that it ends up at index Y.
         */
        public static string MovePositionXToPositionY(string inputString, int x, int y)
        {
            var ret = inputString.ToCharArray();

            if (y > x)
            {
                inputString.CopyTo(x + 1, ret, x, y - x);
            } else
            {
                inputString.CopyTo(y, ret, y + 1, x - y);
            }
            ret[y] = inputString[x];

            return String.Join("", ret);
        }

        public string ScramblePassword(string[] instructions, string password)
        {
            foreach (var l in instructions)
            {
                var m = l.Split(' ');
                if (m[0] == "swap" && m[1] == "position")
                {
                    password = SwapPosition(password, int.Parse(m[2]), int.Parse(m[5]));
                }
                else
                if (m[0] == "swap" && m[1] == "letter")
                {
                    password = SwapLetters(password, m[2], m[5]);
                }
                else
                if (m[0] == "rotate" && m[1] == "left")
                {
                    password = RotateLeft(password, int.Parse(m[2]));
                }
                else
                if (m[0] == "rotate" && m[1] == "right")
                {
                    password = RotateRight(password, int.Parse(m[2]));
                }
                else
                if (m[0] == "rotate" && m[1] == "based")
                {
                    password = RotateRightBasedOnPositionOfLetter(password, m[6]);
                }
                else
                if (m[0] == "reverse")
                {
                    password = ReversePositionsXThroughY(password, int.Parse(m[2]), int.Parse(m[4]));
                }
                else
                if (m[0] == "move")
                {
                    password = MovePositionXToPositionY(password, int.Parse(m[2]), int.Parse(m[5]));
                }
            }
            return password;
        }

        public string UnScramblePassword(string[] instructions, string password)
        {
            var reverse = new string[inputs.Length];
            for (var i = 0; i < inputs.Length; i++)
            {
                reverse[inputs.Length - 1 - i] = inputs[i];
            }

            foreach (var l in reverse)
            {
                var m = l.Split(' ');
                if (m[0] == "swap" && m[1] == "position")
                {
                    password = SwapPosition(password, int.Parse(m[2]), int.Parse(m[5]));
                }
                else
                if (m[0] == "swap" && m[1] == "letter")
                {
                    password = SwapLetters(password, m[2], m[5]);
                }
                else
                if (m[0] == "rotate" && m[1] == "left")
                {
                    password = RotateRight(password, int.Parse(m[2]));
                }
                else
                if (m[0] == "rotate" && m[1] == "right")
                {
                    password = RotateLeft(password, int.Parse(m[2]));
                }
                else
                if (m[0] == "rotate" && m[1] == "based")
                {
                    password = RotateBackBasedOnPositionOfLetter(password, m[6]);
                }
                else
                if (m[0] == "reverse")
                {
                    password = ReversePositionsXThroughY(password, int.Parse(m[2]), int.Parse(m[4]));
                }
                else
                if (m[0] == "move")
                {
                    password = MovePositionXToPositionY(password, int.Parse(m[5]), int.Parse(m[2]));
                }
                Console.WriteLine("After " + l + ": " + password);
            }
            return password;
        }

        public override void Run()
        {
            base.Run();

            firstResult = ScramblePassword(inputs, "abcdefgh");
            secondResult = UnScramblePassword(inputs, "fbgdceah");
        }
    }
}
 
 
 
 
 
 