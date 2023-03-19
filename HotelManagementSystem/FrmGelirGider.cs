using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        //SqlConnection baglanti = new SqlConnection("Data =.\\SQLEXPRESS;Initial Catalog=HotelSaturn;Integrated Security=True");

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP - H6MHAK\\SQLEXPRESS; Initial Catalog = HotelSaturn; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
           //Kasa Tutarı İçin Deneme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Ucret) as toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            // Personel giderleri
            int personel;
            personel = Convert.ToInt32(textBox1.Text);
            LblPrsnlMaas.Text = (personel * 10000).ToString();

            int sonuc;
            sonuc = Convert.ToInt32(lblKasaToplam.Text) - (Convert.ToInt32(LblPrsnlMaas.Text) + Convert.ToInt32(LblAlinanUrun1.Text) + Convert.ToInt32(lblAlinanUrun2.Text) + Convert.ToInt32(lblAlinanUrun3.Text) + Convert.ToInt32(LblFaturalar.Text) + Convert.ToInt32(lblFaturalar2.Text) + Convert.ToInt32(lblFaturalar3.Text) + Convert.ToInt32(lblFaturalar4.Text));
            lblsonuc.Text = sonuc.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            
            //Gıdalar 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select sum(Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                LblAlinanUrun1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();

            //Meşrubatlar
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(Mesrubat) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblAlinanUrun2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();

            //Yan Ürünler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(YanUrunler) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblAlinanUrun3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            //elektrik
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                LblFaturalar.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();

            //Su
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select sum(Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblFaturalar2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();

            //Doğalgaz
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select sum(Dogalgaz) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblFaturalar3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();

            //İnternet
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("Select sum(Internet) as toplam7 from Faturalar", baglanti);
            SqlDataReader oku8 = komut8.ExecuteReader();
            while (oku8.Read())
            {
                lblFaturalar4.Text = oku8["toplam7"].ToString();
            }
            baglanti.Close();


        }

        private void label11_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }
    }
}
