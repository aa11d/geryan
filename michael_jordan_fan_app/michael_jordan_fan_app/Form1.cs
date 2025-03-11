namespace idiot_box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LClick(object sender, EventArgs e)
        {
            char Nchar = (sender as Button).Text[0];
            if (TextBox_Left.Text == "0")
            {
                TextBox_Left.Text = Nchar.ToString();
            }
            else
            {
                TextBox_Left.Text += Nchar.ToString();
            }
        }


        private void RClick(object sender, EventArgs e)
        {
            char Nchar = (sender as Button).Text[0];
            if (TextBox_Right.Text == "0")
            {
                TextBox_Right.Text = Nchar.ToString();
            }
            else
            {
                TextBox_Right.Text += Nchar.ToString();
            }
        }

        private void LDel(object sender, EventArgs e)
        {
            TextBox_Left.Text = TextBox_Left.Text.Substring(0, TextBox_Left.TextLength - 1);
            if (TextBox_Left.Text == "")
            {
                TextBox_Left.Text = "0";
            }
        }

        private void RDel(object sender, EventArgs e)
        {
            TextBox_Right.Text = TextBox_Right.Text.Substring(0, TextBox_Right.TextLength - 1);
            if (TextBox_Right.Text == "")
            {
                TextBox_Right.Text = "0";
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            int LeftNum = int.Parse(TextBox_Left.Text);
            int RightNum = int.Parse(TextBox_Right.Text);

            bool Error = false;

            char Operation = (sender as Button).Text[0];
            int Out = 0;
            switch (Operation)
            {
                case '+':
                    Out = LeftNum + RightNum;
                    break;
                case '-':
                    Out = LeftNum - RightNum;
                    break;
                case '*':
                    Out = LeftNum * RightNum;
                    break;
                case '/':
                    if (RightNum != 0)
                    {
                        Out = LeftNum / RightNum;
                    }
                    else
                    {
                        Error = true;
                    }
                    break;
            }
            if (!Error)
            {
                TextBox_Left.Text = Out.ToString();
                TextBox_Right.Text = "0";
            }
            else
            {
                MessageBox.Show("no division with nulla haha", "kurva anyád", MessageBoxButtons.AbortRetryIgnore);
            }
        }
    }
}
