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
    public partial class FormZorlukSecAdamAsmaca : Form
    {
        public string kullaniciAdi;
        public FormZorlukSecAdamAsmaca()
        {
            InitializeComponent();
        }

        private void btnKolay_Click(object sender, EventArgs e)
        {
            Baslat(new Kolay());
        }

        private void btnOrta_Click(object sender, EventArgs e)
        {
            Baslat(new Orta());
        }

        private void btnZor_Click(object sender, EventArgs e)
        {
            Baslat(new Zor());
        }

        void Baslat(Zorluk zorluk)
        {
            FormAdamAsmaca frm = new FormAdamAsmaca();
            frm.kullaniciAdi = kullaniciAdi;
            frm.zorlukSeviyesi = zorluk;
            frm.Show();
            this.Close();
        }
    }
}
