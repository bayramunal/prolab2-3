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
    public partial class TBL_URETICI_KIMYASALMADDESTOK : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TBL_URETICI_KIMYASALMADDESTOK()
        {
            InitializeComponent();
        }

        private void TBL_URETICI_KIMYASALMADDESTOK_Load(object sender, EventArgs e)
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
            komut.CommandText = "select * from TBL_URETICI_KIMYASALMADDESTOK";

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
            dataGridView1.Columns[1].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[5].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[6].Width = dataGridView1.Width / 6;

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
            komut.CommandText = "DELETE FROM TBL_URETICI_KIMYASALMADDESTOK WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";

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
            komut.CommandText = "UPDATE TBL_URETICI_KIMYASALMADDESTOK SET ureticiId = @ureticiId, kimyasalMaddeId = @kimyasalMaddeId, uretimTarihi = @uretimTarihi, stok = @stok, iscilikMaliyeti = @iscilikMaliyeti, birimFiyat = @birimFiyat, karOrani = @karOrani  WHERE id = '" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString() + "'";
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@kimyasalMaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["kimyasalMaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@uretimTarihi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["uretimTarihi"].Value.ToString());
            komut.Parameters.AddWithValue("@stok", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["stok"].Value.ToString());
            komut.Parameters.AddWithValue("@iscilikMaliyeti", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["iscilikMaliyeti"].Value.ToString());
            komut.Parameters.AddWithValue("@birimFiyat", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["birimFiyat"].Value.ToString());
            komut.Parameters.AddWithValue("@karOrani", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["karOrani"].Value.ToString());


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
            komut.CommandText = "insert into TBL_URETICI_KIMYASALMADDESTOK (ureticiId, kimyasalMaddeId , uretimTarihi, stok, iscilikMaliyeti, birimFiyat, karOrani) values ( @ureticiId,  @kimyasalMaddeId,@uretimTarihi, @stok, @iscilikMaliyeti, @birimFiyat, @karOrani)";
            komut.Parameters.AddWithValue("@ureticiId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["ureticiId"].Value.ToString());
            komut.Parameters.AddWithValue("@kimyasalMaddeId", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["kimyasalMaddeId"].Value.ToString());
            komut.Parameters.AddWithValue("@uretimTarihi", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["uretimTarihi"].Value.ToString());
            komut.Parameters.AddWithValue("@stok", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["stok"].Value.ToString());
            komut.Parameters.AddWithValue("@iscilikMaliyeti", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["iscilikMaliyeti"].Value.ToString());
            komut.Parameters.AddWithValue("@birimFiyat", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["birimFiyat"].Value.ToString());
            komut.Parameters.AddWithValue("@karOrani", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["karOrani"].Value.ToString());

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
