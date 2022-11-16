namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // vector2;
        private int Top;
        private int Left;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Top = this.Width / 2;
            Left = this.Height / 2; 
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Blue, new Rectangle(Top, Left, 100, 100));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Left += 1;
            Top += 1;
            Invalidate();   

        }
    }
}