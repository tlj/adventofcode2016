using System;
using System.Numerics;

namespace Days
{

    public class Two : Base
    {
        string[] directionSets;

        public Two(string dayInput)
        {
            input = dayInput;
            directionSets = dayInput.Split('\n');
        }

        public struct IntVector2
        {
            public int X;
            public int Y;
        }

        public override void Run()
        {
            base.Run();

            var keyPad = new char?[,] { 
                { '1', '2', '3' }, 
                { '4', '5', '6' }, 
                { '7', '8', '9' } };

            firstResult = GetCodeFromPad(keyPad, 1, 1);

            var keyPad2 = new char?[,] { 
                { null, null, '1', null, null }, 
                { null,  '2', '3',  '4', null }, 
                {  '5',  '6', '7',  '8',  '9' },
                { null,  'A', 'B',  'C', null },
                { null, null, 'D', null, null } };

            secondResult = GetCodeFromPad(keyPad2, 0, 2);
        }

        private string GetCodeFromPad(char?[,] keyPad, int startX, int startY) 
        {
            IntVector2 pos;
            pos.X = startX;
            pos.Y = startY; 

            string code = "";

            foreach (var directionSet in directionSets)
            {
                foreach (var direction in directionSet) {
                    switch (direction) {
                        case 'U':
                            if (pos.Y > 0 && keyPad[pos.Y - 1, pos.X] != null) pos.Y -= 1;
                            break;
                        case 'D':
                            if (pos.Y < keyPad.GetLength(0) - 1 && keyPad[pos.Y + 1, pos.X] != null) pos.Y += 1;
                            break;
                        case 'L':
                            if (pos.X > 0 && keyPad[pos.Y, pos.X - 1] != null) pos.X -= 1;
                            break;
                        case 'R':
                            if (pos.X < keyPad.GetLength(1) - 1 && keyPad[pos.Y, pos.X + 1] != null) pos.X += 1;
                            break;
                        default:
                            continue;
                    }
                }

                code += keyPad[pos.Y, pos.X].ToString();
            }
            return code;
        }

    }

}