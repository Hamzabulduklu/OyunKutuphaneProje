using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphaneProje
{
    class Yemek
    {
        public Point Konum { get; set; }
        private Random rnd = new Random();

        public void YeniYemekUret(int genislik, int yukseklik)
        {
            Konum = new Point(rnd.Next(0, genislik / 20) * 20, rnd.Next(0, yukseklik / 20) * 20);
        }
    }
}
