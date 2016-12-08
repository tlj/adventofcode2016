using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Days
{
    public class Eight : Base
    {
        char[,] board;
        int xSize = 50;
        int ySize = 6;
        char[,] screenBuffer;

        public Eight(string inputString)
        {
            input = inputString;
            inputs = inputString.Split('\n');
            InitBoard();    
            screenBuffer = new char[ySize + 1, xSize + 1];        
        }

        public override void Run()
        {
            base.Run();

            string rectPattern = @"rect (?<x>[0-9]+)x(?<y>[0-9]+)";
            Regex rectRegex = new Regex(rectPattern);

            string colPattern = @"rotate column x=(?<x>[0-9]+) by (?<by>[0-9]+)";
            Regex colRegex = new Regex(colPattern);

            string rowPattern = @"rotate row y=(?<y>[0-9]+) by (?<by>[0-9]+)";
            Regex rowRegex = new Regex(rowPattern);            

            foreach (var line in inputs) {
                Match rect = rectRegex.Match(line);
                if (rect.Success) {
                    DrawRect(int.Parse(rect.Groups["x"].Value), int.Parse(rect.Groups["y"].Value));
                }

                Match col = colRegex.Match(line);
                if (col.Success) {
                    RotateColumnBy(int.Parse(col.Groups["x"].Value), int.Parse(col.Groups["by"].Value));
                }

                Match row = rowRegex.Match(line);
                if (row.Success) {
                    RotateRowBy(int.Parse(row.Groups["y"].Value), int.Parse(row.Groups["by"].Value));
                }
            }
            firstResult = CountLights().ToString();

            Console.SetCursorPosition(0, 8);
            Console.WriteLine("");
        }

        public void InitBoard()
        {
            board = new char[ySize + 1, xSize + 1];
            for (var y = 0; y < ySize + 1; y++) {
                for (var x = 0; x < xSize + 1; x++) {
                    board[y, x] = ' ';
                }
            }
        }

        public int CountLights()
        {
            var count = 0;

            for (var y = 0; y < ySize; y++) {
                for (var x = 0; x < xSize; x++) {
                    if (board[y, x] == '█') count++;
                }
            }

            return count;
        }

        public void DrawRect(int rectX, int rectY)
        {
            for (var y = 0; y < rectY; y++) {
                for (var x = 0; x < rectX; x++) {
                    board[y, x] = '█';
                }
            }
        }

        public void RotateRow(int rowNumber)
        {
            char[,] newBoard = board;
            for (var r = xSize - 1; r >= 0; r--) {
                newBoard[rowNumber, r + 1] = board[rowNumber, r];
            }
            newBoard[rowNumber, 0] = board[rowNumber, xSize];
            board = newBoard;
        }

        public void RotateRowBy(int rowNumber, int rotateBy)
        {
            for (var rb = 0; rb < rotateBy; rb++) {
                RotateRow(rowNumber);
                DrawBoard();
            }
        }

        public void RotateColumn(int colNumber)
        {
            char[,] newBoard = board;
            for (var r = ySize - 1; r >= 0; r--) {
                newBoard[r + 1, colNumber] = board[r, colNumber];
            }
            newBoard[0, colNumber] = board[ySize, colNumber];
            board = newBoard;
        }
        
        public void RotateColumnBy(int colNumber, int rotateBy)
        {
            for (var rb = 0; rb < rotateBy; rb++) {
                RotateColumn(colNumber);
                DrawBoard();
            }
        }

        public void DrawBoard()
        {
            for (var y = 0; y < ySize; y++) {
                for (var x = 0; x < xSize; x++) {
                    if (board[y, x] != screenBuffer[y, x]) {
                        screenBuffer[y, x] = board[y, x];
                        Console.SetCursorPosition(x, y);
                        Console.Write(board[y, x]);
                    }
                }
            }
            Thread.Sleep(20);
        }
        
        public override void Output()
        {
            Console.Clear();

            base.Output();

            DrawBoard();
        }
    }
}