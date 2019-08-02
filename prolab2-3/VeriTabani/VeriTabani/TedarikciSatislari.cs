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
namespace VeriTabani
{
    public partial class TedarikciSatislari : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TedarikciSatislari()
        {
            InitializeComponent();
        }

        private void TedarikciSatislari_Load(object sender, EventArgs e)
        {
            tedarikcileriGetir();
            for (int i = 0; i < tedarikciler.Count; i++)
            {
                combo_tedarikci.Items.Add(tedarikciler[i]);
            }

        }

        List<String> tedarikciler = new List<String>();

        public void tedarikcileriGetir()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            string sorgu = "SELECT DISTINCT (select firmaAdi from TBL_TEDARIKCI where id =  tedarikciId) as 'Firma Adı' FROM TBL_URETICI_TEDARIKCI";
            komut.CommandText = sorgu;


            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                tedarikciler.Add(dr["Firma Adı"].ToString());
            }


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void tedarikcininSatislariniGetir(string ad)
        {

            komut.Parameters.Clear();

            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "SELECT (select firmaAdi from TBL_URETICI where id = ureticiId) as 'Üretici adı',	(select hammaddeAdi from TBL_HAMMADDELER where id = hammaddeId) as 'Hammadde adı',	alisFiyati as 'Satış fiyatı',adet as Adet,kargoAdi as 'Kargo tipi',kargoUcreti as 'Kargo ücreti',toplamMaliyet as 'Toplam maliyet' FROM TBL_URETICI_TEDARIKCI where tedarikciId = (select id from TBL_TEDARIKCI where firmaAdi like '%"+combo_tedarikci.SelectedItem.ToString()+"%')";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            //dataGridView1.Columns[0].Width = 100;
            //dataGridView1.Columns[1].Width = 140;
            //dataGridView1.Columns[2].Width = 130;
            //dataGridView1.Columns[3].Width = 100;
            //dataGridView1.Columns[4].Width = 100;
            //dataGridView1.Columns[5].Width = 100;
        }
        
        private void combo_uretici_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            tedarikcininSatislariniGetir(combo_tedarikci.SelectedItem.ToString());
        }

      

        
    }
}
