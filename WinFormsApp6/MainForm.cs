using STJ_PingPong;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace WinFormsApp6
{
    public partial class MainForm : Form
    {
        private Ball CreateBall = new Ball();
        private Puck CreatePuck = new Puck();
        private Puck CreatePuck2 = new Puck();
        private int ClientSizeHeight;
        private int ClientSizeWidth;
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
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ClientSizeWidth = this.ClientSize.Width;
            ClientSizeHeight = this.ClientSize.Height;
            CreateBall = new Ball(ClientSizeHeight, ClientSizeWidth);
            CreatePuck = new Puck(ClientSizeHeight, ClientSizeWidth);
            CreatePuck2 = new Puck(ClientSizeHeight, ClientSizeWidth);


            P1Score.Location = new Point((int)(ClientSizeWidth * (double)(.35)), 50);
            P2Score.Location = new Point((int)(ClientSizeWidth * (double)(.55)), 50);
            P1Score.Text = PlayerOneLblTxt + Player1Score.ToString();
            P2Score.Text = PlayerTwoLblTxt + Player2Score.ToString();
            P1Score.AutoSize = true;
            P2Score.AutoSize = true;
            P1Score.Font = new Font("Verdona", 20, FontStyle.Bold);
            P2Score.Font = new Font("Verdona", 20, FontStyle.Bold);
            P1Score.TextAlign = ContentAlignment.MiddleCenter;
            P2Score.TextAlign = ContentAlignment.MiddleCenter;
            P1Score.BackColor = Color.HotPink;
            P2Score.BackColor = Color.HotPink;
            P1Score.ForeColor = Color.AliceBlue;
            P2Score.ForeColor = Color.AliceBlue;
            P1Score.Size = new System.Drawing.Size (ClientSizeWidth / ClientSizeHeight * (25), ClientSizeWidth / ClientSizeHeight * (25));
            P2Score.Size = new System.Drawing.Size(ClientSizeWidth / ClientSizeHeight * (25), ClientSizeWidth / ClientSizeHeight * (25));

            this.Controls.Add(P1Score);
            this.Controls.Add(P2Score);


        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            CreateBall.Ball_Paint(this, e);
            CreatePuck.Puck_Paint(this, e);
            CreatePuck2.Puck_Paint2(this, e);

            WinRound();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CreateBall.Move(this.ClientSize, CreatePuck.GrabFirstPuck, CreatePuck2.GrabSecondPuck);
            Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                CreatePuck.MoveForward(this.Top);
            }
            else if (e.KeyData == Keys.S)
            {
                CreatePuck.MoveBackward(this.ClientSize);
            }
            else if (e.KeyData == Keys.Up)
            {
                CreatePuck2.MoveForward(this.Top);
            }
            else if (e.KeyData == Keys.Down)
            {
                CreatePuck2.MoveBackward(this.ClientSize);
            }
        }
        private void WinRound()
        {
            if (CreateBall.BallPosition < 0)
            {
                RestartRound();
                Player2Score++;
                P2Score.Text = PlayerTwoLblTxt + Player2Score.ToString();
            }
            else if (CreateBall.BallPosition > ClientSizeWidth)
            {
                RestartRound();
                Player1Score++;
                P1Score.Text = PlayerOneLblTxt + Player1Score.ToString();
            }
        }
        private void RestartRound()
        {
            CreateBall = new Ball(ClientSizeHeight, ClientSizeWidth);
            CreatePuck = new Puck(ClientSizeHeight, ClientSizeWidth);
            CreatePuck2 = new Puck(ClientSizeHeight, ClientSizeWidth);
        }
    }
}