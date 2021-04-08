using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Classes;

namespace Beta
{
    public partial class Form1 : Form
    {
        public readonly object count;

        public Form1()
        {
            AllocConsole();
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        

        public void LanchGame()
        {
            var playerNames = new List<string>();
            playerNames.Add("M");
            playerNames.Add("R");
            playerNames.Add("S");
            playerNames.Add("Y");
            Engine newEngine = new Engine(new GameSettings(playerNames, 32));

            foreach (var player in playerNames)
            {
                listBox1.Items.Add(player);
            }

            newEngine.StartGame();
        }
        //Kasta tärningen
        public void button1_Click(object sender, EventArgs e)
        {
            

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

        //Registera namn
        private void button2_Click(object sender, EventArgs e)
        {
            var playerNames = new List<string>();
            playerNames.Add("M");
            playerNames.Add("R");
            playerNames.Add("S");
            playerNames.Add("Y");
            Engine newEngine = new Engine(new GameSettings(playerNames, 32));

            foreach (var player in playerNames)
            {
                listBox1.Items.Add(player);
            }

            newEngine.StartGame();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        //Starta spelet
        private void button19_Click(object sender, EventArgs e)
        {
            LanchGame();
        }
    }
}
