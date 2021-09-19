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
    class SockedServer
    {
        private TcpListener ls;
        private TcpListener ls2;
        private TcpClient client2;
        private TcpClient client;
        bool keepRunning = true;
        public EventHandler<ImageSend> RaiseImageSendEvent;
        public EventHandler<TextSend> RaiseTextsendEvent;
        
        public async void StartListening()
        {
           
            ls = new TcpListener(IPAddress.Any, 5000);
            keepRunning = true;
            try
            {
                ls.Start();
                while (keepRunning == true)
                {

                    Debug.WriteLine("server is running");
                    client = await ls.AcceptTcpClientAsync();


                    if (client.Connected)
                    {
                        ReadFronClient();
                        Debug.WriteLine(client.Client.RemoteEndPoint.ToString());
                        Debug.WriteLine(ls.LocalEndpoint.ToString());
                    }

                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }

        }
        public void ReadFronClient()
        {
            NetworkStream stream;
            byte[] arr = new byte[10000000];
            try
            {
                stream = client.GetStream();
                while (keepRunning == true)
                {
                    int readbycount = 0;
                    readbycount = stream.Read(arr, 0, arr.Length);


                    if (readbycount == 0)
                    {
                        Debug.WriteLine("Socked disconnected");
                        break;
                    }
                    ImageSend image = new ImageSend(arr);
                    OnRaisedEmageSendEvent(image);
                    Array.Clear(arr, 0, arr.Length);
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }


        }
        protected virtual void OnRaisedEmageSendEvent(ImageSend e)
        {
            EventHandler<ImageSend> handler = RaiseImageSendEvent;
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

        public async void TakeCareofTcpClientEmage(byte[] arrimg)
        {


            if (client.Connected)
            {
                try
                {
                    client.GetStream().Write(arrimg, 0, arrimg.Length);

                    Debug.WriteLine("Data send");
                }
                catch (Exception e)
                {

                    Debug.WriteLine(e);
                }
            }

        }
        public void StartListenning2()
        {
            ls2 = new TcpListener(IPAddress.Any, 8000);
            try
            {
                ls2.Start();
                while (keepRunning == true)
                {
                    Debug.WriteLine("server is running");
                    client2 = ls2.AcceptTcpClient();
                    if (client2.Connected)
                    {
                        ReadFromClient2(client2);
                        Debug.WriteLine(client.Client.RemoteEndPoint.ToString());
                        Debug.WriteLine(ls.LocalEndpoint.ToString());
                    }
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }
        }
        public void ReadFromClient2(TcpClient paramclient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;
            byte[] arr = new byte[10000000];
            try
            {
                stream = paramclient.GetStream();
                reader = new StreamReader(stream);
                char[] buff = new char[64];
                while (keepRunning == true)
                {
                    Debug.WriteLine("Ready to read");
                    int nRet = reader.Read(buff, 0, buff.Length);
                    if (nRet == 0)
                    {
                        Debug.WriteLine("Text socket disconnected");
                        break;
                    }
                    string recieved = new string(buff);
                    TextSend res = new TextSend(recieved);
                    OnRaisedTextSendEvent(res);

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
            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(text);
                await client2.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                Debug.WriteLine("Text Send");
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }
        }
        public void Stopserver()
        {
            try
            {
                if (ls != null && client != null)
                {
                    keepRunning = false;
                    ls.Stop();
                    client.Close();
                }
                if (ls2 != null && client2 != null)
                {
                    ls2.Stop();
                    client2.Close();
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.ToString());
            }
        }
    }
}
