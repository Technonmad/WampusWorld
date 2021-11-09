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
        public Game game = new Game();
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
            game.startGame(panel1, panel2, textBox1);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            game.MoveUnit(textBox1);
            if (game.checkWinOrDie(textBox1))
            {
                button33.Enabled = false;
                //Restart_Button.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Restart_Button_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            textBox1.Text = "";
            game.startGame(panel1, panel2, textBox1);
            button33.Enabled = true;
            //Restart_Button.Visible = false;
        }
    }
}
