using System;
using AdventOfCode2016.Utils;

namespace AdventOfCode2016.Solutions
{
    public class Day05 : Base
    {
        private System.Security.Cryptography.MD5 md5;
        
        public Day05(string inputString) {
            Init(inputString);
            md5 = System.Security.Cryptography.MD5.Create();
        }

        public Day05(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day05.testData);
            }
            else
            {
                Init(Inputs.Day05.realData);
            }
            md5 = System.Security.Cryptography.MD5.Create();
        }

        public override void Run()
        {
            firstResult = FindPassword(input).ToLower();
            secondResult = FindSecondPassword(input).ToLower();
        }

        public string FindPassword(string doorId)
        {
            string password = "";

            int index = 0;
            string md5string = "";
            while (password.Length < 8) {
                md5string = MD5.CalculateMd5(doorId + index.ToString(), md5);
                if (md5string.Substring(0, 5) == "00000") {
                    password += md5string.Substring(5, 1);
                }
                index++;
            }

            return password;
        }

        public string FindSecondPassword(string doorId) 
        {
            char[] password = new char[8];

            int index = 0;
            int found = 0;
            string md5string = "";
            while (found < 8) {
                md5string = MD5.CalculateMd5(doorId + index.ToString(), md5);
                if (md5string.Substring(0, 5) == "00000") {
                    try {
                        int pos = int.Parse(md5string.Substring(5, 1));
                        if (pos < 8 && password[pos] == '\0') {
                            char passwordChar = md5string.Substring(6, 1)[0];
                            
                            password[pos] = passwordChar;
                            found++;
                        }
                    } catch (FormatException) {

                    }
                }
                index++;
            }

            var retPassword = "";
            foreach (var c in password) {
                retPassword += c;
            }

            return retPassword;            
        }
    }

}