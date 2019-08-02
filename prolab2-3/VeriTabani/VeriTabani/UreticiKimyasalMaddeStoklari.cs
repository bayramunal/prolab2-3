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
    public partial class UreticiKimyasalMaddeStoklari : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiKimyasalMaddeStoklari()
        {
            InitializeComponent();
        }

        private void UreticiKimyasalMaddeStoklari_Load(object sender, EventArgs e)
        {
            tedarikcileriGetir();
            for (int i = 0; i < ureticiler.Count; i++)
            {
                combo_uretici.Items.Add(ureticiler[i]);
            }
            //ismeGoreTedarikciGetir("");

        }

        List<String> ureticiler = new List<String>();

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
            string sorgu = "SELECT DISTINCT (select firmaAdi  FROM TBL_URETICI WHERE id = ureticiId) as 'Firma Adı' FROM TBL_URETICI_KIMYASALMADDESTOK";
            komut.CommandText = sorgu;


            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ureticiler.Add(dr["Firma Adı"].ToString());
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

        public void ismeGoreTedarikciGetir(string text)
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
            string sorgu = "SELECT id, (SELECT  urunAdi FROM TBL_KIMYASAL_URUNLER WHERE id = kimyasalMaddeId) as 'Kimyasal Madde Adı', STUFF((SELECT ',' + CONCAT(CAST((olustuguHammaddeMiktari) as varchar), ' adet ', (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = olustuguHammaddeId) )FROM TBL_KIMYASAL_URUN_BILGI WHERE  kimyasalMaddeId = uks.kimyasalMaddeId FOR XML PATH('')),1,1,' ') as 'Oluştuğu Hammaddeler', uretimTarihi as 'Üretim tarihi' , stok as Stok, iscilikMaliyeti as 'İşçilik Maliyeti', birimFiyat as 'Fiyat' FROM TBL_URETICI_KIMYASALMADDESTOK as uks WHERE ureticiId = (SELECT id FROM TBL_URETICI WHERE  firmaAdi LIKE '%" + combo_uretici.SelectedItem.ToString() + "%') AND (SELECT urunAdi FROM TBL_KIMYASAL_URUNLER WHERE id = uks.kimyasalMaddeId) LIKE '%" + txt_kimyasal.Text.Trim() + "%'";
            komut.CommandText = sorgu;
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
            dataGridView1.Columns[1].Width = 105;
            dataGridView1.Columns[2].Width = 167;
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[6].Width = 70;
            //dataGridView1.Columns[7].Width = 80;
        }

        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
        {

            ismeGoreTedarikciGetir(txt_kimyasal.Text.Trim());


        }

        private void combo_tedarikci_SelectedIndexChanged(object sender, EventArgs e)
        {
            ismeGoreTedarikciGetir("");
        }

        private void chk_guncelle_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_guncelle.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
                groupBox1.Enabled = false;
        }

        int mevcutId;

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string fiyat, iscilik, karOrani;
            fiyat = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Fiyat"].Value.ToString(); 
            iscilik = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["İşçilik Maliyeti"].Value.ToString(); 
            //karOrani = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Kar orani"].Value.ToString();
            mevcutId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString());
            

            txt_fiyat.Text = fiyat;
            txt_iscilik.Text = iscilik;

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
            komut.CommandText = "UPDATE TBL_URETICI_KIMYASALMADDESTOK SET iscilikMaliyeti = '"+txt_iscilik.Text.Trim()+"', birimFiyat = '"+txt_fiyat.Text.Trim()+"' WHERE id = '"+mevcutId+"'";

            komut.ExecuteNonQuery();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ismeGoreTedarikciGetir("");

            MessageBox.Show("Seçili bilgiler güncellendi","Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
