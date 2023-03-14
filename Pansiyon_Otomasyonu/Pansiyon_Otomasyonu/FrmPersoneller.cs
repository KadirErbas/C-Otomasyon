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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "PansiyonOtomasyonu.mdf;Integrated Security=True");

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Personeller", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["PersonelID"].ToString();
                liste.SubItems.Add(oku["Ad"].ToString());
                liste.SubItems.Add(oku["Soyad"].ToString());
                liste.SubItems.Add(oku["Cinsiyet"].ToString());
                liste.SubItems.Add(oku["Telefon"].ToString());
                liste.SubItems.Add(oku["Mail"].ToString());
                liste.SubItems.Add(oku["TC"].ToString());
                liste.SubItems.Add(oku["Departman"].ToString());
                liste.SubItems.Add(oku["Maas"].ToString());

                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Personeller set Ad ='" + TxtAdi.Text + "',Soyad='" + TxtSoyadi.Text + "',Cinsiyet='" + CmbCinsiyet.Text + "',Telefon='" + MskTxtTelefon.Text + "',Mail='" + TxtMail.Text + "',TC='" + MskTxtTC.Text + "',Departman='" + CmbDepartman.Text + "',Maas='" + TxtMaas.Text +  "' where  PersonelID='" + id + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personeller tabanından Veriler güncellendi");
            verileriGoster();
        }
        int id;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            CmbCinsiyet.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            MskTxtTC.Text = listView1.SelectedItems[0].SubItems[6].Text;
            CmbDepartman.Text = listView1.SelectedItems[0].SubItems[7].Text;           
            TxtMaas.Text = listView1.SelectedItems[0].SubItems[8].Text;         
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Personeller where PersonelID=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi");
            verileriGoster();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Personeller where Ad like '%" + textBox6.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem liste = new ListViewItem();
                liste.Text = oku["PersonelID"].ToString();
                liste.SubItems.Add(oku["Ad"].ToString());
                liste.SubItems.Add(oku["Soyad"].ToString());
                liste.SubItems.Add(oku["Cinsiyet"].ToString());
                liste.SubItems.Add(oku["Telefon"].ToString());
                liste.SubItems.Add(oku["Mail"].ToString());
                liste.SubItems.Add(oku["TC"].ToString());
                liste.SubItems.Add(oku["Departman"].ToString());
                liste.SubItems.Add(oku["Maas"].ToString());
                listView1.Items.Add(liste);
            }
            baglanti.Close();
        }
    }
}
