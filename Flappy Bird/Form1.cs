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
            pipeBottom2.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left < -300)
            {
                pipeBottom.Left = 680;
                score++;
            }
            if(pipeTop.Left < -300)
            {
                pipeTop.Left = 720;
                score++;
            }
            if (pipeBottom2.Left < -300)
            {
                pipeBottom2.Left = 680;
                score++;
            }
            if (pipeTop2.Left < -300)
            {
                pipeTop2.Left = 720;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || flappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) || flappyBird.Bounds.IntersectsWith(pipeTop2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Top < -35
                )
            {
                endGame();
            }

            if(flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame2();
            }


            if (score > 5)
            {
                pipeSpeed = 15;
            }

            if(score > 15)
            {
                pipeSpeed = 20;
            }

            if (score > 20)
            {
                pipeSpeed = 25;
            }

            if (score > 25)
            {
                pipeSpeed = 35;
            }
            if (score > 45)
            {
                pipeSpeed = 40;
            }
            if (score > 60)
            {
                pipeSpeed = 50;
            }

           
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                gravity = -11;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = 11;
            }

        }

        private void endGame()
        {
            if (score > 100)
            {
                gameTimer.Stop();
                scoreText.Text += " Game Over -> High Score!";
            }
            else
            {
                gameTimer.Stop();
                scoreText.Text += " Game Over!";
            }
            
        }

        private void endGame2()
        {
            ground.Controls.Add(flappyBird);
            flappyBird.Location = new Point(50, 0);
            flappyBird.BackColor = Color.Transparent;
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
        }

        private void karaskivTag_Click(object sender, EventArgs e)
        {

        }

        private void flapform_load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }
}
