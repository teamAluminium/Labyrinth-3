using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWork_Refactored
{
    public static class ScoreBoard
    {
        private static List<Player> players = new List<Player>();

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

        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (Player player in players)
            {
                string scoreboardLine = (players.IndexOf(player) + 1).ToString() + ". " + player.Name + " --> " + player.Moves.ToString() + " moves";
                Console.WriteLine(scoreboardLine);
            }
        }

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
