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
        int score = 0, row = 3, col = 0;
        bool arrow = true;
        
        public void MoveUp(Button[,] world)
        {
            score -= 10;
            row++;
            world[row,col].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
        }
        
        public void MoveDown(TextBox[,] textBox_array)
        {
            score -= 10;
        }

        public void MoveLeft(TextBox[,] textBox_array)
        {
            score -= 10;
        }

        public void MoveRight(TextBox[,] textBox_array)
        {
            score -= 10;
        }

        public void FindTreasure(TextBox[,] textBox_array)
        {
            score += 1000;
        }

        public void DiedFromWampus(TextBox[,] textBox_array)
        {
            score -= 1000;
        }

        public void DiedFromPit(TextBox[,] textBox_array)
        {
            score -= 1000;
        }

        public void Shoot()
        {
            score -= 11;
        }
    }
}
