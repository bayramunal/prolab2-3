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
    public partial class UreticiKarOranlari : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiKarOranlari()
        {
            InitializeComponent();
        }

        private void UreticiKarOranlari_Load(object sender, EventArgs e)
        {
            ureticileriGetir();
            for (int i = 0; i < tedarikciler.Count; i++)
            {
                combo_uretici.Items.Add(tedarikciler[i]);
            }

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
            string sorgu = "SELECT DISTINCT (select firmaAdi from TBL_URETICI where id =  ureticiId) as 'Firma Adı' FROM TBL_URETICI_KIMYASALMADDESTOK";
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

        public void ismeGoreUreticiGetir(string ad)
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
            komut.CommandText = "SELECT (SELECT firmaAdi FROM TBL_URETICI WHERE id = ureticiId) as 'Firma adı', (SELECT musteriAdi FROM TBL_MUSTERILER WHERE id = musteriId) as 'Müşteri Adı', (SELECT urunAdi FROM TBL_KIMYASAL_URUNLER WHERE id = kimyasalMaddeId) as 'Kimyasal madde adı', odenecek as 'Ödenen', urunFiyati as 'Maliyet', odenecek - urunFiyati as 'Kar', karOrani as 'Kar Oranı' FROM TBL_MUSTERI_KM_SIPARIS WHERE ureticiId = (select id from TBL_URETICI WHERE firmaAdi like '%"+combo_uretici.SelectedItem.ToString()+"%')";

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

            
            
            dataGridView1.Columns[0].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[5].Width = dataGridView1.Width / 7;
            dataGridView1.Columns[6].Width = dataGridView1.Width / 7;
        }
        
        private void combo_uretici_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ismeGoreUreticiGetir(combo_uretici.SelectedItem.ToString());
            zararlariListele();
        }

        public void zararlariListele()
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
            komut.CommandText = "select urunId as 'Ürün Adı', uretimTarihi as 'Uretim tarihi', miktar as Miktar, maliyet as Maliyet, urunTipi as 'Ürün tipi' FROM TBL_URETICI_TARIHIGECMISLER";

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
            dataGridView2.Columns[0].Width = dataGridView2.Width / 4;
            dataGridView2.Columns[1].Width = dataGridView2.Width / 4;
            dataGridView2.Columns[2].Width = dataGridView2.Width / 4;
            dataGridView2.Columns[3].Width = dataGridView2.Width / 4;

            dataGridView2.Columns[1].Visible = false;

            List<String> degerler = new List<String>();

            for (int i = 0; i < dataGridView2.RowCount-1; i++)
            {
                //MessageBox.Show(dataGridView2.Rows[i].Cells["Ürün Adı"].Value.ToString());

                degerler.Add( urunIsimleriniGetir(dataGridView2.Rows[i].Cells["Ürün Adı"].Value.ToString(), dataGridView2.Rows[i].Cells["Ürün tipi"].Value.ToString()));
                
            }

            for (int i = 0; i < degerler.Count; i++)
            {
                //MessageBox.Show(degerler[i]);
                dataGridView2.Rows[i].Cells[0].Value = degerler[i];
            }



        }


        public string urunIsimleriniGetir(String id, string tip)
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

            string ad = "";

            SqlDataReader dr;

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            if (tip.Equals("kimyasal"))
            {

                komut.CommandText = "select urunAdi FROM TBL_KIMYASAL_URUNLER WHERE id = " + id + "";
                dr = komut.ExecuteReader();
                while(dr.Read())
                {
                    ad = dr["urunAdi"].ToString();
                }
            }
            else

            {

                komut.CommandText = "select hammaddeAdi FROM TBL_HAMMADDELER WHERE id = " + id + "";
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ad = dr["hammaddeAdi"].ToString();
                }
            }


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ad;

        }

    }
}
