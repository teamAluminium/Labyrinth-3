using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWork_Refactored
{
    public class Labyrinth
    {
        private const int MAX_NUMBER = 2;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public string[,] Field { get; set; }

        public Labyrinth(int rows, int cols)
        {
            //Creating Frame
            this.Rows = rows + 2;
            this.Cols = cols + 2;
            this.Field = new string[this.Rows, this.Cols];
            do
            {
                GenerateRandomLabyrinth();
            }
            while (HasSolution(Rows / 2, Cols / 2));
        }

        private void GenerateRandomLabyrinth()
        {
            Random randomInt = new Random();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    var randomNumber = randomInt.Next(MAX_NUMBER);

                    if (row == 0 || row == this.Rows - 1 || col == 0 || col == this.Cols - 1)
                    {
                        this.Field[row, col] = " # ";
                    }
                    else if (randomNumber == 0)
                    {
                        this.Field[row, col] = " - ";
                    }
                    else
                    {
                        this.Field[row, col] = " x ";
                    }
                }
            }
        }

        private bool HasSolution(int positionX, int positionY)
        {
            if (this.Field[positionX + 1, positionY] == "x" &&
                this.Field[positionX, positionY + 1] == "x" &&
                this.Field[positionX - 1, positionY] == "x" &&
                this.Field[positionX, positionY - 1] == "x")
            {
                return false;
            }

            while (true)
            {
                try
                {
                    if (this.Field[positionX + 1, positionY] == "-")
                    {
                        this.Field[positionX + 1, positionY] = "0";
                        positionX++;
                    }
                    else if (this.Field[positionX, positionY + 1] == "-")
                    {
                        this.Field[positionX, positionY + 1] = "0";
                        positionY++;
                    }
                    else if (this.Field[positionX - 1, positionY] == "-")
                    {
                        this.Field[positionX - 1, positionY] = "0";
                        positionX--;
                    }
                    else if (this.Field[positionX, positionY - 1] == "-")
                    {
                        this.Field[positionX, positionY - 1] = "0";
                        positionY--;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    for (int row = 0; row < this.Rows; row++)
                    {
                        for (int col = 0; col < this.Cols; col++)
                        {
                            if (this.Field[row, col] == "0")
                            {
                                this.Field[row, col] = "-";
                            }
                        }
                    }

                    return true;
                }
            }
        }
    }
}
