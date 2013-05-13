using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Refactored
{
    class Application
    {
        static void Main()
        {
            var gameEngin = new GameEngine();
            gameEngin.Run("Pesho", 10, 10);
        }
    }
}
