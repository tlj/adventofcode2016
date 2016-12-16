using System.Text;

namespace AdventOfCode2016.Solutions
{
    public class Day16 : Base
    {

        public Day16(string dayInput)
        {
            Init(dayInput);
        }

        public Day16(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day16.testData);
            }
            else
            {
                Init(Inputs.Day16.realData);
            }
        }

        public static string Dragon(string a, int stringLength)
        {

            StringBuilder builder = new StringBuilder(a.Length * 2 + 1);
            builder.Append(a + '0'); 
            for (int i = a.Length - 1; i >= 0; i--)
            {                
                builder.Append(a[i] == '1' ? '0' : '1');
            }            

            if (stringLength > 0 && builder.Length < stringLength) 
            {
                return Dragon(builder.ToString(), stringLength).Substring(0, stringLength);
            }

            if (stringLength == 0) stringLength = builder.Length;
            return builder.ToString().Substring(0, stringLength);
        }

        public static string Checksum(string inputString)
        {
            StringBuilder builder = new StringBuilder(inputString.Length / 2);            
            for (var i = 0; i < inputString.Length - 1; i++) 
            {
                if (inputString[i] == inputString[++i]) {
                    builder.Append('1');
                } else {
                    builder.Append('0');
                }
            }
            if (builder.Length % 2 == 0) {
                return Checksum(builder.ToString());
            }
            return builder.ToString();
        }

        public override void Run()
        {
            base.Run();

            var data = Dragon(input, 272);
            var checksum = Checksum(data);
            firstResult = checksum;

            var data2 = Dragon(input, 35651584);
            var checksum2 = Checksum(data2);
            secondResult = checksum2;
        }
    }
}