using System.Linq.Expressions;

namespace nagyonfáj
{
    public partial class MainWindow : Form
    {
        string TextInput;
        int OffsetX = 0;
        int OffsetY = 0;
        public MainWindow()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            MessageBox.Show("A PICSÁDAT", "geci", MessageBoxButtons.AbortRetryIgnore);
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            string Path = textBox1.Text;
            TextInput = File.ReadAllText(Path, System.Text.Encoding.UTF8);
            //out_text.Text = TextInput;
            StreamReader sr = new StreamReader(Path);
            List<string> Lines = new List<string>();
            string Line = sr.ReadLine();
            while (Line != null)
            {
                if (Line.Trim() == "")
                {
                    Lines.Add(Line.Trim());
                }
                Lines.Add(Line);
                Line = sr.ReadLine();
            }
            sr.Close();
            string[] Names = new string[Lines.Count];
            string[] Date = new string[Lines.Count];
            string[] Place = new string[Lines.Count];
            int[] Score = new int[Lines.Count];
            for (int i = 0; i < Lines.Count; i++)
            {
                string[] Pieces = Lines[i].Split(";");
                Names[i] = Pieces[0];
                Date[i] = Pieces[1];
                Place[i] = Pieces[2];
                Score[i] = int.Parse(Pieces[3]);
            }
            out_text.Text = TextInput;
            int MaxPoints = Score.Max();
            int MaxWho = Array.IndexOf(Score, MaxPoints);
            out_text.AppendText("\r\n\r\n" + Names[MaxWho] + " a legjobb mert " + MaxPoints);

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Random RNG = new Random();
            this.BackColor = Color.FromArgb(RNG.Next(1, 255), RNG.Next(1, 255), RNG.Next(1, 255));
        }

        private void tick_Tick(object sender, EventArgs e)
        {


            this.DesktopLocation = new System.Drawing.Point(this.DesktopLocation.X+OffsetX, this.DesktopLocation.Y + OffsetY);
            this.Size = new System.Drawing.Size(this.Size.Width+OffsetX, this.Size.Height+OffsetY);
        }
        private void change_Tick(object sender, EventArgs e)
        {
            Random RNG = new Random();
            OffsetX = RNG.Next(-1, 2);
            OffsetY = RNG.Next(-1, 2);
        }
    }
}
