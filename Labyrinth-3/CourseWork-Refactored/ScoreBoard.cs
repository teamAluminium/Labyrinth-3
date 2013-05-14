using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CourseWork_Refactored
{
    /// <summary>
    /// Static class used for showing best scores of top performed players
    /// </summary>
    public static class ScoreBoard
    {
        private static List<Player> players = new List<Player>();

        /// <summary>
        /// Method used for adding current player to the scoreboard list.
        /// </summary>
        /// <param name="player">Instance of Player class</param>
        public static void AddPlayer(Player player)
        {
            players.Add(player);
            players.Sort(
                delegate(Player playerOne, Player playerTwo)
                {
                    return playerTwo.Moves.CompareTo(playerOne.Moves);
                }

            );
            DeleteAllExceptTopPlayers();
        }

        /// <summary>
        /// Method used for printing scoreboard on the console when requested.
        /// </summary>
        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (Player player in players)
            {
                string scoreboardLine = (players.IndexOf(player) + 1).ToString() + ". " + player.Name + " --> " + player.Moves.ToString() + " moves";
                Console.WriteLine(scoreboardLine);
            }

            Thread.Sleep(1000);
        }

        /// <summary>
        /// Method used to delete all but top players
        /// </summary>
        private static void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < players.Count(); index++)
            {
                if (index > 4)
                {
                    players.Remove(players[index]);
                }
            }
        }
    }
}
