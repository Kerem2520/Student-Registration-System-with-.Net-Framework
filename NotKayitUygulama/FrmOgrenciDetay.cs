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

namespace NotKayitUygulama
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Sınav4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM\SQLEXPRESS;Initial Catalog=DBNotKayit;Integrated Security=True");

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lbl_numara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblDers where OgrNumara=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbl_AdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lbl_sinav1.Text = dr[4].ToString();
                lbl_sinav2.Text = dr[5].ToString();
                lbl_sinav3.Text = dr[6].ToString();
                lbl_ortalama.Text = dr[7].ToString();
                lbl_durum.Text = dr[8].ToString();

            }
            baglanti.Close();
        }
    }
}
