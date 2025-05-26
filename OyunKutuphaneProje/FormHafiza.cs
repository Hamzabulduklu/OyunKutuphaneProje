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
    public partial class FormHafiza: Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        List<Button> kartlar = new List<Button>();
        List<string> semboller = new List<string>();
        Button ilkSecilen = null;
        Button ikinciSecilen = null;
        int eslesenCiftSayisi = 0;
        public string kullaniciAdi;
        public Zorluk zorlukSeviyesi { get; set; } = new Orta();

        public FormHafiza()
        {
            InitializeComponent();
        }

        private void FormHafiza_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde oyunu hemen başlatma
            lblDurum.Text = "Oyunu başlatmak için 'Başlat' butonuna tıklayın.";
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                // Zorluk seviyesini kontrol et
                if (zorlukSeviyesi == null)
                    zorlukSeviyesi = new Orta();

                KartlariOlustur();
                lblDurum.Text = "Eşleştirmeye başla!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun başlatılırken hata oluştu: " + ex.Message);
            }
        }

        void KartlariOlustur()
        {
            // Panel ve kart verilerini temizle
            pnlKartlar.Controls.Clear();
            kartlar.Clear();
            semboller.Clear();
            eslesenCiftSayisi = 0;
            ilkSecilen = null;
            ikinciSecilen = null;

            // Zorluk seviyesine göre kart sayısını al
            int kartSayisi = zorlukSeviyesi.GetHafizaKartSayisi();
            int satir = 4, sutun = 4;

            // Zorluk seviyesine göre satır sütun ayarla
            if (kartSayisi == 8) { satir = 2; sutun = 4; } // Kolay
            else if (kartSayisi == 16) { satir = 4; sutun = 4; } // Orta
            else if (kartSayisi == 36) { satir = 6; sutun = 6; } // Zor

            // Sembol dizisini hazırla ve karıştır
            string[] tumSemboller = { "🍎", "🍌", "🍒", "🍇", "🍓", "🍍", "🥝", "🥥", "🫐", "🥭", "🍉", "🍑", "🍈", "🥕", "🍅", "🌽", "🥔", "🍆" };
            var rnd = new Random();

            // Gerekli sayıda sembol seç
            semboller = tumSemboller.Take(kartSayisi / 2).ToList();
            semboller.AddRange(semboller); // çiftleri oluştur
            semboller = semboller.OrderBy(x => rnd.Next()).ToList(); // karıştır

            // Panel boyutlarını ayarla
            pnlKartlar.SuspendLayout();
            pnlKartlar.Width = sutun * 60;
            pnlKartlar.Height = satir * 60;

            // Kartları oluştur
            for (int i = 0; i < kartSayisi; i++)
            {
                Button btn = new Button();
                btn.Width = 50;
                btn.Height = 50;
                btn.Font = new Font("Segoe UI Emoji", 18);
                btn.Tag = semboller[i];
                btn.Text = ""; // başlangıçta gizli
                btn.Click += Kart_Click;

                int x = (i % sutun) * 60;
                int y = (i / sutun) * 60;
                btn.Location = new Point(x, y);

                pnlKartlar.Controls.Add(btn);
                kartlar.Add(btn);
            }
            pnlKartlar.ResumeLayout();
        }

        void Kart_Click(object sender, EventArgs e)
        {
            try
            {
                Button tiklanan = sender as Button;

                if (tiklanan == null || tiklanan == ilkSecilen || tiklanan.Text != "") return;

                tiklanan.Text = tiklanan.Tag.ToString();

                if (ilkSecilen == null)
                {
                    ilkSecilen = tiklanan;
                    return;
                }

                ikinciSecilen = tiklanan;

                // Eşleşme kontrolü
                if (ilkSecilen.Tag.ToString() == ikinciSecilen.Tag.ToString())
                {
                    ilkSecilen.Enabled = false;
                    ikinciSecilen.Enabled = false;
                    ilkSecilen = null;
                    ikinciSecilen = null;
                    eslesenCiftSayisi++;

                    if (eslesenCiftSayisi == kartlar.Count / 2)
                    {
                        lblDurum.Text = "🎉 Tüm kartları eşledin. OYUN BİTTİ!";
                        // Zorluk seviyesine göre skor hesapla
                        int skor = 50 * zorlukSeviyesi.GetHafizaKartSayisi() / 4;
                        SkoruKaydet(skor);
                    }
                }
                else
                {
                    Timer t = new Timer();
                    t.Interval = 800;
                    t.Tick += (s, ev) =>
                    {
                        ilkSecilen.Text = "";
                        ikinciSecilen.Text = "";
                        ilkSecilen = null;
                        ikinciSecilen = null;
                        t.Stop();
                    };
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kart tıklanırken hata oluştu: " + ex.Message);
            }
        }

        void SkoruKaydet(int skor)
        {
            try
            {
                // 1. OyunID'yi bul
                SqlCommand cmdID = new SqlCommand("SELECT OyunID FROM Oyunlar WHERE OyunAdi = @ad", bgl.baglanti());
                cmdID.Parameters.AddWithValue("@ad", "Hafıza Oyunu");
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
    }
}
