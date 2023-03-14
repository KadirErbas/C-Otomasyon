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
using System.Data.SqlClient;
using System.Data.Sql;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmSifreDegistirme : Form
    {
        public FrmSifreDegistirme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtYeniSifre.Text != "" && TxtYeniSifre.Text == TxtYeniSifre2.Text)
            {
                sifreGuncelle();
                this.Hide();
                FrmAdminGiris fr = new FrmAdminGiris();
                fr.Show();

            }
            else
            {
                MessageBox.Show("Şifre Boş Bırakılamaz ve Şifreler Aynı Girilmelidir");
            }
        }
        void sifreGuncelle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Admin set Sifre='" + TxtYeniSifre.Text + "' where ID=" + 1 + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sifreniz Degisti.");
        }
    }
}
