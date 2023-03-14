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
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(ucret) as _toplamGelir from Musteri", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                LblGelir.Text = reader["_toplamGelir"].ToString();
            }
            baglanti.Close();

            // gida toplami
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Maaliyeti) as _giderler from Giderler", baglanti);
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                LblDigerGiderler.Text = reader2["_giderler"].ToString();
            }
            baglanti.Close();

            // fatura toplamı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(Maas) as topPersonelGideri from Personeller", baglanti);
            SqlDataReader reader3 = komut3.ExecuteReader();
            while (reader3.Read())
            {
                LblPersonelGideri.Text = reader3["topPersonelGideri"].ToString();
            }
            baglanti.Close();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Close();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sonuc = Convert.ToInt32(LblGelir.Text) - Convert.ToInt32(LblPersonelGideri.Text) - Convert.ToInt32(LblDigerGiderler.Text);
            LblSonuc.Text = sonuc.ToString();
        }

        
    }
}
