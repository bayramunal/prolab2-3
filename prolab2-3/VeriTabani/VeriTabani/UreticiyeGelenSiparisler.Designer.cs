namespace VeriTabani
{
    partial class UreticiyeGelenSiparisler
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
            this.combo_uretici = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_onayla = new System.Windows.Forms.Button();
            this.txt_hammaddeAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_kar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_uretici
            // 
            this.combo_uretici.FormattingEnabled = true;
            this.combo_uretici.Location = new System.Drawing.Point(33, 62);
            this.combo_uretici.Name = "combo_uretici";
            this.combo_uretici.Size = new System.Drawing.Size(260, 25);
            this.combo_uretici.TabIndex = 26;
            this.combo_uretici.SelectedIndexChanged += new System.EventHandler(this.combo_uretici_SelectedIndexChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(730, 242);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Üreticiler";
            // 
            // btn_onayla
            // 
            this.btn_onayla.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_onayla.FlatAppearance.BorderSize = 0;
            this.btn_onayla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_onayla.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_onayla.Location = new System.Drawing.Point(480, 341);
            this.btn_onayla.Name = "btn_onayla";
            this.btn_onayla.Size = new System.Drawing.Size(282, 43);
            this.btn_onayla.TabIndex = 29;
            this.btn_onayla.Text = "Siparişi onayla";
            this.btn_onayla.UseVisualStyleBackColor = false;
            this.btn_onayla.Click += new System.EventHandler(this.btn_onayla_Click);
            // 
            // txt_hammaddeAdi
            // 
            this.txt_hammaddeAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_hammaddeAdi.Location = new System.Drawing.Point(537, 65);
            this.txt_hammaddeAdi.Name = "txt_hammaddeAdi";
            this.txt_hammaddeAdi.Size = new System.Drawing.Size(225, 16);
            this.txt_hammaddeAdi.TabIndex = 21;
            this.txt_hammaddeAdi.TextChanged += new System.EventHandler(this.txt_hammaddeAdi_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Kimyasal ara";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(538, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 1);
            this.panel1.TabIndex = 24;
            // 
            // combo_kar
            // 
            this.combo_kar.FormattingEnabled = true;
            this.combo_kar.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.combo_kar.Location = new System.Drawing.Point(33, 359);
            this.combo_kar.Name = "combo_kar";
            this.combo_kar.Size = new System.Drawing.Size(159, 25);
            this.combo_kar.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Kar oranını seçiniz";
            // 
            // UreticiyeGelenSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_kar);
            this.Controls.Add(this.btn_onayla);
            this.Controls.Add(this.combo_uretici);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_hammaddeAdi);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UreticiyeGelenSiparisler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siparişi onayla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UreticiyeGelenSiparisler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_uretici;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_onayla;
        private System.Windows.Forms.TextBox txt_hammaddeAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_kar;
        private System.Windows.Forms.Label label3;
    }
}