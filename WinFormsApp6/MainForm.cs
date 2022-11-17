namespace WinFormsApp6
{
    public partial class MainForm : Form
    {
        // vector2;
        private int Top;
        private int Left;
        private int FormHeight;
        private int FormWidth;
        private double BallRatio;
        private Graphics Ball;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Top = this.Width / 2;
            Left = this.Height / 2;
            WindowState = FormWindowState.Maximized;
            FormHeight = this.Height;
            FormWidth = this.Width;
            BallRatio = FormWidth / (double)FormHeight * 100;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Blue, new Rectangle(Top, Left, (int)BallRatio, (int)BallRatio));
            Ball = g;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Left += 1;
            Top += 1;
           
            Invalidate();   

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeBall();
        }

        private void ResizeBall()
        {
            FormHeight = this.Height;
            FormWidth = this.Width;
            BallRatio = FormWidth / (double)FormHeight * 100;
        }
    }
}