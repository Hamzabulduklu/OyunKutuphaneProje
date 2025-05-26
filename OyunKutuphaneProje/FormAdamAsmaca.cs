using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunKutuphaneProje
{
    public partial class FormAdamAsmaca: Form
    {
        KelimeYonetici kelimeYonetici = new KelimeYonetici();
        public string kullaniciAdi; // Skor kaydı için
        public Zorluk zorlukSeviyesi { get; set; } = new Orta();
        SqlBaglanti bgl = new SqlBaglanti();

        public FormAdamAsmaca()
        {
            InitializeComponent();
        }

        private void FormAdamAsmaca_Load(object sender, EventArgs e)
        {
            btnBaslat_Click(sender, e); // Form yüklenince oyunu başlat
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                btnTahmin.Enabled = true;
                txtHarf.Enabled = true;

                // Zorluk seviyesini kontrol et
                if (zorlukSeviyesi == null)
                    zorlukSeviyesi = new Orta(); // Zorluk seviyesi belirtilmemişse orta olarak ayarla

                // Zorluk seviyesi ile yeni oyun başlat
                int zorlukDegeri = zorlukSeviyesi.GetKelimeUzunlugu();
                kelimeYonetici.YeniOyun(zorlukDegeri);
                
                lblKelime.Text = kelimeYonetici.Gosterim;
                lblKalanHak.Text = "Kalan Hak: " + kelimeYonetici.KalanHak;
                lblMesaj.Text = "Yeni oyun başladı!";
                txtHarf.Text = "";
                txtHarf.Focus();

                // Adam resmini yükle
                GorseliGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun başlatılırken hata oluştu: " + ex.Message);
            }
        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHarf.Text)) return;

                char tahmin = char.ToLower(txtHarf.Text[0]);
                bool dogru = kelimeYonetici.HarfTahminEt(tahmin);

                lblKelime.Text = kelimeYonetici.Gosterim;
                lblKalanHak.Text = "Kalan Hak: " + kelimeYonetici.KalanHak;
                GorseliGuncelle();

                if (kelimeYonetici.OyunBittiMi())
                {
                    if (kelimeYonetici.TumHarflerTahminEdildi())
                    {
                        lblMesaj.Text = "Tebrikler! Kelimeyi bildiniz: " + kelimeYonetici.GetKelime();
                        // Zorluk seviyesine göre skor hesapla
                        int skor = 30 * zorlukSeviyesi.GetKelimeUzunlugu();
                        SkoruKaydet(skor);
                    }
                    else
                    {
                        lblMesaj.Text = "Oyun bitti! Kelime: " + kelimeYonetici.GetKelime();
                    }

                    txtHarf.Enabled = false;
                    btnTahmin.Enabled = false;
                }
                else
                {
                    lblMesaj.Text = dogru ? "Doğru tahmin!" : "Yanlış tahmin!";
                }

                txtHarf.Clear();
                txtHarf.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Harf tahmin edilirken hata: " + ex.Message);
            }
        }

        void SkoruKaydet(int skor)
        {
            try
            {
                // 1. OyunID'yi bul
                SqlCommand cmdID = new SqlCommand("SELECT OyunID FROM Oyunlar WHERE OyunAdi = @ad", bgl.baglanti());
                cmdID.Parameters.AddWithValue("@ad", "Adam Asmaca");
                object sonuc = cmdID.ExecuteScalar();

                if (sonuc != null)
                {
                    int oyunID = Convert.ToInt32(sonuc);

                    // 2. Skoru kaydet
                    SqlCommand komut = new SqlCommand("INSERT INTO Skorlar (KullaniciAdi, OyunID, Skor, Tarih) VALUES (@p1, @p2, @p3, @p4)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", kullaniciAdi ?? "Misafir");
                    komut.Parameters.AddWithValue("@p2", oyunID);
                    komut.Parameters.AddWithValue("@p3", skor);
                    komut.Parameters.AddWithValue("@p4", DateTime.Now);
                    komut.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Oyun adı bulunamadı, skor kaydedilemedi.");
                }

                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Skor kaydı başarısız: " + ex.Message);
            }
        }

        void GorseliGuncelle()
        {
            try
            {
                int hataSayisi = 6 - kelimeYonetici.KalanHak;

                if (hataSayisi >= 0 && hataSayisi <= 6)
                {
                    string dosya = Application.StartupPath + $@"\Resources\adam{hataSayisi}.png";
                    if (System.IO.File.Exists(dosya))
                        picAdam.Image = Image.FromFile(dosya);
                }
            }
            catch (Exception)
            {
                // Görsel yüklenemezse sessizce devam et
            }
        }

        private void lblKalanHak_Click(object sender, EventArgs e)
        {

        }
    }
}
