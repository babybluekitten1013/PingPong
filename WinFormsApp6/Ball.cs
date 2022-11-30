using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace STJ_PingPong
{
    internal class Ball
    {
        public int posX;
        public int posY;
        private int movY = 5;
        private int movX = 5;
        private int radius = 60;
        private Rectangle graphics;

        public Ball(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            graphics = new Rectangle(posX, posY, radius, radius);
            g.FillEllipse(Brushes.Blue, graphics);
            
        }

        public void Move(Size FormsClientSize, Rectangle FirstPuck, Rectangle SecondPuck)
        {
            Random rnd = new Random();

            if (graphics.IntersectsWith(FirstPuck) || graphics.IntersectsWith(SecondPuck))
            {
                movY = -(movY + rnd.Next(0, 2));
                movX = -(movX + rnd.Next(0, 2));
            }
            
            if (graphics.Y < 0 || graphics.Y + graphics.Height > FormsClientSize.Height)
            {
                movY = -movY;
            }

            posY += movY;
            posX += movX;
        }

    }
}
