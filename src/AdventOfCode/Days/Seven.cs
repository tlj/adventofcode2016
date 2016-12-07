using System;
using System.Text.RegularExpressions;

namespace Days
{
    public class Seven : Base
    {
        int firstResultInt = 0;

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
            }

            firstResult = firstResultInt.ToString();
        }

        public bool IsTls(string tlsString)
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

        public bool IsAbba(string abbaString)
        {
            string pattern = @"(.)(?!\1)(.)\2\1";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(abbaString);
            return matches.Count > 0;
        }
    }
}