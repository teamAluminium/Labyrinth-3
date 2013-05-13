using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWork_Refactored
{
    public class Player
    {
        public int Score { get; private set; }
        public int Moves { get; set; }
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

        public void IncreaseMoves()
        {
            this.Moves++;
        }

        public int GetScore()
        {
            var score = this.Moves * 10;
            return score;
        }
    }
}
