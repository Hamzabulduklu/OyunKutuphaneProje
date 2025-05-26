using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphaneProje
{
    class Top
    {
        public Point Konum { get; set; }
        public int Cap { get; } = 20;
        public int HizX { get; set; } = 0;
        public int HizY { get; set; } = 0;

        public Rectangle Alan => new Rectangle(Konum.X, Konum.Y, Cap, Cap);

        public Top(int x, int y)
        {
            Konum = new Point(x, y);
        }

        public void HareketEttir()
        {
            Konum = new Point(Konum.X + HizX, Konum.Y + HizY);
        }
    }
}
