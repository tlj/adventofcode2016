using System.Security.Cryptography;
using System.Text;
using System;

namespace Days
{

    public class Five : Base
    {
        public Five(string inputString) {
            input = inputString;
        }

        public override void Run()
        {
            firstResult = FindPassword(input);
            secondResult = FindSecondPassword(input);
        }

        public string FindPassword(string doorId)
        {
            string password = "";

            int index = 0;
            string md5string = "";
            while (password.Length < 8) {
                md5string = CalculateMd5(doorId + index.ToString());
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
                md5string = CalculateMd5(doorId + index.ToString());
                if (md5string.Substring(0, 5) == "00000") {
                    try {
                        int pos = int.Parse(md5string.Substring(5, 1));
                        if (pos < 8 && password[pos] == '\0') {
                            char passwordChar = md5string.Substring(6, 1)[0];
                            
                            password[pos] = passwordChar;
                            found++;
                        }
                    } catch (FormatException e) {

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

        public string CalculateMd5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }

}