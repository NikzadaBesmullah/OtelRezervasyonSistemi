namespace Otel_Rezervasyon_Sistemi
{
    partial class FrmRezervasyonlar
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
            this.txtAd = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mskTel = new System.Windows.Forms.MaskedTextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateGiris = new System.Windows.Forms.DateTimePicker();
            this.dateCikis = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.txtfiyat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboOdaNo = new System.Windows.Forms.ComboBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(222, 46);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(182, 35);
            this.txtAd.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEkle.Location = new System.Drawing.Point(917, 7);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(117, 70);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Kayıt";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telefon Numarası:";
            // 
            // mskTel
            // 
            this.mskTel.Location = new System.Drawing.Point(222, 145);
            this.mskTel.Mask = "00000000000";
            this.mskTel.Name = "mskTel";
            this.mskTel.Size = new System.Drawing.Size(182, 35);
            this.mskTel.TabIndex = 3;
            this.mskTel.ValidatingType = typeof(int);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Location = new System.Drawing.Point(917, 159);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(117, 68);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGuncelle.Location = new System.Drawing.Point(917, 80);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(117, 73);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Giriş Tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Çıkış Tarihi:";
            // 
            // dateGiris
            // 
            this.dateGiris.Location = new System.Drawing.Point(193, 49);
            this.dateGiris.Name = "dateGiris";
            this.dateGiris.Size = new System.Drawing.Size(182, 35);
            this.dateGiris.TabIndex = 4;
            // 
            // dateCikis
            // 
            this.dateCikis.Location = new System.Drawing.Point(193, 90);
            this.dateCikis.Name = "dateCikis";
            this.dateCikis.Size = new System.Drawing.Size(182, 35);
            this.dateCikis.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 367);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Oda No:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoyad);
            this.groupBox1.Controls.Add(this.mskTel);
            this.groupBox1.Controls.Add(this.txtAd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 291);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kişisel Bilgiler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(222, 100);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(182, 35);
            this.txtSoyad.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboTip);
            this.groupBox2.Controls.Add(this.txtfiyat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboOdaNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateCikis);
            this.groupBox2.Controls.Add(this.dateGiris);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(468, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 291);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rezervasyon Bilgileri";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "Fiyat:";
            // 
            // comboTip
            // 
            this.comboTip.FormattingEnabled = true;
            this.comboTip.Items.AddRange(new object[] {
            "Bir Kişilik",
            "Çift Kişilik"});
            this.comboTip.Location = new System.Drawing.Point(193, 139);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(182, 36);
            this.comboTip.TabIndex = 6;
            // 
            // txtfiyat
            // 
            this.txtfiyat.Location = new System.Drawing.Point(193, 226);
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Size = new System.Drawing.Size(182, 35);
            this.txtfiyat.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "Oda Tipi:";
            // 
            // comboOdaNo
            // 
            this.comboOdaNo.FormattingEnabled = true;
            this.comboOdaNo.Items.AddRange(new object[] {
            "101",
            "102",
            "201",
            "202",
            "301",
            "302"});
            this.comboOdaNo.Location = new System.Drawing.Point(193, 184);
            this.comboOdaNo.Name = "comboOdaNo";
            this.comboOdaNo.Size = new System.Drawing.Size(182, 36);
            this.comboOdaNo.TabIndex = 7;
            this.comboOdaNo.SelectedIndexChanged += new System.EventHandler(this.comboOdaTipi_SelectedIndexChanged);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnTemizle.Location = new System.Drawing.Point(917, 236);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(117, 68);
            this.btnTemizle.TabIndex = 20;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click_1);
            // 
            // FrmRezervasyonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1059, 719);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnSil);
            this.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmRezervasyonlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "x";
            this.Load += new System.EventHandler(this.FrmRezervasyonlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskTel;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateGiris;
        private System.Windows.Forms.DateTimePicker dateCikis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboOdaNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtfiyat;
        private System.Windows.Forms.Button btnTemizle;
    }
}