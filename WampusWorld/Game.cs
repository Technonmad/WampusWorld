using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
    public class Game
    {
        World world = new World();
        int posx, posy;
        bool arrow = true;

        Knowledge knowledge = new Knowledge();
        Button[,] world_array = new Button[4, 4];
        Button[,] knowledge_array = new Button[4, 4];

        public void startGame(Panel panel1, Panel panel2, TextBox adventure_log)
        {
            world.MakeWorld(panel1, world_array);
            knowledge.MakeKnowledgeMap(panel2, knowledge_array);
            MakeUnit(panel1);
            checkPlace(adventure_log);
        }

        public void MoveUnit(Panel panel1, TextBox adventure_log)
        {
            if (posx < 4 && posx > 0)
            {
                if (knowledge_array[posy, posx + 1].Text == null || knowledge_array[posy, posx + 1].Text.Contains(" OK "))
                {
                    world_array[posy, posx].Image = null;
                    world_array[posy, posx + 1].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                    checkPlace(adventure_log);

                    /*if (knowledge_array[posy, posx].Text == "W" && world_array[posy, posx].Image == Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png"))
                    {
                        adventure_log.Text += "Ну вот, меня съедят(";
                    }*/

                }
                if (knowledge_array[posy, posx - 1].Text == null || knowledge_array[posy, posx + 1].Text.Contains(" OK "))
                {
                    world_array[posy, posx].Image = null;
                    world_array[posy, posx + 1].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                    checkPlace(adventure_log);

                    /*if (knowledge_array[posy, posx].Text == "W" && world_array[posy, posx].Image == Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png"))
                    {
                        adventure_log.Text += "Ну вот, меня съедят(";
                    }*/

                }
            }
            else if (posy < 4 && posx > 0)
            {
                if (knowledge_array[posy, posx + 1].Text == null || knowledge_array[posy, posx + 1].Text.Contains(" OK "))
                {
                    world_array[posy, posx].Image = null;
                    world_array[y, x].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                    posx = x;
                    posy = y;
                    checkPlace(adventure_log);

                    if (knowledge_array[posy, posx].Text == "W" && world_array[posy, posx].Image == Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png"))
                    {
                        adventure_log.Text += "Ну вот, меня съедят(";
                    }

                }
            }
        }

        public void checkPlace(TextBox adventure_log)
        {
            try
            {
                if (posx == 0 && posy == 3)
                    knowledge_array[posy, posx].Text = " OK ";
                else
                    knowledge_array[posy, posx].Text = " OK ";
                knowledge_array[posy, posx].Text += world_array[posy, posx].Text;
                if (posx + 1 < 4)
                {
                    if (world_array[posy, posx].Text == "B")
                        knowledge_array[posy, posx + 1].Text += " P? ";
                    if (world_array[posy, posx].Text == "S")
                        knowledge_array[posy, posx + 1].Text += " W? ";
                }
                if (posy + 1 < 4)
                {
                    if (world_array[posy, posx].Text == "B")
                        knowledge_array[posy + 1, posx].Text += " P? ";
                    if (world_array[posy, posx].Text == "S")
                        knowledge_array[posy + 1, posx].Text += " W? ";
                }
                if (posx - 1 >= 0)
                {
                    if (world_array[posy, posx].Text == "B")
                        if (knowledge_array[posy, posx - 1].Text != " OK ")
                            knowledge_array[posy, posx - 1].Text += " P? ";
                    if (world_array[posy, posx].Text == "S")
                        if (knowledge_array[posy, posx - 1].Text != " OK ")
                            knowledge_array[posy, posx - 1].Text += " W? ";
                }
                if (posy - 1 >= 0)
                {
                    if (world_array[posy, posx].Text == "B")
                        knowledge_array[posy - 1, posx].Text += " P? ";
                    if (world_array[posy, posx].Text == "S")
                        knowledge_array[posy - 1, posx].Text += " W? ";
                }
                if (world_array[posy, posx].Text == "B")
                    adventure_log.Text += "Сквозняк...наверняка где-то поблизости есть яма" + Environment.NewLine + Environment.NewLine;
                if (world_array[posy, posx].Text == "S")
                    adventure_log.Text += "Что за жуткая вонь? Это мои носки или..." + Environment.NewLine + Environment.NewLine;
            }
            catch { };
        }

        public void MakeUnit(Panel panel1)
        {
            world_array[3, 0].Image = Image.FromFile("C://Users/User/Documents/GitHub/WampusWorld/images/unit.png");
            posx = 0;
            posy = 3;
        }
    }
}
