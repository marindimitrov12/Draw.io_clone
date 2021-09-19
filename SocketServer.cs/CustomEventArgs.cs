using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace SocketServer
{
    public class ImageSend : EventArgs
    {
        public byte[] MyStream { get; set; }
        public ImageSend(byte[] netstr)
        {
            MyStream = netstr;
        }
    }
    public class TextSend : EventArgs
    {
        public string Mytext { get; set; }
        public TextSend(string text)
        {
            Mytext = text;
        }
    }
}