namespace VeriTabani
{
    partial class UreticiHammaddeSatinAl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_ulke = new System.Windows.Forms.RadioButton();
            this.rb_hammadde = new System.Windows.Forms.RadioButton();
            this.rb_sehir = new System.Windows.Forms.RadioButton();
            this.rb_ad = new System.Windows.Forms.RadioButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tedarikci = new System.Windows.Forms.TextBox();
            this.btn_Ekle = new System.Windows.Forms.Button();
            this.rb_hava = new System.Windows.Forms.RadioButton();
            this.rb_kara = new System.Windows.Forms.RadioButton();
            this.txt_ureticiAra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_adet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_fiyat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_odenecek = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(756, 196);
            this.dataGridView1.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_ulke);
            this.groupBox2.Controls.Add(this.rb_hammadde);
            this.groupBox2.Controls.Add(this.rb_sehir);
            this.groupBox2.Controls.Add(this.rb_ad);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_tedarikci);
            this.groupBox2.Location = new System.Drawing.Point(41, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 286);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tedarikçiler";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rb_ulke
            // 
            this.rb_ulke.AutoSize = true;
            this.rb_ulke.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rb_ulke.Location = new System.Drawing.Point(6, 49);
            this.rb_ulke.Name = "rb_ulke";
            this.rb_ulke.Size = new System.Drawing.Size(159, 21);
            this.rb_ulke.TabIndex = 28;
            this.rb_ulke.TabStop = true;
            this.rb_ulke.Text = "Bulunduğu ülkeye göre";
            this.rb_ulke.UseVisualStyleBackColor = true;
            // 
            // rb_hammadde
            // 
            this.rb_hammadde.AutoSize = true;
            this.rb_hammadde.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rb_hammadde.Location = new System.Drawing.Point(223, 49);
            this.rb_hammadde.Name = "rb_hammadde";
            this.rb_hammadde.Size = new System.Drawing.Size(164, 21);
            this.rb_hammadde.TabIndex = 29;
            this.rb_hammadde.TabStop = true;
            this.rb_hammadde.Text = "Hammaddeye göre ara";
            this.rb_hammadde.UseVisualStyleBackColor = true;
            // 
            // rb_sehir
            // 
            this.rb_sehir.AutoSize = true;
            this.rb_sehir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rb_sehir.Location = new System.Drawing.Point(223, 22);
            this.rb_sehir.Name = "rb_sehir";
            this.rb_sehir.Size = new System.Drawing.Size(156, 21);
            this.rb_sehir.TabIndex = 29;
            this.rb_sehir.TabStop = true;
            this.rb_sehir.Text = "Bulunduğu şehire göre";
            this.rb_sehir.UseVisualStyleBackColor = true;
            // 
            // rb_ad
            // 
            this.rb_ad.AutoSize = true;
            this.rb_ad.Checked = true;
            this.rb_ad.Location = new System.Drawing.Point(6, 22);
            this.rb_ad.Name = "rb_ad";
            this.rb_ad.Size = new System.Drawing.Size(89, 21);
            this.rb_ad.TabIndex = 27;
            this.rb_ad.TabStop = true;
            this.rb_ad.Text = "İsme göre";
            this.rb_ad.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 71);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(743, 209);
            this.dataGridView2.TabIndex = 23;
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Location = new System.Drawing.Point(597, 64);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(130, 1);
            this.panel5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(549, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Ara : ";
            // 
            // txt_tedarikci
            // 
            this.txt_tedarikci.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tedarikci.Location = new System.Drawing.Point(597, 48);
            this.txt_tedarikci.Name = "txt_tedarikci";
            this.txt_tedarikci.Size = new System.Drawing.Size(130, 16);
            this.txt_tedarikci.TabIndex = 24;
            this.txt_tedarikci.TextChanged += new System.EventHandler(this.txt_musteriAd_TextChanged);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Ekle.FlatAppearance.BorderSize = 0;
            this.btn_Ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ekle.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Ekle.Location = new System.Drawing.Point(694, 282);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(101, 48);
            this.btn_Ekle.TabIndex = 11;
            this.btn_Ekle.Text = "Satın al";
            this.btn_Ekle.UseVisualStyleBackColor = false;
            this.btn_Ekle.Click += new System.EventHandler(this.button2_Click);
            // 
            // rb_hava
            // 
            this.rb_hava.AutoSize = true;
            this.rb_hava.Location = new System.Drawing.Point(212, 302);
            this.rb_hava.Name = "rb_hava";
            this.rb_hava.Size = new System.Drawing.Size(91, 21);
            this.rb_hava.TabIndex = 17;
            this.rb_hava.Text = "Hava yolu";
            this.rb_hava.UseVisualStyleBackColor = true;
            // 
            // rb_kara
            // 
            this.rb_kara.AutoSize = true;
            this.rb_kara.Checked = true;
            this.rb_kara.Location = new System.Drawing.Point(120, 302);
            this.rb_kara.Name = "rb_kara";
            this.rb_kara.Size = new System.Drawing.Size(86, 21);
            this.rb_kara.TabIndex = 17;
            this.rb_kara.TabStop = true;
            this.rb_kara.Text = "Kara yolu";
            this.rb_kara.UseVisualStyleBackColor = true;
            // 
            // txt_ureticiAra
            // 
            this.txt_ureticiAra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ureticiAra.Location = new System.Drawing.Point(40, 56);
            this.txt_ureticiAra.Name = "txt_ureticiAra";
            this.txt_ureticiAra.Size = new System.Drawing.Size(226, 16);
            this.txt_ureticiAra.TabIndex = 0;
            this.txt_ureticiAra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Aranan üretici";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(41, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 1);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(390, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 1);
            this.panel2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Alınacak adet";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_adet
            // 
            this.txt_adet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_adet.Location = new System.Drawing.Point(389, 311);
            this.txt_adet.Name = "txt_adet";
            this.txt_adet.Size = new System.Drawing.Size(100, 16);
            this.txt_adet.TabIndex = 18;
            this.txt_adet.TextChanged += new System.EventHandler(this.txt_adet_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Kargo türü";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(40, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(70, 1);
            this.panel3.TabIndex = 20;
            // 
            // lbl_fiyat
            // 
            this.lbl_fiyat.AutoSize = true;
            this.lbl_fiyat.Location = new System.Drawing.Point(495, 313);
            this.lbl_fiyat.Name = "lbl_fiyat";
            this.lbl_fiyat.Size = new System.Drawing.Size(46, 17);
            this.lbl_fiyat.TabIndex = 21;
            this.lbl_fiyat.Text = "x ---  =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ödenecek";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.Location = new System.Drawing.Point(560, 302);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(70, 1);
            this.panel4.TabIndex = 20;
            // 
            // lbl_odenecek
            // 
            this.lbl_odenecek.AutoSize = true;
            this.lbl_odenecek.Location = new System.Drawing.Point(575, 311);
            this.lbl_odenecek.Name = "lbl_odenecek";
            this.lbl_odenecek.Size = new System.Drawing.Size(20, 17);
            this.lbl_odenecek.TabIndex = 21;
            this.lbl_odenecek.Text = "---";
            // 
            // UreticiHammaddeSatinAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 650);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_odenecek);
            this.Controls.Add(this.lbl_fiyat);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_adet);
            this.Controls.Add(this.rb_kara);
            this.Controls.Add(this.rb_hava);
            this.Controls.Add(this.btn_Ekle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ureticiAra);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UreticiHammaddeSatinAl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musteriekle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UreticiHammaddeSatinAl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_ulke;
        private System.Windows.Forms.RadioButton rb_sehir;
        private System.Windows.Forms.RadioButton rb_ad;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tedarikci;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_Ekle;
        private System.Windows.Forms.RadioButton rb_hammadde;
        private System.Windows.Forms.RadioButton rb_hava;
        private System.Windows.Forms.RadioButton rb_kara;
        private System.Windows.Forms.TextBox txt_ureticiAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_adet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_fiyat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_odenecek;
    }
}