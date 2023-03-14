using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmBilgilerimiGuncelle : Form
    {
        public FrmBilgilerimiGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");


        string _ePosta;
        string _sifre;
        string onayKodu;
        
        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Admin", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                _ePosta = oku["EPosta"].ToString();
                _sifre = oku["Sifre"].ToString();

            }
            if (_ePosta.Trim() == TxtEPosta.Text && _sifre.Trim() == TxtSifre.Text)
            {
                MessageBox.Show("E-Posta ve Şifrenizi Güncelleyebilirsiniz.","Onaylandı");
                TxtEPosta.Enabled = false;
                TxtSifre.Enabled = false;
                BtnOnayla.Enabled = false;
                TxtEPosta2.Enabled = true;
                TxtSifre2.Enabled = true;
                BtnOnayKoduGonder.Enabled = true;
                               
            }
            else
            {
                MessageBox.Show("E-Posta Ve Şifreniz Hatalı, Tekrar Deneyiniz.", "Hata!");
            }
            baglanti.Close();
        }
        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            if (TxtOnayKodu.Text == onayKodu)
            {
                sifreVeEPostaGuncelle();
            }
            else
            {
                MessageBox.Show("Hatalı Kod Girişi", "Hata!");
            }

        }
        void mailGonder(string baslik, string govde, string kime)
        {
            try
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress("dadlunurmsp53@gmail.com");
                ePosta.To.Add(kime);
                ePosta.Subject = baslik;
                ePosta.Body = govde;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("dadlunurmsp53@gmail.com", "szgdfucrzqitxglx");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                smtp.SendAsync(ePosta, (object)ePosta);
                MessageBox.Show("EPostanıza Onay Kodu Gönderildi.");
                TxtEPosta2.Enabled = false;
                TxtSifre2.Enabled = false;
                TxtOnayKodu.Enabled = true;
                BtnGuncelle.Enabled = true;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Mail Hatası!");
            }

        }



        void sifreVeEPostaGuncelle()
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Admin set EPosta ='" + TxtEPosta2.Text + "',Sifre='" + TxtSifre2.Text + "' where ID='" + 1 + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bilgileriniz Güncellendi.");
                FrmAnaForm anaform= new FrmAnaForm();
                anaform.ShowDialog();
                this.Hide();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
            
        }

        private void BtnKoduOnayla_Click(object sender, EventArgs e)
        {
        }

        private void BtnOnayKoduGonder_Click(object sender, EventArgs e)
        {
            onayKodu = FrmAdminGiris.kodOlustur(100000, 999999).ToString();
            mailGonder("Guvenlik Kodu", $"Kod: {onayKodu}", TxtEPosta2.Text);
            

            
        }

       
        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
    }
}
