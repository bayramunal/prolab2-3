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
    public partial class Musteriekle : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public Musteriekle()
        {
            InitializeComponent();
        }

        private void Musteriekle_Load(object sender, EventArgs e)
        {
            musterileriGetir("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_musteriAdi.Text = "";
            txt_musteriSoyadi.Text = "";
            txt_musteriAdres.Text = "";
            txt_musteriAdi.Focus();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            komut.Parameters.Clear();

            if (txt_musteriAdi.Text == "")
            {
                MessageBox.Show("Müşteri adı boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_musteriSoyadi.Text == "")
            {
                MessageBox.Show("Müşteri soyadı boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_musteriAdres.Text == "")
            {
                MessageBox.Show("Müşteri telefon bilgisi boş bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                komut.CommandText = "dbo.MUSTERI_EKLE";
                komut.Parameters.AddWithValue("@musteriAdi", txt_musteriAdi.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@musteriSoyadi", txt_musteriSoyadi.Text.Trim().ToString());
                komut.Parameters.AddWithValue("@musteriAdres", txt_musteriAdres.Text.Trim().ToString());

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
                    MessageBox.Show(txt_musteriAdi.Text.Trim().ToString() + " adlı müşteri eklendi", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                musterileriGetir("");


            }
        }


        public void musterileriGetir(string text)
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
            komut.CommandText = "SELECT musteriAdi as 'Müşteri Adı', musteriSoyadi as 'Müşteri Soyadı', musteriAdres as 'Müşteri Adres' FROM TBL_MUSTERILER WHERE musteriAdi LIKE '%" + text + "%'";

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


            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 175;
        }

        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
        {
            musterileriGetir("");
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
            komut.CommandText = "MUSTERISIL";

            komut.Parameters.AddWithValue("@musteriAd", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Adı"].Value);
            komut.Parameters.AddWithValue("@musteriSoyad", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Soyadı"].Value);
            komut.Parameters.AddWithValue("@musteriAdres", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Adres"].Value);
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
                MessageBox.Show("Müşteri silindi.", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            musterileriGetir("");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        string id = "";

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string ad = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Adı"].Value.ToString();
            string soyad = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Soyadı"].Value.ToString();
            string adres = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Müşteri Adres"].Value.ToString();


            txt_guncelleAd.Text = ad;
            txt_guncelleSoyad.Text = soyad;
            txt_guncelleAdres.Text = adres;

            string sorgu = "SELECT id FROM TBL_MUSTERILER WHERE musteriAdi = '" + ad + "' AND musteriSoyadi = '" + soyad + "' AND musteriAdres = '" + adres + "'";

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
            komut.CommandText = sorgu;

            SqlDataReader dr = komut.ExecuteReader();

            while(dr.Read())
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

        private void button1_Click_1(object sender, EventArgs e)
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

            string sorgu = "UPDATE TBL_MUSTERILER SET musteriAdi = '" + txt_guncelleAd.Text.Trim().ToString() + "', musteriSoyadi = '" + txt_guncelleSoyad.Text.Trim().ToString() + "', musteriAdres = '" + txt_guncelleAdres.Text.Trim().ToString() + "' WHERE id = '"+id+"'";


            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = sorgu;

            komut.ExecuteNonQuery();

            musterileriGetir("");
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

            MessageBox.Show("Bilgiler güncellendi", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
