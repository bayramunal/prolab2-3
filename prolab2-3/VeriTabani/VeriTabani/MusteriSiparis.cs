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
    public partial class MusteriSiparis : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public MusteriSiparis()
        {
            InitializeComponent();
        }

        private void MusteriSiparis_Load(object sender, EventArgs e)
        {
            musterileriGetir();
            kimyasalUrunleriGetir("");
        }

        public void musterileriGetir()
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

            komut.CommandText = "SELECT musteriAdi FROM TBL_MUSTERILER";

            SqlDataReader dr = komut.ExecuteReader();

            List<String> musteriler = new List<String>();

            while (dr.Read())
            {
                musteriler.Add(dr["musteriAdi"].ToString());
            }


            for (int i = 0; i < musteriler.Count; i++)
            {
                combo_musteriler.Items.Add(musteriler[i]);
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

        public void kimyasalUrunleriGetir(string ara)
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
            komut.CommandType = CommandType.StoredProcedure;

            komut.CommandText = "KIMYASAL_URUNLERI_LISTELE";

            komut.Parameters.AddWithValue("@kimyasalMaddeAdi", ara);

            komut.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView2.Columns[0].Width = dataGridView2.Width / 3;
            dataGridView2.Columns[1].Width = dataGridView2.Width / 3;
            dataGridView2.Columns[2].Width = dataGridView2.Width / 3;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kimyasalUrunleriGetir(txt_ara.Text.Trim().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(System.DateTime.Today.Day.ToString() + " " + System.DateTime.Today.Month.ToString() + " " + System.DateTime.Today.Year.ToString());

            if (combo_musteriler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

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
            komut.CommandType = CommandType.StoredProcedure;

            komut.CommandText = "MUSTERI_KIMYASALURUN_SIPARIS";
            komut.Parameters.AddWithValue("@bilesikFormulu", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Bileşik Formülü"].Value.ToString());
            komut.Parameters.AddWithValue("@musteriAdi", combo_musteriler.SelectedItem.ToString());
            komut.Parameters.AddWithValue("firmaAdi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Üretici Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@miktar", Convert.ToInt32(txt_adet.Text.Trim()));
           // komut.Parameters.AddWithValue("@uretimTarihi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Üretim tarihi"].Value.ToString());

            komut.ExecuteNonQuery();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Sipariş oluşturuldu", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txt_adet_TextChanged(object sender, EventArgs e)
        {
            int adet;

            if (txt_adet.Text == "")
            {
                adet = 0;
            }
            else
            {
                int a;
                if (int.TryParse(txt_adet.Text.Trim(), out a))
                {
                    adet = Convert.ToInt32(txt_adet.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Yalnızca sayısal değerler kabul edilebilir", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adet = 0;
                }

            }
            
           

        }
    }
}
