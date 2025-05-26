public abstract class Zorluk
{   //
    // Encapsulation(Kapsülleme)
    //Abstraction
    public abstract int Hiz { get; }
    public abstract int GetHizDegeri();
    public abstract int GetLabirentZorluk();
    public abstract int GetHafizaKartSayisi();
    public abstract int GetKelimeUzunlugu();
}

public class Kolay : Zorluk
{
    public override int Hiz => 200;
    
    public override int GetHizDegeri() => 30; // Zıplayan top için daha yavaş (kolay)
    
    public override int GetLabirentZorluk() => 1; // Labirent zorluk seviyesi
    
    public override int GetHafizaKartSayisi() => 8; // 2x4 kart
    
    public override int GetKelimeUzunlugu() => 1; // Kolay kelimeler
}

public class Orta : Zorluk
{
    public override int Hiz => 100;
    
    public override int GetHizDegeri() => 20; // Zıplayan top için orta hız
    
    public override int GetLabirentZorluk() => 2; // Labirent zorluk seviyesi
    
    public override int GetHafizaKartSayisi() => 16; // 4x4 kart
    
    public override int GetKelimeUzunlugu() => 2; // Orta zorlukta kelimeler
}

public class Zor : Zorluk
{
    public override int Hiz => 50;
    
    public override int GetHizDegeri() => 10; // Zıplayan top için daha hızlı (zor)
    
    public override int GetLabirentZorluk() => 3; // Labirent zorluk seviyesi
    
    public override int GetHafizaKartSayisi() => 36; // 6x6 kart
    
    public override int GetKelimeUzunlugu() => 3; // Zor kelimeler
}
