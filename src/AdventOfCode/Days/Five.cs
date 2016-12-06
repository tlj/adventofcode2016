using System.Security.Cryptography;
using System.Text;
using System;

namespace Days
{
    public class Five : Base
    {
        private MD5 md5;
        
        public Five(string inputString) {
            input = inputString;
            md5 = MD5.Create();
        }

        public override void Run()
        {
            firstResult = FindPassword(input).ToLower();
//            secondResult = FindSecondPassword(input).ToLower();
        }

        public string FindPassword(string doorId)
        {
            string password = "";
            char[] secondPassword = new char[8];

            int index = 0;
            string md5string = "";
            int found = 0;
            while (password.Length < 8 || found < 8) {
                md5string = CalculateMd5(doorId + index.ToString());
                if (md5string != "" && md5string.Substring(0, 5) == "00000") {
                    if (password.Length < 8) {
                      password += md5string.Substring(5, 1);
                    }
                    int pos;
                    if (int.TryParse(md5string.Substring(5,1), out pos)) {
                      if (pos < 8 && secondPassword[pos] == '\0') {
                        char passwordChar = md5string.Substring(6, 1)[0];
                        secondPassword[pos] = passwordChar;
                        found++;
                      }
                    }
                }
                index++;
            }
            
            firstResult = password;
            foreach (var c in secondPassword) {
              secondResult += c;
            }
            secondResult = secondResult.ToLower();

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
                if (md5string != "" && md5string.Substring(0, 5) == "00000") {
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
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            if (hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xf0) == 0) {
              return BitConverter.ToString(hash).Replace("-", "");
            } else {
              return "";
            }
        }
    }

}
