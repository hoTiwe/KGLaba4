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
            label3 = new Label();
            label4 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button7 = new Button();
            label5 = new Label();
            label6 = new Label();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            label9 = new Label();
            textBox11 = new TextBox();
            label10 = new Label();
            textBox12 = new TextBox();
            label11 = new Label();
            textBox13 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 400);
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
            button1.Location = new Point(533, 244);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(103, 22);
            button1.TabIndex = 1;
            button1.Text = "Показать оси";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnDrawAxes_Click;
            // 
            // button2
            // 
            button2.Location = new Point(654, 244);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(161, 22);
            button2.TabIndex = 2;
            button2.Text = "Включить сетку растра";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDrawGrid_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(533, 109);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(104, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "500";
            // 
            // button3
            // 
            button3.Location = new Point(533, 74);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(212, 22);
            button3.TabIndex = 4;
            button3.Text = "Изменить скорость отрисовки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += textBoxSpeed_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(533, 142);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 5;
            button4.Text = "Масштаб";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(533, 197);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(82, 22);
            button5.TabIndex = 6;
            button5.Text = "Смещение";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(633, 144);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(50, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "3";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(633, 200);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(50, 23);
            textBox3.TabIndex = 8;
            textBox3.Text = "0";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(696, 200);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(50, 23);
            textBox4.TabIndex = 9;
            textBox4.Text = "0";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(633, 183);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 10;
            label1.Text = "Х";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(708, 183);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 11;
            label2.Text = "Y";
            // 
            // button6
            // 
            button6.Location = new Point(533, 22);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(82, 22);
            button6.TabIndex = 12;
            button6.Text = "Режим А";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(708, 285);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 17;
            label3.Text = "Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(633, 285);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 16;
            label4.Text = "Х";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(696, 302);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(50, 23);
            textBox5.TabIndex = 15;
            textBox5.Text = "0";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(633, 302);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(50, 23);
            textBox6.TabIndex = 14;
            textBox6.Text = "0";
            // 
            // button7
            // 
            button7.Location = new Point(533, 334);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(82, 40);
            button7.TabIndex = 13;
            button7.Text = "Добавить слой";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(707, 334);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 21;
            label5.Text = "Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(632, 334);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 20;
            label6.Text = "Х";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(695, 351);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(50, 23);
            textBox7.TabIndex = 19;
            textBox7.Text = "0";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(632, 351);
            textBox8.Margin = new Padding(3, 2, 3, 2);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(50, 23);
            textBox8.TabIndex = 18;
            textBox8.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(707, 384);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 25;
            label7.Text = "Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(632, 384);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 24;
            label8.Text = "Х";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(695, 401);
            textBox9.Margin = new Padding(3, 2, 3, 2);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(50, 23);
            textBox9.TabIndex = 23;
            textBox9.Text = "0";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(632, 401);
            textBox10.Margin = new Padding(3, 2, 3, 2);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(50, 23);
            textBox10.TabIndex = 22;
            textBox10.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(763, 384);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 31;
            label9.Text = "B";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(751, 401);
            textBox11.Margin = new Padding(3, 2, 3, 2);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(50, 23);
            textBox11.TabIndex = 30;
            textBox11.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(763, 334);
            label10.Name = "label10";
            label10.Size = new Size(15, 15);
            label10.TabIndex = 29;
            label10.Text = "G";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(751, 351);
            textBox12.Margin = new Padding(3, 2, 3, 2);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(50, 23);
            textBox12.TabIndex = 28;
            textBox12.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(764, 285);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 27;
            label11.Text = "R";
            // 
            // textBox13
            // 
            textBox13.Location = new Point(752, 302);
            textBox13.Margin = new Padding(3, 2, 3, 2);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(50, 23);
            textBox13.TabIndex = 26;
            textBox13.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 450);
            Controls.Add(label9);
            Controls.Add(textBox11);
            Controls.Add(label10);
            Controls.Add(textBox12);
            Controls.Add(label11);
            Controls.Add(textBox13);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(textBox9);
            Controls.Add(textBox10);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(textBox8);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(textBox6);
            Controls.Add(button7);
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
        private Label label3;
        private Label label4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button7;
        private Label label5;
        private Label label6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label7;
        private Label label8;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label9;
        private TextBox textBox11;
        private Label label10;
        private TextBox textBox12;
        private Label label11;
        private TextBox textBox13;
    }
}
