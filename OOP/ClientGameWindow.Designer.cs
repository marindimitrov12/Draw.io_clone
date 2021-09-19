namespace OOP
{
    partial class ClientGameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SendTextbutton = new System.Windows.Forms.Button();
            this.QuestTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Check = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.textBoxinfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelHighScore = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton_Black = new System.Windows.Forms.RadioButton();
            this.radioButton_Red = new System.Windows.Forms.RadioButton();
            this.button_Circle = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(584, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 217);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox2.Location = new System.Drawing.Point(12, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(348, 217);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "YOU!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "OPPONENT!";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(848, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(717, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(632, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Answear:";
            // 
            // SendTextbutton
            // 
            this.SendTextbutton.Location = new System.Drawing.Point(848, 446);
            this.SendTextbutton.Name = "SendTextbutton";
            this.SendTextbutton.Size = new System.Drawing.Size(75, 29);
            this.SendTextbutton.TabIndex = 8;
            this.SendTextbutton.Text = "Send";
            this.SendTextbutton.UseVisualStyleBackColor = true;
            this.SendTextbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // QuestTextbox
            // 
            this.QuestTextbox.Location = new System.Drawing.Point(82, 324);
            this.QuestTextbox.Name = "QuestTextbox";
            this.QuestTextbox.Size = new System.Drawing.Size(126, 22);
            this.QuestTextbox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Guess:";
            // 
            // button_Check
            // 
            this.button_Check.Location = new System.Drawing.Point(228, 312);
            this.button_Check.Name = "button_Check";
            this.button_Check.Size = new System.Drawing.Size(86, 34);
            this.button_Check.TabIndex = 11;
            this.button_Check.Text = "Check";
            this.button_Check.UseVisualStyleBackColor = true;
            this.button_Check.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(817, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Score:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.Location = new System.Drawing.Point(909, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(23, 25);
            this.labelScore.TabIndex = 13;
            this.labelScore.Text = "0";
            // 
            // textBoxinfo
            // 
            this.textBoxinfo.Location = new System.Drawing.Point(414, 71);
            this.textBoxinfo.Multiline = true;
            this.textBoxinfo.Name = "textBoxinfo";
            this.textBoxinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxinfo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxinfo.Size = new System.Drawing.Size(119, 226);
            this.textBoxinfo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Hight Score:";
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHighScore.Location = new System.Drawing.Point(152, 17);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(20, 24);
            this.labelHighScore.TabIndex = 16;
            this.labelHighScore.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 446);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 17;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.Location = new System.Drawing.Point(584, 294);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(80, 31);
            this.button_Rectangle.TabIndex = 18;
            this.button_Rectangle.Text = "Rect";
            this.button_Rectangle.UseVisualStyleBackColor = true;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(751, 294);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 31);
            this.button5.TabIndex = 19;
            this.button5.Text = "Draw";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // radioButton_Black
            // 
            this.radioButton_Black.AutoSize = true;
            this.radioButton_Black.Location = new System.Drawing.Point(682, 340);
            this.radioButton_Black.Name = "radioButton_Black";
            this.radioButton_Black.Size = new System.Drawing.Size(63, 21);
            this.radioButton_Black.TabIndex = 20;
            this.radioButton_Black.TabStop = true;
            this.radioButton_Black.Text = "Black";
            this.radioButton_Black.UseVisualStyleBackColor = true;
            // 
            // radioButton_Red
            // 
            this.radioButton_Red.AutoSize = true;
            this.radioButton_Red.Location = new System.Drawing.Point(771, 340);
            this.radioButton_Red.Name = "radioButton_Red";
            this.radioButton_Red.Size = new System.Drawing.Size(55, 21);
            this.radioButton_Red.TabIndex = 21;
            this.radioButton_Red.TabStop = true;
            this.radioButton_Red.Text = "Red";
            this.radioButton_Red.UseVisualStyleBackColor = true;
            // 
            // button_Circle
            // 
            this.button_Circle.Location = new System.Drawing.Point(584, 335);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(80, 30);
            this.button_Circle.TabIndex = 22;
            this.button_Circle.Text = "Circle";
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(848, 339);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 33);
            this.button6.TabIndex = 23;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(717, 453);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 22);
            this.textBox2.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(666, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hint:";
            // 
            // ClientGameWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(999, 503);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button_Circle);
            this.Controls.Add(this.radioButton_Red);
            this.Controls.Add(this.radioButton_Black);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button_Rectangle);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxinfo);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Check);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QuestTextbox);
            this.Controls.Add(this.SendTextbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "ClientGameWindow";
            this.Text = "ClientGameWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientGameWindow_FormClosed);
            this.Load += new System.EventHandler(this.ClientGameWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendTextbutton;
        private System.Windows.Forms.TextBox QuestTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Check;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.TextBox textBoxinfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelHighScore;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_Rectangle;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton_Black;
        private System.Windows.Forms.RadioButton radioButton_Red;
        private System.Windows.Forms.Button button_Circle;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
    }
}