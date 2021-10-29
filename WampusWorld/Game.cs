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
        World world = new World();
        Unit unit = new Unit();
        int score = 0, row = 3, col = 0;
        bool arrow = true;

        Knowledge knowledge;
        Button[,] world_array = new Button[4, 4];
        Button[,] knowledge_array = new Button[4, 4];

        public void startGame(Panel panel1)
        {
            world.MakeWorld(panel1, world_array);
            unit.MakeUnit(panel1, world_array);
        }

        public void MoveUnit(Panel panel1)
        {
            unit.Move(panel1, world_array);
            
        }
    }
}
