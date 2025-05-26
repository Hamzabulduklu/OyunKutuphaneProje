using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphaneProje
{
    class Platform
    {
        public Point Konum { get; set; }
        public int Genislik { get; } = 80;
        public int Yukseklik { get; } = 20;
        public int HareketHizi { get; } = 15;

        public Rectangle Alan => new Rectangle(Konum.X, Konum.Y, Genislik, Yukseklik);
        //overloading
        public Platform(int x, int y)
        {
            Konum = new Point(x, y);
        }
        //overloading
        public Platform(int x )
        {
            Konum = new Point(x);
        }

        public void SolaGit()
        {
            Konum = new Point(Konum.X - HareketHizi, Konum.Y);
        }

        public void SagaGit()
        {
            Konum = new Point(Konum.X + HareketHizi, Konum.Y);
        }
    }
}
