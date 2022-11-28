using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Puck
    {
        private int _XAxis = 1;
        private int _YAxis;
        private int _MoveYAxis = 20;
        private double _ScreenRatio;
        private Rectangle _PuckGraphics;

        public Puck()
        {

        }

        public Puck(int FormHeight, int FormWidth)
        {
            _ScreenRatio = FormWidth / (double)FormHeight * 100;
            _YAxis = FormHeight / 2;
        }
        public Puck(int FormHeight, int FormWidth, int XAxis)
        {
            _ScreenRatio = FormWidth / (double)FormHeight * 100;
            _XAxis = XAxis;
            _YAxis = FormHeight / 2;
        }

        public void Puck_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _PuckGraphics = new Rectangle(_XAxis, _YAxis, (int)_ScreenRatio/2, (int)_ScreenRatio);
            g.FillRectangle(Brushes.Black, _PuckGraphics);
        }

        public void ResizePuck(int NewFormHeight, int NewFormWidth)
        {
            _ScreenRatio = NewFormWidth / (double)NewFormHeight * 100;
        }

        public void MoveForward(int FormsClientSize)
        {
            if (_PuckGraphics.Y <= FormsClientSize /*|| _PuckGraphics.Y - _PuckGraphics.Height < 0*/)
            {
                
            }
            else
            {
                _YAxis -= _MoveYAxis;
            }
        }
        public void MoveBackward(Size FormsClientSize)
        {
            if (_PuckGraphics.Y >= FormsClientSize.Height || _PuckGraphics.Y + _PuckGraphics.Height > FormsClientSize.Height)
            {

            }
            else
            {
                _YAxis += _MoveYAxis;
            }
        }
    }
}
