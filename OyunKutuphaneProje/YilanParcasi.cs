using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphaneProje
{
    public class YilanParcasi
    {
        public Point Konum { get; set; }

        public YilanParcasi(int x, int y)
        {
            Konum = new Point(x, y);
        }
    }
}
