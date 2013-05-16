using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_Refactored;
using System.IO;

namespace CourseWork_Labyrinth_3_Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void AddPlayerTest()
        {
            Player player = new Player("Name", 4, 7);
            ScoreBoard.AddPlayer(player);
            
            //Verify that the player is added 
            //Error: No access to players list due to its protection level

            Assert.AreEqual(1,0);
        }

        [TestMethod]
        public void KeepOnlyTopPlayersTest()
        {           
            ScoreBoard.AddPlayer(new Player("Name0", 4, 7));
            ScoreBoard.AddPlayer(new Player("Name1", 4, 3));
            ScoreBoard.AddPlayer(new Player("Name2", 5, 3));
            ScoreBoard.AddPlayer(new Player("Name3", 7, 1));
            ScoreBoard.AddPlayer(new Player("Name4", 9, 3));

            //Verify that only the top players are kept
            //Error: No access to players list due to its protection level

            Assert.AreEqual(1, 0);
        }

        [TestMethod]
        public void PrintScoreboardTest()
        {
            Player player = new Player("Name", 4, 7);
            ScoreBoard.AddPlayer(player);

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(@"Scoreboard:
1. Name --> 0 moves"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    
                    // Act
                    ScoreBoard.PrintScoreboard();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals(@"Scoreboard:
1. Name --> 0 moves"));
                }
            }
            
        }
    }
}
