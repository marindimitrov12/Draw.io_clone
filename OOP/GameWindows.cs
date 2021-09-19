using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketServer;
using SocketServer.cs;

namespace OOP
{
    public partial class GameWindows : Form
    {
        AsyncSockedserver server;
        bool white = true;
        int score = 0;
        string Answer;
        Thread newtr;
        StreamWriter FileScore;
        Point StartPoint = Point.Empty;
        Point lastPoint = Point.Empty;
        bool isMouseDown = new Boolean();
        Graphics g;
        bool isrectangle=false;
        bool isCircle = false;
        Bitmap bmp;
        string Hint;
        
        public GameWindows()
        {
            InitializeComponent();
             bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            server = new AsyncSockedserver();

            newtr = new Thread(() => {
                server.StartListening();
            });
            newtr.IsBackground = true;
            newtr.Start();
            Thread listenforText = new Thread(() => {
                server.StartListenning2();
            });
            listenforText.IsBackground = true;
            listenforText.Start();
            server.RaiseImageSendEvent += HandleImageSend;
            server.RaiseTextsendEvent += HandleTextSend;
            if (File.Exists("HightScore.txt"))
            {
                string score = File.ReadAllText("HightScore.txt");
                labelHighScore.Text = score;
            }
            
            
               buttonSendText.Enabled = true;
            
        }
        public void HandleImageSend(object sender, ImageSend e)
        {
            MemoryStream m = new MemoryStream(e.MyStream);
            pictureBox1.Image = new Bitmap(m);
            Debug.WriteLine("Image Shown");
        }
        public void HandleTextSend(object sender, TextSend e)
        {
            string textdata = e.Mytext;
            string[] splited = textdata.Split('|');
            Answer = splited[0];
            Hint = splited[1];
            Debug.WriteLine(Answer);
            string info = "Answear Sended";
            textBoxInfo.Invoke(new Action(() => textBoxInfo.AppendText(info))) ;
            textBoxInfo.Invoke(new Action(() => textBoxInfo.AppendText(Environment.NewLine)));
            textBoxInfo.Invoke(new Action(() => textBoxInfo.AppendText("Hint: "+Hint)));
            textBoxInfo.Invoke(new Action(() => textBoxInfo.AppendText(Environment.NewLine)));

            button_Check.Invoke(new Action(() => button_Check.Enabled = true));
            buttonSendText.Invoke(new Action(() => buttonSendText.Enabled = true));
            
            
        }
        public void Image_Receiver()
        {
            if (pictureBox2.Image!=null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, ImageFormat.Bmp);
                Debug.WriteLine(ms.GetBuffer().Length);
                byte[] arrImage = ms.GetBuffer();
                ms.Close();
                server.TakeCareofTcpClientEmage(arrImage);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image_Receiver();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            lastPoint = e.Location;
            isMouseDown = true;
           
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true&&isrectangle==false&&isCircle==false)
            {
                if (lastPoint != null)
                {
                    if (pictureBox2.Image == null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

                        pictureBox2.Image = bmp;
                    }
                    using (g = Graphics.FromImage(pictureBox2.Image))
                    {

                        if (white)
                        {
                            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox2.Width, pictureBox2.Height);
                            white = false;

                        }

                        g.DrawLine(new Pen(Color.Red, 2), lastPoint, e.Location);
                        if (radioButton_Black.Checked)
                        {
                            g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        }
                       
                    }
                    pictureBox2.Invalidate();
                    lastPoint = e.Location;
                }

            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = e.Location;
          
                if (pictureBox2.Image == null)
                {
                 
                    pictureBox2.Image = bmp;


                }
                using (Graphics g1 = Graphics.FromImage(pictureBox2.Image))
                {
                    if (white)
                    {
                        g1.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox2.Width, pictureBox2.Height);
                        white = false;

                    }
                   
                if (isrectangle==true)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.colour = Color.Red;
                    

                    if (radioButton_Black.Checked)
                    {
                        rectangle.colour = Color.Black;
                                                   
                    }

                    rectangle.location = new Point(Math.Min(StartPoint.X, lastPoint.X), Math.Min(StartPoint.Y, lastPoint.Y));
                    
                    rectangle.High = Math.Abs(StartPoint.Y - lastPoint.Y);

                    rectangle.Width = Math.Abs(StartPoint.X - lastPoint.X);
                    rectangle.DrawGraphics(g1);
                }
                if (isCircle==true)
                {
                    Circle circle = new Circle();
                    circle.colour = Color.Red;
                    if (radioButton_Black.Checked)
                    {
                        circle.colour = Color.Black;
                        
                    }

                    circle.location = new Point(Math.Min(StartPoint.X, lastPoint.X), Math.Min(StartPoint.Y, lastPoint.Y));
                    
                    circle.High = Math.Abs(StartPoint.Y - lastPoint.Y);

                    circle.Width = Math.Abs(StartPoint.X - lastPoint.X);
                    circle.DrawGraphics(g1);

                }
                  
                }
                pictureBox2.Invalidate();

            
            lastPoint = Point.Empty;
            StartPoint = Point.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                white = true;
                pictureBox2.Image = null;
                Invalidate();
               
            }

        }

        private void buttonSendText_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text+"|"+textBox2.Text;
            server.SendText(text);
            buttonSendText.Enabled = false;
        }

        private void buttonQues_Click(object sender, EventArgs e)
        {
            if (Answer!=null)
            {


                if (Answer.Contains(textBoxQues.Text) && !String.IsNullOrEmpty(textBoxQues.Text))
                {
                    score++;
                    labelScore.Text = score.ToString();
                    button_Check.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("HightScore.txt"))
            {
                string score = File.ReadAllText("HightScore.txt");
                if (int.Parse(score) < int.Parse(labelScore.Text))
                {
                    FileScore = new StreamWriter("HightScore.txt");
                    FileScore.Write(labelScore.Text);
                    FileScore.Close();

                }
            }
            else
            {
                FileScore = new StreamWriter("HightScore.txt");
                FileScore.Write(labelScore.Text);
                FileScore.Close();
            }
            server.Stopserver();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isrectangle = true;
            isCircle = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isrectangle = false;
            isCircle = false;
        }

        private void GameWindows_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists("HightScore.txt"))
            {
                string score = File.ReadAllText("HightScore.txt");
                if (int.Parse(score) < int.Parse(labelScore.Text))
                {
                    FileScore = new StreamWriter("HightScore.txt");
                    FileScore.Write(labelScore.Text);
                    FileScore.Close();

                }
            }
            else
            {
                FileScore = new StreamWriter("HightScore.txt");
                FileScore.Write(labelScore.Text);
                FileScore.Close();
            }
            server.Stopserver();
            Application.Exit();
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            isCircle = true;
            isrectangle = false;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image!=null)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "JPG(*.JPG)|*.jpg";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image.Save(f.FileName);
                }
            }
            
        }

        
    }
}
