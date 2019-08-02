using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace VeriTabani
{
    public partial class TedarikciEkle : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TedarikciEkle()
        {
            InitializeComponent();
        }

        private void TedarikciEkle_Load(object sender, EventArgs e)
        {
            tedarikcileriGetir("");
        }

      

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (txt_firmaAdi.Text == "")
            {
                MessageBox.Show("Firma adı boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_sehir.Text == "")
            {
                MessageBox.Show("Şehir bilgisi boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_ulke.Text == "")
            {
                MessageBox.Show("Ülke bilgisi boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (baglanti.State == ConnectionState.Closed)
                {
                    try
                    {
                        baglanti.Open();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "dbo.TEDARIKCI_EKLE";
                komut.Parameters.AddWithValue("@firmaAdi", txt_firmaAdi.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@ulkeAdi", txt_ulke.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@sehirAdi", txt_sehir.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@uzaklik", txt_uzaklik.Text.Trim());
                
                try
                {
                    komut.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sorgu çalıştırma hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                komut.Parameters.Clear();

                Boolean kontrol = false;

                try
                {
                    komut.Dispose();
                    baglanti.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kapanış hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kontrol = true;
                }

                if (kontrol == false)
                {
                    MessageBox.Show(txt_firmaAdi.Text.Trim().ToString() + " adlı tedarikçi eklendi", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                tedarikcileriGetir("");

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void tedarikcileriGetir(string text)
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
                komut.CommandText = "SELECT firmaAdi as 'Firma Adı', sehirAdi as 'Şehir', ulkeAdi  as 'Ülke' , uzaklik as Uzaklık FROM TBL_TEDARIKCI WHERE firmaAdi LIKE '%" + text + "%'";
            }

            if (rb_sehir.Checked)
            {
                komut.CommandText = "SELECT firmaAdi as 'Firma Adı', sehirAdi as 'Şehir',  ulkeAdi  as 'Ülke', uzaklik as Uzaklık  FROM TBL_TEDARIKCI WHERE  sehirAdi LIKE '%" + text + "%'";
            }

            if (rb_ulke.Checked)
            {
                komut.CommandText = "SELECT firmaAdi as 'Firma Adı',  sehirAdi as 'Şehir', ulkeAdi as 'Ülke', uzaklik as Uzaklık FROM TBL_TEDARIKCI WHERE ulkeAdi LIKE '%" + text + "%'";
            }

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


            dataGridView1.Columns[0].Width = dataGridView1.Width/4;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 4;
        }


        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
        {
            tedarikcileriGetir(txt_ara.Text.Trim().ToString());
        }

        private void chk_guncelle_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_guncelle.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
                groupBox2.Enabled = false;
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
            komut.CommandType = CommandType.Text;
            komut.CommandText = "DELETE FROM TBL_TEDARIKCI WHERE firmaAdi = '"+ dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString() + "' AND sehirAdi = '"+ dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString() + "' AND  ulkeAdi = '"+ dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Ülke"].Value.ToString() + "'";

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
                MessageBox.Show("Tedarikçi silindi.", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_ara.Text = "";
            tedarikcileriGetir("");

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
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
            komut.CommandText = "TEDARIKCI_GUNCELLE";

            komut.Parameters.AddWithValue("@tedarikciAdi", txt_guncelleFirmaAdi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@ulkeAdi", txt_guncelleUlke.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@sehirAdi", txt_guncelleSehir.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@tedarikciId", Convert.ToInt32(id));
            komut.Parameters.AddWithValue("@uzaklik", Convert.ToInt32(txt_guncelleUzaklik.Text.Trim().ToString()));

            komut.ExecuteNonQuery();

            try
            {
                komut.Parameters.Clear();
                komut.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tedarikçi güncellendi", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_ara.Text = "";
            tedarikcileriGetir("");
        }

        string id = "";

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string ad = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString();
            string sehir = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString();
            string ulke = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Ülke"].Value.ToString();
            string uzaklik = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Uzaklık"].Value.ToString();
           

            txt_guncelleFirmaAdi.Text = ad;
            txt_guncelleSehir.Text = sehir;
            txt_guncelleUlke.Text = ulke;
            txt_guncelleUzaklik.Text = uzaklik;


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
            string sorgu = "SELECT id FROM TBL_TEDARIKCI WHERE firmaAdi = '"+ad+"' AND   sehirAdi = '"+sehir+"'";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = sorgu;

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                id = dr["id"].ToString();
            }

            try
            {
                komut.Parameters.Clear();
                komut.Dispose();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
