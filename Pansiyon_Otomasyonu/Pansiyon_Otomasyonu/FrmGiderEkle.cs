using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmGiderEkle : Form
    {
        public FrmGiderEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Giderler(GiderTuru,Maaliyeti,Tarihi) values ('" + CmbGiderTürü.Text + "','" + TxtMaaliyeti.Text + "','" + date.ToString("yyyy-MM-dd") + "' )", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                VerileriGoster();
            }
            catch(System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Maaliyete sayı girmelisiniz!","Uyarı!");
            }
            
        }
        private void VerileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Giderler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["GiderTuru"].ToString();
                liste.SubItems.Add(oku["Maaliyeti"].ToString());
                liste.SubItems.Add(oku["Tarihi"].ToString());
                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }

        private void FrmGiderEkle_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
    }
}
