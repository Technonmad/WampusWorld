using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
    public class Unit
    {
        Button[,] knowledge_map = new Button[4, 4];
        public void MoveUp(Button[,] world, int row, int col)
        {
            row++;
            world[row,col].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
        }

        public Unit(Panel panel1, Button[,] World_array)
        {
            World_array[3, 0].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
            int posx = 0;
            int posy = 3;
        }

        public void checkPlace(int posX, int posY, bool Stench, bool Breeze, bool Glitter, bool Bump, bool Died, Button[,] knowledge)
        {
            if(posX == 0 && posY == 3)
                knowledge[posY, posX].Text = "OK";
            if (!Died)
            {
                if (Stench)
                {
                    knowledge[posY, posX].Text = "S";

                }
            }
            
        }

        public void FindTreasure(Button[,] btn_array)
        {
            
        }

        public void Died(Button[,] btn_array)
        {
            
        }

        public void Shoot()
        {
            
        }
    }
}
