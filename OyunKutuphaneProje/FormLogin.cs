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
    public partial class FormLogin: Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public FormLogin()
        {
            InitializeComponent();
        }


        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.Show();
            this.Hide();
        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(@"
        SELECT K.KullaniciAdi, K.ID, Y.YetkiAdi 
        FROM Kullanici K
        JOIN Yetkiler Y ON K.YetkiID = Y.YetkiID
        WHERE K.KullaniciAdi = @p1 AND K.Sifre = @p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text.Trim());
            komut.Parameters.AddWithValue("@p2", txtSifre.Text.Trim());

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string kullaniciAdi = dr["KullaniciAdi"].ToString();
                int kullaniciID = Convert.ToInt32(dr["ID"]);
                string yetki = dr["YetkiAdi"].ToString();

                MessageBox.Show("Giriş başarılı! Hoş geldin " + kullaniciAdi);

                if (yetki == "Admin")
                {
                    FormAdmin adminForm = new FormAdmin();
                    adminForm.Show();
                }
                else
                {
                    FormMain userForm = new FormMain();
                    userForm.kullaniciAdi = kullaniciAdi;
                    userForm.kullaniciID = kullaniciID;
                    userForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }

            bgl.baglanti().Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
