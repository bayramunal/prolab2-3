namespace VeriTabani
{
    partial class AnaEkran
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.müşteriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kimyasalÜrünSiparişiVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçiİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçiHammaddeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürettiğiHammaddeleriListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammaddeSatışlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üreticiİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üreticiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammaddeSatınAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoklarınıGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üreticiyeGelenSiparişlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karOranlarınıGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veriTabanıTablolarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLHAMMADDELERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLKIMYASALURUNBILGIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLKIMYASALURUNLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLMUSTERIKMSIPARISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLMUSTERILERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLTEDARIKCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLURETICIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBLURETICITEDARIKCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriİşlemleriToolStripMenuItem,
            this.tedarikçiİşlemleriToolStripMenuItem,
            this.üreticiİşlemleriToolStripMenuItem,
            this.veriTabanıTablolarıToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // müşteriİşlemleriToolStripMenuItem
            // 
            this.müşteriİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriEkleToolStripMenuItem,
            this.kimyasalÜrünSiparişiVerToolStripMenuItem});
            this.müşteriİşlemleriToolStripMenuItem.Name = "müşteriİşlemleriToolStripMenuItem";
            this.müşteriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.müşteriİşlemleriToolStripMenuItem.Text = "Müşteri İşlemleri";
            this.müşteriİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.müşteriİşlemleriToolStripMenuItem_Click);
            // 
            // müşteriEkleToolStripMenuItem
            // 
            this.müşteriEkleToolStripMenuItem.Name = "müşteriEkleToolStripMenuItem";
            this.müşteriEkleToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.müşteriEkleToolStripMenuItem.Text = "Müşteri Ekle";
            this.müşteriEkleToolStripMenuItem.Click += new System.EventHandler(this.müşteriEkleToolStripMenuItem_Click);
            // 
            // kimyasalÜrünSiparişiVerToolStripMenuItem
            // 
            this.kimyasalÜrünSiparişiVerToolStripMenuItem.Name = "kimyasalÜrünSiparişiVerToolStripMenuItem";
            this.kimyasalÜrünSiparişiVerToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.kimyasalÜrünSiparişiVerToolStripMenuItem.Text = "Kimyasal Ürün Siparişi Ver";
            this.kimyasalÜrünSiparişiVerToolStripMenuItem.Click += new System.EventHandler(this.kimyasalÜrünSiparişiVerToolStripMenuItem_Click);
            // 
            // tedarikçiİşlemleriToolStripMenuItem
            // 
            this.tedarikçiİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tedarikçiEkleToolStripMenuItem,
            this.tedarikçiHammaddeEkleToolStripMenuItem,
            this.ürettiğiHammaddeleriListeleToolStripMenuItem,
            this.hammaddeSatışlarıToolStripMenuItem});
            this.tedarikçiİşlemleriToolStripMenuItem.Name = "tedarikçiİşlemleriToolStripMenuItem";
            this.tedarikçiİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.tedarikçiİşlemleriToolStripMenuItem.Text = "Tedarikçi İşlemleri";
            // 
            // tedarikçiEkleToolStripMenuItem
            // 
            this.tedarikçiEkleToolStripMenuItem.Name = "tedarikçiEkleToolStripMenuItem";
            this.tedarikçiEkleToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.tedarikçiEkleToolStripMenuItem.Text = "Tedarikçi Ekle";
            this.tedarikçiEkleToolStripMenuItem.Click += new System.EventHandler(this.tedarikçiEkleToolStripMenuItem_Click);
            // 
            // tedarikçiHammaddeEkleToolStripMenuItem
            // 
            this.tedarikçiHammaddeEkleToolStripMenuItem.Name = "tedarikçiHammaddeEkleToolStripMenuItem";
            this.tedarikçiHammaddeEkleToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.tedarikçiHammaddeEkleToolStripMenuItem.Text = "Hammadde Üret";
            this.tedarikçiHammaddeEkleToolStripMenuItem.Click += new System.EventHandler(this.tedarikçiHammaddeEkleToolStripMenuItem_Click);
            // 
            // ürettiğiHammaddeleriListeleToolStripMenuItem
            // 
            this.ürettiğiHammaddeleriListeleToolStripMenuItem.Name = "ürettiğiHammaddeleriListeleToolStripMenuItem";
            this.ürettiğiHammaddeleriListeleToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ürettiğiHammaddeleriListeleToolStripMenuItem.Text = "Hammadde Stoklarını Göster";
            this.ürettiğiHammaddeleriListeleToolStripMenuItem.Click += new System.EventHandler(this.ürettiğiHammaddeleriListeleToolStripMenuItem_Click);
            // 
            // hammaddeSatışlarıToolStripMenuItem
            // 
            this.hammaddeSatışlarıToolStripMenuItem.Name = "hammaddeSatışlarıToolStripMenuItem";
            this.hammaddeSatışlarıToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.hammaddeSatışlarıToolStripMenuItem.Text = "Hammadde Satışları";
            this.hammaddeSatışlarıToolStripMenuItem.Click += new System.EventHandler(this.hammaddeSatışlarıToolStripMenuItem_Click);
            // 
            // üreticiİşlemleriToolStripMenuItem
            // 
            this.üreticiİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.üreticiEkleToolStripMenuItem,
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem,
            this.hammaddeSatınAlToolStripMenuItem,
            this.stoklarınıGösterToolStripMenuItem,
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem,
            this.üreticiyeGelenSiparişlerToolStripMenuItem,
            this.karOranlarınıGösterToolStripMenuItem});
            this.üreticiİşlemleriToolStripMenuItem.Name = "üreticiİşlemleriToolStripMenuItem";
            this.üreticiİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.üreticiİşlemleriToolStripMenuItem.Text = "Üretici İşlemleri";
            // 
            // üreticiEkleToolStripMenuItem
            // 
            this.üreticiEkleToolStripMenuItem.Name = "üreticiEkleToolStripMenuItem";
            this.üreticiEkleToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.üreticiEkleToolStripMenuItem.Text = "Üretici Ekle";
            this.üreticiEkleToolStripMenuItem.Click += new System.EventHandler(this.üreticiEkleToolStripMenuItem_Click);
            // 
            // üreticiyeKimyasalMaddeEkleToolStripMenuItem
            // 
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem.Name = "üreticiyeKimyasalMaddeEkleToolStripMenuItem";
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem.Text = "Kimyasal Madde Üret";
            this.üreticiyeKimyasalMaddeEkleToolStripMenuItem.Click += new System.EventHandler(this.üreticiyeKimyasalMaddeEkleToolStripMenuItem_Click);
            // 
            // hammaddeSatınAlToolStripMenuItem
            // 
            this.hammaddeSatınAlToolStripMenuItem.Name = "hammaddeSatınAlToolStripMenuItem";
            this.hammaddeSatınAlToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.hammaddeSatınAlToolStripMenuItem.Text = "Hammadde Satın Al";
            this.hammaddeSatınAlToolStripMenuItem.Click += new System.EventHandler(this.hammaddeSatınAlToolStripMenuItem_Click);
            // 
            // stoklarınıGösterToolStripMenuItem
            // 
            this.stoklarınıGösterToolStripMenuItem.Name = "stoklarınıGösterToolStripMenuItem";
            this.stoklarınıGösterToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.stoklarınıGösterToolStripMenuItem.Text = "Hammadde Stoklarını Göster";
            this.stoklarınıGösterToolStripMenuItem.Click += new System.EventHandler(this.stoklarınıGösterToolStripMenuItem_Click);
            // 
            // kimyasalÜrünStoklarınıGösterToolStripMenuItem
            // 
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem.Name = "kimyasalÜrünStoklarınıGösterToolStripMenuItem";
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem.Text = "Kimyasal Ürün Stoklarını Göster";
            this.kimyasalÜrünStoklarınıGösterToolStripMenuItem.Click += new System.EventHandler(this.kimyasalÜrünStoklarınıGösterToolStripMenuItem_Click);
            // 
            // üreticiyeGelenSiparişlerToolStripMenuItem
            // 
            this.üreticiyeGelenSiparişlerToolStripMenuItem.Name = "üreticiyeGelenSiparişlerToolStripMenuItem";
            this.üreticiyeGelenSiparişlerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.üreticiyeGelenSiparişlerToolStripMenuItem.Text = "Üreticiye Gelen Siparişler";
            this.üreticiyeGelenSiparişlerToolStripMenuItem.Click += new System.EventHandler(this.üreticiyeGelenSiparişlerToolStripMenuItem_Click);
            // 
            // karOranlarınıGösterToolStripMenuItem
            // 
            this.karOranlarınıGösterToolStripMenuItem.Name = "karOranlarınıGösterToolStripMenuItem";
            this.karOranlarınıGösterToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.karOranlarınıGösterToolStripMenuItem.Text = "Kar Oranlarını Göster";
            this.karOranlarınıGösterToolStripMenuItem.Click += new System.EventHandler(this.karOranlarınıGösterToolStripMenuItem_Click);
            // 
            // veriTabanıTablolarıToolStripMenuItem
            // 
            this.veriTabanıTablolarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBLHAMMADDELERToolStripMenuItem,
            this.tBLKIMYASALURUNBILGIToolStripMenuItem,
            this.tBLKIMYASALURUNLERToolStripMenuItem,
            this.tBLMUSTERIKMSIPARISToolStripMenuItem,
            this.tBLMUSTERILERToolStripMenuItem,
            this.tBLTEDARIKCIToolStripMenuItem,
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem,
            this.tBLURETICIToolStripMenuItem,
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem,
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem,
            this.tBLURETICITEDARIKCIToolStripMenuItem});
            this.veriTabanıTablolarıToolStripMenuItem.Name = "veriTabanıTablolarıToolStripMenuItem";
            this.veriTabanıTablolarıToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.veriTabanıTablolarıToolStripMenuItem.Text = "Veri tabanı tabloları";
            // 
            // tBLHAMMADDELERToolStripMenuItem
            // 
            this.tBLHAMMADDELERToolStripMenuItem.Name = "tBLHAMMADDELERToolStripMenuItem";
            this.tBLHAMMADDELERToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLHAMMADDELERToolStripMenuItem.Text = "TBL_HAMMADDELER";
            this.tBLHAMMADDELERToolStripMenuItem.Click += new System.EventHandler(this.tBLHAMMADDELERToolStripMenuItem_Click);
            // 
            // tBLKIMYASALURUNBILGIToolStripMenuItem
            // 
            this.tBLKIMYASALURUNBILGIToolStripMenuItem.Name = "tBLKIMYASALURUNBILGIToolStripMenuItem";
            this.tBLKIMYASALURUNBILGIToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLKIMYASALURUNBILGIToolStripMenuItem.Text = "TBL_KIMYASAL_URUN_BILGI";
            this.tBLKIMYASALURUNBILGIToolStripMenuItem.Click += new System.EventHandler(this.tBLKIMYASALURUNBILGIToolStripMenuItem_Click);
            // 
            // tBLKIMYASALURUNLERToolStripMenuItem
            // 
            this.tBLKIMYASALURUNLERToolStripMenuItem.Name = "tBLKIMYASALURUNLERToolStripMenuItem";
            this.tBLKIMYASALURUNLERToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLKIMYASALURUNLERToolStripMenuItem.Text = "TBL_KIMYASAL_URUNLER";
            this.tBLKIMYASALURUNLERToolStripMenuItem.Click += new System.EventHandler(this.tBLKIMYASALURUNLERToolStripMenuItem_Click);
            // 
            // tBLMUSTERIKMSIPARISToolStripMenuItem
            // 
            this.tBLMUSTERIKMSIPARISToolStripMenuItem.Name = "tBLMUSTERIKMSIPARISToolStripMenuItem";
            this.tBLMUSTERIKMSIPARISToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLMUSTERIKMSIPARISToolStripMenuItem.Text = "TBL_MUSTERI_KM_SIPARIS";
            this.tBLMUSTERIKMSIPARISToolStripMenuItem.Click += new System.EventHandler(this.tBLMUSTERIKMSIPARISToolStripMenuItem_Click);
            // 
            // tBLMUSTERILERToolStripMenuItem
            // 
            this.tBLMUSTERILERToolStripMenuItem.Name = "tBLMUSTERILERToolStripMenuItem";
            this.tBLMUSTERILERToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLMUSTERILERToolStripMenuItem.Text = "TBL_MUSTERILER";
            this.tBLMUSTERILERToolStripMenuItem.Click += new System.EventHandler(this.tBLMUSTERILERToolStripMenuItem_Click);
            // 
            // tBLTEDARIKCIToolStripMenuItem
            // 
            this.tBLTEDARIKCIToolStripMenuItem.Name = "tBLTEDARIKCIToolStripMenuItem";
            this.tBLTEDARIKCIToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLTEDARIKCIToolStripMenuItem.Text = "TBL_TEDARIKCI";
            this.tBLTEDARIKCIToolStripMenuItem.Click += new System.EventHandler(this.tBLTEDARIKCIToolStripMenuItem_Click);
            // 
            // tBLTEDARIKCIHAMMADDEToolStripMenuItem
            // 
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem.Name = "tBLTEDARIKCIHAMMADDEToolStripMenuItem";
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem.Text = "TBL_TEDARIKCI_HAMMADDE";
            this.tBLTEDARIKCIHAMMADDEToolStripMenuItem.Click += new System.EventHandler(this.tBLTEDARIKCIHAMMADDEToolStripMenuItem_Click);
            // 
            // tBLURETICIToolStripMenuItem
            // 
            this.tBLURETICIToolStripMenuItem.Name = "tBLURETICIToolStripMenuItem";
            this.tBLURETICIToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLURETICIToolStripMenuItem.Text = "TBL_URETICI";
            this.tBLURETICIToolStripMenuItem.Click += new System.EventHandler(this.tBLURETICIToolStripMenuItem_Click);
            // 
            // tBLURETICIHAMMADDESTOKToolStripMenuItem
            // 
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem.Name = "tBLURETICIHAMMADDESTOKToolStripMenuItem";
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem.Text = "TBL_URETICI_HAMMADDESTOK";
            this.tBLURETICIHAMMADDESTOKToolStripMenuItem.Click += new System.EventHandler(this.tBLURETICIHAMMADDESTOKToolStripMenuItem_Click);
            // 
            // tBLURETICIKIMYASALMADDESTOKToolStripMenuItem
            // 
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem.Name = "tBLURETICIKIMYASALMADDESTOKToolStripMenuItem";
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem.Text = "TBL_URETICI_KIMYASALMADDESTOK";
            this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem.Click += new System.EventHandler(this.tBLURETICIKIMYASALMADDESTOKToolStripMenuItem_Click);
            // 
            // tBLURETICITEDARIKCIToolStripMenuItem
            // 
            this.tBLURETICITEDARIKCIToolStripMenuItem.Name = "tBLURETICITEDARIKCIToolStripMenuItem";
            this.tBLURETICITEDARIKCIToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.tBLURETICITEDARIKCIToolStripMenuItem.Text = "TBL_URETICI_TEDARIKCI";
            this.tBLURETICITEDARIKCIToolStripMenuItem.Click += new System.EventHandler(this.tBLURETICITEDARIKCIToolStripMenuItem_Click);
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 749);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "AnaEkran";
            this.Text = "AnaEkran";
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem müşteriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müşteriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kimyasalÜrünSiparişiVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikçiİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikçiEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tedarikçiHammaddeEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üreticiİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürettiğiHammaddeleriListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üreticiEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üreticiyeKimyasalMaddeEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammaddeSatınAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoklarınıGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kimyasalÜrünStoklarınıGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üreticiyeGelenSiparişlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karOranlarınıGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammaddeSatışlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veriTabanıTablolarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLHAMMADDELERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLKIMYASALURUNBILGIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLKIMYASALURUNLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLMUSTERIKMSIPARISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLMUSTERILERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLTEDARIKCIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLTEDARIKCIHAMMADDEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLURETICIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLURETICIHAMMADDESTOKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLURETICIKIMYASALMADDESTOKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBLURETICITEDARIKCIToolStripMenuItem;
    }
}



