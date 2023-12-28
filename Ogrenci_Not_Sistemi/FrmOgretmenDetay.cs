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

namespace Ogrenci_Not_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet3.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet3.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBLDERS (OgrNumara,OgrAd,OgrSoyAd) values (@p1,@p2,@p3)",bgl);
            komut1.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut1.Parameters.AddWithValue("@p2", textBox1.Text);
            komut1.Parameters.AddWithValue("@p3", textBox2.Text);
            komut1.ExecuteNonQuery(); //Sorguyu Çalıştır, Sorguyu Gerçekleştir Anlamında.   
            bgl.Close();
            MessageBox.Show("Öğrenci başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet3.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //Okunuşu Datagridwivew'in seçilen hücreleri içerisinde seçtiğim 0 hücreye göre satır indexini al. 
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); // Okunuşu = Datagrid'in satırları içerisinde seçilen satırın hücreleri içerisinde 4 değeri string olarak yazdır.
            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double s1, s2, s3, ortalama;
            string durum;
            s1 = Convert.ToDouble(textBox5.Text);
            s2 = Convert.ToDouble(textBox4.Text);
            s3 = Convert.ToDouble(textBox3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            label8.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE TBLDERS SET OgrS1=@P1, OgrS2=@P2, OgrS3=@P3, Ortalama=@P4,Durum=@P5 WHERE OgrNumara=@P6", bgl);
            komut2.Parameters.AddWithValue("@P1", textBox5.Text);
            komut2.Parameters.AddWithValue("@P2", textBox4.Text);
            komut2.Parameters.AddWithValue("@P3", textBox3.Text);
            komut2.Parameters.AddWithValue("@P4",decimal.Parse (label8.Text));
            komut2.Parameters.AddWithValue("@P5",durum);
            komut2.Parameters.AddWithValue("@P6", maskedTextBox1.Text);
            komut2.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Öğrenci başarılı bir şekilde Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet3.TBLDERS);
        }

        
    }
}
