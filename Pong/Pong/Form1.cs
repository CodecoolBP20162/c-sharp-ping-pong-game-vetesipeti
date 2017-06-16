using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        private bool movingLeft;
        private bool movingRight;
        private int pooVelocityX;
        private int pooVelocityY;

        public Form1()
        {
            InitializeComponent();
        }

        public void MovePoo()
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if (pictureBox1.Top <= Field.Top | pictureBox1.Bottom >= Field.Bottom)
            {
                pooVelocityY *= -1;
            }
            else if (pictureBox1.Left <= Field.Left | pictureBox1.Right >= Field.Right)
            {
                pooVelocityX *= -1;
            } else if(pictureBox1.Bounds.IntersectsWith(Paddle.Bounds))
            {
                pooVelocityY *= -1;
            }
            pictureBox1.Location = new Point(x + pooVelocityX, y + pooVelocityY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            pooVelocityX = 2;
            pooVelocityY = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MovePoo();
            if (movingRight && Paddle.Right < Field.Right - 3)
            {
                Paddle.Left += 2;
            }
            else if (movingLeft && Paddle.Left > Field.Left + 3)
            {
                Paddle.Left -= 2;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) movingRight = true;
            else if (e.KeyCode == Keys.Left) movingLeft = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) movingRight = false;
            else if (e.KeyCode == Keys.Left) movingLeft = false;
        }
    }
}
