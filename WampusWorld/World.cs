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


        public void MakeWorld(Panel panel1, Button[,] World_array) 
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

            MakeWampus(panel1, World_array);
            MakeTreasure(panel1, World_array);
            makePits(panel1, World_array);
            
        }
        public void MakeWampus(Panel panel, Button[,] World_array)
        {
            row_wampus = random.Next(0, 3);
            col_wampus = random.Next(0, 3);
            while(row_wampus == 0 && col_wampus == 0)
            {
                row_wampus = random.Next(0, 3);
                col_wampus = random.Next(0, 3);
            }
            World_array[row_wampus, col_wampus].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/wampus.png");
            if((row_wampus + 1) < 4)
                World_array[row_wampus + 1, col_wampus].Text += "S";
            if((col_wampus + 1) < 4)
                World_array[row_wampus, col_wampus + 1].Text += "S";
            if((row_wampus - 1) >= 0)
                World_array[row_wampus - 1, col_wampus].Text += "S";
            if((col_wampus - 1) >= 0)
                World_array[row_wampus, col_wampus - 1].Text += "S";

        }

        

        public void MakeTreasure(Panel panel1, Button[,] World_array)
        {
            row_treasure = random.Next(0, 3);
            col_treasure = random.Next(0, 3);
            while ((row_treasure == row_wampus && col_treasure == col_wampus) || (row_treasure == 0 && col_treasure == 0))
            {
                row_treasure = random.Next(0, 3);
                col_treasure = random.Next(0, 3);
            }

            World_array[row_treasure, col_treasure].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/treasure.png");
            World_array[row_treasure, col_treasure].Text = "G";
        }

        public void makePits(Panel panel1, Button[,] World_array)
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

            if((row_pit1 + 1) < 4)
            {
                if (World_array[row_pit1 + 1, col_pit1].Text != "B" && World_array[row_pit1 + 1, col_pit1].Text != "SB")
                    World_array[row_pit1 + 1, col_pit1].Text += "B";
            }
            if((col_pit1 + 1) < 4)
            {
                if (World_array[row_pit1, col_pit1 + 1].Text != "B" && World_array[row_pit1, col_pit1 + 1].Text != "SB")
                    World_array[row_pit1, col_pit1 + 1].Text += "B";
            }
            if((row_pit1 - 1) >= 0)
            {
                if (World_array[row_pit1 - 1, col_pit1].Text != "B" && World_array[row_pit1 - 1, col_pit1].Text != "SB")
                    World_array[row_pit1 - 1, col_pit1].Text += "B";
            }
            if((col_pit1 - 1) >= 0)
            {
                if (World_array[row_pit1, col_pit1 - 1].Text != "B" && World_array[row_pit1, col_pit1 - 1].Text != "SB")
                    World_array[row_pit1, col_pit1 - 1].Text += "B";
            }

            if((row_pit2 + 1) < 4)
            {
                if (World_array[row_pit2 + 1, col_pit2].Text != "B" && World_array[row_pit2 + 1, col_pit2].Text != "SB")
                    World_array[row_pit2 + 1, col_pit2].Text += "B";
            }
            if((col_pit2 + 1) < 4)
            {
                if (World_array[row_pit2, col_pit2 + 1].Text != "B" && World_array[row_pit2, col_pit2 + 1].Text != "SB")
                    World_array[row_pit2, col_pit2 + 1].Text += "B";
            }
            if((row_pit2 - 1) >= 0)
            {
                if (World_array[row_pit2 - 1, col_pit2].Text != "B" && World_array[row_pit2 - 1, col_pit2].Text != "SB")
                    World_array[row_pit2 - 1, col_pit2].Text += "B";
            }
            if((col_pit2 - 1) >= 0)
            {
                if (World_array[row_pit2, col_pit2 - 1].Text != "B" && World_array[row_pit2, col_pit2 - 1].Text != "SB")
                    World_array[row_pit2, col_pit2 - 1].Text += "B";
            }
            
        }

    }
}
