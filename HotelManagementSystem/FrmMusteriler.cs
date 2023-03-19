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

using System.IO;
using System.Threading;

namespace HotelManagementSystem
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7H6MHAK\\SQLEXPRESS;Initial Catalog=HotelSaturn;Integrated Security=True");

        //SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "HotelSaturn.mdf;Integrated Security=True");
        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();

        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutx = new SqlCommand("update MusteriEkle set Adi='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "',Cinsiyet='" + comboBox1.Text + "',Telefon='" + MskdTxtTelefon.Text + "',TC='" + TxtKimlikNo.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "'where MusteriId=" + id + "", baglanti);
            komutx.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskdTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtKimlikNo.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtUcret.Text = listView1.SelectedItems[0].SubItems[7].Text;
            DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[8].Text;
            DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from MusteriEkle where MusteriId= (" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            comboBox1.Text = "";
            MskdTxtTelefon.Clear();
            TxtKimlikNo.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            DtpCikisTarihi.Text = "";
            DtpGirisTarihi.Text = "";
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from MusteriEkle where Adi like '%" + textBox1.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriId"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }


        private void Btn_BilgileriGoster_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void Btn_Guncelle_Click_1(object sender, EventArgs e)
        {
            try
            {
                // müşteri veri tablosundan gunceller
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update MusteriEkle set Adi='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "' ,Cinsiyet= '" + comboBox1.Text + "',Telefon='" + MskdTxtTelefon.Text + "',TC='" + TxtKimlikNo.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "' where MusteriId=" + id + "", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verileriGoster();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }
        private void verileriOku()
        {
            //Veritabanından verileri oku
            //Verileri "Odalar" formunda göster
        }
        private void BtnSil_Click_1(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from MusteriEkle where MusteriId= (" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriOku(); //Verileri Güncelle

            if (TxtOdaNo.Text == "101")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda101", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle

            }
            if (TxtOdaNo.Text == "102")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda102", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle

            }
            if (TxtOdaNo.Text == "103")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda103", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle

            }
            if (TxtOdaNo.Text == "104")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda104", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "105")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda105", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "106")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda106", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "107")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda107", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "108")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda108", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "201")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda201", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "202")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda202", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "203")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda203", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "204")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda204", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "205")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda205", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "206")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda206", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "207")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda207", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "208")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda208", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "301")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda301", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "302")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda302", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "303")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda303", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "304")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda304", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "305")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda305", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "306")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda306", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "307")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda307", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "308")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda308", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "401")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda401", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "402")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda402", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "403")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda403", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "404")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda404", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "405")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda405", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "405")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda405", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "406")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda406", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "407")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda407", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
            if (TxtOdaNo.Text == "408")
            {
                baglanti.Open();
                SqlCommand komutx = new SqlCommand("delete from Oda408", baglanti);
                komutx.ExecuteNonQuery();
                baglanti.Close();
                verileriOku(); //Verileri Güncelle
            }
        }


        /*  private void BtnSil_Click_1(object sender, EventArgs e)
          {
              try
              {
                  baglanti.Open();
                  SqlCommand komut = new SqlCommand("delete from MusteriEkle where MusteriId= @id", baglanti);
                  komut.Parameters.Add("@id", SqlDbType.Int).Value = id;
                  komut.ExecuteNonQuery();
                  verileriOku(); //Verileri Güncelle
              }
              catch (SqlException ex)
              {
                  MessageBox.Show("Error: " + ex.Message);
              }
              finally
              {
                  baglanti.Close();
              }

          }*/


        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            comboBox1.Text = "";
            MskdTxtTelefon.Clear();
            TxtKimlikNo.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            DtpCikisTarihi.Text = "";
            DtpGirisTarihi.Text = "";


        }

        private void label11_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }

        private void BtnYazdir_Click_1(object sender, EventArgs e)
        {
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

