using System;
using Days;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Twelve(System.IO.File.ReadAllText("../../input/DayTwelve.txt")).Output();
        }
    }

}
