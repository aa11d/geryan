namespace golyózás
{
    partial class labdázó
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
            C_Labda = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            C_Left = new PictureBox();
            P1 = new Label();
            C_Right = new PictureBox();
            P2 = new Label();
            ((System.ComponentModel.ISupportInitialize)C_Labda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)C_Left).BeginInit();
            ((System.ComponentModel.ISupportInitialize)C_Right).BeginInit();
            SuspendLayout();
            // 
            // C_Labda
            // 
            C_Labda.BackColor = Color.Transparent;
            C_Labda.BackgroundImage = Properties.Resources.Biden_Circle;
            C_Labda.BackgroundImageLayout = ImageLayout.Stretch;
            C_Labda.Location = new Point(380, 222);
            C_Labda.Name = "C_Labda";
            C_Labda.Size = new Size(45, 49);
            C_Labda.TabIndex = 0;
            C_Labda.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // C_Left
            // 
            C_Left.BackColor = Color.Transparent;
            C_Left.BackgroundImage = Properties.Resources.greatwall;
            C_Left.BackgroundImageLayout = ImageLayout.Stretch;
            C_Left.Location = new Point(12, 156);
            C_Left.Name = "C_Left";
            C_Left.Size = new Size(100, 150);
            C_Left.TabIndex = 1;
            C_Left.TabStop = false;
            C_Left.Click += pictureBox1_Click;
            // 
            // P1
            // 
            P1.AutoSize = true;
            P1.BackColor = Color.Transparent;
            P1.Font = new Font("Comic Sans MS", 14F);
            P1.Location = new Point(12, 9);
            P1.Name = "P1";
            P1.Size = new Size(62, 26);
            P1.TabIndex = 2;
            P1.Text = "label1";
            // 
            // C_Right
            // 
            C_Right.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            C_Right.BackColor = Color.Transparent;
            C_Right.BackgroundImage = Properties.Resources.greatwall;
            C_Right.BackgroundImageLayout = ImageLayout.Stretch;
            C_Right.Location = new Point(688, 156);
            C_Right.Name = "C_Right";
            C_Right.Size = new Size(100, 150);
            C_Right.TabIndex = 3;
            C_Right.TabStop = false;
            // 
            // P2
            // 
            P2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            P2.AutoSize = true;
            P2.BackColor = Color.Transparent;
            P2.Font = new Font("Comic Sans MS", 14F);
            P2.Location = new Point(726, 9);
            P2.Name = "P2";
            P2.Size = new Size(62, 26);
            P2.TabIndex = 4;
            P2.Text = "label1";
            // 
            // labdázó
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(P2);
            Controls.Add(C_Right);
            Controls.Add(P1);
            Controls.Add(C_Left);
            Controls.Add(C_Labda);
            Name = "labdázó";
            Text = "Form1";
            Load += labdázó_Load;
            PreviewKeyDown += labdázó_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)C_Labda).EndInit();
            ((System.ComponentModel.ISupportInitialize)C_Left).EndInit();
            ((System.ComponentModel.ISupportInitialize)C_Right).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox C_Labda;
        private System.Windows.Forms.Timer timer1;
        private PictureBox C_Left;
        private Label P1;
        private PictureBox C_Right;
        private Label P2;
    }
}
