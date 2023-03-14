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
using System.Data.Sql;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmMusteriEkle : Form
    {
        public FrmMusteriEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void FrmMusteriEkle_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sqlCommand = new SqlCommand("select * from Odalar where OdaID>0", baglanti);
            SqlDataReader oku = sqlCommand.ExecuteReader();
            
            string odaNo;
            while (oku.Read())
            {
                
                odaNo = oku["OdaNo"].ToString();
                if (odaNo == "101") {
                    BtnOda101.BackColor = Color.Red;
                    BtnOda101.Enabled = false;
                }
                else if (odaNo == "102")
                {
                    BtnOda102.BackColor = Color.Red;
                    BtnOda102.Enabled = false;

                }
                else if (odaNo == "103")
                {
                    BtnOda103.BackColor = Color.Red;
                    BtnOda103.Enabled = false;
                }
                else if (odaNo == "104")
                {
                    BtnOda104.BackColor = Color.Red;
                    BtnOda104.Enabled = false;
                }
                else if (odaNo == "105") {
                    BtnOda105.BackColor = Color.Red;
                    BtnOda105.Enabled = false;
                }
                else if (odaNo == "106")
                {
                    BtnOda106.BackColor = Color.Red;
                    BtnOda106.Enabled = false;
                }
                
            }
            baglanti.Close();
            
           
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Müşteri kaydedilince Musteri adlı veritabanına değerleri ekleme
                baglanti.Open();
                SqlCommand akomut = new SqlCommand("insert into Musteri (Adi, Soyadi, Cinsiyet, Telefon, Mail, TC, OdaNo, Ucret, GirisTarihi, CikisTarihi) values('" + TxtAdi.Text + "','" + TxtSoyadi.Text + "','" + CmbCinsiyet.Text + "','" + MskTxtTelefon.Text + "','" + TxtMail.Text + "','" + MskTxtTC.Text + "','" + TxtOdaNo.Text + "','" + TxtUcret.Text + "','" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "','" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "')", baglanti);
                akomut.ExecuteNonQuery();
                baglanti.Close();

                // Müşteri kaydedilince Odalar adlı veritabanına değerleri ekleme
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("insert into Odalar(OdaNo , OdaKullanimdaMi, MusteriAdi, MusteriSoyadi, MusteriGirisTarihi, MusteriCikisTarihi) values ('" + TxtOdaNo.Text + "','" + true + "','" + TxtAdi.Text + "','" + TxtSoyadi.Text + "','" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "','" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "')", baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Müşteri Kaydı Yapıldı.");
            }
            catch (Exception)
            {
                MessageBox.Show("Verileri doğru bir şekilde giriniz", "Hata!");
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "101";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "102";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "103";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "104";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "105";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "106";
        }
       

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Yeşil renkli odalar \"boş\" odaları gösterir.");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Kırmızı renkli odalar \"dolu\" odaları gösterir.");

        }

        private void DtpCikisTarihi_ValueChanged_1(object sender, EventArgs e)
        {
            int _gunBasiUcret = 200;

            DateTime _girisTarihi = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime _cikisTarihi = Convert.ToDateTime(DtpCikisTarihi.Text);
            TimeSpan _gunSayisi = _cikisTarihi - _girisTarihi;
            
            int ucret = Convert.ToInt32(_gunSayisi.TotalDays.ToString()) * _gunBasiUcret;
            TxtUcret.Text = ucret.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Close();
        }
    }
}
