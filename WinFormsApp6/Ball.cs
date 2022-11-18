using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Ball
    {
        private int XAxis;
        private int YAxis;
        private double BallRatio;
        private Graphics BallGraphics;

        public Ball(int FormHeight, int FormWidth)
        {
            BallRatio = FormWidth / (double)FormHeight * 100;
            XAxis = FormWidth / 2;
            YAxis = FormHeight / 2;
        }

        public void Ball_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Blue, new Rectangle(XAxis, YAxis, (int)BallRatio, (int)BallRatio));
            BallGraphics = g;
        }
        
        public void ResizeBall(int NewFormHeight, int NewFormWidth)
        {
            BallRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void Move(int FormTop, int FormBottom)
        {
            if(XAxis < FormBottom)
            {
                YAxis += 8;
                XAxis +=8;
            }
            else if(XAxis > FormBottom)
            {
                YAxis -= 8;
                XAxis -= 8;
            }
        }
    }
}
