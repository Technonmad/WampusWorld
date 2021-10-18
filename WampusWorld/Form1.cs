using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WampusWorld
{
    public partial class Form1 : Form
    {
        World world = new World();
        Knowledge knowledge = new Knowledge();
        Game
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            world.MakeWorld(panel1);
            knowledge.MakeKnowledgeMap(panel2);
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }
    }
}
