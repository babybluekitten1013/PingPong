using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Puck
    {
        private int XAxis = 1;
        private int YAxis;
        private int MoveYAxis = 20;
        private double ScreenRatio;
        private Rectangle PuckGraphics;

        public Puck()
        {

        }

        public Puck(int FormHeight, int FormWidth)
        {
            ScreenRatio = FormWidth / (double)FormHeight * 100;
            YAxis = FormHeight / 2;
        }

        public void Puck_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PuckGraphics = new Rectangle(XAxis, YAxis, (int)ScreenRatio/2, (int)ScreenRatio);
            g.FillRectangle(Brushes.Black, PuckGraphics);
        }

        public void ResizePuck(int NewFormHeight, int NewFormWidth)
        {
            ScreenRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void MoveForward(int FormsClientSize)
        {
            if (PuckGraphics.Y <= FormsClientSize /*|| PuckGraphics.Y - PuckGraphics.Height < 0*/)
            {
                
            }
            else
            {
                YAxis -= MoveYAxis;
            }
        }
        public void MoveBackward(Size FormsClientSize)
        {
            if (PuckGraphics.Y >= FormsClientSize.Height || PuckGraphics.Y + PuckGraphics.Height > FormsClientSize.Height)
            {

            }
            else
            {
                YAxis += MoveYAxis;
            }
        }
    }
}
