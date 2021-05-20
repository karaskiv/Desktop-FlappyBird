using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 7;
        int gravity = 11;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 680;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 720;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -11;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 11;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
        }
    }
}
