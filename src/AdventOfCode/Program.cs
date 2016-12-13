using System;
using Days;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Eleven(System.IO.File.ReadAllText("../../input/DayEleven.txt")).Output();
        }
    }

}
