﻿using System;
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
        int score = 1000;
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
            game.MoveUnit(panel1, textBox1);
            score -= 10;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
