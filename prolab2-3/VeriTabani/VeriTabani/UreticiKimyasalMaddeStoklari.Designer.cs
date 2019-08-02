namespace VeriTabani
{
    partial class UreticiKimyasalMaddeStoklari
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_kimyasal = new System.Windows.Forms.TextBox();
            this.combo_uretici = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_fiyat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_iscilik = new System.Windows.Forms.TextBox();
            this.chk_guncelle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Aranan üretici";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(529, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 1);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(730, 242);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // txt_kimyasal
            // 
            this.txt_kimyasal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_kimyasal.Location = new System.Drawing.Point(528, 59);
            this.txt_kimyasal.Name = "txt_kimyasal";
            this.txt_kimyasal.Size = new System.Drawing.Size(225, 16);
            this.txt_kimyasal.TabIndex = 0;
            this.txt_kimyasal.TextChanged += new System.EventHandler(this.txt_musteriAd_TextChanged);
            // 
            // combo_uretici
            // 
            this.combo_uretici.FormattingEnabled = true;
            this.combo_uretici.Location = new System.Drawing.Point(24, 56);
            this.combo_uretici.Name = "combo_uretici";
            this.combo_uretici.Size = new System.Drawing.Size(260, 25);
            this.combo_uretici.TabIndex = 14;
            this.combo_uretici.SelectedIndexChanged += new System.EventHandler(this.combo_tedarikci_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aranan kimyasal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_guncelle);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.txt_fiyat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_iscilik);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(24, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güncelle";
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_guncelle.FlatAppearance.BorderSize = 0;
            this.btn_guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guncelle.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_guncelle.Location = new System.Drawing.Point(480, 33);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(204, 43);
            this.btn_guncelle.TabIndex = 32;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.UseVisualStyleBackColor = false;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(193, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 1);
            this.panel3.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fiyat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(71, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 1);
            this.panel2.TabIndex = 26;
            // 
            // txt_fiyat
            // 
            this.txt_fiyat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fiyat.Location = new System.Drawing.Point(192, 57);
            this.txt_fiyat.Name = "txt_fiyat";
            this.txt_fiyat.Size = new System.Drawing.Size(100, 16);
            this.txt_fiyat.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "işçilik";
            // 
            // txt_iscilik
            // 
            this.txt_iscilik.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_iscilik.Location = new System.Drawing.Point(70, 57);
            this.txt_iscilik.Name = "txt_iscilik";
            this.txt_iscilik.Size = new System.Drawing.Size(100, 16);
            this.txt_iscilik.TabIndex = 24;
            // 
            // chk_guncelle
            // 
            this.chk_guncelle.AutoSize = true;
            this.chk_guncelle.Location = new System.Drawing.Point(24, 341);
            this.chk_guncelle.Name = "chk_guncelle";
            this.chk_guncelle.Size = new System.Drawing.Size(150, 21);
            this.chk_guncelle.TabIndex = 16;
            this.chk_guncelle.Text = "Seçili satırı güncelle";
            this.chk_guncelle.UseVisualStyleBackColor = true;
            this.chk_guncelle.CheckedChanged += new System.EventHandler(this.chk_guncelle_CheckedChanged);
            // 
            // UreticiKimyasalMaddeStoklari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 492);
            this.Controls.Add(this.chk_guncelle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.combo_uretici);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_kimyasal);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UreticiKimyasalMaddeStoklari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musteriekle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UreticiKimyasalMaddeStoklari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_kimyasal;
        private System.Windows.Forms.ComboBox combo_uretici;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_fiyat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_iscilik;
        private System.Windows.Forms.CheckBox chk_guncelle;
        private System.Windows.Forms.Button btn_guncelle;
    }
}