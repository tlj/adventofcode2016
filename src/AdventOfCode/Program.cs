using System;
using Days;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dayOne = new One(System.IO.File.ReadAllText("../../input/DayOne.txt"));
            dayOne.Run();

            Console.WriteLine("Day one. Distance: " + dayOne.GetFirstResult() + ".");
            Console.WriteLine("Day one. Distance to first visited twice: " + dayOne.GetSecondResult());
        }
    }

}
