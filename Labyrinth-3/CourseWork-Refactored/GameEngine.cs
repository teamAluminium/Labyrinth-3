using System;
using System.Threading;

namespace CourseWork_Refactored
{
    public class GameEngine
    {
        public GameEngine()
        {
        }

        public void Run(string playerName, int fieldRows, int fieldColls)
        {
            var labyrinth = new Labyrinth(fieldRows, fieldColls);
            var player = new Player(playerName, labyrinth.Rows / 2, labyrinth.Cols / 2);
            var gameIsInProgress = true;
            PrepareConsole();

            while (gameIsInProgress)
            {
                DrowInitalState(labyrinth, player);
                var playerCommand = ReadPlayerCommand();
                var hasEscaped = CheckIfOut(player, labyrinth.Field);
                if (hasEscaped)
                {
                    break;
                }
                ReadCommand(playerCommand, labyrinth.Field, player);
                Thread.Sleep(100);
                Console.Clear();
            }
            PrintCredits(player);
        }

        private void PrepareConsole()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.BufferWidth;
            Console.CursorVisible = false;
        }

        private void PrintCredits(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.BufferWidth / 2 - 10, Console.BufferHeight / 2);
            Console.WriteLine("Congratulations, {0}!", player.Name);
            Console.SetCursorPosition(Console.BufferWidth / 2 - 15, Console.BufferHeight / 2 + 1);
            Console.WriteLine("You have won. Your score is {0}!", player.GetScore());
            Console.ReadKey();
        }

        private void DrowInitalState(Labyrinth labyrinth, Player player)
        {
            Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard,'restart' to start a new game and 'exit' to quit the game.");
            labyrinth.Field = SetPlayerOnField(labyrinth.Field, player);
            labyrinth.DrawLabyrinth();
        }

        private string[,] SetPlayerOnField(string[,] labyrinth, Player player)
        {
            labyrinth[player.PossitionX, player.PossitionY] = " * ";
            return labyrinth;
        }

        private string ReadPlayerCommand()
        {
            Console.WriteLine("Enter your move (L=left, R=right, D=down, U=up): ");
            string playerCommand = Console.ReadLine();
            return playerCommand;
        }

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

        private void ReadCommand(string playerCommand, string[,] labyrinth, Player player)
        {
            playerCommand = playerCommand.ToLower();

            switch (playerCommand)
            {
                case "d": MovePlayerDown(labyrinth, player); break;
                case "u": MovePlayerUp(labyrinth, player); break;
                case "r": MovePlayerRight(labyrinth, player); break;
                case "l": MovePlayerLeft(labyrinth, player); break;
                case "top": //Show Scoreboard
                case "exit": PrintCredits(player); break;
                case "restart": //Restart 
                    break;
                default: break;
            }
        }

        private static void MovePlayerLeft(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX, player.PossitionY - 1] == " - " ||
    labyrinth[player.PossitionX, player.PossitionY - 1] == " # ")
            {
                labyrinth[player.PossitionX, player.PossitionY] = " - ";
                labyrinth[player.PossitionX, player.PossitionY - 1] = " * ";
                player.PossitionY--;
                player.Moves++;
            }
            else
            {
                Console.WriteLine("Invalid move! ");
            }
        }

        private static void MovePlayerRight(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX, player.PossitionY + 1] == " - " ||
     labyrinth[player.PossitionX, player.PossitionY + 1] == " # ")
            {
                labyrinth[player.PossitionX, player.PossitionY] = " - ";
                labyrinth[player.PossitionX, player.PossitionY + 1] = " * ";
                player.PossitionY++;
                player.Moves++;
            }
            else
            {
                Console.WriteLine("Invalid move! ");
            }
        }

        private static void MovePlayerUp(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX - 1, player.PossitionY] == " - " ||
    labyrinth[player.PossitionX - 1, player.PossitionY] == " # ")
            {
                labyrinth[player.PossitionX, player.PossitionY] = " - ";
                labyrinth[player.PossitionX - 1, player.PossitionY] = " * ";
                player.PossitionX--;
                player.Moves++;
            }
            else
            {
                Console.WriteLine("Invalid move! ");
            }
        }

        private static void MovePlayerDown(string[,] labyrinth, Player player)
        {
            if (labyrinth[player.PossitionX + 1, player.PossitionY] == " - " ||
            labyrinth[player.PossitionX + 1, player.PossitionY] == " # ")
            {
                labyrinth[player.PossitionX, player.PossitionY] = " - ";
                labyrinth[player.PossitionX + 1, player.PossitionY] = " * ";
                player.PossitionX++;
                player.Moves++;
            }
            else
            {
                Console.WriteLine("Invalid move! ");
            }
        }
    }
}
