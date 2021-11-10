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
        int posx, posy, flag = 0, pitsCount = 0;
        bool arrow = true, wampusDead = false;

        Knowledge knowledge = new Knowledge();
        Button[,] world_array = new Button[4, 4];
        Button[,] knowledge_array = new Button[4, 4];

        public void startGame(Panel panel1, Panel panel2, TextBox adventure_log)
        {
            pitsCount = 0;
            world.MakeWorld(panel1, world_array);
            knowledge.MakeKnowledgeMap(panel2, knowledge_array);
            MakeUnit(panel1);
            checkPlace(adventure_log);
        }

        public void MoveUnit(TextBox adventure_log)
        {
            try
            {
                if (knowledge_array[posy, posx + 1].Text == "")
                    GoRight(adventure_log);
                else
                    ChangeLevel(adventure_log);
            }
            catch
            {
                ChangeLevel(adventure_log);
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
                try
                {
                    if (world_array[posy, posx].Text.Contains("B"))
                    {
                        if (knowledge_array[posy, posx + 1].Text.Contains("P?"))
                        {
                            knowledge_array[posy, posx + 1].Text = "";
                            knowledge_array[posy, posx + 1].Text = "P!";
                            pitsCount++;
                        }
                        if (knowledge_array[posy, posx - 1].Text.Contains("P?"))
                        {
                            knowledge_array[posy, posx - 1].Text = "";
                            knowledge_array[posy, posx - 1].Text = "P!";
                            pitsCount++;
                        }

                    }
                    if (world_array[posy, posx].Text.Contains("S"))
                    {
                        if (knowledge_array[posy, posx + 1].Text.Contains("W?"))
                        {
                            knowledge_array[posy, posx + 1].Text = "";
                            knowledge_array[posy, posx + 1].Text = "W! dead";
                            Shoot(adventure_log);
                            UpdateWampus();
                        }
                        else if (knowledge_array[posy, posx - 1].Text.Contains("W?"))
                        {
                            knowledge_array[posy, posx - 1].Text = "";
                            knowledge_array[posy, posx - 1].Text = "W! dead";
                            wampusDead = true;
                            Shoot(adventure_log);
                            UpdateWampus();
                        }
                    }
                }
                catch { };

                //if (posy - 1 >= 0)
                //{
                try
                {
                    if (knowledge_array[posy, posx].Text.Contains("B") && !knowledge_array[posy - 1, posx].Text.Contains("OK") && !knowledge_array[posy - 1, posx].Text.Contains("!"))
                        knowledge_array[posy - 1, posx].Text += "P?";
                    if (knowledge_array[posy, posx].Text.Contains("S") && !knowledge_array[posy - 1, posx].Text.Contains("OK") && !knowledge_array[posy - 1, posx].Text.Contains("!") && wampusDead == false)
                        knowledge_array[posy - 1, posx].Text += "W?";
                    //}
                    //if (posx + 1 < 4)
                    //{
                    if (knowledge_array[posy, posx].Text.Contains("B") && !knowledge_array[posy, posx + 1].Text.Contains("OK") && !knowledge_array[posy, posx + 1].Text.Contains("!"))
                        knowledge_array[posy, posx + 1].Text += "P?";
                    if (knowledge_array[posy, posx].Text.Contains("S") && !knowledge_array[posy, posx + 1].Text.Contains("OK") && !knowledge_array[posy, posx + 1].Text.Contains("!") && wampusDead == false)
                        knowledge_array[posy, posx + 1].Text += "W?";
                    //}
                    //if (posy + 1 < 4)
                    //{
                    if (knowledge_array[posy, posx].Text.Contains("B") && !knowledge_array[posy + 1, posx].Text.Contains("OK") && !knowledge_array[posy + 1, posx].Text.Contains("!"))
                        knowledge_array[posy + 1, posx].Text += "P?";
                    if (knowledge_array[posy, posx].Text.Contains("S") && !knowledge_array[posy + 1, posx].Text.Contains("OK") && !knowledge_array[posy + 1, posx].Text.Contains("!") && wampusDead == false)
                        knowledge_array[posy + 1, posx].Text += "W?";

                    if (knowledge_array[posy, posx].Text.Contains("B") && !knowledge_array[posy, posx - 1].Text.Contains("OK") && !knowledge_array[posy, posx - 1].Text.Contains("!"))
                        knowledge_array[posy, posx - 1].Text += "P?";
                    if (knowledge_array[posy, posx].Text.Contains("S") && !knowledge_array[posy, posx - 1].Text.Contains("OK") && !knowledge_array[posy, posx - 1].Text.Contains("!") && wampusDead == false)
                        knowledge_array[posy, posx - 1].Text += "W?";
                    //}
                }
                catch { };

                if (world_array[posy, posx].Text == "B")
                    adventure_log.Text += "Сквозняк...наверняка где-то поблизости есть яма" + Environment.NewLine + Environment.NewLine;
                if (world_array[posy, posx].Text == "S")
                    adventure_log.Text += "Что за жуткая вонь? Это мои носки или..." + Environment.NewLine + Environment.NewLine;

                if (pitsCount == 2)
                    UpdatePits();

            }
            catch { };
        }

        public void MakeUnit(Panel panel1)
        {
            world_array[3, 0].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
            posx = 0;
            posy = 3;
        }

        public int checkWinOrDie(TextBox adventure_log)
        {
            if (adventure_log.Text.Contains("*Персонаж находит сокровище и уходит живым и богатым*"))
            {
                return 1;
            }
            else if (adventure_log.Text.Contains("*Персонаж погибает ужасной смертью*") ||
                adventure_log.Text.Contains("*Персонаж падает в яму и погибает*"))
            {
                return 2;
            }
            return 0;
        }

        public void Shoot(TextBox adventure_log)
        {
            adventure_log.Text += "*Из глубин пещеры издается ужасающий крик...*" + Environment.NewLine + Environment.NewLine;
            arrow = false;
        }


        public void UpdatePits()
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

        public void UpdateWampus()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (knowledge_array[i, j].Text.Contains("W?"))
                        knowledge_array[i, j].Text.Replace("W?","");
                }
            }
        }

        public void GoRight(TextBox adventure_log)
        {
            world_array[posy, posx].Image = null;
            posx++;
            world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
            checkPlace(adventure_log);
        }

        public void ChangeLevel(TextBox adventure_log)
        {
            flag = 0;
            for (int j = posy; j >= 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (j == 3)
                    {
                        try
                        {
                            if (knowledge_array[j, i - 1].Text == "")
                                knowledge_array[j, i].Text = "OK";
                            if (world_array[j, i + 1].Text.Contains("B"))
                                knowledge_array[j - 1, i].Text += "P?";
                        }
                        catch { };
                        
                            //checkPlace(adventure_log);
                        if (!knowledge_array[j, i].Text.Contains("OK"))
                            knowledge_array[j, i].Text += "OK";
                    }
                    if (knowledge_array[j, i].Text == "" || world_array[j, i].Text.Contains("T"))
                    {
                        world_array[posy, posx].Image = null;
                        posx = i;
                        posy = j;
                        world_array[posy, posx].Image = Image.FromFile("C:/Users/Anton/Documents/GitHub/WampusWorld/images/unit.png");
                        //checkPlace(adventure_log);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                    break;
            }
        }
    }
}
