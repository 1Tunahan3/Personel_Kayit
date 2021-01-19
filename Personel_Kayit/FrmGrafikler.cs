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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1=new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg22 = new SqlCommand("Selcet PerMeslek,Avg(Permaas) From Tbl_Personel Group By PerMeslek", baglanti);
            SqlDataReader rd = komutg1.ExecuteReader();
            while (rd.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(rd[0], rd[1]);
            }
            baglanti.Close();
        }
    }
}
