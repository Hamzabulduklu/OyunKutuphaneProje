using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphaneProje
{ 
    // Abstraction YeniOyun(), HarfTahminEt(), OyunBittiMi()
    //polymorphism yenioyun() metodu
    class KelimeYonetici
    {
        private string secilenKelime;
        private HashSet<char> dogruHarfler = new HashSet<char>();
        private int kalanHak;

        public int KalanHak => kalanHak;
        public string Gosterim => new string(secilenKelime.Select(c => dogruHarfler.Contains(c) ? c : '_').ToArray());
        //kapsülleme (Encapsulation) - private değişkenleri dışarıdan erişime kapatıyoruz.
        //STATIC DEGISKEN
        private static string[] kolayKelimeler = { "masa", "araba", "elma", "ev", "kedi" };
        private static string[] ortaKelimeler = { "bilgisayar", "okul", "kitaplik", "defter" };
        private static string[] zorKelimeler = { "geliştirici", "programlama", "veritabani", "algoritma" };
        
        //polymorphism
        public void YeniOyun(int zorlukSeviyesi)
        {
            Random rnd = new Random();
            switch (zorlukSeviyesi)
            {
                case 1: // Kolay
                    secilenKelime = kolayKelimeler[rnd.Next(kolayKelimeler.Length)];
                    break;
                case 2: // Orta
                    secilenKelime = ortaKelimeler[rnd.Next(ortaKelimeler.Length)];
                    break;
                case 3: // Zor
                    secilenKelime = zorKelimeler[rnd.Next(zorKelimeler.Length)];
                    break;
                default:
                    secilenKelime = ortaKelimeler[rnd.Next(ortaKelimeler.Length)]; // Varsayılan olarak orta seviye
                    break;
            }

            dogruHarfler.Clear();
            kalanHak = 6;
        }
        //polymorphism
        // Eski metodu da bırakalım, geriye uyumluluk için
        public void YeniOyun(string zorluk)
        {
            int zorlukSeviyesi;
            switch (zorluk.ToLower())
            {
                case "kolay":
                    zorlukSeviyesi = 1;
                    break;
                case "zor":
                    zorlukSeviyesi = 3;
                    break;
                case "orta":
                default:
                    zorlukSeviyesi = 2;
                    break;
            }
            YeniOyun(zorlukSeviyesi);
        }
        //Abstraction
        public bool HarfTahminEt(char harf)
        {
            if (secilenKelime.Contains(harf))
            {
                dogruHarfler.Add(harf);
                return true;
            }
            else
            {
                kalanHak--;
                return false;
            }
        }

        public bool OyunBittiMi() => kalanHak <= 0 || TumHarflerTahminEdildi();

        public bool TumHarflerTahminEdildi()
        {
            return secilenKelime.All(c => dogruHarfler.Contains(c));
        }

        public string GetKelime() => secilenKelime;
    }
}
