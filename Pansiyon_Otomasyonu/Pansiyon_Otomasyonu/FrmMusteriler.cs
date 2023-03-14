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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();

        }
     
        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Musteri where Adi like '%" + textBox6.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["MusteriID"].ToString();
                liste.SubItems.Add(oku["Adi"].ToString());
                liste.SubItems.Add(oku["Soyadi"].ToString());
                liste.SubItems.Add(oku["Cinsiyet"].ToString());
                liste.SubItems.Add(oku["Telefon"].ToString());
                liste.SubItems.Add(oku["Mail"].ToString());
                liste.SubItems.Add(oku["TC"].ToString());
                liste.SubItems.Add(oku["OdaNo"].ToString());
                liste.SubItems.Add(oku["Ucret"].ToString());
                liste.SubItems.Add(oku["GirisTarihi"].ToString());
                liste.SubItems.Add(oku["CikisTarihi"].ToString());
                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }
        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Musteri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["MusteriID"].ToString();
                liste.SubItems.Add(oku["Adi"].ToString());
                liste.SubItems.Add(oku["Soyadi"].ToString());
                liste.SubItems.Add(oku["Cinsiyet"].ToString());
                liste.SubItems.Add(oku["Telefon"].ToString());
                liste.SubItems.Add(oku["Mail"].ToString());
                liste.SubItems.Add(oku["TC"].ToString());
                liste.SubItems.Add(oku["OdaNo"].ToString());
                liste.SubItems.Add(oku["Ucret"].ToString());
                liste.SubItems.Add(oku["GirisTarihi"].ToString());
                liste.SubItems.Add(oku["CikisTarihi"].ToString());
                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // müsteri veri tabanını güncelleme
            baglanti.Open();           
            SqlCommand komut = new SqlCommand("update Musteri set Adi ='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "',Cinsiyet='" + CmbCinsiyet.Text + "',Telefon='" + MskTxtTelefon.Text + "',Mail='" + TxtMail.Text + "',TC='" + MskTxtTC.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "' where  MusteriID='" + id + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
           


            // Odalar veri tabanını güncelleme         
            baglanti.Open();
            SqlCommand komutt = new SqlCommand("update Odalar set OdaNo ='" + TxtOdaNo.Text + "',MusteriAdi='" + TxtAdi.Text  + "',MusteriSoyadi='" + TxtSoyadi.Text  + "',MusteriGirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "',MusteriCikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "' where  OdaNo='" + TxtOdaNo2.Text + "'", baglanti);
            komutt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler güncellendi");
            
            verileriGoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from Odalar where OdaNo=("+ TxtOdaNo2.Text +")", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("delete from Musteri where MusteriID=(" + id + ")", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Silindi");
            verileriGoster();
        }
        int id;

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            CmbCinsiyet.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            MskTxtTC.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtOdaNo2.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;
            DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm= new FrmAnaForm();
            frm.Show();
            this.Hide();
        }

        private void DtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int _gunBasiUcret = 100;

            DateTime _girisTarihi = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime _cikisTarihi = Convert.ToDateTime(DtpCikisTarihi.Text);

            TimeSpan _gunSayisi = _cikisTarihi - _girisTarihi;
         
            int ucret = Convert.ToInt32(_gunSayisi.TotalDays.ToString()) * _gunBasiUcret;
            TxtUcret.Text = ucret.ToString();
        }
    }
}
