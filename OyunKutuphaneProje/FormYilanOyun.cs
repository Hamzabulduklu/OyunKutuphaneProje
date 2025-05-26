using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OyunKutuphaneProje
{
    public partial class FormYilanOyun : Form
    {
        public Zorluk zorlukSeviyesi { get; set; } = new Orta();
        SqlBaglanti bgl = new SqlBaglanti();
        public string kullaniciAdi;

        List<YilanParcasi> yilan = new List<YilanParcasi>();
        Yon mevcutYon = Yon.Saga;
        Yon sonrakiYon = Yon.Saga; // Sonraki yönü tutmak için yeni değişken
        Yemek yemek = new Yemek();
        int skor = 0;
        bool oyunBasladi = false;

        public FormYilanOyun()
        {
            InitializeComponent();
            pnlOyunAlani.BackColor = Color.Black;
            pnlOyunAlani.Paint += pnlOyunAlani_Paint;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormYilanOyun_KeyDown);
            timer1.Tick += timer1_Tick;
            timer1.Interval = 200;
        }

        private void FormYilanOyun_Load(object sender, EventArgs e)
        {
            this.Focus();
            pnlOyunAlani.BackColor = Color.Black;
            pnlOyunAlani.Paint += pnlOyunAlani_Paint;
            this.ActiveControl = null;
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kullaniciAdi))
                kullaniciAdi = "test_user";

            yilan.Clear();
            skor = 0;
            lblSkor.Text = "Skor: 0";
            mevcutYon = Yon.Saga;
            sonrakiYon = Yon.Saga;
            oyunBasladi = true;
            
            int baslangicX = pnlOyunAlani.Width / 2;
            int baslangicY = pnlOyunAlani.Height / 2;
            yilan.Add(new YilanParcasi(baslangicX, baslangicY));
            
            yemek.YeniYemekUret(pnlOyunAlani.Width, pnlOyunAlani.Height);
            timer1.Start();
            pnlOyunAlani.Invalidate();
            this.ActiveControl = null;
            this.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!oyunBasladi) return;

            // Yön değişikliğini uygula
            mevcutYon = sonrakiYon;

            Point bas = yilan[0].Konum;
            Point yeniBas = bas;

            switch (mevcutYon)
            {
                case Yon.Saga: yeniBas.X += 20; break;
                case Yon.Sola: yeniBas.X -= 20; break;
                case Yon.Yukari: yeniBas.Y -= 20; break;
                case Yon.Asagi: yeniBas.Y += 20; break;
            }

            // Duvara çarpma kontrolü
            if (yeniBas.X < 0 || yeniBas.X >= pnlOyunAlani.Width || yeniBas.Y < 0 || yeniBas.Y >= pnlOyunAlani.Height)
            {
                OyunuBitir("Duvara çarptın!");
                return;
            }

            // Kendine çarpma kontrolü
            foreach (var parc in yilan)
            {
                if (parc.Konum == yeniBas)
                {
                    OyunuBitir("Kendine çarptın!");
                    return;
                }
            }

            yilan.Insert(0, new YilanParcasi(yeniBas.X, yeniBas.Y));

            // Yemeği yeme kontrolü - Daha hassas kontrol
            Rectangle yilanBas = new Rectangle(yeniBas.X, yeniBas.Y, 20, 20);
            Rectangle yemekAlan = new Rectangle(yemek.Konum.X, yemek.Konum.Y, 20, 20);

            if (yilanBas.IntersectsWith(yemekAlan))
            {
                skor += 10;
                lblSkor.Text = "Skor: " + skor;
                yemek.YeniYemekUret(pnlOyunAlani.Width, pnlOyunAlani.Height);
            }
            else
            {
                yilan.RemoveAt(yilan.Count - 1);
            }

            pnlOyunAlani.Invalidate();
        }

        private void FormYilanOyun_KeyDown(object sender, KeyEventArgs e)
        {
            if (!oyunBasladi) return;

            switch (e.KeyCode)
            {
                // Ok tuşları
                case Keys.Up:
                case Keys.W:
                    if (mevcutYon != Yon.Asagi)
                        sonrakiYon = Yon.Yukari;
                    break;
                case Keys.Down:
                case Keys.S:
                    if (mevcutYon != Yon.Yukari)
                        sonrakiYon = Yon.Asagi;
                    break;
                case Keys.Left:
                case Keys.A:
                    if (mevcutYon != Yon.Saga)
                        sonrakiYon = Yon.Sola;
                    break;
                case Keys.Right:
                case Keys.D:
                    if (mevcutYon != Yon.Sola)
                        sonrakiYon = Yon.Saga;
                    break;
            }
            e.Handled = true;
        }

        private void OyunuBitir(string mesaj)
        {
            timer1.Stop();
            oyunBasladi = false;
            SkoruKaydet(skor);
            MessageBox.Show(mesaj);
            lblSkor.Text += " - OYUN BİTTİ";
        }

        private void pnlOyunAlani_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            foreach (var parc in yilan)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(parc.Konum.X, parc.Konum.Y, 20, 20));
                g.DrawRectangle(Pens.DarkGreen, new Rectangle(parc.Konum.X, parc.Konum.Y, 20, 20));
            }

            g.FillEllipse(Brushes.Red, new Rectangle(yemek.Konum.X, yemek.Konum.Y, 20, 20));
            g.DrawEllipse(Pens.DarkRed, new Rectangle(yemek.Konum.X, yemek.Konum.Y, 20, 20));
        }

        void SkoruKaydet(int skor)
        {
            try
            {
                SqlCommand cmdID = new SqlCommand("SELECT OyunID FROM Oyunlar WHERE OyunAdi = @ad", bgl.baglanti());
                cmdID.Parameters.AddWithValue("@ad", "Yılan Oyunu");
                object sonuc = cmdID.ExecuteScalar();

                if (sonuc != null)
                {
                    int oyunID = Convert.ToInt32(sonuc);

                    SqlCommand komut = new SqlCommand("INSERT INTO Skorlar (KullaniciAdi, OyunID, Skor, Tarih) VALUES (@p1, @p2, @p3, @p4)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", kullaniciAdi);
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
