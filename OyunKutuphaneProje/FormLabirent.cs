using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunKutuphaneProje
{
    public partial class FormLabirent : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        List<Duvar> duvarlar = new List<Duvar>();
        Oyuncu oyuncu;
        Cikis cikis;
        public string kullaniciAdi;
        public Zorluk zorlukSeviyesi { get; set; } = new Orta();
        bool oyunBasladi = false;

        public FormLabirent()
        {
            InitializeComponent();
            this.KeyPreview = true; // Form tuşlara baksın
            this.KeyDown += FormLabirent_KeyDown; // KeyDown olayı formda
            pnlLabirent.Paint += pnlLabirent_Paint; // Panel çizim olayı
            timer1.Tick += Timer1_Tick; // Timer olayı
            timer1.Interval = 50; // Timer sıklığı
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (oyunBasladi && oyuncu != null)
            {
                this.Focus(); // Formu sürekli odakta tut
                pnlLabirent.Invalidate(); // Sürekli çiz
            }
        }

        private void FormLabirent_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                // Zorluk seviyesini kontrol et
                if (zorlukSeviyesi == null)
                    zorlukSeviyesi = new Orta();

                duvarlar.Clear();
                pnlLabirent.Invalidate();
                lblDurum.Text = "";

                oyuncu = new Oyuncu(20, 20);
                cikis = new Cikis(360, 360, 20);

                // Zorluk seviyesine göre labirent oluştur
                OlusturLabirent(zorlukSeviyesi.GetLabirentZorluk());

                // Başlat butonunu gizle
                btnBaslat.Visible = false;
                
                // Oyun başladı
                oyunBasladi = true;
                
                // Timer'ı başlat
                timer1.Start();
                
                this.ActiveControl = null; // Odağı forma al
                this.Focus();
                pnlLabirent.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun başlatılırken hata oluştu: " + ex.Message);
            }
        }

        private void OlusturLabirent(int zorlukSeviyesi)
        {
            try
            {
                Random rnd = new Random();
                
                // Önce panel etrafına duvarlar ekleyelim (tüm zorluk seviyeleri için)
                // Üst sınır
                duvarlar.Add(new Duvar(0, 0, pnlLabirent.Width, 20));
                // Alt sınır
                duvarlar.Add(new Duvar(0, pnlLabirent.Height - 20, pnlLabirent.Width, 20));
                // Sol sınır
                duvarlar.Add(new Duvar(0, 0, 20, pnlLabirent.Height));
                // Sağ sınır
                duvarlar.Add(new Duvar(pnlLabirent.Width - 20, 0, 20, pnlLabirent.Height));
                
                switch (zorlukSeviyesi)
                {
                    case 1: // Kolay
                        // Temel birkaç duvar
                        duvarlar.Add(new Duvar(60, 40, 20, 110));
                        duvarlar.Add(new Duvar(120, 150, 150, 20));
                        duvarlar.Add(new Duvar(180, 40, 20, 100));
                        break;
                    
                    case 2: // Orta
                        // Orta seviye duvarlar
                        duvarlar.Add(new Duvar(60, 40, 20, 160));
                        duvarlar.Add(new Duvar(120, 200, 200, 20));
                        duvarlar.Add(new Duvar(180, 40, 20, 110));
                        duvarlar.Add(new Duvar(240, 150, 20, 200));
                        duvarlar.Add(new Duvar(300, 40, 20, 100));
                        break;
                    
                    case 3: // Zor
                        // Karmaşık labirent
                        duvarlar.Add(new Duvar(60, 40, 20, 160));
                        duvarlar.Add(new Duvar(120, 200, 200, 20));
                        duvarlar.Add(new Duvar(180, 40, 20, 110));
                        duvarlar.Add(new Duvar(240, 150, 20, 200));
                        duvarlar.Add(new Duvar(300, 40, 20, 210));
                        duvarlar.Add(new Duvar(40, 100, 60, 20));
                        duvarlar.Add(new Duvar(100, 250, 20, 120));
                        duvarlar.Add(new Duvar(150, 300, 150, 20));
                        duvarlar.Add(new Duvar(350, 100, 50, 20));
                        break;
                        
                    default: // Varsayılan olarak orta
                        // Orta seviye duvarlar
                        duvarlar.Add(new Duvar(60, 40, 20, 160));
                        duvarlar.Add(new Duvar(120, 200, 200, 20));
                        duvarlar.Add(new Duvar(180, 40, 20, 110));
                        duvarlar.Add(new Duvar(240, 150, 20, 200));
                        duvarlar.Add(new Duvar(300, 40, 20, 100));
                        break;
                }
                
                // Oyuncu başlangıç konumunu sağ üst köşeye ayarla (duvarların içinde kalmaması için)
                oyuncu.Konum = new Point(40, 40);
                
                // Çıkış konumunu zorluk seviyesine göre ayarla
                if (zorlukSeviyesi == 1) // Kolay
                    cikis.Konum = new Point(pnlLabirent.Width - 60, pnlLabirent.Height - 60);
                else if (zorlukSeviyesi == 3) // Zor
                    cikis.Konum = new Point(pnlLabirent.Width - 60, pnlLabirent.Height - 60);
                else // Orta
                    cikis.Konum = new Point(pnlLabirent.Width - 60, pnlLabirent.Height - 60);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Labirent oluşturulurken hata: " + ex.Message);
            }
        }

        private void pnlLabirent_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (oyuncu != null)
                g.FillRectangle(Brushes.Blue, new Rectangle(oyuncu.Konum.X, oyuncu.Konum.Y, 20, 20));

            if (cikis != null)
                g.FillRectangle(Brushes.Green, cikis.Alan);

            foreach (var duvar in duvarlar)
            {
                g.FillRectangle(Brushes.Gray, duvar.Alan);
            }
        }

        private void FormLabirent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (oyuncu == null || !oyunBasladi) return;

                Point eskiKonum = oyuncu.Konum;
                
                // WASD ve ok tuşlarını destekle
                switch (e.KeyCode)
                {
                    case Keys.W:
                    case Keys.Up:
                        oyuncu.Konum = new Point(oyuncu.Konum.X, oyuncu.Konum.Y - 20);
                        break;
                    case Keys.S:
                    case Keys.Down:
                        oyuncu.Konum = new Point(oyuncu.Konum.X, oyuncu.Konum.Y + 20);
                        break;
                    case Keys.A:
                    case Keys.Left:
                        oyuncu.Konum = new Point(oyuncu.Konum.X - 20, oyuncu.Konum.Y);
                        break;
                    case Keys.D:
                    case Keys.Right:
                        oyuncu.Konum = new Point(oyuncu.Konum.X + 20, oyuncu.Konum.Y);
                        break;
                }

                Rectangle oyuncuAlan = new Rectangle(oyuncu.Konum.X, oyuncu.Konum.Y, 20, 20);

                foreach (var duvar in duvarlar)
                {
                    if (oyuncuAlan.IntersectsWith(duvar.Alan))
                    {
                        oyuncu.Konum = eskiKonum;
                        lblDurum.Text = "Duvara çarptın!";
                        pnlLabirent.Invalidate();
                        return;
                    }
                }

                if (oyuncuAlan.IntersectsWith(cikis.Alan))
                {
                    timer1.Stop();
                    oyunBasladi = false;
                    lblDurum.Text = "Kazandın! OYUN BİTTİ!!";
                    // Zorluk seviyesine göre skor belirle
                    int skorKatsayi = 50 * zorlukSeviyesi.GetLabirentZorluk();
                    SkoruKaydet(skorKatsayi);
                    btnBaslat.Visible = true; // Oyun bitince butonu göster
                }

                pnlLabirent.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hareket esnasında hata: " + ex.Message);
            }
        }

        void SkoruKaydet(int skor)
        {
            try
            {
                SqlCommand cmdID = new SqlCommand("SELECT OyunID FROM Oyunlar WHERE OyunAdi = @ad", bgl.baglanti());
                cmdID.Parameters.AddWithValue("@ad", "Labirent Oyunu");
                object sonuc = cmdID.ExecuteScalar();

                if (sonuc != null)
                {
                    int oyunID = Convert.ToInt32(sonuc);

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
