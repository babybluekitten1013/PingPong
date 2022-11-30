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
        //these are our ball variables
        public int posX;
        public int posY;
        private int movY = 5;
        private int movX = 5;
        private int radius = 60;
        private Rectangle graphics;

        // this is where our ball is at
        public Ball(int x, int y)
        {
            posX = x;
            posY = y;
        }

        // this is us making our ball on the screen
        public void Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            graphics = new Rectangle(posX, posY, radius, radius);
            g.FillEllipse(Brushes.Blue, graphics);
            
        }

        // this is how the ball moves
        public void Move(Size FormsClientSize, Rectangle FirstPuck, Rectangle SecondPuck)
        {
            // this makes the ball go off in a random direction... just a little bit
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
