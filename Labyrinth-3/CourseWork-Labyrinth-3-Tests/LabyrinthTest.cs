using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork_Refactored;
using System.IO;

namespace CourseWork_Labyrinth_3_Tests
{
    [TestClass]
    public class LabyrinthTest
    {


        [TestMethod]
        public void CreateLabyrinthTest()
        {
            Labyrinth lab = new Labyrinth(5, 5);

            Assert.AreEqual(7, lab.Cols);
            Assert.AreEqual(7, lab.Rows);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateLabyrinthZeroDimentions()
        {
            Labyrinth lab = new Labyrinth(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateLabyrinthNegativeDimentions()
        {
            Labyrinth lab = new Labyrinth(-1, -1);
        }

        [TestMethod]
        public void DrawLabyrithTest()
        {
            string[,] StaticField = {{"#", "#", "#", "#", "#", "#", "#"},
                               {"#", "x", "-", "-", "x", "-", "#"},
                               {"#", "-", "-", "-", "x", "-", "#"},
                               {"#", "-", "-", "-", "x", "-", "#"},
                               {"#", "x", "-", "x", "x", "x", "#"},
                               {"#", "x", "-", "x", "-", "x", "#"},
                               {"#", "#", "#", "#", "#", "#", "#"}};

            Labyrinth lab = new Labyrinth(5, 5);
            lab.Field = StaticField;

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(@"
 #  #  #  #  #  #  #
 #  x  -  -  x  -  #
 #  -  -  -  x  -  #
 #  -  -  -  x  -  #
 #  x  -  x  x  x  #
 #  x  -  x  -  x  #
 #  #  #  #  #  #  #
"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    lab.DrawLabyrinth();

                    // Assert
                    var result = sw.ToString();
                    Assert.IsFalse(result.Equals(@"
 #  #  #  #  #  #  #
 #  x  -  -  x  -  #
 #  -  -  -  x  -  #
 #  -  -  -  x  -  #
 #  x  -  x  x  x  #
 #  x  -  x  -  x  #
 #  #  #  #  #  #  #
"));
                }
            }
        }                                                      
    }
}     