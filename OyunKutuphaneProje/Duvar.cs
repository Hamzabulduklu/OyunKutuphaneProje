using System.Drawing;

public class Duvar
{
    public Rectangle Alan { get; set; }

    public Duvar(int x, int y, int genislik, int yukseklik)
    {
        Alan = new Rectangle(x, y, genislik, yukseklik);
    }
}
