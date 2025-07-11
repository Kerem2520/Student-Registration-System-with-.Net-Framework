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
using System.Web;

namespace NotKayitUygulama
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

      
       
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KEREM\SQLEXPRESS;Initial Catalog=DBNotKayit;Integrated Security=True");

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNotKayitDataSet.TblDers' table. You can move, or remove it, as needed.
            this.tblDersTableAdapter.Fill(this.dBNotKayitDataSet.TblDers);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into TblDers (OgrNumara, OgrAd, OgrSoyad) values (@P1,@P2,@P3)", baglanti);
            cmd.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@P2", textBox_ad.Text);
            cmd.Parameters.AddWithValue("@P3", textBox_soyad.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tblDersTableAdapter.Fill(this.dBNotKayitDataSet.TblDers);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox_ad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox_soyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txt_Sinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_sinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_sinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txt_Sinav1.Text);
            s2 = Convert.ToDouble(txt_sinav2.Text);
            s3 = Convert.ToDouble(txt_sinav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lbl_sinif_ortalamasi.Text = ortalama.ToString();

            if (ortalama >= 60)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update TblDers set OgrS1=@P1, OgrS2=@P2, OgrS3 = @P3 , Ortalama = @P4, Durum = @P5 " +
                "where OgrNumara = @P6", baglanti);

            cmd.Parameters.AddWithValue("@P1", txt_Sinav1.Text);
            cmd.Parameters.AddWithValue("@P2", txt_sinav2.Text);
            cmd.Parameters.AddWithValue("@P3", txt_sinav3.Text);
            cmd.Parameters.AddWithValue("@P4", decimal.Parse(lbl_sinif_ortalamasi.Text));
            cmd.Parameters.AddWithValue("@P5", durum);
            cmd.Parameters.AddWithValue("@P6", maskedTextBox1.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Notları Güncellendi");
           

            this.tblDersTableAdapter.Fill(this.dBNotKayitDataSet.TblDers);
            baglanti.Close();


        }
    }
}
