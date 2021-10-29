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
        public int posx, posy;

        public void MakeUnit(Panel panel1, Button[,] World_array)
        {
            World_array[3, 0].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
            posx = 0;
            posy = 3;
        }

       //Доделать
        public void checkPlace(Button[,] World_array)
        {
            if(posx == 0 && posy == 3)
                knowledge_map[posy, posx].Text = "OK";
            if (World_array[posy, posx].Image == Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/pit.png") 
                || World_array[posy, posx].Image == Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/wampus.png"))
            {
                
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

        public void Move(Panel panel1, Button[,] world_array)
        {
            world_array[posy, posx].Image = null;
            posx++;
            world_array[posy, posx].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
        }
    }
}
