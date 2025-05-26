using System;
using System.Collections.Generic;

namespace OyunKutuphaneProje
{
    public class OyunYonetici : IOyunYonetici, IVeritabaniIslemleri
    {
        private int _zorlukSeviyesi;
        private int _mevcutPuan;
        private bool _oyunAktif;
        private static int _toplamOyunSayisi = 0;

        // Constructor
        public OyunYonetici()
        {
            _zorlukSeviyesi = 1;
            _mevcutPuan = 0;
            _oyunAktif = false;
            _toplamOyunSayisi++;
        }

        // Method Overloading Örnekleri
        public void SkorKaydet(int puan)
        {
            _mevcutPuan = puan;
            Console.WriteLine($"Skor kaydedildi: {puan}");
        }

        public void SkorKaydet(int puan, string oyuncuAdi)
        {
            _mevcutPuan = puan;
            Console.WriteLine($"{oyuncuAdi} için skor kaydedildi: {puan}");
        }

        public void SkorKaydet(int puan, string oyuncuAdi, DateTime tarih)
        {
            _mevcutPuan = puan;
            Console.WriteLine($"{oyuncuAdi} için {tarih.ToShortDateString()} tarihinde skor kaydedildi: {puan}");
        }

        // IOyunIslemleri implementasyonu
        public void OyunuBaslat()
        {
            _oyunAktif = true;
            Console.WriteLine("Oyun başlatıldı!");
        }

        public void OyunuDurdur()
        {
            _oyunAktif = false;
            Console.WriteLine("Oyun durduruldu!");
        }

        public int PuanHesapla()
        {
            return _mevcutPuan;
        }

        // IOyunYonetici implementasyonu
        public void ZorlukAyarla(int seviye)
        {
            if (seviye >= 1 && seviye <= 3)
            {
                _zorlukSeviyesi = seviye;
                Console.WriteLine($"Zorluk seviyesi {seviye} olarak ayarlandı.");
            }
        }

        public List<int> EnYuksekSkorlariGetir()
        {
            return new List<int> { 1000, 800, 600, 400, 200 };
        }

        // IVeritabaniIslemleri implementasyonu
        public void Ekle(string tabloAdi, Dictionary<string, object> veriler)
        {
            Console.WriteLine($"{tabloAdi} tablosuna veri eklendi.");
        }

        public void Guncelle(string tabloAdi, Dictionary<string, object> veriler, string whereKosulu)
        {
            Console.WriteLine($"{tabloAdi} tablosunda veri güncellendi.");
        }

        public void Sil(string tabloAdi, string whereKosulu)
        {
            Console.WriteLine($"{tabloAdi} tablosundan veri silindi.");
        }

        public List<Dictionary<string, object>> Listele(string tabloAdi)
        {
            return new List<Dictionary<string, object>>();
        }

        // Static metot örneği
        public static int GetToplamOyunSayisi()
        {
            return _toplamOyunSayisi;
        }
    }
} 