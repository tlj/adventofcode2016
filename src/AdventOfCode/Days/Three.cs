using System;

namespace Days
{

    public class Three
    {
        string[] lines;
        int firstResult = 0;
        
        public Three(string input)
        {
            lines = input.Split('\n');
        }

        public void Run()
        {
            foreach (var triangle in lines)
            {
                if (IsTriangle(triangle)) {
                    firstResult++;
                }
            }

            var i = 0;
            foreach (var triangle in lines) {
                if (++i == 3) {

                }
            }
        }

        private int[] SplitRow(string row)
        {
            int[] sides = new int[3];

            int i = 0;
            foreach (var side in row.Split(' ')) {
                if (side == " " || side == "") continue;

                sides[i++] = int.Parse(side);
            }

            return sides;
        }

        public bool IsTriangle(string input)
        {
            int[] sides = SplitRow(input);

            return (sides[0] + sides[1] > sides[2]) && 
                    (sides[1] + sides[2] > sides[0]) && 
                    (sides[2] + sides[0] > sides[1]);
        }

        public string GetFirstResult()
        {
            return firstResult.ToString();
        }
    }

}