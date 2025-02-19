using kokain.Properties;

namespace kokain
{
    public partial class Faszom : Form
    {
        List<PictureBox> Balls = new List<PictureBox>();
        List<int> BallsvX = new List<int>();
        List<int> BallsvY = new List<int>();
        public Faszom()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random RNG = new Random();
            if (RNG.NextDouble() < 0.3)
            {
                PictureBox NewBall = new PictureBox();
                int VX = RNG.Next(-5, 6);
                int VY = RNG.Next(2, 6);
                NewBall.Location = new Point(ClientRectangle.Width / 2, 0);
                NewBall.Size = new Size(50, 50);
                NewBall.Image = new Bitmap(Resources.NicePng_jeff_goldblum_png_17035881);
                NewBall.SizeMode = PictureBoxSizeMode.StretchImage;
                Balls.Add(NewBall);
                BallsvX.Add(VX);
                BallsvY.Add(VY);
                Controls.Add(NewBall);
                NewBall.BringToFront();
                NewBall.BackColor = Color.Transparent;
            }
            for (int i = 0; i < Balls.Count; i++)
            {
                int NewLeft = Balls[i].Left + BallsvX[i];
                int NewTop = Balls[i].Top + BallsvY[i];
                if (NewLeft < 0)
                {
                    BallsvX[i] *= -1;
                }
                else if (NewTop < 0)
                {
                    BallsvY[i] *= -1;
                }
                else if (NewLeft + Balls[i].Width > ClientRectangle.Width)
                {
                    BallsvX[i] *= -1;
                }
                else if (NewTop + Balls[i].Height > ClientRectangle.Height)
                {
                    BallsvY[i] *= -1;
                }
                else
                {
                    Balls[i].Top = NewTop;
                    Balls[i].Left = NewLeft;
                }
            }
        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (pictureBox2.Left > 10)
                {
                    pictureBox2.Left -= 10;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (pictureBox2.Left < ClientRectangle.Width)
                {
                    pictureBox2.Left += 10;
                }
            }
        }
    }
}
