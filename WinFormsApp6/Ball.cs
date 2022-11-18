using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Ball
    {
        private int Top;
        private int Left;
        private double BallRatio;
        private Graphics BallGraphics;

        public Ball(int FormHeight, int FormWidth)
        {
            BallRatio = FormWidth / (double)FormHeight * 100;
            Top = FormWidth / 2;
            Left = FormHeight / 2;
        }

        public void Ball_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Blue, new Rectangle(Top, Left, (int)BallRatio, (int)BallRatio));
            BallGraphics = g;
        }
        
        public void ResizeBall(int NewFormHeight, int NewFormWidth)
        {
            BallRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void Move()
        {
            Left += 1;
            Top += 1;
        }
    }
}
