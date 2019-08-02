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
    public partial class UreticiyeGelenSiparisler : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public UreticiyeGelenSiparisler()
        {
            InitializeComponent();
        }

        private void UreticiyeGelenSiparisler_Load(object sender, EventArgs e)
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
            string sorgu = "SELECT DISTINCT (select firmaAdi from TBL_URETICI where id = ureticiId) as 'Firma Adı' FROM TBL_URETICI_HAMMADDESTOK";
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
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "URETICININ_SIPARISLERINI_GETIR";

            komut.Parameters.AddWithValue("@ureticiAdi", ad);

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
            dataGridView1.Columns[4].Visible = false;
        }
        
        private void combo_uretici_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ismeGoreUreticiGetir(combo_uretici.SelectedItem.ToString(), txt_hammaddeAdi.Text.Trim());
        }

        private void txt_hammaddeAdi_TextChanged_1(object sender, EventArgs e)
        {
            ismeGoreUreticiGetir(combo_uretici.SelectedItem.ToString(), txt_hammaddeAdi.Text.Trim());

        }

        private int secilenId, ureticiId, musteriId, kimyasalMaddeId, stok;

        private int stokKontrolu()
        {
            int donecek = 0;
            //SELECT SUM(stok) FROM TBL_URETICI_KIMYASALMADDE WHERE kimyasalMaddeId = 28 AND ureticiId = 3

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
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "URETICI_KIMYASALURUN_STOK";
            komut.Parameters.AddWithValue("@kimyasalMaddeId", kimyasalMaddeId);
            komut.Parameters.AddWithValue("@ureticiId", ureticiId);

            SqlDataReader dr = komut.ExecuteReader();
            int mevcutStok = 0;
            string okunan = "";
            while (dr.Read())
            {
                okunan = dr["stok"].ToString();
                //MessageBox.Show(okunan);
            }

            mevcutStok = Convert.ToInt32(okunan);

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (mevcutStok < stok)
            {
                MessageBox.Show("Yeterli stok bulunmamaktadır.", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                donecek = -1;
            }
            else
                donecek = 1;

            return donecek;
        }

        private void btn_onayla_Click(object sender, EventArgs e)
        {
            if (combo_kar.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kâr oranını giriniz", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (stokKontrolu() != -1)
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
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "URETICI_KIMYASALMADDE_GUNCELLE";
                    komut.Parameters.AddWithValue("@satirId", secilenId);
                    komut.Parameters.AddWithValue("@musteriId", musteriId);
                    komut.Parameters.AddWithValue("@ureticiId", ureticiId);
                    komut.Parameters.AddWithValue("@kimyasalMaddeId", kimyasalMaddeId);
                    komut.Parameters.AddWithValue("@stok", stok);
                    komut.Parameters.AddWithValue("@satisKari", Convert.ToInt32(combo_kar.SelectedItem.ToString()));

                    try
                    {
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    try
                    {
                        baglanti.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Sipariş onaylandı", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            secilenId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value.ToString()) ;

            //MessageBox.Show(secilenId.ToString());

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
            komut.CommandText = "SELECT ureticiId, musteriId, kimyasalMaddeId, miktar FROM TBL_MUSTERI_KM_SIPARIS WHERE id = '"+secilenId.ToString()+"'";

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ureticiId = Convert.ToInt32(dr["ureticiId"].ToString());
                kimyasalMaddeId = Convert.ToInt32(dr["kimyasalMaddeId"].ToString());
                stok = Convert.ToInt32(dr["miktar"].ToString());
                musteriId = Convert.ToInt32(dr["musteriId"].ToString());
            }

            //MessageBox.Show
                //(stok.ToString());

            //MessageBox.Show(secilenId.ToString() + " " + ureticiId.ToString() + "  " + kimyasalMaddeId.ToString()  + " " + musteriId.ToString());

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
