using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmOnayKodu : Form
    {
        public FrmOnayKodu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtOnayKodu.Text == FrmAdminGiris.onayKodu)
            {
                MessageBox.Show("Giriş Başarılı");
                FrmSifreDegistirme fr = new FrmSifreDegistirme();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kod Girişi");
            }
        }
       
    }
}
