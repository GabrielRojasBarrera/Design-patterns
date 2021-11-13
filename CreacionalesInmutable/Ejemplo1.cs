using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns.CreacionalesInmutable
{
    public class Punto
    {
        private int x;
        private int y;

        public   Punto(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;


        }
       
        public int geyx()
        {
            return x;
        }
        public int geyy()
        {
            return y;
        }

        public  Punto Offset  (int xoff, int yoff)
        {
            return new Punto (x + xoff, y + yoff);
            
        }
    }
}
