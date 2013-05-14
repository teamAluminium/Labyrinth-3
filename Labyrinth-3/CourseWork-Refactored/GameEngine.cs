using System;
using System.Threading;

namespace CourseWork_Refactored
{
    /// <summary>
    /// The main logic behind this game. This class contain the main algorithm for application run. 
    /// </summary>
    public class GameEngine
    {
        public GameEngine()
        {
        }

        /// <summary>
        /// The main algorithm behind the gameplay
        /// </summary>
        /// <param name="playerName">string variable needed for creation of new player</param>
        /// <param name="fieldRows">integer variable needed for creation of the game field</param>
        /// <param name="fieldColls">integer variable needed for creation of the game field</param>
        public void Run(string playerName, int fieldRows, int fieldColls)
        {
            var labyrinth = new Labyrinth(fieldRows, fieldColls);
            var player = new Player(playerName, labyrinth.Rows / 2, labyrinth.Cols / 2);
            var gameIsInProgress = true;
            ScoreBoard.AddPlayer(player);
            PrepareConsole();

            while (gameIsInProgress)
            {
                Console.Clear();
                DrowInitalState(labyrinth, player);
                var playerCommand = ReadPlayerCommand();
                var hasEscaped = CheckIfOut(player, labyrinth.Field);
                if (hasEscaped)
                {
                    break;
                }

                ExecuteCommand(playerCommand, labyrinth.Field, player);
                Thread.Sleep(100);
            }

            PrintCredits(player);
        }

        /// <summary>
        /// Simple method for fixing Console width and height
        /// </summary>
        private void PrepareConsole()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.BufferWidth;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Method used for the end game credentials. 
        /// </summary>
        /// <param name="player">Instance of Player's class</param>
        private void PrintCredits(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.BufferWidth / 2 - 10, Console.BufferHeight / 2);
            Console.WriteLine("Congratulations, {0}!", player.Name);
            Console.SetCursorPosition(Console.BufferWidth / 2 - 15, Console.BufferHeight / 2 + 1);
            Console.WriteLine("You have won. Your score is {0}!", player.GetScore());
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// Method for printing the initial instructions on the screen. 
        /// </summary>
        /// <param name="labyrinth">Insance of class Labyrinth. Used as game field</param>
        /// <param name="player">Instance of class Player.</param>
        private void DrowInitalState(Labyrinth labyrinth, Player player)
        {
            Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard,'restart' to start a new game and 'exit' to quit the game.");
            labyrinth.Field = SetPlayerOnField(labyrinth.Field, player);
            labyrinth.DrawLabyrinth();
        }

        /// <summary>
        /// Method used for setting player's position on the game field.
        /// </summary>
        /// <param name="labyrinth">Insance of class Labyrinth. Used as game field</param>
        /// <param name="player">Instance of class Player.</param>
        /// <returns>String Array used as game field</returns>
        private string[,] SetPlayerOnField(string[,] labyrinth, Player player)
        {
            labyrinth[player.PossitionX, player.PossitionY] = " * ";
            return labyrinth;
        }

        /// <summary>
        /// Method for reading player's input from the console. 
        /// </summary>
        /// <returns>Returns the command in string form</returns>
        private string ReadPlayerCommand()
        {
            Console.WriteLine("Enter your move (L=left, R=right, D=down, U=up): ");
            string playerCommand = Console.ReadLine();
            return playerCommand;
        }

        /// <summary>
        /// Method for checking if players has made it out of the labyrinth. Executed after each player's move
        /// </summary>
        /// <param name="player">Instance of class Player.</param>
        /// <param name="labyrinth">String Array used as game field</param>
        /// <returns>boolean value if player has made it out of the labyrinth</returns>
        private bool CheckIfOut(Player player, string[,] labyrinth)
        {
            var hasEscaped = false;
            if (player.PossitionX == 1 ||
                player.PossitionX == labyrinth.GetLength(0) - 2 ||
                player.PossitionY == 1 ||
                player.PossitionY == labyrinth.GetLength(1) - 2)
            {
                hasEscaped = true;
            }

            return hasEscaped;
        }

        /// <summary>
        /// Method for execution of player's commands
        /// </summary>
        /// <param name="playerCommand">string variable conttaining player's command</param>
        /// <param name="labyrinth">String Array used as game field</param>
        /// <param name="player">Instance of class Player.</param>
        private void ExecuteCommand(string playerCommand, string[,] labyrinth, Player player)
        {
            playerCommand = playerCommand.ToLower();

            switch (playerCommand)
            {
                case "d": MovePlayerDown(labyrinth, player);
                    break;
                case "u": MovePlayerUp(labyrinth, player);
                    break;
                case "r": MovePlayerRight(labyrinth, player);
                    break;
                case "l": MovePlayerLeft(labyrinth, player);
                    break;
                case "top": ScoreBoard.PrintScoreboard();
                    break;
                case "exit": PrintCredits(player);
                    break;
                case "restart": Run(player.Name, labyrinth.GetLength(0), labyrinth.GetLength(1));
                    break;
                default: break;
            }
        }

        /// <summary>
        /// Method used for moving player to the left with 1 space
        /// </summary>
        /// <param name="labyrinth">String Array used as game field</param>
        /// <param name="player">Instance of class Player.</param>
        private static void MovePlayerLeft(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX, player.PossitionY - 1] == " - " ||
    labyrinth[player.PossitionX, player.PossitionY - 1] == " # ")
            {
                ClearPlayerPossition(labyrinth, player);
                player.MoveLeft();
            }
            else
            {
                PrintInvalidMove();
            }
        }

        /// <summary>
        /// Method used for moving player to the right with 1 space
        /// </summary>
        /// <param name="labyrinth">String Array used as game field</param> 
        /// <param name="player">Instance of class Player.</param>
        private static void MovePlayerRight(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX, player.PossitionY + 1] == " - " ||
     labyrinth[player.PossitionX, player.PossitionY + 1] == " # ")
            {
                ClearPlayerPossition(labyrinth, player);
                player.MoveRight();
            }
            else
            {
                PrintInvalidMove();
            }
        }

        /// <summary>
        /// Method used for moving player up with 1 space
        /// </summary>
        /// <param name="labyrinth">String Array used as game field</param> 
        /// <param name="player">Instance of class Player.</param>
        private static void MovePlayerUp(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX - 1, player.PossitionY] == " - " ||
    labyrinth[player.PossitionX - 1, player.PossitionY] == " # ")
            {
                ClearPlayerPossition(labyrinth, player);
                player.MoveUp();
            }
            else
            {
                PrintInvalidMove();
            }
        }

        /// <summary>
        /// Method used for moving player down with 1 space
        /// </summary>
        /// <param name="labyrinth">String Array used as game field</param> 
        /// <param name="player">Instance of class Player.</param>
        private static void MovePlayerDown(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX + 1, player.PossitionY] == " - " ||
            labyrinth[player.PossitionX + 1, player.PossitionY] == " # ")
            {
                ClearPlayerPossition(labyrinth, player);
                player.MoveDown();
            }
            else
            {
                PrintInvalidMove();
            }
        }

        /// <summary>
        /// Clearing player's previous position. 
        /// </summary>
        /// <param name="labyrinth">String Array used as game field</param> 
        /// <param name="player">Instance of class Player.</param>
        private static void ClearPlayerPossition(string[,] labyrinth, Player player)
        {
            labyrinth[player.PossitionX, player.PossitionY] = " - ";
        }

        /// <summary>
        /// Simple method used for notifying user when he/she has made invalid move.
        /// </summary>
        private static void PrintInvalidMove()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid move! ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
        }
    }
}
