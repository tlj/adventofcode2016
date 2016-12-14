using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Solutions
{
    public class Day14 : Base
    {

        public Day14(string dayInput)
        {
            Init(dayInput);
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
        }

        public static int GenerateKey(string inputString, int keyNumber, int keyStretchingCount)
        {
            var md5 = MD5.Create();
            var threePattern = @"(.)\1\1";
            var fivePattern = @"(.)\1\1\1\1";

            var threeRgx = new Regex(threePattern);
            var fiveRgx = new Regex(fivePattern);

            var index = 0;
            var foundKeys = new List<int>();
            var triples = new Dictionary<int, string>();
            while (foundKeys.Count < keyNumber || (foundKeys.Count > keyNumber - 1 && index < foundKeys[keyNumber - 1] + 1000))
            {
                var md5string = Util.CalculateMd5(inputString + index.ToString(), md5);
                for (var j = 0; j < keyStretchingCount; j++)
                {
                    md5string = Util.CalculateMd5(md5string.ToLower(), md5);
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
            return foundKeys[keyNumber - 1];
        }

        public override void Run()
        {
            base.Run();

            firstResult = GenerateKey(input, 64, 0).ToString();
            secondResult = GenerateKey(input, 64, 2016).ToString();
        }
    }
}