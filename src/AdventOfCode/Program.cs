using System;
using Days;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dayOne = new One(System.IO.File.ReadAllText("../../input/DayOne.txt"));
            Console.WriteLine("Day one. Distance: " + dayOne.Run().ToString() + ".");
            Console.WriteLine("Day one. Distance to first visited twice: " + dayOne.GetFirstVisitedTwice());
        }
    }

}
