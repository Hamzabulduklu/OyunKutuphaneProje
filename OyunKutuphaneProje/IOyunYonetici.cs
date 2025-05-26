using System;
using System.Collections.Generic;

namespace OyunKutuphaneProje
{
    // Interface 1: Oyun işlemleri için temel arayüz
    public interface IOyunIslemleri
    {
        void OyunuBaslat();
        void OyunuDurdur();
        int PuanHesapla();
    }

    // Interface 2: Veritabanı işlemleri için arayüz
    public interface IVeritabaniIslemleri
    {
        void Ekle(string tabloAdi, Dictionary<string, object> veriler);
        void Guncelle(string tabloAdi, Dictionary<string, object> veriler, string whereKosulu);
        void Sil(string tabloAdi, string whereKosulu);
        List<Dictionary<string, object>> Listele(string tabloAdi);
    }

    // Interface 3: Kullanıcı işlemleri için arayüz
    public interface IKullaniciIslemleri
    {
        bool GirisYap(string kullaniciAdi, string sifre);
        void KayitOl(string kullaniciAdi, string sifre, string email);
        void SifreSifirla(string email);
    }

    // Interface 4: IOyunIslemleri'ni miras alan genişletilmiş arayüz
    public interface IOyunYonetici : IOyunIslemleri
    {
        void ZorlukAyarla(int seviye);
        void SkorKaydet(int puan);
        List<int> EnYuksekSkorlariGetir();
    }

    // Static sınıf ve değişkenler
    public static class OyunSabitleri
    {
        public static readonly int MAX_SKOR = 1000;
        public static readonly int MIN_SKOR = 0;
        public static readonly string VERITABANI_ADI = "OyunKutuphaneDB";

        public static int SkorHesapla(int puan, int zorlukSeviyesi)
        {
            return puan * zorlukSeviyesi;
        }

        public static bool SkorGecerliMi(int skor)
        {
            return skor >= MIN_SKOR && skor <= MAX_SKOR;
        }
    }
} 