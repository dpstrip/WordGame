using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordGame;

namespace WindowsWord
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game();
            game.startRound();
            label4.Text = game.score.ToString();
            label7.Text = game.turn.score.ToString();
            label2.Text = game.turn.word.jumbleWord;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string guess = textBox1.Text;
            if (game.turn.takeATurn(guess))
            {  //if made guess, is correct update the game score, clear text box and then start new turn
                textBox1.Text = "";
                game.endTurn();
                startTurn();

            }//Did I run out of turns? if I did start new turn
            else if (game.turn.score == 0)
            {
                textBox1.Text = "";
                game.endTurn();
                startTurn();

            }//clear text box and get next guess
            else
            {
                textBox1.Text = "";
                label7.Text = game.turn.score.ToString();
                

            }
        }

        private void startTurn()
        {
            // int score = game.turn.score + game.score;
            //label4.Text = score.ToString();
            label4.Text = game.score.ToString();
            if (game.startRound())
            {
                label7.Text = game.turn.score.ToString();
                label2.Text = game.turn.word.jumbleWord;
            }
            else
            {
                MessageBox.Show("Out of words");
            }
        }
    }
}
