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
    public partial class txt_iscilikMaliyeti : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        public txt_iscilikMaliyeti()
        {
            InitializeComponent();
        }

        private void UreticiKimyasalUrunUret_Load(object sender, EventArgs e)
        {

            // musterileriGetir("");
            ureticileriGetir();

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
                }
            }

            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            komut.CommandText = "SELECT distinct (SELECT firmaAdi FROM TBL_URETICI WHERE id = ureticiId) as 'Firma adı' FROM TBL_URETICI_HAMMADDESTOK";

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                combo_ureticiler.Items.Add(dr["Firma Adı"].ToString());
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


        //public void musterileriGetir(string text)
        //{
        //    if (baglanti.State == ConnectionState.Closed)
        //    {
        //        try
        //        {
        //            baglanti.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    komut.Connection = baglanti;
        //    komut.CommandType = CommandType.Text;

        //    if (rb_ad.Checked)
        //    {
        //        komut.CommandText = "SELECT (SELECT firmaAdi FROM TBL_URETICI_ISIMLERI WHERE id = ureticiId) as 'Firma adı',(SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde adı',	stok, uretimTarihi FROM TBL_URETICI_HAMMADDESTOK WHERE  (SELECT firmaAdi FROM TBL_URETICI_ISIMLERI WHERE id = ureticiId) LIKE '%"+txt_musteriAd.Text.Trim().ToString()+"%'";
        //    }

        //    if (rb_hammadde.Checked)
        //    {
        //        komut.CommandText = "SELECT (SELECT firmaAdi FROM TBL_URETICI_ISIMLERI WHERE id = ureticiId) as 'Firma adı',(SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde adı',	stok, uretimTarihi FROM TBL_URETICI_HAMMADDESTOK WHERE (SELECT hammaddeAdi FROM TBL_HAMMADDELER WHERE id = hammaddeId) LIKE '%"+txt_musteriAd.Text.Trim().ToString()+"%'";
        //    }


        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(komut);
        //    da.Fill(dt);
        //    dataGridView1.DataSource = dt;


        //    try
        //    {
        //        baglanti.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //    dataGridView1.Columns[0].Width = 200;
        //    dataGridView1.Columns[1].Width = 222;
        //    dataGridView1.Columns[2].Width = 200;
        //}

        private void txt_musteriAd_TextChanged(object sender, EventArgs e)
        {

            //musterileriGetir(txt_musteriAd.Text.Trim().ToString());


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_musteriAd_TextChanged_1(object sender, EventArgs e)
        {

        }

        public void ureticininHammaddeleriniGetir()
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

            komut.CommandText = " SELECT (Select hammaddeAdi from TBL_HAMMADDELER WHERE id = hammaddeId) as 'Hammadde Adı', stok as Stok, maliyet FROM TBL_URETICI_HAMMADDESTOK WHERE ureticiId = (SELECT id FROM TBL_URETICI WHERE firmaAdi = '"+combo_ureticiler.SelectedItem.ToString()+"')";


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


            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 3;
        }

        public void ureticininKimyasalUrunleri()
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
            komut.CommandText = "URETICININ_KIMYASALURUNLERI";

            komut.Parameters.AddWithValue("@ureticiAdi", combo_ureticiler.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@kimyasalMaddeAdi", txt_kimyasalMaddeAdi.Text.Trim().ToString());

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

            dataGridView2.Columns[0].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[1].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[2].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[3].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[4].Width = dataGridView2.Width / 6;
            dataGridView2.Columns[5].Width = dataGridView2.Width / 6;

        }

        private void combo_ureticiler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ureticininHammaddeleriniGetir();
            ureticininKimyasalUrunleri();
        }

        public string hammaddeSemboluGetir(string ad)
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
            komut.CommandText = "Select sembolu FROM TBL_HAMMADDELER WHERE hammaddeAdi = '" + ad + "'";

            SqlDataReader dr = komut.ExecuteReader();

            string sembol = "";

            while (dr.Read())
            {
                sembol = dr["sembolu"].ToString();
            }

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sembol;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string ad = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Hammadde Adı"].Value.ToString();
                string sembol = hammaddeSemboluGetir(ad);

                lbl_secilenElement.Text = ad + " - " + sembol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        List<String> bilesik = new List<String>();

        public void bilesigiYazdir()
        {
            lbl_olusturulanBilesik.Text = "";

            for (int i = 0; i < bilesik.Count; i++)
            {
                if (!bilesik[i].Equals(".") && !bilesik[i].Equals("1"))
                {
                    lbl_olusturulanBilesik.Text += bilesik[i];
                }
            }

        }

        private void btn_karistir_Click(object sender, EventArgs e)
        {
            if (txt_maddeMiktari.Text == "0" || txt_maddeMiktari.Text == "")
            {
                MessageBox.Show("Sıfır değeri veya boş değer kabul edilemez", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            else if(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Stok"].Value) - Convert.ToInt32(txt_maddeMiktari.Text) < 0)
            {
                MessageBox.Show("Yeterli stok bulunmamaktadır", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else

            {
                int miktar;
                if (txt_maddeMiktari.Text == "")
                    miktar = 1;
                else
                    miktar = Convert.ToInt32(txt_maddeMiktari.Text.Trim().ToString());

                bilesik.Add(lbl_secilenElement.Text.Substring(lbl_secilenElement.Text.IndexOf("-") + 1).Trim());
                bilesik.Add(".");

                bilesik.Add(miktar.ToString());

                bilesik.Add(".");

                bilesigiYazdir();
                
                    dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Stok"].Value = (Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Stok"].Value) - miktar);

                    if (txt_satisFiyati.Text == "")
                    {
                        txt_satisFiyati.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["maliyet"].Value.ToString();
                    }
                    else
                    {
                        txt_satisFiyati.Text = (Convert.ToDouble(txt_satisFiyati.Text) + Convert.ToDouble(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["maliyet"].Value) * miktar).ToString();
                    }
                


            }
        }

        public void kimyasalUrunOlustur(string hammadde, string miktar)
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
            komut.CommandText = "KIMYASALURUN_OLUSTUR";

            komut.Parameters.AddWithValue("@kimyasalMaddeAdi", txt_kimyasalUrunAdi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@olustuguHammadde", hammadde.Trim());
            komut.Parameters.AddWithValue("@olustuguHammaddeMiktari", miktar);

            komut.ExecuteNonQuery();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void KIMYASALURUN_EKLE()
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
            komut.CommandText = "KIMYASALURUN_BILGIEKLE";

            komut.Parameters.AddWithValue("@kimyasalUrunAdi", txt_kimyasalUrunAdi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@rafOmru", txt_rafOmru.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@bilesikFormulu", lbl_olusturulanBilesik.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@ureticiAdi", combo_ureticiler.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@uretimTarihi", txt_uretimTarihi.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@stok", txt_uretilenAdet.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@iscilikMaliyeti", txt_iscilik.Text.Trim().ToString());
            komut.Parameters.AddWithValue("@satisFiyati", Convert.ToDouble(txt_satisFiyati.Text.Trim()));

            komut.ExecuteNonQuery();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Kimyasal ürün eklendi");
        }

        public int stokKontrol(string hammadde)
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
            komut.CommandText = "SELECT sum(stok) as stok FROM TBL_URETICI_HAMMADDESTOK WHERE hammaddeId = (select id from TBL_HAMMADDELER where sembolu = '" + hammadde + "') AND ureticiId = (SELECT id from TBL_URETICI WHERE  firmaAdi = '" + combo_ureticiler.SelectedItem.ToString() + "') ";

            SqlDataReader dr = komut.ExecuteReader();

            int stok = -1;

            while (dr.Read())
            {
                stok = Convert.ToInt32(dr["stok"]);
            }

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return stok;

        }


        public void ureticiStoklariniGuncelle(string hammadde, string miktar)
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
            komut.CommandText = "URETICI_HAMMADDE_GUNCELLE";

            komut.Parameters.AddWithValue("@ureticiAdi", combo_ureticiler.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@hammaddeSembol", hammadde);
            komut.Parameters.AddWithValue("@stok", Convert.ToInt32(miktar) * Convert.ToInt32(txt_uretilenAdet.Text.Trim()));

            komut.ExecuteNonQuery();


            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            int a;
            Boolean kontrol = false;
            for (int i = 0; i < bilesik.Count; i++)
            {
                if (!bilesik[i].Equals(".") && int.TryParse(bilesik[i], out a) == false)
                {
                    int stok = stokKontrol(bilesik[i]);

                    if (stok < (Convert.ToInt32(txt_uretilenAdet.Text.Trim().ToString())) * Convert.ToInt32(bilesik[i + 2]))
                    {
                        kontrol = true;
                        break;
                    }

                }
            }


            if (!kontrol) // stoklar yeterliyse
            {
                
                KIMYASALURUN_EKLE();

                for (int i = 0; i < bilesik.Count - 2; i++)
                {
                    if (!bilesik[i].Equals(".") && int.TryParse(bilesik[i], out a) == false)
                    {
                        kimyasalUrunOlustur(bilesik[i], bilesik[i + 2]);
                        ureticiStoklariniGuncelle(bilesik[i], bilesik[i + 2]);
                    }
                }

                
            }
            else
            {
                MessageBox.Show("Kimyasal ürünü üretmek için yeterli hammadde bulunmuyor.", "Bilgilendirme penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_uretilenAdet_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (txt_uretilenAdet.Text == "")
            {
                txt_iscilik.Text = 0.ToString();
            }
            else if (int.TryParse(txt_uretilenAdet.Text, out a) == false)
            {
                MessageBox.Show("Sadece sayısal değerler kabul edilebilir", "Bilgilendirme Kutusu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                txt_iscilik.Text = txt_uretilenAdet.Text.ToString();

            }
            
        }
    }
}
