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
    public partial class FormZiplayanTop : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        Top top;
        Platform platform;
        int skor = 0;
        public string kullaniciAdi;
        public Zorluk zorlukSeviyesi { get; set; } = new Orta();
        
        // Klavye durumunu izlemek için değişkenler
        private bool solTusuBasili = false;
        private bool sagTusuBasili = false;
        private Timer klavyeTimer = new Timer();

        public FormZiplayanTop()
        {
            InitializeComponent();
            this.KeyPreview = true; // 🔥 Form tuşları yakalayacak
            this.KeyDown += FormZiplayanTop_KeyDown; // 🔥 Tuş basınca çalışacak
            this.KeyUp += FormZiplayanTop_KeyUp; // 🔥 Tuş bırakılınca çalışacak
            pnlOyunAlani.Paint += pnlOyunAlani_Paint; // 🔥 Panel üzerine çizecek
            timer1.Tick += timer1_Tick; // 🔥 Timer tick olayını dinleyecek
            
            // Klavye durumunu sürekli kontrol eden timer
            klavyeTimer.Interval = 30; // 30ms aralıklarla kontrol et
            klavyeTimer.Tick += KlavyeTimer_Tick;
        }

        private void FormZiplayanTop_Load(object sender, EventArgs e)
        {
            this.Focus();
            // Sadece form yüklendiğinde oyunu hemen başlatmayalım
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                // Zorluk seviyesini kontrol et
                if (zorlukSeviyesi == null)
                    zorlukSeviyesi = new Orta();

                skor = 0;
                lblDurum.Text = "Oyun başladı!";

                top = new Top(pnlOyunAlani.Width / 2, pnlOyunAlani.Height / 2);
                platform = new Platform(pnlOyunAlani.Width / 2 - 40, pnlOyunAlani.Height - 30);

                // Direk sabit değerlerle başlatalım, rasgele değerler sorun çıkartabilir
                top.HizX = 5; // Başlangıçta sağa doğru gitsin
                top.HizY = -5; // Başlangıçta yukarı doğru gitsin

                // Zorluk seviyesine göre timer ayarla
                timer1.Interval = zorlukSeviyesi.GetHizDegeri();

                // Timerları başlat
                timer1.Start();
                klavyeTimer.Start();
                
                this.ActiveControl = null;
                this.Focus();
                pnlOyunAlani.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun başlatılırken hata: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (top == null || platform == null) return;

                // Mevcut konumu kaydet
                Point eskiKonum = top.Konum;
                
                // Topu hareket ettir
                top.HareketEttir();

                // Yan duvarlara çarpınca yön değiştir
                if (top.Konum.X <= 0 || top.Konum.X + top.Cap >= pnlOyunAlani.Width)
                    top.HizX *= -1;

                // Üst duvara çarpınca yön değiştir
                if (top.Konum.Y <= 0)
                    top.HizY *= -1;

                // Platforma çarpma kontrolü - Top aşağıya doğru gidiyorsa kontrol et
                Rectangle topAlan = top.Alan;
                Rectangle platformAlan = platform.Alan;
                
                if (top.HizY > 0 && // Sadece aşağı giderken kontrol et
                    topAlan.IntersectsWith(platformAlan) &&
                    eskiKonum.Y + top.Cap <= platform.Konum.Y) // Top platformun üstündeydi
                {
                    // Yukarı sektir
                    top.HizY = -Math.Abs(top.HizY);
                    
                    // Topun platforma çarptığı konuma bağlı olarak X yönünü değiştir
                    int topMerkezi = top.Konum.X + (top.Cap / 2);
                    int platformMerkezi = platform.Konum.X + (platform.Genislik / 2);
                    
                    // Platformun soluna çarparsa sola, sağına çarparsa sağa gitsin
                    if (topMerkezi < platformMerkezi)
                        top.HizX = -5; // Sola git
                    else if (topMerkezi > platformMerkezi)
                        top.HizX = 5;  // Sağa git
                    else
                        top.HizX = 0;  // Ortaya çarparsa düz gitsin
                    
                    skor += 10;
                    lblDurum.Text = "Skor: " + skor;
                }

                // Aşağı düşerse oyun biter
                if (top.Konum.Y >= pnlOyunAlani.Height)
                {
                    timer1.Stop();
                    klavyeTimer.Stop(); // Klavye timerını da durdur
                    lblDurum.Text = "Oyun Bitti! Skor: " + skor + " - OYUN BİTTİ!!";
                    SkoruKaydet(skor);
                }

                pnlOyunAlani.Invalidate();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("Oyun sırasında hata oluştu: " + ex.Message);
            }
        }

        private void pnlOyunAlani_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            // Oyun alanı arka planı
            g.Clear(Color.Black);
            
            // Kenar çizgileri
            g.DrawRectangle(Pens.White, 0, 0, pnlOyunAlani.Width - 1, pnlOyunAlani.Height - 1);

            if (top != null)
            {
                // Topun daha güzel görünmesi için iç içe daireler çizelim
                g.FillEllipse(Brushes.Red, top.Alan);
                
                // Parlama efekti
                Rectangle parlamaAlan = new Rectangle(top.Konum.X + 5, top.Konum.Y + 5, top.Cap - 10, top.Cap - 10);
                g.FillEllipse(Brushes.White, parlamaAlan);
            }

            if (platform != null)
            {
                // Platformu daha güzel çiz (3D efekti)
                g.FillRectangle(Brushes.Blue, platform.Alan);
                
                // Platform üst çizgisi (daha açık renk)
                g.DrawLine(Pens.LightBlue, platform.Konum.X, platform.Konum.Y, 
                          platform.Konum.X + platform.Genislik, platform.Konum.Y);
                
                // Kenarlık
                g.DrawRectangle(Pens.DarkBlue, platform.Alan);
            }
        }

        private void FormZiplayanTop_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    solTusuBasili = true;
                    break;
                case Keys.Right:
                case Keys.D:
                    sagTusuBasili = true;
                    break;
            }
            e.Handled = true;
        }

        private void FormZiplayanTop_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    solTusuBasili = false;
                    break;
                case Keys.Right:
                case Keys.D:
                    sagTusuBasili = false;
                    break;
            }
            e.Handled = true;
        }

        private void KlavyeTimer_Tick(object sender, EventArgs e)
        {
            if (platform == null) return;
            
            int hareketMiktari = 10; // Daha hızlı hareket
            bool hareketVar = false;
            
            if (solTusuBasili && platform.Konum.X > 0)
            {
                platform.Konum = new Point(Math.Max(0, platform.Konum.X - hareketMiktari), platform.Konum.Y);
                hareketVar = true;
            }
            
            if (sagTusuBasili && platform.Konum.X + platform.Genislik < pnlOyunAlani.Width)
            {
                platform.Konum = new Point(Math.Min(pnlOyunAlani.Width - platform.Genislik, platform.Konum.X + hareketMiktari), platform.Konum.Y);
                hareketVar = true;
            }
            
            if (hareketVar)
            {
                pnlOyunAlani.Invalidate();
            }
        }

        void SkoruKaydet(int skor)
        {
            try
            {
                SqlCommand cmdID = new SqlCommand("SELECT OyunID FROM Oyunlar WHERE OyunAdi = @ad", bgl.baglanti());
                cmdID.Parameters.AddWithValue("@ad", "Zıplayan Top Oyunu");
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
