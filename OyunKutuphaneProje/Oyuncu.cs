using System.Drawing;
using System.Windows.Forms;

public class Oyuncu
{
    public Point Konum { get; set; }

    public Oyuncu(int x, int y)
    {
        Konum = new Point(x, y);
    }

    public void HareketEt(Keys yon)
    {
        Point yeniKonum = Konum;

        switch (yon)
        {
            case Keys.Up: yeniKonum.Y -= 20; break;
            case Keys.Down: yeniKonum.Y += 20; break;
            case Keys.Left: yeniKonum.X -= 20; break;
            case Keys.Right: yeniKonum.X += 20; break;
        }

        Konum = yeniKonum;
    }
}
