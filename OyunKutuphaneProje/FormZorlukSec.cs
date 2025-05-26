using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunKutuphaneProje
{
    public partial class FormZorlukSec: Form
    {
        public string kullaniciAdi;
        public FormZorlukSec()
        {
            InitializeComponent();
        }

        private void btnKolay_Click(object sender, EventArgs e)
        {
            FormYilanOyun frm = new FormYilanOyun();
            frm.zorlukSeviyesi = new Kolay();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
            this.Close();
        }

        private void btnOrta_Click(object sender, EventArgs e)
        {
            FormYilanOyun frm = new FormYilanOyun();
            frm.zorlukSeviyesi = new Orta();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
            this.Close();
        }

        private void btnZor_Click(object sender, EventArgs e)
        {

            FormYilanOyun frm = new FormYilanOyun();
            frm.zorlukSeviyesi = new Zor();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
            this.Close();
        }

        private void FormZorlukSec_Load(object sender, EventArgs e)
        {

        }
    }
}
