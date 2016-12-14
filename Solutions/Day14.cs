using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Solutions
{
    public class Day14 : Base
    {
        private MD5 md5;

        public Day14(string dayInput)
        {
            Init(dayInput);
            md5 = MD5.Create();
        }

        public Day14(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day14.testData);
            }
            else
            {
                Init(Inputs.Day14.realData);
            }
            md5 = MD5.Create();
        }

        public string GenerateKey(string inputString, int keyNumber, int keyStretchingCount)
        {
            var threePattern = @"(.)\1\1";
            var fivePattern = @"(.)\1\1\1\1";

            var threeRgx = new Regex(threePattern);
            var fiveRgx = new Regex(fivePattern);

            var index = 0;
            var foundKeys = new List<int>();
            var triples = new Dictionary<int, string>();
            while (foundKeys.Count < keyNumber || (foundKeys.Count > keyNumber - 1 && index < foundKeys[63] + 1000))
            {
                var md5string = CalculateMd5(input + index.ToString()).ToLower();
                for (var j = 0; j < keyStretchingCount; j++)
                {
                    md5string = CalculateMd5(md5string.ToLower());
                }
                Match fiveMatch = fiveRgx.Match(md5string);
                if (fiveMatch.Success)
                {
                    foreach (var triple in triples)
                    {
                        if (triple.Key > index - 1000 &&
                            !foundKeys.Contains(triple.Key) &&
                            triple.Value == fiveMatch.Groups[0].Value.Substring(0, 3))
                        {
                            foundKeys.Add(triple.Key);
                        }
                    }
                    triples.Add(index, fiveMatch.Groups[0].Value.Substring(0,3));
                } else
                {
                    Match threeMatch = threeRgx.Match(md5string);
                    if (threeMatch.Success)
                    {
                        triples.Add(index, threeMatch.Groups[0].Value);
                    }
                }

                foundKeys.Sort();
                index++;
            }
            return foundKeys[keyNumber - 1].ToString();
        }

        public override void Run()
        {
            base.Run();

            firstResult = GenerateKey(input, 64, 0);
            secondResult = GenerateKey(input, 64, 2016);
        }

        public string CalculateMd5(string input)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}