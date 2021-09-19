using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static OOP.CustonEventArgs;

namespace OOP
{
    class ClientSide
    {
        private TcpClient myclient = new TcpClient();
        private TcpClient client2;
        public EventHandler<ImageSend> RaiseImageresEvent;
        public EventHandler<TextSend> RaiseTextsendEvent;
        private IPAddress IpAdress;
        bool keepRunning = true;
        public ClientSide(string ip)
        {
            this.serverIP = ip;
        }
        public string serverIP
        {
            get
            {
                return IpAdress.ToString();
            }
            set
            {
                if (CheckIPAdress(value) == true)
                {
                    this.IpAdress = IPAddress.Parse(value);
                }
            }
        }
        public bool CheckIPAdress(string ip)
        {
            IPAddress neIP;
            if (!IPAddress.TryParse(ip, out neIP))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ConnectingToServer()
        {
            byte[] buff = new byte[5368086];
            keepRunning = true;

            try
            {
                myclient.Connect(IpAdress, 5000);
                NetworkStream clientStreamReader;
                clientStreamReader = myclient.GetStream();
                while (keepRunning)
                {

                    int readbycount = 0;
                    readbycount = clientStreamReader.Read(buff, 0, buff.Length);
                    ImageSend image = new ImageSend(buff);
                    if (readbycount == 0)
                    {
                        Debug.WriteLine("Socked disconnected");
                        break;
                    }
                    OnRaiseImageSendEvent(image);
                    Array.Clear(buff, 0, buff.Length);


                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            Debug.WriteLine("Sending buff");

        }
        public void SendingToServer(byte[] imgarr)
        {
            try
            {
                myclient.GetStream().Write(imgarr, 0, imgarr.Length);

                Debug.WriteLine("DataSend");
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
        }
        protected virtual void OnRaiseImageSendEvent(ImageSend e)
        {
            EventHandler<ImageSend> handler = RaiseImageresEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnRaisedTextSendEvent(TextSend e)
        {
            EventHandler<TextSend> handler = RaiseTextsendEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void ConnectingToServer2()
        {
            if (client2 == null)
            {
                client2 = new TcpClient();
            }
            try
            {
                client2.Connect(IpAdress, 8000);
                ReadText();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }
        }

        private void ReadText()
        {
            try
            {
                StreamReader reader = new StreamReader(client2.GetStream());
                char[] buff = new char[64];
                int readbycunt = 0;
                while (keepRunning)
                {
                    readbycunt = reader.Read(buff, 0, buff.Length);
                    if (readbycunt == 0)
                    {
                        Debug.WriteLine("disconnected from server");
                        client2.Close();
                        break;
                    }
                    string text1 = new string(buff);
                    TextSend text = new TextSend(text1);
                    OnRaisedTextSendEvent(text);

                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }
        }
        public async void SendText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (client2 != null)
            {
                if (client2.Connected)
                {
                    StreamWriter clientwrite = new StreamWriter(client2.GetStream());
                    clientwrite.AutoFlush = true;
                    await clientwrite.WriteAsync(text);
                    Debug.WriteLine("Text send");
                }
            }
        }
        public void CloseClient()
        {
            if (client2 != null)
            {
                if (client2.Connected)
                {
                    client2.Close();
                }
            }
            if (myclient != null)
            {
                if (myclient.Connected)
                {
                    myclient.Close();
                }
            }
        }
    }
}
