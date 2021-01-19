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

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut7=new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut7.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut7.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut7.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr=new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali Giris");
            }
        }
    }
}
