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
    public partial class AnaEkran : Form
    {


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1HV6T5\\SQLEXPRESS;Initial Catalog=VTP2;Integrated Security=True");
        SqlCommand komut = new SqlCommand();

        private int childFormNumber = 0;
        List<Form> formlar = new List<Form>();
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void tedarikçiHammaddeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TedarikciHammaddeUret form = new TedarikciHammaddeUret();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;

        }

        private void müşteriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            Musteriekle form = new Musteriekle();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();


            this.Height = 700;

        }

        public void formlariTemizle()
        {
            for (int i = 0; i < formlar.Count; i++)
            {
                formlar[i].Close();
            }
        }

        private void tedarikçiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TedarikciEkle form = new TedarikciEkle();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();


            this.Height = 700;

        }

        private void üreticiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiEkle form = new UreticiEkle();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();


            this.Height = 700;

        }

        private void kimyasalÜrünSiparişiVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            MusteriSiparis form = new MusteriSiparis();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;

        }
        

        private void ürettiğiHammaddeleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TedarikciHammaddeStoklari form = new TedarikciHammaddeStoklari();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;

        }

        

        private void hammaddeSatınAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiHammaddeSatinAl form = new UreticiHammaddeSatinAl();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();


            this.Height = 700;

        }

        private void stoklarınıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiHammaddeleriListele form = new UreticiHammaddeleriListele();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();


            this.Height = 550;

        }

        private void üreticiyeKimyasalMaddeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            txt_iscilikMaliyeti form = new txt_iscilikMaliyeti();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 700;

        }

        private void üreticiyeGelenSiparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiyeGelenSiparisler form = new UreticiyeGelenSiparisler();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();
            this.Height = 550;
        }

        private void kimyasalÜrünStoklarınıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiKimyasalMaddeStoklari form = new UreticiKimyasalMaddeStoklari();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;

        }

        private void karOranlarınıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            UreticiKarOranlari form = new UreticiKarOranlari();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;

        }

        private void hammaddeSatışlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TedarikciSatislari form = new TedarikciSatislari();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLHAMMADDELERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_HAMMADDELER form = new TBL_HAMMADDELER();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLKIMYASALURUNBILGIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_KIMYASAL_URUN_BILGI form = new TBL_KIMYASAL_URUN_BILGI();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLKIMYASALURUNLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_KIMYASAL_URUNLER form = new TBL_KIMYASAL_URUNLER();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLMUSTERIKMSIPARISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_MUSTERI_KM_SIPARIS form = new TBL_MUSTERI_KM_SIPARIS();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLMUSTERILERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_MUSTERILER form = new TBL_MUSTERILER();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLTEDARIKCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_TEDARIKCI form = new TBL_TEDARIKCI();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLTEDARIKCIHAMMADDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_TEDARIKCI_HAMMADDE form = new TBL_TEDARIKCI_HAMMADDE();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLURETICIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_URETICI form = new TBL_URETICI();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLURETICIHAMMADDESTOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_URETICI_HAMMADDESTOK form = new TBL_URETICI_HAMMADDESTOK();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLURETICIKIMYASALMADDESTOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_URETICI_KIMYASALMADDESTOK form = new TBL_URETICI_KIMYASALMADDESTOK();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void tBLURETICITEDARIKCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlariTemizle();
            TBL_URETICI_TEDARIKCI form = new TBL_URETICI_TEDARIKCI();
            formlar.Add(form);
            form.MdiParent = this;
            form.Show();

            this.Height = 550;
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            uretimTarihleriniGetirHammadde();
            uretimTarihleriniGetirKimyasal();

        }

        public void zararlaraEkle(string ureticiId, string hammaddeId, string uretimTarihi, int miktar, double maliyet, string urunTipi)
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
            komut.CommandText = "insert into TBL_URETICI_TARIHIGECMISLER (ureticiId, urunId, uretimTarihi, miktar, maliyet, urunTipi) values ('" + ureticiId + "', '" + hammaddeId + "', '" + uretimTarihi + "', '" + miktar + "', @maliyet, '"+urunTipi+"')";
            komut.Parameters.AddWithValue("@maliyet", maliyet);
            komut.ExecuteNonQuery();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            komut.Parameters.Clear();
        }

        public void tarihiGeceniSil(string id, string urunTipi)
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
            if (urunTipi.Equals("hammadde"))
            {

                komut.CommandText = "delete from TBL_URETICI_HAMMADDESTOK WHERE id = '" + id + "'";
            }
            else
            {

                komut.CommandText = "delete from TBL_URETICI_KIMYASALMADDESTOK WHERE id = '" + id + "'";
            }
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

        public string urunAdiGetir(String id, string urunTipi)
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

            string hammaddeAdi = "";
            SqlDataReader dr;
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            if (urunTipi.Equals("hammadde"))
            {

                komut.CommandText = "select hammaddeAdi from TBL_HAMMADDELER WHERE id = '" + id + "'";
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    hammaddeAdi = dr["hammaddeAdi"].ToString();
                }
                dr.Close();
            }
            else

            {

                komut.CommandText = "select urunAdi from TBL_KIMYASAL_URUNLER WHERE id = '" + id + "'";
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    hammaddeAdi = dr["urunAdi"].ToString();
                }
                dr.Close();
            }
            

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hammaddeAdi;
        }

        public String rafOmurleri(String id, string urunTipi)
        {
            komut.Parameters.Clear();
            String rafOmurleri = "";
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
            if (urunTipi.Equals("hammadde"))
            {

                komut.CommandText = "select rafOmru from TBL_HAMMADDELER WHERE id = '" + id + "'";
            }

            else
            {

                komut.CommandText = "select rafOmru from TBL_KIMYASAL_URUNLER WHERE id = '" + id + "'";
            }

            SqlDataReader dr = komut.ExecuteReader();


            while (dr.Read())
            {
                rafOmurleri = dr["rafOmru"].ToString();
            }
            dr.Close();

            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bağlantı kapanırken hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rafOmurleri;
        }

        public void uretimTarihleriniGetirKimyasal()
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
            komut.CommandText = "select id, ureticiId, kimyasalMaddeId, uretimTarihi, stok,(iscilikMaliyeti + birimFiyat) as 'Fiyat' from TBL_URETICI_KIMYASALMADDESTOK";
            SqlDataReader dr = komut.ExecuteReader();

            List<String> idler = new List<String>();
            List<String> kimyasalMaddeId = new List<String>();
            List<String> uretimTarihi = new List<String>();
            List<String> stok = new List<String>();
            List<String> ureticiId = new List<String>();
            List<String> fiyat = new List<String>();
            List<String> rafOmru = new List<String>();
            


            while (dr.Read())
            {
                idler.Add(dr["id"].ToString());
                kimyasalMaddeId.Add(dr["kimyasalMaddeId"].ToString());
                uretimTarihi.Add(dr["uretimTarihi"].ToString());
                stok.Add(dr["stok"].ToString());
                ureticiId.Add(dr["ureticiId"].ToString());
                fiyat.Add(dr["Fiyat"].ToString());
            }

            dr.Close();
            for (int i = 0; i < kimyasalMaddeId.Count; i++)
            {
                rafOmru.Add(rafOmurleri(kimyasalMaddeId[i], "kimyasal"));
            }
            int bugun = Convert.ToInt32(DateTime.Today.Day.ToString());
            int buay = Convert.ToInt32(DateTime.Today.Month.ToString());
            int buyil = Convert.ToInt32(DateTime.Today.Year.ToString());

            int gun, ay, yil;

            for (int i = 0; i < idler.Count; i++)
            {
                gun = Convert.ToInt32(uretimTarihi[i].Substring(0, 2));
                ay = Convert.ToInt32(uretimTarihi[i].Substring(2, 2));
                yil = Convert.ToInt32(uretimTarihi[i].Substring(4));

                int indeks = rafOmru[i].IndexOf(" ");
                int raf = Convert.ToInt32(rafOmru[i].Substring(0, indeks));
                DateTime tarih = Convert.ToDateTime(gun + "/" + ay + "/" + (yil + raf));
                //MessageBox.Show("tarih : " + tarih.ToString());
                int sonuc = DateTime.Compare(DateTime.Now, tarih);
                //MessageBox.Show(sonuc.ToString());

               // MessageBox.Show(buyil + " " + (yil + Convert.ToInt32(rafOmru[i].Substring(0, indeks))).ToString());
                if (sonuc > 0)
                {
                    //string ureticiId, string hammaddeId, string uretimTarihi, int miktar, double maliyet
                    zararlaraEkle(ureticiId[i], kimyasalMaddeId[i], uretimTarihi[i], Convert.ToInt32(stok[i]), Convert.ToDouble(fiyat[i]), "kimyasal");
                    tarihiGeceniSil(idler[i], "kimyasal");

                    string kimyasalAdi = urunAdiGetir(kimyasalMaddeId[i],"kimyasal");
                    string mesaj = uretimTarihi[i] + " tarihli " + stok[i] + " adet " + kimyasalAdi + " isimli kimyasal tarihi geçtiği için stoklardan düşülmüştür.";
                    MessageBox.Show(mesaj, "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public void uretimTarihleriniGetirHammadde()
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
            komut.CommandText = "select id,ureticiId, hammaddeId, stok, maliyet,  uretimTarihi from TBL_URETICI_HAMMADDESTOK";

            List<String> uretimTarihleri = new List<String>();
            List<String> ureticiId = new List<String>();
            List<String> hammadeId = new List<String>();
            List<String> satirId = new List<String>();
            List<String> miktar = new List<String>();
            List<String> maliyet = new List<String>();
            List<String> rafOmru = new List<String>();


            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                uretimTarihleri.Add(dr["uretimTarihi"].ToString());
                ureticiId.Add(dr["ureticiId"].ToString());
                hammadeId.Add(dr["hammaddeId"].ToString());
                satirId.Add(dr["id"].ToString());
                miktar.Add(dr["stok"].ToString());
                maliyet.Add(dr["maliyet"].ToString());
            }
            dr.Close();

            for (int i = 0; i < hammadeId.Count; i++)
            {
                rafOmru.Add(rafOmurleri(hammadeId[i], "hammadde"));
            }

            int bugun = Convert.ToInt32(DateTime.Today.Day.ToString());
            int buay = Convert.ToInt32(DateTime.Today.Month.ToString());
            int buyil = Convert.ToInt32(DateTime.Today.Year.ToString());

            int gun, ay, yil;

            for (int i = 0; i < uretimTarihleri.Count; i++)
            {
                gun = Convert.ToInt32(uretimTarihleri[i].Substring(0, 2));
                ay = Convert.ToInt32(uretimTarihleri[i].Substring(2, 2));
                yil = Convert.ToInt32(uretimTarihleri[i].Substring(4));


                int indeks = rafOmru[i].IndexOf(" ");
                int raf = Convert.ToInt32(rafOmru[i].Substring(0, indeks));

                DateTime tarih = Convert.ToDateTime(gun + "/" + ay + "/" + (yil + raf));
                int sonuc = DateTime.Compare(DateTime.Now, tarih);

                if (sonuc > 0)
                {
                    zararlaraEkle(ureticiId[i], hammadeId[i], uretimTarihleri[i], Convert.ToInt32(miktar[i]), Convert.ToDouble(maliyet[i]), "Hammadde");
                    tarihiGeceniSil(satirId[i], "hammadde");

                    string hammaddeAdi = urunAdiGetir(hammadeId[i], "hammadde");
                    string mesaj = uretimTarihleri[i] + " tarihli " + miktar[i] + " adet " + hammaddeAdi + " isimli hammadde tarihi geçtiği için stoklardan düşülmüştür.";
                    MessageBox.Show(mesaj, "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }

    }
}
