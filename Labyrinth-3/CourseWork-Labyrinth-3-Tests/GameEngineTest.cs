using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_Refactored;

namespace CourseWork_Labyrinth_3_Tests
{
    [TestClass]
    public class GameEngineTest
    {
        
        [TestMethod]
        public void TryEscapeFromLabyrinthRight()
        {
            Labyrinth lab = new Labyrinth(5, 5);
            Player player = new Player("Name", 4, 4);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Invalid move! "))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    player.MoveRight();
                    player.MoveRight();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals("Invalid move! "));
                }
            }
        }

        [TestMethod]
        public void TryEscapeFromLabyrinthLeft()
        {
            Labyrinth lab = new Labyrinth(5, 5);
            Player player = new Player("Name", 1, 1);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Invalid move! "))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    player.MoveLeft();
                    player.MoveLeft();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals("Invalid move! "));
                }
            }
        }

        [TestMethod]
        public void TryEscapeFromLabyrinthDown()
        {
            Labyrinth lab = new Labyrinth(5, 5);
            Player player = new Player("Name", 4, 1);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Invalid move! "))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    player.MoveDown();
                    player.MoveDown();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals("Invalid move! "));
                }
            }
        }

        [TestMethod]
        public void TryEscapeFromLabyrinthUp()
        {
            Labyrinth lab = new Labyrinth(5, 5);
            Player player = new Player("Name", 0, 1);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Invalid move! "))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    player.MoveUp();
                    player.MoveUp();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals("Invalid move! "));
                }
            }
        }
    }
}
