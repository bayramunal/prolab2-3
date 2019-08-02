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
    public partial class TedarikciHammaddeStoklari : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public TedarikciHammaddeStoklari()
        {
            InitializeComponent();
        }

        private void TedarikciHammaddeStoklari_Load(object sender, EventArgs e)
        {
            tedarikcileriGetir();
            for (int i = 0; i < tedarikciler.Count; i++)
            {
                combo_tedarikci.Items.Add(tedarikciler[i]);
            }
            //ismeGoreTedarikciGetir("");

        }

        List<String> tedarikciler = new List<String>();

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
            string sorgu = "SELECT DISTINCT (select firmaAdi from TBL_TEDARIKCI where id = tedarikciId) as 'Firma Adı' FROM TBL_TEDARIKCI_HAMMADDE";
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
            string sorgu = "SELECT (select firmaAdi from TBL_TEDARIKCI where id =  tedarikciId) as 'Firma Adı', (SELECT sehirAdi FROM TBL_TEDARIKCI WHERE id = tedarikciId) as 'şehir',  (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde Adı', uretimTarihi as 'Üretim tarihi', satisFiyati as 'Satış fiyatı', stok as 'Stok' FROM TBL_TEDARIKCI_HAMMADDE WHERE tedarikciId IN (SELECT id FROM TBL_TEDARIKCI WHERE firmaAdi LIKE '%"+combo_tedarikci.SelectedItem.ToString()+"%') AND (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) LIKE '%"+text+"%'";
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
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 65;
        }

        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
        {

            ismeGoreTedarikciGetir(txt_hammaddeAdi.Text.Trim());


        }

        private void combo_tedarikci_SelectedIndexChanged(object sender, EventArgs e)
        {
            ismeGoreTedarikciGetir("");
        }
    }
}
