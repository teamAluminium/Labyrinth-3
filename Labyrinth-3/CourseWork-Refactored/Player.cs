using System;

namespace CourseWork_Refactored
{
    /// <summary>
    /// Class representing our player. It contains crucial information about player's performance and current state.
    /// </summary>
    public class Player
    {
        public int Score { get; private set; }

        public int Moves { get; private set; }

        public string Name { get; private set; }

        public int PossitionX { get; set; }

        public int PossitionY { get; set; }

        public Player(string name, int possitionX, int possitionY)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            this.Name = name;
            this.Moves = 0;
            this.Score = 0;
            this.PossitionX = possitionX;
            this.PossitionY = possitionY;
        }

        /// <summary>
        /// Method for increasing player's moves.
        /// </summary>
        public void IncreaseMoves()
        {
            this.Moves++;
        }

        /// <summary>
        /// Method used for moving played down 
        /// </summary>
        public void MoveDown()
        {
            this.PossitionX++;
            this.Moves++;
        }

        /// <summary>
        /// Method used for moving played up 
        /// </summary>
        public void MoveUp()
        {
            this.PossitionX--;
            this.Moves++;
        }

        /// <summary>
        /// Method used for moving played left
        /// </summary>
        public void MoveLeft()
        {
            this.PossitionY--;
            this.Moves++;
        }

        /// <summary>
        /// Method used for moving played right
        /// </summary>
        public void MoveRight()
        {
            this.PossitionY++;
            this.Moves++;
        }

        /// <summary>
        /// Simple method usef for obtaining player's score
        /// </summary>
        /// <returns>Integer value returned as player's score</returns>
        public int GetScore()
        {
            var score = this.Moves * 10;
            return score;
        }
    }
}
