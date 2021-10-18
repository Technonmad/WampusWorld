using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
    public class World
    {
        Button[,] WorldButtons = new Button[4, 4];
        Random random = new Random();
        int row, col;
        public void MakeWorld(Panel panel1)
        {
            for(int i = 0; i < WorldButtons.GetLength(0); i++)
            {
                for(int j = 0; j < WorldButtons.GetLength(1); j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + i + j;
                    btn.Width = 80;
                    btn.Height = 80;
                    btn.Location = new Point(btn.Width * j, btn.Height * i);
                    WorldButtons[i, j] = btn;
                    panel1.Controls.Add(btn);
                }
            }

            MakeWampus(panel1);
            MakeUnit(panel1);
            MakeTreasure(panel1);
            
            
        }
        public void MakeWampus(Panel panel)
        {
            row = random.Next(1, 3);
            col = random.Next(0, 3);
            WorldButtons[row, col].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/wampus.png");
        }

        public void MakeUnit(Panel panel1)
        {
            WorldButtons[3, 0].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
        }

        public void MakeTreasure(Panel panel1)
        {
            int row1 = random.Next(1, 3);
            int col1 = random.Next(0, 3);
            if(row1 == row && col1 == col)
                WorldButtons[row1 + 1, col1].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/treasure.png");
            else
                WorldButtons[row1, col1].Image = Image.FromFile("C://Users/Anton/Documents/GitHub/WampusWorld/images/treasure.png");
        }

    }
}
