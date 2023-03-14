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

namespace Pansiyon_Otomasyonu
{
    public partial class FrmPersonelEkle : Form
    {
        public FrmPersonelEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void FrmPersonelEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Personeller (Ad, Soyad, Cinsiyet, Telefon, Mail, TC, Departman, Maas) values('" + TxtAdi.Text + "','" + TxtSoyadi.Text + "','" + CmbCinsiyet.Text + "','" + MskTxtTelefon.Text + "','" + TxtMail.Text + "','" + MskTxtTC.Text + "','" + CmbDepartman.Text + "','" + TxtMaas.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Personel kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Verileri doğru bir şekilde giriniz!","Hata!");
            }
            

        }

        

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
    }
}
