namespace golyózás
{
    public partial class labdázó : Form
    {
        int velX, velY;
        int Score1, Score2;
        public labdázó()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void labdázó_Load(object sender, EventArgs e)
        {
            Random RNG = new Random();
            velX = RNG.Next(5, 10);
            if (RNG.Next(0, 1) == 0)
            {
                velX *= -1;
            }
            velY = RNG.Next(-5, 6);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int balfent = C_Labda.Top + velY;
            int balbal = C_Labda.Left + velX;
            int jobblent = balfent + C_Labda.Height;
            int jobbjobb = balbal + C_Labda.Width;
            if (balbal < 0 || jobbjobb > ClientRectangle.Width)
            {
                velX *= -1;
            }
            else
            {
                C_Labda.Left = balbal;
            }
            if (balfent < 0 || jobblent > ClientRectangle.Height)
            {
                velY *= -1;
            }
            else
            {
                C_Labda.Top = balfent;
            }
            if (C_Labda.Left + C_Labda.Width >= C_Right.Left && C_Labda.Top >= C_Right.Top && C_Labda.Top + C_Labda.Height <= C_Right.Top + C_Left.Height)
            {
                velX *= -1;
                Score2 += 1;
                P2.Text = Score2.ToString();
            }
            C_Labda.Refresh();
        }

        private void labdázó_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (C_Left.Top > 10) 
                { 
                    C_Left.Top -= 10;
                }
            }
            if (e.KeyCode == Keys.S)
            {
                if (C_Left.Top + 10 < ClientRectangle.Height + C_Right.Height)
                {
                    C_Left.Top += 10;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (C_Right.Top > 10)
                {
                    C_Right.Top -= 10;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (C_Right.Top + 10 < ClientRectangle.Height + C_Right.Height)
                {
                    C_Right.Top += 10;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
