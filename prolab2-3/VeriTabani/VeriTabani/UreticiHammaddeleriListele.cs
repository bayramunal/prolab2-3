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
    public partial class UreticiHammaddeleriListele : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiHammaddeleriListele()
        {
            InitializeComponent();
        }

        private void UreticiHammaddeleriListele_Load(object sender, EventArgs e)
        {
            ureticileriGetir();
            for (int i = 0; i < tedarikciler.Count; i++)
            {
                combo_uretici.Items.Add(tedarikciler[i]);
            }
            ismeGoreUreticiGetir("", "");


        }

        List<String> tedarikciler = new List<String>();

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
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            string sorgu = "SELECT DISTINCT (select firmaAdi from TBL_URETICI where  id = ureticiId) as 'Firma Adı' FROM TBL_URETICI_HAMMADDESTOK";
            komut.CommandText = sorgu;


            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                tedarikciler.Add(dr["Firma Adı"].ToString());
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

        public void ismeGoreUreticiGetir(string ad, string text)
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
            string sorgu = "SELECT (select firmaAdi from TBL_URETICI where id = ureticiId) as 'Firma Adı', (SELECT sehirAdi FROM TBL_URETICI WHERE id = ureticiId) as 'şehir',  (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde Adı', uretimTarihi as 'Üretim tarihi',  stok as 'Stok' FROM TBL_URETICI_HAMMADDESTOK WHERE ureticiId IN (SELECT id FROM TBL_URETICI WHERE  firmaAdi LIKE '%" + ad + "%') AND (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) LIKE '%" + text + "%'";
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


            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 142;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 133;
            dataGridView1.Columns[4].Width = 110;
        }




        private void txt_hammaddeAdi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ismeGoreUreticiGetir(combo_uretici.SelectedItem.ToString(), txt_hammaddeAdi.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Üretici seçiniz", "Hata ile karşılaşıldı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_uretici_SelectedIndexChanged(object sender, EventArgs e)
        {

            ismeGoreUreticiGetir(combo_uretici.SelectedItem.ToString(), txt_hammaddeAdi.Text.Trim());
        }


    }
}
