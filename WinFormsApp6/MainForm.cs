using STJ_PingPong;
using System.Runtime.CompilerServices;

namespace WinFormsApp6
{
    public partial class MainForm : Form
    {
        // vector2;

        //private int FormHeight;
        //private int FormWidth;
        private Ball CreateBall;
        private Puck CreatePuck;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateBall = new Ball(this.Height, this.Width);
            CreatePuck = new Puck(this.Height, this.Width);
            WindowState = FormWindowState.Maximized;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            CreateBall.Ball_Paint(this, e);
            CreatePuck.Puck_Paint(this, e);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            CreateBall.ResizeBall(this.Height, this.Width);
            CreatePuck.ResizePuck(this.Height, this.Width);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CreateBall.Move(this.ClientSize);
            Invalidate();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString() == Keys.W.ToString())
            {
                CreatePuck.MoveForward(this.ClientSize);
            }
            else if (e.KeyChar == (char)Keys.S)
            {
                CreatePuck.MoveBackward(this.ClientSize);
            }
        }
    }
}