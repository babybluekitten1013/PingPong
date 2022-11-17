namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // vector2;
        private int Top;
        private int Left;
        private int FormHeight;
        private int FormWidth;
        private double BallRatio;
        private Graphics Ball;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Top = this.Width / 2;
            Left = this.Height / 2;
            WindowState = FormWindowState.Maximized;
            FormHeight = this.Height;
            FormWidth = this.Width;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            BallRatio = FormWidth / (double)FormHeight;
            g.FillEllipse(Brushes.Blue, new Rectangle(Top, Left, (int)BallRatio * 100, (int)BallRatio * 100));
            Ball = g;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Left += 1;
            Top += 1;
           
            Invalidate();   

        }
    }
}