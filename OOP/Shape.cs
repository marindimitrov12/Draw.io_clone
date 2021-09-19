using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
   abstract class Shape
    {
        public Point location;


        public virtual Graphics DrawGraphics(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
