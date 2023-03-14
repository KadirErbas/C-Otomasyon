using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_Otomasyonu
{
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }

        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sqlCommand = new SqlCommand("select * from Odalar where OdaID>0", baglanti);
            SqlDataReader oku = sqlCommand.ExecuteReader();

            string odaNo;
            while (oku.Read())
            {

                odaNo = oku["OdaNo"].ToString();
                if (odaNo == "101")
                {
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
                else if (odaNo == "105")
                {
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
            verileriGoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Odalar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["OdaID"].ToString();
                liste.SubItems.Add(oku["MusteriAdi"].ToString());
                liste.SubItems.Add(oku["MusteriSoyadi"].ToString());
                liste.SubItems.Add(oku["MusteriGirisTarihi"].ToString());
                liste.SubItems.Add(oku["MusteriCikisTarihi"].ToString());
                liste.SubItems.Add(oku["OdaNo"].ToString());

                DateTime _girisTarihi = Convert.ToDateTime(oku["MusteriGirisTarihi"].ToString());
                DateTime _cikisTarihi = Convert.ToDateTime(oku["MusteriCikisTarihi"].ToString());
                TimeSpan _gunSayisi = _cikisTarihi - _girisTarihi;
                int ucret = Convert.ToInt32(_gunSayisi.TotalDays.ToString());
                liste.SubItems.Add( ucret.ToString());
                
                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
    }
    
}
