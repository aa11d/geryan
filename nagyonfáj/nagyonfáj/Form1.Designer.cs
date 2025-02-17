namespace nagyonfáj
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Enter = new Button();
            out_text = new TextBox();
            change = new System.Windows.Forms.Timer(components);
            tick = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "ide";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 60);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "opa gangam sztájl";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 60);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(47, 15);
            label2.TabIndex = 2;
            label2.Text = "fájl        ";
            // 
            // Enter
            // 
            Enter.BackgroundImage = Properties.Resources.obama;
            Enter.BackgroundImageLayout = ImageLayout.Stretch;
            Enter.FlatAppearance.BorderSize = 2;
            Enter.FlatStyle = FlatStyle.Flat;
            Enter.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            Enter.Location = new Point(23, 107);
            Enter.Name = "Enter";
            Enter.Size = new Size(231, 218);
            Enter.TabIndex = 3;
            Enter.Text = "lesz go";
            Enter.UseVisualStyleBackColor = true;
            Enter.Click += Enter_Click;
            // 
            // out_text
            // 
            out_text.Location = new Point(260, 107);
            out_text.Multiline = true;
            out_text.Name = "out_text";
            out_text.Size = new Size(243, 126);
            out_text.TabIndex = 4;
            // 
            // change
            // 
            change.Enabled = true;
            change.Interval = 1000;
            change.Tick += change_Tick;
            // 
            // tick
            // 
            tick.Enabled = true;
            tick.Interval = 8;
            tick.Tick += tick_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.BackgroundImage = Properties.Resources.guy1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(260, 233);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 205);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ang;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(out_text);
            Controls.Add(Enter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            Name = "MainWindow";
            Text = "NAGYON FÁJL";
            Load += Window_Load;
            MouseMove += Window_MouseMove;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button Enter;
        private TextBox out_text;
        private System.Windows.Forms.Timer change;
        private System.Windows.Forms.Timer tick;
        private PictureBox pictureBox1;
    }
}
