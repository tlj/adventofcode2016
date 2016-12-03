using System;

namespace Days
{

    public class Three : Base
    {
        string[] lines;
        int firstResultInt = 0;
        int secondResultInt = 0;

        public Three(string dayInput)
        {
            input = dayInput;
            lines = input.Split('\n');
        }

        public override void Run()
        {
            base.Run();
            
            foreach (var triangle in lines)
            {
                if (IsTriangle(triangle)) {
                    firstResultInt++;
                }
            }

            var i = 0;
            var triangles = new string[3];
            foreach (var line in lines) {
                var cols = SplitRow(line);

                triangles[0] += " " + cols[0];
                triangles[1] += " " + cols[1];
                triangles[2] += " " + cols[2];

                if (++i == 3) {
                    for (var j = 0; j < 3; j++) {
                        if(IsTriangle(triangles[j])) {
                            secondResultInt++;
                        }
                    }
                    triangles = new string[3];
                    i = 0;
                }
            }

            firstResult = firstResultInt.ToString();
            secondResult = secondResultInt.ToString();
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

    }

}