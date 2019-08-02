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
    public partial class TBL_MUSTERI_KM_SIPARIS : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TBL_MUSTERI_KM_SIPARIS()
        {
            InitializeComponent();
        }

        private void TBL_MUSTERI_KM_SIPARIS_Load(object sender, EventArgs e)
        {
            hammaddeleriGetir();
        }
        
        

        public void hammaddeleriGetir()
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
            komut.CommandText = "select * from TBL_MUSTERI_KM_SIPARIS";

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

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[5].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[6].Width = dataGridView1.Width / 8;
            dataGridView1.Columns[7].Width = dataGridView1.Width / 8;

        }

        private void btn_sil_Click(object sender, EventArgs e)
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
            komut.CommandText = "DELETE FROM TBL_MUSTERI_KM_SIPARIS WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";

            komut.ExecuteNonQuery();
            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hammaddeleriGetir();

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
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
            komut.CommandText = "UPDATE TBL_MUSTERI_KM_SIPARIS SET birimMaliyet = @birimMaliyet,karOrani = @karOrani,durum = @durum,odenecek = @odenecek,miktar = @miktar, musteriId = @musteriId, ureticiId = @ureticiId, kimyasalMaddeId = @kimyasalMaddeId WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";

            komut.Parameters.AddWithValue("@musteriId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["musteriId"].Value.ToString());
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@kimyasalMaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["kimyasalMaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@miktar", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["miktar"].Value.ToString());
            komut.Parameters.AddWithValue("@odenecek", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["odenecek"].Value.ToString());
            komut.Parameters.AddWithValue("@durum", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["durum"].Value.ToString());
            komut.Parameters.AddWithValue("@karOrani", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["karOrani"].Value.ToString());
            komut.Parameters.AddWithValue("@birimMaliyet", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["birimMaliyet"].Value.ToString());


            komut.ExecuteNonQuery();
            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hammaddeleriGetir();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
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
            komut.CommandText = "insert into TBL_MUSTERI_KM_SIPARIS (musteriId, ureticiId, kimyasalMaddeId, miktar, odenecek, durum, karOrani, birimMaliyet) values (@musteriId, @ureticiId, @kimyasalMaddeId, @miktar, @odenecek, @durum, @karOrani, @birimMaliyet)";

            komut.Parameters.AddWithValue("@musteriId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["musteriId"].Value.ToString());
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@kimyasalMaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["kimyasalMaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@miktar", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["miktar"].Value.ToString());
            komut.Parameters.AddWithValue("@odenecek", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["odenecek"].Value.ToString());
            komut.Parameters.AddWithValue("@durum", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["durum"].Value.ToString());
            komut.Parameters.AddWithValue("@karOrani", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["karOrani"].Value.ToString());
            komut.Parameters.AddWithValue("@birimMaliyet", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["birimMaliyet"].Value.ToString());


            komut.ExecuteNonQuery();
            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hammaddeleriGetir();
        }
    }
}
