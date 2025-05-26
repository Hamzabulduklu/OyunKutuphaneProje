using System;
using System.Drawing;

namespace OyunKutuphaneProje
{
    class Cikis
    {
        public Point Konum { get; set; }
        public int Boyut { get; }

        public Rectangle Alan => new Rectangle(Konum.X, Konum.Y, Boyut, Boyut);

        public Cikis(int x, int y, int boyut)
        {
            Konum = new Point(x, y);
            Boyut = boyut;
        }
    }
}
