using System;
using System.Collections.Generic;
using System.Numerics;

namespace Days {
    
    public class One : Base
    {
        
        private List<Vector2> visitedLocations; 
        private Vector2 firstVisitedTwice;
        bool hasVisitedTwice = false;

        public One(string dayInput)
        {
            input = dayInput;
        }

        private void CheckAndAddCoordinate(int X, int Y)
        {
            Vector2 location = new Vector2(X, Y); 
            if (visitedLocations.Contains(location)) {
                if (!hasVisitedTwice) {
                    firstVisitedTwice = location;
                    hasVisitedTwice = true;
                }
            }
            visitedLocations.Add(location);
        }

        public float GetFirstVisitedTwice()
        {
            return Math.Abs(firstVisitedTwice.X) + Math.Abs(firstVisitedTwice.Y);
        }

        public override void Run()
        {
            base.Run();

            string input2 = input.Replace(" ", "");
            string[] instructions = input2.Split(',');

            int X = 0;
            int Y = 0;

            visitedLocations = new List<Vector2>();
            visitedLocations.Add(new Vector2(X, Y));

            string previousDirection = "NORTH";
            foreach (var instruction in instructions) {
                char direction = instruction[0];
                int distance = int.Parse(instruction.Substring(1));

                if (previousDirection == "NORTH" && direction == 'L' || 
                    previousDirection == "SOUTH" && direction == 'R') {
                    previousDirection = "WEST";
                    for (var i = X - 1; i >= X - distance; i--) {
                        CheckAndAddCoordinate(i, Y);
                    }
                    X -= distance;
                } else
                if (previousDirection == "WEST" && direction == 'L' ||
                    previousDirection == "EAST" && direction == 'R') {
                    previousDirection = "SOUTH";
                    for (var i = Y - 1; i >= Y - distance; i--) {
                        CheckAndAddCoordinate(X, i);
                    }
                    Y -= distance; 
                } else
                if (previousDirection == "EAST" && direction == 'L' ||
                    previousDirection == "WEST" && direction == 'R') {
                    previousDirection = "NORTH";
                    for (var i = Y + 1; i <= Y + distance; i++) {
                        CheckAndAddCoordinate(X, i);
                    }                    
                    Y += distance;
                } else 
                if (previousDirection == "NORTH" && direction == 'R' ||
                    previousDirection == "SOUTH" && direction == 'L') {
                    previousDirection = "EAST";
                    for (var i = X + 1; i <= X + distance; i++) {
                        CheckAndAddCoordinate(i, Y);
                    }
                    X += distance;
                }
            } 

            firstResult = (Math.Abs(X) + Math.Abs(Y)).ToString();
            secondResult = GetFirstVisitedTwice().ToString();
        }

    }

}