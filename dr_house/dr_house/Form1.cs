namespace dr_house
{
    public partial class Form1 : Form
    {
        public static float input_1 = 0.0f;
        public static float input_2 = 0.0f;
        public static bool b_is1 = true;
        public static char operation = '=';

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string input = (sender as Button).Text;
            if (input == ",")
            {
                display.Text = display.Text.Replace(",", "");
            }
            if (display.Text == "0")
            {
                display.Text = input;
            }
            else
            {
                display.Text += input;
            }

        }

        private void button_enter(object sender, EventArgs e)
        {
            char operation1 = (sender as Button).Text[0];
            operation = operation1;
            if (b_is1)
            {
                input_1 = float.Parse(display.Text);
                display.Text = input_1.ToString() + " " + operation1 + " ";
                b_is1 = false;
            }
        }

        private void f_calculate(object sender, EventArgs e)
        {
            if (!b_is1)
            {
                input_2 = float.Parse(display.Text.Split(operation)[1]);
            }
            switch (operation)
            {
                case '+':
                    listBox1.Items.Add(input_1.ToString() + operation + input_2.ToString() + "=" + (input_1 + input_2).ToString());
                    break;
                case '-':
                    listBox1.Items.Add(input_1.ToString() + operation + input_2.ToString() + "=" + (input_1 - input_2).ToString());
                    break;
                case '*':
                    listBox1.Items.Add(input_1.ToString() + operation + input_2.ToString() + "=" + (input_1 * input_2).ToString());
                    break;
                case '/':
                    listBox1.Items.Add(input_1.ToString() + operation + input_2.ToString() + "=" + (input_1 / input_2).ToString());
                    break;
            }
            display.Text = "0";
            b_is1 = true;
            input_1 = 0.0f;
            input_2 = 0.0f;
        }

        private void button_backspace(object sender, EventArgs e)
        {
            display.Text = display.Text.Substring(0, display.Text.Length - 1);
            if (display.Text == "")
            {
                display.Text = "0";
            }
            if(float.TryParse(display.Text, out input_1) ) 
            {
                b_is1 = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            input_1 = 0.0f;
            input_2 = 0.0f;
            b_is1 = true;
            operation = '=';
        }
    }
}

