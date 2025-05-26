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
    public partial class FormMain: Form
    {
        public string kullaniciAdi; // Giriş ekranından gelecek
        public int kullaniciID;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = $"Hoş geldin, {kullaniciAdi} (ID: {kullaniciID})";
        }

        private void btnYilan_Click(object sender, EventArgs e)
        {
            FormZorlukSec frm = new FormZorlukSec();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
        }

        private void btnKelime_Click(object sender, EventArgs e)
        {
            FormZorlukSecAdamAsmaca frm = new FormZorlukSecAdamAsmaca();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
        }

        private void btnLabirent_Click(object sender, EventArgs e)
        {
            FormZorlukSecLabirent frm = new FormZorlukSecLabirent();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
        }

        private void btnHafiza_Click(object sender, EventArgs e)
        {
            FormZorlukSecHafiza frm = new FormZorlukSecHafiza();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
        }

        private void btnZiplayanTop_Click(object sender, EventArgs e)
        {
            FormZorlukSecZiplayanTop frm = new FormZorlukSecZiplayanTop();
            frm.kullaniciAdi = kullaniciAdi;
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHosgeldin_Click(object sender, EventArgs e)
        {

        }
    }
}
