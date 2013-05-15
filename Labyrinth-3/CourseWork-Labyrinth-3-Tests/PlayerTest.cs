using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_Refactored;

namespace CourseWork_Labyrinth_3_Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void CreatePlayerNameTest()
        {
            Player player = new Player("MyName", 3, 5);

            Assert.AreEqual("MyName", player.Name);
        }

        [TestMethod]
        public void CreatePlayerPositionTest()
        {
            Player player = new Player("MyName", 4, 9);

            Assert.AreEqual(4, player.PossitionX);
            Assert.AreEqual(9, player.PossitionY);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePlayerEmptyName()
        {
            Player player = new Player("", 5, 7);
        }

        [TestMethod]
        public void IncreaseMovesTest()
        {
            Player player = new Player("Name", 4, 3);

            player.IncreaseMoves();

            Assert.AreEqual(1, player.Moves);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            Player player = new Player("NAme", 3, 5);

            player.MoveDown();

            Assert.AreEqual(4, player.PossitionX);
        }

        [TestMethod]
        public void MoveUpTest()
        {
            Player player = new Player("Name", 5, 3);

            player.MoveUp();

            Assert.AreEqual(4, player.PossitionX);
        }

        [TestMethod]
        public void MoveLeftTest()
        {
            Player player = new Player("Name", 6, 9);

            player.MoveLeft();

            Assert.AreEqual(8, player.PossitionY);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            Player player = new Player("Name", 8, 5);

            player.MoveRight();

            Assert.AreEqual(6, player.PossitionY);
        }

        [TestMethod]
        public void GetScoreTest()
        {
            Player player = new Player("Name", 8, 6);

            player.MoveRight();
            player.MoveLeft();
            player.MoveDown();
            player.MoveUp();

            int expected = 4 * 10;
            int actual = player.GetScore();

            Assert.AreEqual(expected, actual);

        }
    }
}
