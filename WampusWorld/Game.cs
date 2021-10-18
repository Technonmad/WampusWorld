using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
   public class Game
    {
        Game(Button[,] World_Array)
        {
            this.world = World_Array;
        }

        Unit unit = new Unit();
        World newWorld = new World();
        Button[,] world;



    }
}
