using STJ_PingPong;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace WinFormsApp6
{
    public partial class MainForm : Form
    {
        //variables of ball, both pucks, and score cards
        private Ball Ball;
        private Puck Puck;
        private Puck Puck2;
        private int Player1Score = 0;
        private int Player2Score = 0;
        private string PlayerOneLblTxt = "Player 1 Score\n<><><><><><><><>\n";
        private string PlayerTwoLblTxt = "Player 2 Score\n<><><><><><><><>\n";
        private Label P1Score = new Label();
        private Label P2Score = new Label();

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // max sized window
            WindowState = FormWindowState.Maximized;

            // always start with a new round
            RestartRound();

            // this is all play score cards including text, color, and size
            P1Score.Text = PlayerOneLblTxt + Player1Score.ToString();
            P2Score.Text = PlayerTwoLblTxt + Player2Score.ToString();
            P1Score.AutoSize = true;
            P2Score.AutoSize= true;
            P1Score.Font = new Font("Verdona", 20, FontStyle.Bold);
            P2Score.Font = new Font("Verdona", 20, FontStyle.Bold);
            P1Score.TextAlign = ContentAlignment.MiddleCenter;
            P2Score.TextAlign = ContentAlignment.MiddleCenter;
            P1Score.BackColor = Color.HotPink;
            P2Score.BackColor = Color.HotPink;
            P1Score.ForeColor = Color.AliceBlue;
            P2Score.ForeColor = Color.AliceBlue;

            // yep this is where the score card is on the screen
            P1Score.Location = new Point(this.ClientSize.Width / 2 - 450, 50);
            P2Score.Location = new Point(this.ClientSize.Width / 2 + 150, 50);

            this.Controls.Add(P1Score);
            this.Controls.Add(P2Score);
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // we are putting both pucks and the ball on the screen
            Puck.Paint(this, e);
            Puck2.Paint(this, e);
            Ball.Paint(this, e);

            // this is to check to see if we scored
            WinRound();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // how often this happens 
            Ball.Move(this.ClientSize, Puck.graphic, Puck2.graphic);
            Invalidate();
        }

        // these are the controlls for moving two pucks independently of each other
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                Puck.Move(-1);
            }
            else if (e.KeyData == Keys.S)
            {
                Puck.Move(1);
            }
            else if (e.KeyData == Keys.Up)
            {
                Puck2.Move(-1);
            }
            else if (e.KeyData == Keys.Down)
            {
                Puck2.Move(1);
            }
        }
        // yay we won a game
        private void WinRound()
        {
            if (Ball.posX < 0)
            {
                // we restart a round after a score is scored
                RestartRound();
                Player2Score++;
                P2Score.Text = PlayerTwoLblTxt + Player2Score.ToString();
            }
            else if (Ball.posX >= this.ClientSize.Width)
            {
                // same thing on the other side
                RestartRound();
                Player1Score++;
                P1Score.Text = PlayerOneLblTxt + Player1Score.ToString();
            }
        }

        // this is how we restart the round the balls and pucks go back to where they were when the game started
        private void RestartRound()
        {
            Ball = new Ball(this.ClientSize.Width/2, this.ClientSize.Height/2);
            Puck = new Puck(150, this.ClientSize.Height / 2, this.ClientSize.Height);
            Puck2 = new Puck(this.ClientSize.Width - 200, this.ClientSize.Height / 2, this.ClientSize.Height);
        }
    }
}