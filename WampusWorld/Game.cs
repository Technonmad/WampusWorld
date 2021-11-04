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
            try
            {
                if (world_array[posy, posx].Text.Contains("T"))
                    adventure_log.Text += "*Персонаж находит сокровище и уходит живым и богатым*" + Environment.NewLine + Environment.NewLine;
                else if (world_array[posy, posx].Text.Contains("W"))
                    adventure_log.Text += "*Персонаж погибает ужасной смертью*" + Environment.NewLine + Environment.NewLine;
                else if (world_array[posy, posx].Text.Contains("P"))
                    adventure_log.Text += "*Персонаж падает в яму и погибает*" + Environment.NewLine + Environment.NewLine;
                else if (knowledge_array[posy, posx + 1].Text.Contains("?") && knowledge_array[posy - 1, posx].Text.Contains("?"))
                {
                    world_array[posy, posx].Image = null;
                    posx = 0;
                    posy = 3;
                    for(int i = 3; i >= 0 ; i--)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            if(knowledge_array[i,j].Text == null)
                            {
                                world_array[i, j].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                                posx = j;
                                posy = i;
                                
                            }
                        }
                    }
                    checkPlace(adventure_log);


                }
                else
                {
                    if (knowledge_array[posy, posx + 1].Text == "" || knowledge_array[posy, posx + 1].Text.Contains(" B "))
                    {
                        world_array[posy, posx].Image = null;
                        world_array[posy, posx + 1].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                        posx++;
                        checkPlace(adventure_log);

                    }
                    else
                    {
                        try
                        {
                            world_array[posy, posx].Image = null;
                            posx = 0;
                            posy--;
                            world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                            checkPlace(adventure_log);
                        }
                        catch
                        {
                            world_array[posy, posx].Image = null;
                            posx = 0;
                            posy = 3;
                            world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                            checkPlace(adventure_log);
                        }
                    }
                }

            }
            catch
            {
                if (posy > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!knowledge_array[posy - 1, i].Text.Contains("?"))
                        {
                            world_array[posy, posx].Image = null;
                            posx = i;
                            posy--;
                            world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                            checkPlace(adventure_log);
                            break;
                        }
                    }
                    adventure_log.Text += "*Персонаж бьется об стену, но находит другой проход*" + Environment.NewLine + Environment.NewLine;
                    world_array[posy, posx].Image = null;
                    posx = 0;
                    posy--;
                    world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                    checkPlace(adventure_log);
                }
                else
                {
                    adventure_log.Text += "*Персонаж бьется об стену, но находит другой проход*" + Environment.NewLine + Environment.NewLine;
                    world_array[posy, posx].Image = null;
                    posx = 0;
                    posy = 3;
                    world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
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
                    if (world_array[posy, posx].Text.Contains("B"))
                        knowledge_array[posy, posx + 1].Text += " P? ";
                    if (world_array[posy, posx].Text.Contains("S"))
                        knowledge_array[posy, posx + 1].Text += " W? ";
                    if (knowledge_array[posy, posx + 1].Text.Contains("W? W?"))
                        Shoot(adventure_log);
                    if (knowledge_array[posy, posx + 1].Text.Contains("P? P?"))
                        knowledge_array[posy, posx + 1].Text = " P ";
                }
                /*if (posx - 1 >= 0)
                {
                    if (world_array[posy, posx].Text == "B")
                        if (knowledge_array[posy, posx - 1].Text != " OK ")
                            knowledge_array[posy, posx - 1].Text += " P? ";
                    if (world_array[posy, posx].Text == "S")
                        if (knowledge_array[posy, posx - 1].Text != " OK ")
                            knowledge_array[posy, posx - 1].Text += " W? ";
                }*/
                if (posy - 1 >= 0)
                {
                    if (world_array[posy, posx].Text.Contains("B"))
                        knowledge_array[posy - 1, posx].Text += " P? ";
                    if (world_array[posy, posx].Text.Contains("S"))
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
            world_array[3, 0].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
            posx = 0;
            posy = 3;
        }

        public bool checkWinOrDie(TextBox adventure_log)
        {
            if (adventure_log.Text.Contains("*Персонаж находит сокровище и уходит живым и богатым*") ||
                adventure_log.Text.Contains("*Персонаж погибает ужасной смертью*") ||
                adventure_log.Text.Contains("*Персонаж падает в яму и погибает*"))
                return true;
            else return false;
        }

        public void Shoot(TextBox adventure_log)
        {
            adventure_log.Text += "*Из глубин пещеры издается ужасающий крик...*" + Environment.NewLine + Environment.NewLine;
            arrow = false;
        }
    }
}
