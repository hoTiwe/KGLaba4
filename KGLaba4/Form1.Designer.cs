namespace KGLaba4
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(571, 533);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(609, 326);
            button1.Name = "button1";
            button1.Size = new Size(118, 29);
            button1.TabIndex = 1;
            button1.Text = "Показать оси";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnDrawAxes_Click;
            // 
            // button2
            // 
            button2.Location = new Point(747, 326);
            button2.Name = "button2";
            button2.Size = new Size(184, 29);
            button2.TabIndex = 2;
            button2.Text = "Включить сетку растра";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDrawGrid_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(609, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(118, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "500";
            // 
            // button3
            // 
            button3.Location = new Point(609, 99);
            button3.Name = "button3";
            button3.Size = new Size(242, 29);
            button3.TabIndex = 4;
            button3.Text = "Изменить скорость отрисовки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += textBoxSpeed_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(609, 190);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Масштаб";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(609, 263);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "Смещение";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(723, 192);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(56, 27);
            textBox2.TabIndex = 7;
            textBox2.Text = "3";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(723, 267);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(56, 27);
            textBox3.TabIndex = 8;
            textBox3.Text = "0";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(795, 267);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(56, 27);
            textBox4.TabIndex = 9;
            textBox4.Text = "0";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 244);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 10;
            label1.Text = "Х";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(809, 244);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 11;
            label2.Text = "Y";
            // 
            // button6
            // 
            button6.Location = new Point(609, 30);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 12;
            button6.Text = "Режим А";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 600);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Button button6;
    }
}
