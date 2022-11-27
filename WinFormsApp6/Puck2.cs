using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Puck2
    {
        private int XAxis = 500; // obviously not a good position just can't figure out how to capture and use the max x axis
        private int YAxis;
        private int MoveYAxis = 20;
        private double ScreenRatio;
        private Rectangle PuckGraphics;

        public Puck2()
        {

        }

        public Puck2(int FormHeight, int FormWidth)
        {
            ScreenRatio = FormWidth / (double)FormHeight * 100;
            YAxis = FormHeight / 2;
        }

        public void Puck_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PuckGraphics = new Rectangle(XAxis, YAxis, (int)ScreenRatio / 2, (int)ScreenRatio);
            g.FillRectangle(Brushes.Black, PuckGraphics);
        }

        public void ResizePuck(int NewFormHeight, int NewFormWidth)
        {
            ScreenRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void MoveForward2(int FormsClientSize)
        {
            if (PuckGraphics.Y <= FormsClientSize)
            {

            }
            else
            {
                YAxis -= MoveYAxis;
            }
        }

        public void MoveBackward2(Size FormsClientSize)
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
