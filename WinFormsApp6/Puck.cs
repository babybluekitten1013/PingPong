using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STJ_PingPong
{
    internal class Puck
    {
        private int posX = 0;
        private int posY;
        private int movY = 20;
        private int width = 50;
        private int height = 200;
        public int screenHeight;

        public Rectangle graphic;

        public Puck(int x, int y, int height)
        {
            posX = x;
            posY = y;
            screenHeight = height;
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            graphic = new Rectangle(posX, posY, width, height);
            g.FillRectangle(Brushes.Black, graphic);
        }


        public void Move(int direction)
        {
            posY += direction * movY;

            // clamp the values
            if (posY < 0)
            {
                posY = 0;
            } else if (posY >= screenHeight - height)
            {
                posY = screenHeight - height;
            }
        }

    }
}
