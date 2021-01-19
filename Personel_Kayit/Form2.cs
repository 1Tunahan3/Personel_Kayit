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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private SqlConnection baglanti =
            new SqlConnection(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        
        private void Form2_Load(object sender, EventArgs e)
        {  // Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1=new SqlCommand("Select Count (*) From Tbl_Personel",baglanti);
            SqlDataReader rd1 = komut1.ExecuteReader();
            while (rd1.Read())
            {
                lblToplamPersonel.Text = rd1[0].ToString();
            }
            baglanti.Close();
            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2=new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3=new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4=new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //Toplam Maas
            baglanti.Open();
            SqlCommand komut5=new SqlCommand("Select Sum(PerMaas) From Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6=new SqlCommand("Select Avg(PerMaas) From Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
