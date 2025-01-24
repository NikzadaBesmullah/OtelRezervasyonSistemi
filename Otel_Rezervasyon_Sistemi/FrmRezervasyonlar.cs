using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;
using Otel_Rezervasyon_Sistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class FrmRezervasyonlar : Form
    {
        private RezervasyonService rezervasyonService;
        private RezervasyonDomain seciliRezervasyon;
        public FrmRezervasyonlar()
        {
            InitializeComponent();
            ConfigureDataGridView();
            rezervasyonService = new RezervasyonService();
        }
        private MusteriService _musteriService = new MusteriService();
        private OdaService _odaService = new OdaService();
        private RezervasyonService _rezervasyonService = new RezervasyonService();

        private void btnTemizle_Click(object sender, EventArgs e)
        {
        }

        private void comboOdaTipi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmRezervasyonlar_Load(object sender, EventArgs e)
        {
            RezervasyonDao rezervasyonDao = new RezervasyonDao();
            dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
            BosOdalariYukle();
        }
        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;



            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MusteriAd",
                HeaderText = "Müşteri Adı",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MusteriSoyad",
                HeaderText = "Müşteri Soyadı",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OdaNumara",
                HeaderText = "Oda Numarası",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GirisTarihi",
                HeaderText = "Giriş Tarihi",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CikisTarihi",
                HeaderText = "Çıkış Tarihi",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ToplamFiyat",
                HeaderText = "Toplam Fiyat",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void BosOdalariYukle()
        {
            try
            {
                var bosOdalar = _odaService.BosOdalariGetir();

                comboOdaNo.DataSource = null;
                comboOdaNo.DataSource = bosOdalar;
                comboOdaNo.DisplayMember = "OdaNumarasi";
                comboOdaNo.ValueMember = "OdaId";

                if (bosOdalar.Count == 0)
                {
                    MessageBox.Show("Şu anda müsait oda bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalar yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Validasyonlar
                if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
                {
                    MessageBox.Show("Lütfen müşteri bilgilerini eksiksiz giriniz!");
                    return;
                }

                if (comboOdaNo.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir oda seçiniz!");
                    return;
                }

                // 1. Müşteri kaydetme
                var musteri = new Musteri
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Telefon = mskTel.Text
                };
                int musteriId = _musteriService.MusteriEkle(musteri);
                if (musteriId == 0)
                {
                    MessageBox.Show("Müşteri kaydedilemedi!");
                    return;
                }

                // 2. Seçili odayı al
                int secilenOdaId = Convert.ToInt32(comboOdaNo.SelectedValue);

                // 3. Rezervasyon kaydetme
                var rezervasyon = new RezervasyonDomain
                {
                    MusteriId = musteriId,
                    OdaId = secilenOdaId,
                    GirisTarihi = dateGiris.Value,
                    CikisTarihi = dateCikis.Value,
                    ToplamFiyat = decimal.Parse(txtfiyat.Text) * (dateCikis.Value - dateGiris.Value).Days
                };

                if (_rezervasyonService.RezervasyonEkle(rezervasyon))
                {
                    // Rezervasyon başarılı olursa odanın durumunu güncelle
                    _odaService.OdaDurumGuncelle(secilenOdaId, false);
                    MessageBox.Show("Rezervasyon başarıyla oluşturuldu!");

                    // ComboBox'ı güncelle
                    BosOdalariYukle();

                    // Form kontrollerini temizle
                    FormTemizle();
                }
                else
                {
                    MessageBox.Show("Rezervasyon oluşturulamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında bir hata oluştu: " + ex.Message);
            }
            dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
        }


        private void comboOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOdaNo.SelectedItem != null && comboOdaNo.SelectedItem is OdaDomain selectedOda)
            {
                txtfiyat.Text = selectedOda.Fiyat.ToString();
            }
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            FormTemizle();
        }


        private void FormTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mskTel.Clear();
            txtfiyat.Clear();
            dateGiris.Value = DateTime.Now;
            dateCikis.Value = DateTime.Now.AddDays(1);
            BosOdalariYukle(); // ComboBox'ı da yenile

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txtAd.Text = row.Cells[0].Value?.ToString();
                txtSoyad.Text = row.Cells[1].Value?.ToString();
                comboOdaNo.Text = row.Cells[2].Value?.ToString();

                // Tarih dönüşümlerini güvenli şekilde yapalım
                if (DateTime.TryParseExact(row.Cells[3].Value?.ToString(),
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime girisTarihi))
                {
                    dateGiris.Value = girisTarihi;
                }

                if (DateTime.TryParseExact(row.Cells[4].Value?.ToString(),
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime cikisTarihi))
                {
                    dateCikis.Value = cikisTarihi;
                }

                txtfiyat.Text = row.Cells[5].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen güncellenecek müşterinin adını ve soyadını giriniz!");
                return;
            }

            try
            {
                // Validasyonlar
                if (dateGiris.Value >= dateCikis.Value)
                {
                    MessageBox.Show("Giriş tarihi çıkış tarihinden sonra olamaz!");
                    return;
                }

                // Toplam fiyat hesaplama
                decimal gunlukFiyat = decimal.Parse(txtfiyat.Text);
                int gunSayisi = (dateCikis.Value - dateGiris.Value).Days;
                decimal toplamFiyat = gunlukFiyat * gunSayisi;

                // Güncellenecek rezervasyon nesnesini oluştur
                var guncelRezervasyon = new RezervasyonDomain
                {
                    MusteriAd = txtAd.Text.Trim(),
                    MusteriSoyad = txtSoyad.Text.Trim(),
                    OdaNumara = comboOdaNo.Text,
                    GirisTarihi = dateGiris.Value,
                    CikisTarihi = dateCikis.Value,
                    ToplamFiyat = toplamFiyat
                };

                if (_rezervasyonService.RezervasyonGuncelle(guncelRezervasyon))
                {
                    MessageBox.Show($"{txtAd.Text} {txtSoyad.Text} isimli müşterinin rezervasyonu başarıyla güncellendi.");
                    dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
                    FormTemizle();
                }
                else
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu veya belirtilen isimde müşteri bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string musteriAd = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string musteriSoyad = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show($"{musteriAd} {musteriSoyad} için rezervasyonu silmek istediğinize emin misiniz?",
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool silindi = _rezervasyonService.RezervasyonSil(musteriAd, musteriSoyad);

                    if (silindi)
                    {
                        MessageBox.Show("Rezervasyon başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView'i yeniden doldur
                    }
                    else
                    {
                        MessageBox.Show("Rezervasyon silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataGridView1.DataSource = _rezervasyonService.GetAllRezervasyonlar();
        }
    }
}








