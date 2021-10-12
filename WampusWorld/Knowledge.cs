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
        Button[,] KnowledgeButtons = new Button[4, 4];
        public void MakeKnowledgeMap(Panel panel)
        {
            for (int i = 0; i < KnowledgeButtons.GetLength(0); i++)
            {
                for (int j = 0; j < KnowledgeButtons.GetLength(1); j++)
                {
                    Button btn = new Button();
                    btn.Name = "btnK" + i + j;
                    btn.Width = 80;
                    btn.Height = 80;
                    btn.Location = new Point(btn.Width * j, btn.Height * i);
                    KnowledgeButtons[i, j] = btn;
                    panel.Controls.Add(btn);
                }
            }
        }
    }
}
