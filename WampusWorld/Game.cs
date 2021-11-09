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
        int posx, posy, flag, pitsCount = 0;
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

        public void MoveUnit(TextBox adventure_log)
        {

            try
            {

                //Может ли пойти направо
                if (posx < 3)
                {
                    if (knowledge_array[posy, posx + 1].Text == "" || knowledge_array[posy, posx + 1].Text.Contains("OK"))
                    {
                        world_array[posy, posx].Image = null;
                        world_array[posy, posx + 1].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                        posx++;
                    }
                }
                //или налево
                else if (knowledge_array[posy, posx - 1].Text == "")
                {
                    world_array[posy, posx].Image = null;
                    world_array[posy, posx - 1].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                    posx--;
                }
                //а может вверх?
                else if (knowledge_array[posy - 1, posx].Text == "")
                {
                    world_array[posy, posx].Image = null;
                    world_array[posy - 1, posx].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                    posy--;
                }
                else
                {
                    for (int j = 3; j > 0; j--)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (knowledge_array[j, i].Text == "")
                            {
                                world_array[posy, posx].Image = null;
                                posx = i;
                                posy = j;
                                world_array[posy, posy].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;
                    }

                }
                //нет? Тогда пробуем найти непосещенные клетки
                //else
                //{
                //    for (int i = posy; i > 0; i--)
                //    {
                //        for (int j = posx; j < 4; j++)
                //        {
                //            if (knowledge_array[i, j].Text == "")
                //            {
                //                world_array[posy, posx].Image = null;
                //                world_array[i, j].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                //                posx = j;
                //                posy = i;
                //                flag = 1;
                //                break;
                //            }
                //        }
                //        if (flag == 1)
                //            break;
                //    }

                //}

            }
            //если уперлись в стену
            //пробуем пройти выше
            catch
            {
                /*if(posy > 0)
                {
                    for (int i = posy - 1; i > 0; i--)
                    {
                        for (int j = posx; j < 4; j++)
                        {
                            if (knowledge_array[i, j].Text == "")
                            {
                                world_array[posy, posx].Image = null;
                                world_array[i, j].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
                                posx = j;
                                posy = i;
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;
                    }
                }*/
            }
            if (!knowledge_array[posy, posx].Text.Contains("OK"))
                checkPlace(adventure_log);
        }

        public void checkPlace(TextBox adventure_log)
        {
            try
            {
                if (world_array[posy, posx].Text.Contains("T"))
                    adventure_log.Text += "*Персонаж находит сокровище и уходит живым и богатым*" + Environment.NewLine + Environment.NewLine;
                else if (world_array[posy, posx].Text.Contains("W"))
                    adventure_log.Text += "*Персонаж погибает ужасной смертью*" + Environment.NewLine + Environment.NewLine;
                else if (world_array[posy, posx].Text.Contains("P"))
                    adventure_log.Text += "*Персонаж падает в яму и погибает*" + Environment.NewLine + Environment.NewLine;
                if (posx == 0 && posy == 3)
                    knowledge_array[posy, posx].Text = " OK ";
                else
                    knowledge_array[posy, posx].Text = " OK ";
                knowledge_array[posy, posx].Text += world_array[posy, posx].Text;
                if (posx + 1 < 4)
                {
                    if (world_array[posy, posx].Text.Contains("B"))
                    {
                        if (knowledge_array[posy, posx + 1].Text.Contains("P?"))
                        {
                            knowledge_array[posy, posx + 1].Text = "P!";
                            pitsCount++;
                        }
                    }
                    if (world_array[posy, posx].Text.Contains("S"))
                    {
                        if (knowledge_array[posy, posx + 1].Text.Contains("W?"))
                        {
                            knowledge_array[posy, posx + 1].Text = "W! dead";
                            Shoot(adventure_log);
                        }
                    }
                }

                if (posy - 1 >= 0)
                {
                    if (world_array[posy, posx].Text.Contains("B") && !knowledge_array[posy - 1, posx].Text.Contains("OK"))
                        knowledge_array[posy - 1, posx].Text += " P? ";
                    if (world_array[posy, posx].Text.Contains("S"))
                        knowledge_array[posy - 1, posx].Text += " W? ";
                }
                if (world_array[posy, posx].Text == "B")
                    adventure_log.Text += "Сквозняк...наверняка где-то поблизости есть яма" + Environment.NewLine + Environment.NewLine;
                if (world_array[posy, posx].Text == "S")
                    adventure_log.Text += "Что за жуткая вонь? Это мои носки или..." + Environment.NewLine + Environment.NewLine;

                if (pitsCount == 2)
                    UpdateKnowledgeMap();

            }
            catch { };
        }

        public void MakeUnit(Panel panel1)
        {
            world_array[3, 0].Image = Image.FromFile("C:/Users/User/Documents/GitHub/WampusWorld/images/unit.png");
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


        public void UpdateKnowledgeMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (knowledge_array[i, j].Text.Contains("P?"))
                        knowledge_array[i, j].Text = "";
                }
            }
        }

    }
}
