using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Classes;

namespace Beta
{
    public partial class Form1 : Form
    {
        public int players { get; private set; }

        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine newEngine = new Engine(new GameSettings(4, 44));
            newEngine.StartGame();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
