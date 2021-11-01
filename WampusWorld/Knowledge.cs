using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
    class Knowledge
    {
        //Button[,] KnowledgeButtons = new Button[4, 4];
        public void MakeKnowledgeMap(Panel panel, Button[,] knowledge_array)
        {
            for (int i = 0; i < knowledge_array.GetLength(0); i++)
            {
                for (int j = 0; j < knowledge_array.GetLength(1); j++)
                {
                    Button btn = new Button();
                    btn.Name = "btnK" + i + j;
                    btn.Width = 80;
                    btn.Height = 80;
                    btn.Location = new Point(btn.Width * j, btn.Height * i);
                    knowledge_array[i, j] = btn;
                    panel.Controls.Add(btn);
                }
            }
        }
    }
}
