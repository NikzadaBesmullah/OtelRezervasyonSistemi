namespace Otel_Rezervasyon_Sistemi
{
    partial class Frmodalar
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
            this.comboNumara = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.ComboDurum = new System.Windows.Forms.ComboBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboTip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboNumara
            // 
            this.comboNumara.FormattingEnabled = true;
            this.comboNumara.Location = new System.Drawing.Point(179, 62);
            this.comboNumara.Name = "comboNumara";
            this.comboNumara.Size = new System.Drawing.Size(121, 36);
            this.comboNumara.TabIndex = 2;
            this.comboNumara.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oda Numara:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblid);
            this.groupBox1.Controls.Add(this.txtFiyat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.ComboDurum);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ComboTip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboNumara);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 367);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Oda Ekleme/Silme";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(164, 31);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(54, 28);
            this.lblid.TabIndex = 6;
            this.lblid.Text = ".......";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(179, 219);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(121, 35);
            this.txtFiyat.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Oda Fiyat:";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(30, 321);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(276, 41);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sİl";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // ComboDurum
            // 
            this.ComboDurum.FormattingEnabled = true;
            this.ComboDurum.Items.AddRange(new object[] {
            "0",
            "1"});
            this.ComboDurum.Location = new System.Drawing.Point(179, 164);
            this.ComboDurum.Name = "ComboDurum";
            this.ComboDurum.Size = new System.Drawing.Size(121, 36);
            this.ComboDurum.TabIndex = 9;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(179, 265);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(127, 41);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Oda Durum:";
            // 
            // ComboTip
            // 
            this.ComboTip.FormattingEnabled = true;
            this.ComboTip.Items.AddRange(new object[] {
            "1 Kişilik",
            "2 Kişilik"});
            this.ComboTip.Location = new System.Drawing.Point(179, 116);
            this.ComboTip.Name = "ComboTip";
            this.ComboTip.Size = new System.Drawing.Size(121, 36);
            this.ComboTip.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oda Türü:";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(30, 265);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(127, 41);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(372, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(451, 367);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Frmodalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(854, 468);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "Frmodalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmodalar";
            this.Load += new System.EventHandler(this.Frmodalar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboNumara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.ComboBox ComboDurum;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label label5;
    }
}