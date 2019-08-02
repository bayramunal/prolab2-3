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
    public partial class UreticiEkle : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiEkle()
        {
            InitializeComponent();
        }

        private void UreticiEkle_Load(object sender, EventArgs e)
        {
            ureticileriGetir("");
        }

        public void ureticileriGetir(string text)
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
                komut.CommandText = "SELECT firmaAdi  as 'Firma Adı',  sehirAdi  as 'Şehir',  ulkeAdi  as 'Ülke' FROM TBL_URETICI WHERE firmaAdi LIKE '%" + text + "%'";
            }

            if (rb_sehir.Checked)
            {
                komut.CommandText = "SELECT firmaAdi  as 'Firma Adı',  sehirAdi  as 'Şehir', ulkeAdi  as 'Ülke' FROM TBL_URETICI WHERE sehirAdi LIKE '%" + text + "%'";
            }

            if (rb_ulke.Checked)
            {
                komut.CommandText = "SELECT firmaAdi as 'Firma Adı',  sehirAdi as 'Şehir', ulkeAdi  as 'Ülke' FROM TBL_URETICI WHERE ulkeAdi LIKE '%" + text + "%'";
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


            dataGridView1.Columns[0].Width = 210;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 210;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut.Parameters.Clear();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "dbo.URETICIEKLE";
                komut.Parameters.AddWithValue("@firmaAdi", txt_firmaAdi.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@ulkeAdi", txt_ulke.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@sehirAdi", txt_sehir.Text.Trim().ToString());

                try
                {
                    komut.ExecuteNonQuery();
                }
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kapanış hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kontrol = true;
                }

                if (kontrol == false)
                {
                    MessageBox.Show(txt_firmaAdi.Text.Trim().ToString() + " adlı üretici eklendi", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            ureticileriGetir("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_firmaAdi.Text = "";
            txt_sehir.Text = "";
            txt_ulke.Text = "";

            txt_firmaAdi.Focus();
        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            ureticileriGetir(txt_ara.Text.Trim().ToString());
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
            komut.CommandText = "URETICI_GUNCELLE";

            komut.Parameters.AddWithValue("@ureticiAdi", txt_guncelleFirmaAdi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@ulkeAdi", txt_guncelleUlke.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@sehirAdi", txt_guncelleSehir.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@ureticiId", Convert.ToInt32(id));

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

            MessageBox.Show("Üretici güncellendi", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_ara.Text = "";
            ureticileriGetir("");
        }


        string id = "";

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string ad = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString();
            string sehir = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString();
            string ulke = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Ülke"].Value.ToString();


            txt_guncelleFirmaAdi.Text = ad;
            txt_guncelleSehir.Text = sehir;
            txt_guncelleUlke.Text = ulke;


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
            string sorgu = "SELECT id FROM TBL_URETICI WHERE  firmaAdi = '" + ad + "' AND sehirAdi = '" + sehir + "'";
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

        private void chk_guncelle_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_guncelle.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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
            komut.CommandText = "DELETE FROM TBL_URETICI WHERE firmaAdi = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString() + "' AND sehirAdi = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString() + "' AND ulkeAdi = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Ülke"].Value.ToString() + "'";

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
                MessageBox.Show("Üretici silindi.", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_ara.Text = "";
            ureticileriGetir("");
        }
    }
}
