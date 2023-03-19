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
    public partial class FrmSifreGuncelle : Form
    {
        public FrmSifreGuncelle()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7H6MHAK\\SQLEXPRESS;Initial Catalog=HotelSaturn;Integrated Security=True");

        //SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "HotelSaturn.mdf;Integrated Security=True");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                // müşteri veri tablosundan gunceller
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Giris set Kullanici='" + TxtKullaniciAdi.Text + "',Sifre='" + txtSifre.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Başarılı!");
                FrmGiris fr = new FrmGiris();
                fr.Show();
                this.Hide();
                baglanti.Close();
                

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void FrmSifreGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frm_anaSayfa fr = new Frm_anaSayfa();
            fr.Show();
            this.Hide();
        }
    }
}
