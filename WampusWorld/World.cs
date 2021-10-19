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
        Random random = new Random();
        int row_wampus, col_wampus, row_treasure, col_treasure, row_pit1, col_pit1, row_pit2, col_pit2;
        Button[,] World_array = new Button[4, 4];


        public void MakeWorld(Panel panel1)
        {
            for(int i = 0; i < World_array.GetLength(0); i++)
            {
                for(int j = 0; j < World_array.GetLength(1); j++)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + i + j;
                    btn.Width = 80;
                    btn.Height = 80;
                    btn.Location = new Point(btn.Width * j, btn.Height * i);
                    World_array[i, j] = btn;
                    panel1.Controls.Add(btn);
                }
            }

            MakeWampus(panel1);
            MakeUnit(panel1);
            MakeTreasure(panel1);
            makePits(panel1);
            
        }
        public void MakeWampus(Panel panel)
        {
            row_wampus = random.Next(0, 3);
            col_wampus = random.Next(0, 3);
            while(row_wampus == 0 && col_wampus == 0)
            {
                row_wampus = random.Next(0, 3);
                col_wampus = random.Next(0, 3);
            }
            World_array[row_wampus, col_wampus].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/wampus.png");
        }

        public void MakeUnit(Panel panel1)
        {
            World_array[3, 0].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
        }

        public void MakeTreasure(Panel panel1)
        {
            row_treasure = random.Next(0, 3);
            col_treasure = random.Next(0, 3);
            while ((row_treasure == row_wampus && col_treasure == col_wampus) || (row_treasure == 0 && col_treasure == 0))
            {
                row_treasure = random.Next(0, 3);
                col_treasure = random.Next(0, 3);
            }

            World_array[row_treasure, col_treasure].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/treasure.png");
        }

        public void makePits(Panel panel1)
        {
            row_pit1 = random.Next(0, 3);
            col_pit1 = random.Next(0, 3);
            
            while((row_pit1 == row_wampus && col_pit1 == col_wampus) || (row_pit1 == 0
                && col_pit1 == 0) || (row_pit1 == row_treasure && col_pit1 == col_treasure))
            {
                row_pit1 = random.Next(0, 3);
                col_pit1 = random.Next(0, 3);
            }

            World_array[row_pit1, col_pit1].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/pit.png");
            
            row_pit2 = random.Next(0, 3);
            col_pit2 = random.Next(0, 3);

            while ((row_pit2 == row_wampus && col_pit2 == col_wampus) || (row_pit2 == 0 && col_pit2 == 0)
                || (row_pit2 == row_treasure && col_pit2 == col_treasure) || (row_pit2 == row_pit1 && col_pit2 == col_pit1))
            {
                row_pit2 = random.Next(0, 3);
                col_pit2 = random.Next(0, 3);
            }

            World_array[row_pit2, col_pit2].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/pit.png");
        }

    }
}
