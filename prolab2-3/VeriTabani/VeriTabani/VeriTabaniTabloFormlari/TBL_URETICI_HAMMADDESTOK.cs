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
    public partial class TBL_URETICI_HAMMADDESTOK : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TBL_URETICI_HAMMADDESTOK()
        {
            InitializeComponent();
        }

        private void TBL_URETICI_HAMMADDESTOK_Load(object sender, EventArgs e)
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
            komut.CommandText = "select * from TBL_URETICI_HAMMADDESTOK   ";

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
            dataGridView1.Columns[1].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 4;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 4;

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
            komut.CommandText = "DELETE FROM TBL_URETICI_HAMMADDESTOK WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";

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
            komut.CommandText = "UPDATE TBL_URETICI_HAMMADDESTOK SET uretimTarihi = @uretimTarihi, ureticiId = @ureticiId, hammaddeId = @hammaddeId, stok = @stok WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";
            komut.Parameters.AddWithValue("@uretimTarihi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["uretimTarihi"].Value.ToString());
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@hammaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["hammaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@stok", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["stok"].Value.ToString());

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
            komut.CommandText = "insert into TBL_URETICI_HAMMADDESTOK (uretimTarihi, ureticiId, hammaddeId, stok) values (@uretimTarihi, @ureticiId, @hammaddeId, @stok)";
            komut.Parameters.AddWithValue("@uretimTarihi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["uretimTarihi"].Value.ToString());
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@hammaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["hammaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@stok", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["stok"].Value.ToString());


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
