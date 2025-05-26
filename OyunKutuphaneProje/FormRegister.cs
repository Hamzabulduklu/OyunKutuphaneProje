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
    public partial class FormRegister: Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("INSERT INTO Kullanici (KullaniciAdi, Sifre) VALUES (@p1, @p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtYeniKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtYeniSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarılı, giriş yapabilirsiniz.");
            FormLogin frm = new FormLogin();
            frm.Show();
            this.Hide();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
