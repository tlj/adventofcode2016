using System;
using System.Numerics;

namespace Days
{

    public class Two : IDayInterface
    {
        string firstResult;
        string secondResult;

        string[] directionSets;

        public Two(string input)
        {
            directionSets = input.Split('\n');
        }

        public struct IntVector2
        {
            public int X;
            public int Y;
        }

        public void Run()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            IntVector2 pos;
            pos.X = 1;
            pos.Y = 1; 

            foreach (var directionSet in directionSets)
            {
                foreach (var direction in directionSet) {
                    switch (direction) {
                        case 'U':
                            if (pos.Y > 0) pos.Y -= 1;
                            break;
                        case 'D':
                            if (pos.Y < 2) pos.Y += 1;
                            break;
                        case 'L':
                            if (pos.X > 0) pos.X -= 1;
                            break;
                        case 'R':
                            if (pos.X < 2) pos.X += 1;
                            break;
                        default:
                            continue;
                    }
                }
                firstResult += matrix[pos.Y, pos.X].ToString();
            }

        }

        public string GetFirstResult()
        {
            return firstResult;
        }

        public string GetSecondResult()
        {
            return secondResult;
        }

    }

}