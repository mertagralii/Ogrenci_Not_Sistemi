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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection bgl = new SqlConnection(@"Data Source=Mert;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblOgrenciNumarasi.Text = numara;
            bgl.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLDERS WHERE OgrNumara=@P1", bgl);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataReader dr = komut.ExecuteReader(); // Komut Okuyucu
            while (dr.Read()) // DR KOMUTU OKUMA İŞLEMİ YAPTIĞI SÜRECE (Kısaca anlayacağın şekilde burdan geliyorda bilgiler nasıl diğerlerine aktarıyoruz diye sorduğunda bu senin sorgunu okudu bilgileri kaydetti bir yere sende şimdi yerleştiriceksin)
            {
                LblAdSoyad.Text = dr[2].ToString() + "" + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();

            }
            bgl.Close();
        }
    }
}
