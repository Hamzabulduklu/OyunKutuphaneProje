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
    
    public partial class FormAdmin: Form
    {
        SqlBaglanti bgl = new SqlBaglanti();

        public FormAdmin()
        {
            InitializeComponent();
        }
        private void KullaniciListele()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT K.ID, K.KullaniciAdi, K.Sifre, Y.YetkiAdi
        FROM Kullanici K
        JOIN Yetkiler Y ON K.YetkiID = Y.YetkiID", bgl.baglanti());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKullanicilar.DataSource = dt;
        }
        private void YetkileriYukle()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Yetkiler", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbYetki.Items.Add(new
                {
                    Text = dr["YetkiAdi"].ToString(),
                    Value = dr["YetkiID"]
                });
            }

            cmbYetki.DisplayMember = "Text";
            cmbYetki.ValueMember = "Value";
            bgl.baglanti().Close();
        }

        private void OyunlariYukle()
        {
            cmbOyunSec.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Oyunlar", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbOyunSec.Items.Add(new
                {
                    Text = dr["OyunAdi"].ToString(),
                    Value = dr["OyunID"]
                });
            }

            cmbOyunSec.DisplayMember = "Text";
            cmbOyunSec.ValueMember = "Value";
            bgl.baglanti().Close();
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            dgvKullanicilar.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvKullanicilar.RowTemplate.Height = 30;

            dgvSkorlar.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvSkorlar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvSkorlar.RowTemplate.Height = 30;

            OyunlariYukle();
            KullaniciListele();
            YetkileriYukle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKullanicilar.Rows[e.RowIndex];

                txtAd.Text = row.Cells["KullaniciAdi"].Value.ToString();
                txtSifre.Text = row.Cells["Sifre"].Value.ToString();
                cmbYetki.Text = row.Cells["YetkiAdi"].Value.ToString();
            }
        
        }

        private void cmbOyunSec_SelectedIndexChanged(object sender, EventArgs e)
        {

            int oyunID = (cmbOyunSec.SelectedItem as dynamic).Value;

            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT TOP 10 KullaniciAdi, Skor, Tarih
        FROM Skorlar
        WHERE OyunID = @oid
        ORDER BY Skor DESC", bgl.baglanti());

            da.SelectCommand.Parameters.AddWithValue("@oid", oyunID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSkorlar.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            int yetkiID = (cmbYetki.SelectedItem as dynamic).Value;

            SqlCommand cmd = new SqlCommand("INSERT INTO Kullanici (KullaniciAdi, Sifre, YetkiID) VALUES (@ad, @sifre, @yetki)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
            cmd.Parameters.AddWithValue("@yetki", yetkiID);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Kullanıcı eklendi.");
            KullaniciListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);
                SqlCommand cmd = new SqlCommand("DELETE FROM Kullanici WHERE KullaniciID = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Kullanıcı silindi.");
                KullaniciListele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {


            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);
                int yetkiID = (cmbYetki.SelectedItem as dynamic).Value;

                SqlCommand cmd = new SqlCommand("UPDATE Kullanici SET KullaniciAdi = @ad, Sifre = @sifre, YetkiID = @yetki WHERE KullaniciID = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                cmd.Parameters.AddWithValue("@yetki", yetkiID);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Kullanıcı güncellendi.");
                KullaniciListele();
            }
        }
        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKullanicilar.Rows[e.RowIndex];
                txtAd.Text = row.Cells["KullaniciAdi"].Value.ToString();
                txtSifre.Text = row.Cells["Sifre"].Value.ToString();
                cmbYetki.Text = row.Cells["YetkiAdi"].Value.ToString(); // Görünüm için
            }
        }


    }
}
