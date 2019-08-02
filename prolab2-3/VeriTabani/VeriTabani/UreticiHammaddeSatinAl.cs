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
    public partial class UreticiHammaddeSatinAl : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiHammaddeSatinAl()
        {
            InitializeComponent();
        }

        private void UreticiHammaddeSatinAl_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            tedarikcileriGetir();
            ureticileriGetir();
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
            string sorgu = "SELECT (SELECT firmaAdi FROM TBL_TEDARIKCI WHERE id = tedarikciId) as 'Firma Adı', (SELECT sehirAdi FROM TBL_TEDARIKCI WHERE id  = tedarikciId) as 'Şehir', (SELECT ulkeAdi  FROM TBL_TEDARIKCI WHERE id = tedarikciId) as 'Ülke', (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde Adı', uretimTarihi as 'Üretim tarihi', (SELECT rafOmru FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Raf ömrü', stok as 'Stok', satisFiyati as 'Satis fiyati' FROM TBL_TEDARIKCI_HAMMADDE";

            komut.CommandText = sorgu;
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
            
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[5].Width = 50;
            dataGridView2.Columns[6].Width = 67;
            dataGridView2.Columns[7].Width = 65;
        }

        public void ureticileriGetir()
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
            komut.CommandText = "SELECT firmaAdi as 'Üretici Adı', sehirAdi  as 'Şehir',  ulkeAdi  as 'Ülke' FROM TBL_URETICI  WHERE firmaAdi LIKE '%" + txt_ureticiAra.Text.Trim().ToString() + "%'";
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


            if (txt_adet.Text == "")
            {
                MessageBox.Show("Alınacak adeti girmediniz", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(txt_adet.Text.Trim()) > (Convert.ToInt32(dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Stok"].Value)))
            {
                MessageBox.Show("Sipariş adedi stoktan fazla olamaz", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            komut.CommandText = "URETICI_HAMMADDE_SATIN_AL";

            komut.Parameters.AddWithValue("@ureticiAdi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Üretici Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@hammaddeAdi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Hammadde Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@stok", Convert.ToInt32(txt_adet.Text.Trim()));
            komut.Parameters.AddWithValue("@tedarikciAdi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Firma Adı"].Value.ToString());

            string kargoAdi = "";

            if (rb_kara.Checked)
                kargoAdi = "Kara";
            if (rb_hava.Checked)
                kargoAdi = "Hava";
            

            komut.Parameters.AddWithValue("@kargoAdi", kargoAdi);
            komut.Parameters.AddWithValue("@alisFiyati", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Satis fiyati"].Value.ToString());
            komut.Parameters.AddWithValue("@uretimTarihi", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Üretim tarihi"].Value.ToString());
            komut.Parameters.AddWithValue("@ureticiSehir", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString());
            komut.Parameters.AddWithValue("@tedarikciSehir", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Şehir"].Value.ToString());

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
                MessageBox.Show("Hammadde satın alındı", "Bilgilendirme mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tedarikcileriGetir();
            txt_adet.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ureticileriGetir();

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

            string sorgu = "SELECT (SELECT firmaAdi FROM TBL_TEDARIKCI WHERE id =  tedarikciId) as 'Firma Adı', (SELECT sehirAdi FROM TBL_TEDARIKCI WHERE id = tedarikciId) as 'Şehir', (SELECT ulkeAdi FROM TBL_TEDARIKCI WHERE id = tedarikciId) as 'Ülke', (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde Adı', uretimTarihi as 'Üretim tarihi', (SELECT rafOmru FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Raf ömrü', stok as 'Stok', satisFiyati as 'Satis fiyati' FROM TBL_TEDARIKCI_HAMMADDE ";

            if (rb_ad.Checked)
            {
                komut.CommandText = sorgu + " WHERE (SELECT firmaAdi FROM TBL_TEDARIKCI WHERE id =  tedarikciId) like '%" + txt_tedarikci.Text.Trim().ToString() + "%' order by satisFiyati asc";
            }

            if (rb_sehir.Checked)
            {
                komut.CommandText = sorgu + " WHERE (SELECT sehirAdi FROM TBL_TEDARIKCI WHERE id = tedarikciId) like '%" + txt_tedarikci.Text.Trim().ToString() + "%' order by satisFiyati asc";
            }

            if (rb_ulke.Checked)
            {
                komut.CommandText = sorgu + " WHERE (SELECT ulkeAdi  FROM TBL_TEDARIKCI WHERE id = tedarikciId)  like '%" + txt_tedarikci.Text.Trim().ToString() + "%' order by satisFiyati asc";
            }

            if (rb_hammadde.Checked)
            {
                komut.CommandText = sorgu + " WHERE (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) like '%" + txt_tedarikci.Text.Trim().ToString() + "%' order by satisFiyati asc";

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
            dataGridView2.Columns[5].Width = 50;
            dataGridView2.Columns[6].Width = 50;
            dataGridView2.Columns[7].Width = 50;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_adet_TextChanged(object sender, EventArgs e)
        {

            int a;
            if (txt_adet.Text == "")
            {

                int satisFiyati = Convert.ToInt32(fiyat);
                int toplamFiyat = 0 * satisFiyati;

                lbl_odenecek.Text = toplamFiyat.ToString();
            }


            else if (int.TryParse(txt_adet.Text,out a))
            {

                int satisFiyati = Convert.ToInt32(fiyat);
                int toplamFiyat = Convert.ToInt32(txt_adet.Text.Trim().ToString()) * satisFiyati;

                lbl_odenecek.Text = toplamFiyat.ToString();
            }
            else
            {
                txt_adet.Text = "";
                MessageBox.Show("Sadece nümerik ifadeler girilmelidir.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        string fiyat = "";

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            fiyat = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Satis fiyati"].Value.ToString();
            lbl_fiyat.Text = "x " + fiyat + " = ";
        }
    }
}
