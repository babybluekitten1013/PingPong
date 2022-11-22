using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Puck
    {
        private int XAxis;
        private int YAxis;
        private int MoveYAxis = 20;
        private double ScreenRatio;
        private Rectangle BallGraphics;

        public Puck(int FormHeight, int FormWidth)
        {
            ScreenRatio = FormWidth / (double)FormHeight * 100;
            XAxis = 0;
            YAxis = FormHeight / 2;
        }

        public void Puck_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            BallGraphics = new Rectangle(XAxis, YAxis, (int)ScreenRatio/2, (int)ScreenRatio);
            g.FillRectangle(Brushes.Black, BallGraphics);
        }

        public void ResizePuck(int NewFormHeight, int NewFormWidth)
        {
            ScreenRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void MoveForward(Size FormsClientSize)
        {
            if (BallGraphics.Y < 0 || BallGraphics.Y + BallGraphics.Height > FormsClientSize.Height)
            {
                MoveYAxis = -MoveYAxis;
            }
            YAxis += MoveYAxis;
        }
        public void MoveBackward(Size FormsClientSize)
        {
            if (BallGraphics.Y < 0 || BallGraphics.Y + BallGraphics.Height > FormsClientSize.Height)
            {
                MoveYAxis = -MoveYAxis;
            }
            YAxis += MoveYAxis;
        }
    }
}
