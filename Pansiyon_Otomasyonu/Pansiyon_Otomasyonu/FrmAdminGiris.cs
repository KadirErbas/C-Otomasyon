using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");
        string _ePosta;
        string _sifre;
        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Başarılı Giriş");
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-Posta Ve Şifreniz Hatalı, Tekrar Deneyiniz.", "Hata!");
            }
            baglanti.Close();
        }

        public static string onayKodu;
        public static int kodOlustur(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
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

                FrmOnayKodu frm = new FrmOnayKodu();
                frm.Show();
                this.Hide();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Mail Hatası!");
            }

        }

        private void FrmAdminGiris_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            onayKodu = kodOlustur(100000, 999999).ToString();
            mailGonder("Guvenlik Kodu", $"Kod: {onayKodu}", TxtEPosta.Text);
        }

        private void BtnBilgi_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Admin epostası: kdrerbas_72@hotmail.com\nAdmin Sifresi: 123456\n\nEposta adresini kendi epostanız yapmak istiyorsanız şu adımları izleyin;\n1- Eposta kısmına kendi epostanızı yazın.\n2- Şifremi unuttuma tıklayın.\n3- Epostanıza gelen kodu onaylatın.","Bilgi!");
        }
    }
}
