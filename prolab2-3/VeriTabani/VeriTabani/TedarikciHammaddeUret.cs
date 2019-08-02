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
    public partial class TedarikciHammaddeUret : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TedarikciHammaddeUret()
        {
            InitializeComponent();
        }

        private void TedarikciHammaddeUret_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            tedarikcileriGetir();
            hammaddeleriGetir();
        }

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
                    return;
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select firmaAdi  as 'Firma Adı',  sehirAdi  as Şehir,  ulkeAdi as Ülke from TBL_TEDARIKCI";
            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView2.DataSource = dt;


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView2.Columns[0].Width = 157;
            dataGridView2.Columns[1].Width = 160;
            dataGridView2.Columns[2].Width = 160;
        }

        public void hammaddeleriGetir()
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
                    return;
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "Select hammaddeAdi as 'Hammadde Adı' from TBL_HAMMADDELER";
            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Width = 165;
        }

        private void button2_Click(object sender, EventArgs e)
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
                    return;
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "TEDARIKCI_HAMMADDE_URET";

            komut.Parameters.AddWithValue("@hammaddeAdi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Hammadde Adı"].Value);
            komut.Parameters.AddWithValue("@tedarikciAdi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@tedarikciSehir", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString());
            komut.Parameters.AddWithValue("@uretilenAdet", txt_adet.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@uretimTarihi", txt_uretimTarihi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@satisFiyati", txt_satisFiyati.Text.Trim().ToString());

            komut.ExecuteNonQuery();

            Boolean kontrol = false;

            try
            {
                komut.Parameters.Clear();
                komut.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                kontrol = true;
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kontrol == false)
                MessageBox.Show("Hammadde " + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString() + " tedarikçisi tarafından " + txt_adet.Text.Trim().ToString() + " adet olarak üretildi", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                    return;
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "SELECT hammaddeAdi as 'Hammadde Adı' FROM TBL_HAMMADDELER WHERE hammaddeAdi LIKE '%" + txt_hammaddeAra.Text.Trim().ToString() + "%'";
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


            dataGridView1.Columns[0].Width = 165;


        }

        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
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

                if (rb_ad.Checked)
                {
                    komut.CommandText = "SELECT firmaAdi 'Firma Adı', (SELECT sehirAdi FROM TBL_SEHIRLER WHERE id = sehirId) as 'Şehir', (SELECT ulkeAdi FROM TBL_ULKELER WHERE id = (SELECT ulkeId FROM TBL_SEHIRLER WHERE id = sehirId)) as 'Ülke' FROM TBL_TEDARIKCI WHERE firmaId IN (SELECT id FROM TBL_TEDARIKCI_ISIMLERI WHERE firmaAdi LIKE '%" + txt_musteriAd.Text.Trim().ToString() + "%')";
                }

                if (rb_sehir.Checked)
                {
                    komut.CommandText = "SELECT firmaAdi  as 'Firma Adı', (SELECT sehirAdi FROM TBL_SEHIRLER WHERE id = sehirId) as 'Şehir', (SELECT ulkeAdi FROM TBL_ULKELER WHERE id = (SELECT ulkeId FROM TBL_SEHIRLER WHERE id = sehirId)) as 'Ülke' FROM TBL_TEDARIKCI WHERE sehirId IN (SELECT id FROM TBL_SEHIRLER WHERE sehirAdi LIKE '%" + txt_musteriAd.Text.Trim().ToString() + "%')";
                }

                if (rb_ulke.Checked)
                {
                    komut.CommandText = "SELECT firmaAdi as 'Firma Adı', (SELECT sehirAdi FROM TBL_SEHIRLER WHERE id = sehirId) as 'Şehir', (SELECT ulkeAdi FROM TBL_ULKELER WHERE id = (SELECT ulkeId FROM TBL_SEHIRLER WHERE id = sehirId)) as 'Ülke' FROM TBL_TEDARIKCI WHERE sehirId IN (SELECT id FROM TBL_SEHIRLER WHERE ulkeId IN (SELECT id FROM TBL_ULKELER WHERE ulkeAdi LIKE '%" + txt_musteriAd.Text.Trim().ToString() + "%'))";
                }

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


                dataGridView2.Columns[0].Width = 100;
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].Width = 100;
            
        }
    }
}
