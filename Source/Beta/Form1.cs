using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Classes;
using GameEngine.Constants;
using GameEngine.Enumerations;
using GameEngine.Interfaces;

namespace Beta
{
    public partial class Form1 : Form
    {

        private List<Player> players;
        private IList<PictureBox> tokens;
        private IList<Board> playground;
        private int turn;
        private IDice Dice;
        private Random rnd;
        private IList<Board> redFinish;
        private IList<Board> blueFinish;
        private IList<Board> yellowFinish;
        private IList<Board> greenFinish;


        public Form1()
        {
            AllocConsole();
            InitializeComponent();
            this.players = new List<Player>();


        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();



        public void LanchGame()
        {
            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new Dice()));
            playerNames.Add(new("R", new Dice()));
            playerNames.Add(new("S", new Dice()));
            playerNames.Add(new("Y", new Dice()));
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
            if (string.IsNullOrEmpty(textInput.Text) || string.IsNullOrWhiteSpace(textInput.Text))
            {

                listBox1.Items.Add("Skriv in ett giltigt namn");
            }
            else
            {
                var playerNames = new List<string>(); 
                playerNames.Add(textInput.Text);

                foreach (var player in playerNames)
                {
                    listBox1.Items.Add(player);
                }
            }
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
