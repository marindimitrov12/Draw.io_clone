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
using System.Net;


namespace OOP
{
    public partial class ClientGameWindow : Form
    {
       public  string ip;
        public string Answer;
        ClientSide socketClient;
        Thread listenningThread;
        Thread lisText;
        Graphics g;
        int score=0;
        bool white = true;
        Point StartPoint = Point.Empty;
        Point lastPoint = Point.Empty;
        bool isMouseDown = new Boolean();
        StreamWriter FileScore;
        Bitmap bmp;
        bool isrectangle;
        bool isCircle;
        string Hint;
        public ClientGameWindow()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            ip = clientConnectingWindow.ipAdress;
            socketClient = new ClientSide(ip);
            listenningThread = new Thread(() => {

                 socketClient.ConnectingToServer();
          
            });
            listenningThread.IsBackground = true;
            listenningThread.Start();
             lisText = new Thread(()=> {
                socketClient.ConnectingToServer2();
            });
            lisText.IsBackground = true;
            lisText.Start();
            socketClient.RaiseImageresEvent += HandleImageSend;
            socketClient.RaiseTextsendEvent += HandleTextSend;
            if (File.Exists("HightScore.txt"))
            {
                string score = File.ReadAllText("HightScore.txt");
                labelHighScore.Text = score;
            }
          
            
        }
        public void HandleImageSend(object sender, ImageSend e)
        {
            MemoryStream m = new MemoryStream(e.MyStream);
            pictureBox2.Image = new Bitmap(m);
            Debug.WriteLine("Image Shown");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image_Receiver();
        }
        public void Image_Receiver()
        {
            if (pictureBox1.Image!=null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Bmp);
                byte[] arrImage = ms.GetBuffer();
                ms.Close();
                socketClient.SendingToServer(arrImage);
            }
           

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true&& isrectangle==false&&isCircle==false)
            {
                if (lastPoint != null)
                {
                    if (pictureBox1.Image == null)
                    {
                        Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                        pictureBox1.Image = bmp;
                    }
                    using (g = Graphics.FromImage(pictureBox1.Image))
                    {

                        if (white)
                        {
                            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
                            white = false;

                        }
                        g.DrawLine(new Pen(Color.Red, 2), lastPoint, e.Location);
                        if (radioButton_Black.Checked == true)
                        {
                            g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                            
                        }
                    }
                    pictureBox1.Invalidate();
                    lastPoint = e.Location;
                }

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = e.Location;
            
                if (pictureBox1.Image == null)
                {
                    
                    pictureBox1.Image = bmp;


                }
                using (Graphics g1 = Graphics.FromImage(pictureBox1.Image))
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
                    if (radioButton_Black.Checked == true)
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
                    if (radioButton_Black.Checked == true)
                    {
                        circle.colour = Color.Black;
                       
                    }

                    circle.location = new Point(Math.Min(StartPoint.X, lastPoint.X), Math.Min(StartPoint.Y, lastPoint.Y));
                    
                    circle.High = Math.Abs(StartPoint.Y - lastPoint.Y);

                    circle.Width = Math.Abs(StartPoint.X - lastPoint.X);
                    circle.DrawGraphics(g1);
                }
                    
                }
                pictureBox1.Invalidate();

            
            lastPoint = Point.Empty;
            StartPoint = Point.Empty;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                white = true;
                pictureBox1.Image = null;
                Invalidate();
            }
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text + "|" + textBox2.Text;
            socketClient.SendText(text);
            SendTextbutton.Enabled = false;
        }
        public void HandleTextSend(object sender, TextSend e)
        {
            string textdata = e.Mytext;
            string[] splited = textdata.Split('|');
            Answer = splited[0];
            Hint = splited[1];
            Debug.WriteLine(Answer);
            string info="Answear Send";
            textBoxinfo.Invoke(new Action(() => textBoxinfo.AppendText(info)));
            textBoxinfo.Invoke(new Action(() => textBoxinfo.AppendText(Environment.NewLine)));
            textBoxinfo.Invoke(new Action(() => textBoxinfo.AppendText("Hint: "+Hint)));
            textBoxinfo.Invoke(new Action(() => textBoxinfo.AppendText(Environment.NewLine)));

            button_Check.Invoke(new Action(() => button_Check.Enabled = true));
            
                SendTextbutton.Invoke(new Action(() => SendTextbutton.Enabled = true));
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Answer!=null)
            {


                if (Answer.Contains(QuestTextbox.Text.ToString())&&!String.IsNullOrEmpty(QuestTextbox.Text))
                {
                    score++;
                    Debug.WriteLine(score.ToString());
                    labelScore.Text = score.ToString();
                    button_Check.Enabled = false;
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists("HightScore.txt"))
            {
                string score = File.ReadAllText("HightScore.txt");
                if (int.Parse(score)<int.Parse(labelScore.Text))
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
            socketClient.CloseClient();
            Application.Exit();

        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            isrectangle = true;
            isCircle = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isrectangle = false;
            isCircle = false;
        }

        private void ClientGameWindow_FormClosed(object sender, FormClosedEventArgs e)
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
            socketClient.CloseClient();
            Application.Exit();

        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            isCircle = true;
            isrectangle = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image!=null)
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "JPG(*.JPG)|*.jpg";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(f.FileName);
                }
            }
        }

        private void ClientGameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
