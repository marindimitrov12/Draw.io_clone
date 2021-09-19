using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Circle:Shape
    {
        public int High { get; set; }
        public int Width { get; set; }
        public Color colour { get; set; } 
        public Color fill { get; set; } 

        public override Graphics DrawGraphics(Graphics g)
        {
            using (var brush = new SolidBrush(fill))
            using (var pen = new Pen(colour))
            {
                if (colour!=null)
                {
                    g.DrawEllipse(pen, this.location.X, this.location.Y, Width, High);
                }
               
                if (fill!=null)
                {
                    g.FillEllipse(brush, this.location.X + 1, this.location.Y + 1, Width - 1, High - 1);
                }
               
                return g;

            }
        }
    }
}
