using System;

namespace CourseWork_Refactored
{
    /// <summary>
    /// Class for creating the game field
    /// </summary>
    public class Labyrinth
    {
        private const int MAX_NUMBER = 2;

        public Labyrinth(int rows, int cols)
        {
            ///Creating Frame used to avoid unneded exceptions during checks.
            this.Rows = rows + 2;
            this.Cols = cols + 2;
            this.Field = new string[this.Rows, this.Cols];
            do
            {
                GenerateRandomLabyrinth();
            }
            while (HasSolution(this.Rows / 2, this.Cols / 2));
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public string[,] Field { get; set; }

        /// <summary>
        /// Method used for formatted printing the labyrinth on the console. 
        /// </summary>
        public void DrawLabyrinth()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int row = 0; row < this.Field.GetLength(0); row++)
            {
                for (int col = 0; col < this.Field.GetLength(1); col++)
                {
                    if (this.Field[row, col] == " # ")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(this.Field[row, col]);
                    }
                    else if (this.Field[row, col] == " x ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(this.Field[row, col]);
                    }
                    else if (this.Field[row, col] == " - ")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(this.Field[row, col]);
                    }
                    else if (this.Field[row, col] == " * ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(this.Field[row, col]);
                    }
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Method used for creation of the labyrinth game field. Uses simple logic for deciding the symbols.
        /// </summary>
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

        /// <summary>
        /// Method used for checking if the generated labyrinth has a solution
        /// </summary>
        /// <param name="positionX">Initial player position on X coordinate</param>
        /// <param name="positionY">Initial player position on Y coordinate</param>
        /// <returns></returns>
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
