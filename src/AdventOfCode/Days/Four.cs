using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public class Four : Base
    {
        string[] rooms;
        int firstResultInt;

        public Four(string inputString)
        {
            input = inputString;
            rooms = input.Split('\n');
        }

        public override void Run()
        {
            base.Run();

            foreach (var e in rooms) {
                firstResultInt += IsValidEncryption(e);

                var data = SplitString(e);
                if (DecryptString(data[0], int.Parse(data[1])) == "northpole object storage") {
                    secondResult = data[1];
                }
            }

            firstResult = firstResultInt.ToString();
        }

        public string[] SplitString(string inputString)
        {
            string pattern = @"^(?<encrypted>.*?)-(?<sectorId>[0-9]+)\[(?<checksum>[a-z]+)\]$";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(inputString);
            if (matches.Count == 0) {
                throw new Exception("Invalid string");
            } 

            var ret = new String[3];
            foreach (Match match in matches) {
                ret[0] = match.Groups["encrypted"].Value;
                ret[1] = match.Groups["sectorId"].Value;
                ret[2] = match.Groups["checksum"].Value;
                break;
            }

            return ret;
        }

        public string DecryptString(string inputString, int shiftBy)
        {
            string decryptedString = "";

            var alphabetLookup = new Dictionary<int, char>();
            var alphabetNumLookup = new Dictionary<char, int>();
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var i = 0;
            foreach (var c in alphabet) {
                alphabetLookup.Add(i, c);
                alphabetNumLookup.Add(c, i);
                i++;
            }

            foreach (var c in inputString) {
                if (c == '-') {
                    decryptedString += ' ';
                } else {
                    var pos = alphabetNumLookup[c];
                    var k = pos;
                    for (var j = 0; j < shiftBy; j++) {
                        if (k < alphabetLookup.Count - 1) {
                            k += 1;
                        } else {
                            k = 0;
                        }
                    }
                    decryptedString += alphabetLookup[k];       
                }
            }

            return decryptedString;
        }

        public int IsValidEncryption(string inputString)
        {
            int sectorId = 0;
            string encryptedString = "";
            string checksum = "";
            int inputSectorId = 0;

            var splitStr = SplitString(inputString);
            encryptedString = splitStr[0];
            inputSectorId = int.Parse(splitStr[1]);
            checksum = splitStr[2];

            var occcurances = new Dictionary<char, int>();

            foreach (var c in encryptedString) {
                if (c == '-') continue;

                if (!occcurances.ContainsKey(c)) {
                    occcurances.Add(c, 1);
                } else {
                    occcurances[c] += 1;
                }
            }

            var sortedOccurances = (from entry in occcurances 
                    orderby entry.Value descending, entry.Key ascending                     
                    select entry).Take(5);

            var calculatedChecksum = "";
            foreach (var o in sortedOccurances) {
                calculatedChecksum += o.Key;
            }

            if (calculatedChecksum == checksum) {
                sectorId = inputSectorId;
            }

            return sectorId;
        }
    }
}