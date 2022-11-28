using STJ_PingPong;
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

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            ClientSizeWidth = this.ClientSize.Width;
            ClientSizeHeight = this.ClientSize.Height;
            CreateBall = new Ball(ClientSizeHeight, ClientSizeWidth);
            CreatePuck = new Puck(ClientSizeHeight, ClientSizeWidth);
            CreatePuck2 = new Puck(ClientSizeHeight, ClientSizeWidth, this.DesktopBounds.Right); ;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            CreateBall.Ball_Paint(this, e);
            CreatePuck.Puck_Paint(this, e);
            CreatePuck2.Puck_Paint(this, e);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            ClientSizeHeight = this.ClientSize.Height;
            ClientSizeWidth = this.ClientSize.Width;
            CreateBall.ResizeBall(ClientSizeHeight, ClientSizeWidth);
            CreatePuck.ResizePuck(ClientSizeHeight, ClientSizeWidth);
            CreatePuck2.ResizePuck(ClientSizeHeight, ClientSizeWidth);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CreateBall.Move(this.ClientSize);
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
    }
}