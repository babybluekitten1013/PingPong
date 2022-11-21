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
        private Rectangle BallGraphics;

        public Ball(int FormHeight, int FormWidth)
        {
            BallRatio = FormWidth / (double)FormHeight * 100;
            XAxis = FormWidth / 2;
            YAxis = FormHeight / 2;
        }

        public void Ball_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            BallGraphics = new Rectangle(XAxis, YAxis, (int)BallRatio, (int)BallRatio);
            g.FillEllipse(Brushes.Blue, BallGraphics);
            
        }
        
        public void ResizeBall(int NewFormHeight, int NewFormWidth)
        {
            BallRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void Move(Rectangle FormBounds)
        {

            //XAxis += 20;
     

            if (BallGraphics.Y < 0 || BallGraphics.Y + BallGraphics.Height > FormBounds.Height)
            {
                YAxis -= 20;
                //XAxis -= 20;
            }
            else if(BallGraphics.Y > 0 || BallGraphics.Y + BallGraphics.Height < FormBounds.Height)
            {
                YAxis += 20;
            }


            //else if (BallGraphics.Y + BallGraphics.Height < FormBounds.Height)
            //{
            //    YAxis += 20;
            //    XAxis += 20;
            //}

        }
    }
}
