using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
     class CustonEventArgs
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
}
