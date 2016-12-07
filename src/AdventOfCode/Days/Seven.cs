using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Days
{
    public class Seven : Base
    {
        int firstResultInt = 0;
        int secondResultInt = 0;

        public Seven(string inputString)
        {
            input = inputString;
            inputs = inputString.Split('\n');
        }

        public override void Run()
        {
            base.Run();

            foreach (var line in inputs) {
                if (IsTls(line)) {
                    firstResultInt++;
                }
                if (IsSsl(line)) {
                    secondResultInt++;
                }
            }

            firstResult = firstResultInt.ToString();
            secondResult = secondResultInt.ToString();
        }

        public static bool IsTls(string tlsString)
        {
            string pattern = @"(?<outside>[a-z]+)|(?<inside>\[[a-z]+\])";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(tlsString);

            var found = false;
            foreach (Match match in matches) {
                if (IsAbba(match.Groups["inside"].Value)) return false;
                if (IsAbba(match.Groups["outside"].Value)) { 
                    found = true;
                }            
            }
            return found;
        }

        public static bool IsSsl(string sslString)
        {
            string splitHyperSuperPattern = @"(?<supernet>[a-z]+)|(?<hypernet>\[[a-z]+\])";
            Regex hyperSuperRegex = new Regex(splitHyperSuperPattern);
            MatchCollection matches = hyperSuperRegex.Matches(sslString);

            var supernet = "";
            var hypernet = ""; 

            foreach (Match match in matches) {
                supernet += match.Groups["supernet"].Value + " ";
                hypernet += match.Groups["hypernet"].Value + " ";
            }

            foreach (var abaString in GetAbaStrings(supernet)) {
                if (hypernet.Contains(FromAbaToBab(abaString))) {
                    return true;
                }
            }

            return false;
        }

        public static String FromAbaToBab(string aba) 
        {
            return aba.Substring(1, 1) + aba.Substring(0, 1) + aba.Substring(1, 1);
        }

        public static List<String> GetAbaStrings(string inputString)
        {
            var ret = new List<String>();

            for (var i = 0; i < inputString.Length - 2; i++) {
                if (inputString[i] == inputString[i + 2] && inputString[i] != inputString[i + 1]) {
                    ret.Add(inputString.Substring(i, 3));
                }
            }

            return ret;
        }

        public static bool IsAbba(string abbaString)
        {
            string pattern = @"(.)(?!\1)(.)\2\1";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(abbaString);
            return matches.Count > 0;
        }
    }
}