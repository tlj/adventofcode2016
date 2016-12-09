using System;
using Days;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //new One(System.IO.File.ReadAllText("../../input/DayOne.txt")).Output();
            //new Two(System.IO.File.ReadAllText("../../input/DayTwo.txt")).Output();
            //new Three(System.IO.File.ReadAllText("../../input/DayThree.txt")).Output();
            //new Four(System.IO.File.ReadAllText("../../input/DayFour.txt")).Output();
            //new Five("abbhdwsy").Output();
            //new Six(System.IO.File.ReadAllText("../../input/DaySix.txt")).Output();
            //new Seven(System.IO.File.ReadAllText("../../input/DaySeven.txt")).Output();
            //var day = new Eight(System.IO.File.ReadAllText("../../input/DayEight.txt"));
            //day.Run();
            //day.EnableAnimation();
            //day.Output();
            
            //day.DrawRect(3,2);
            //day.DrawBoard();
            //day.RotateRowBy(1, 5);
            //day.RotateColumnBy(2, 11);
            //day.Output();
            //day.DrawBoard();
            //day.Output();

            new Nine(System.IO.File.ReadAllText("../../input/DayNine.txt")).Output();
        }
    }

}
