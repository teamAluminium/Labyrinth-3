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
                var moveDirection = ReadPlayerCommand();
                var hasEscaped = CheckIfOut(player, labyrinth.Field);
                if (hasEscaped)
                {
                    break;
                }
                MovePlayer(moveDirection, labyrinth.Field, player);
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
            DrowLabirinthOnConsole(labyrinth);

        }

        private void DrowLabirinthOnConsole(Labyrinth labyrinth)
        {
            //I could have done it with overwritting ToString(), but then I could not use colors;
            Console.WriteLine();
            Console.WriteLine();
            for (int row = 0; row < labyrinth.Field.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.Field.GetLength(1); col++)
                {
                    if (labyrinth.Field[row, col] == " # ")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(labyrinth.Field[row, col]);
                    }
                    else if (labyrinth.Field[row, col] == " x ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(labyrinth.Field[row, col]);
                    }
                    else if (labyrinth.Field[row, col] == " - ")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(labyrinth.Field[row, col]);
                    }
                    else if (labyrinth.Field[row, col] == " * ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(labyrinth.Field[row, col]);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();
        }

        private string[,] SetPlayerOnField(string[,] labyrinth, Player player)
        {
            labyrinth[player.PossitionX, player.PossitionY] = " * ";
            return labyrinth;
        }

        private string ReadPlayerCommand()
        {
            Console.WriteLine("Enter your move (L=left, R=right, D=down, U=up): ");
            string moveDirection = Console.ReadLine();
            return moveDirection;

            //TODO: Implement these commands
            // case "top":
            //
            //     ShowScoreboard(scores);
            //     Console.WriteLine("\n");
            //     DisplayLabyrinth(labyrinth);
            //
            //     break;
            // case "restart":
            //     flag_temp = false;
            //
            //     break;
            // case "exit":
            //     Console.WriteLine("Good bye!");
            //     Environment.Exit(0);
            //     break;
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

        private void MovePlayer(string moveDirection, string[,] labyrinth, Player player)
        {
            switch (moveDirection)
            {
                case "d":

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
                    break;

                case "D":
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
                    break;

                case "u":
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
                    break;

                case "U":
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
                    break;

                case "r":

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
                    break;

                case "R":

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
                    break;

                case "l":

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
                    break;

                case "L":

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
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }
    }
}
