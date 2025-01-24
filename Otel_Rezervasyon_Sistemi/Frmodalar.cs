using Otel_Rezervasyon_Sistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;
using Mysqlx.Datatypes;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class Frmodalar : Form
    {
        public Frmodalar()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        private OdaService _odaService = new OdaService();
        private OdaDomain _secilenOda;

        private void button1_Click(object sender, EventArgs e)
        {

            OdaDomain newOda = new OdaDomain
            {
                OdaNumarasi = comboNumara.Text,
                Fiyat = decimal.Parse(txtFiyat.Text),
                Durum = ComboDurum.Text,
                OdaTipi = ComboTip.SelectedItem?.ToString() ?? "Standart"
            };

            int odaId = _odaService.AddOda(newOda);
            if (odaId > 0)
            {
                MessageBox.Show($"Oda başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Oda eklenirken bir hata oluştu.");
            }
            OdaDao odaDao = new OdaDao();
            List<OdaDomain> odalar = odaDao.odalarıgoruntele();

            dataGridView1.DataSource = odalar;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblid.Text, out int odaId) || odaId <= 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir oda seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OdaDomain guncellenecekOda = new OdaDomain
                {
                    OdaId = odaId, // ID'yi lblOdaId'den al
                    OdaNumarasi = comboNumara.Text,
                    Fiyat = decimal.Parse(txtFiyat.Text),
                    Durum = ComboDurum.Text,
                    OdaTipi = ComboTip.SelectedItem?.ToString() ?? "Standart"
                };

                if (_odaService.Guncelle(guncellenecekOda))
                {
                    MessageBox.Show("Oda başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oda güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            OdaDao odaDao = new OdaDao();
            List<OdaDomain> odalar = odaDao.odalarıgoruntele();

            dataGridView1.DataSource = odalar;
        }






        private void comboBoxOda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnListele_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir oda seçin.");
                return;
            }

            int odaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Odaid"].Value);

            DialogResult result = MessageBox.Show(
                $"{odaId} ID'li odayı silmek istediğinizden emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool silmeSonucu = _odaService.OdaSil(odaId);

                if (silmeSonucu)
                {
                    MessageBox.Show("Oda başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Oda silinemedi. Lütfen tekrar deneyin.");
                }
            }
            OdaDao odaDao = new OdaDao();
            List<OdaDomain> odalar = odaDao.odalarıgoruntele();

            dataGridView1.DataSource = odalar;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frmodalar_Load(object sender, EventArgs e)
        {
            OdaDao odaDao = new OdaDao();
            List<OdaDomain> odalar = odaDao.odalarıgoruntele();

            dataGridView1.DataSource = odalar;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            lblid.Text = selectedRow.Cells[0].Value.ToString();
            comboNumara.Text = selectedRow.Cells[1].Value.ToString();
            ComboTip.Text = selectedRow.Cells[2].Value.ToString();
            ComboDurum.Text = selectedRow.Cells[4].Value.ToString();
            txtFiyat.Text = selectedRow.Cells[3].Value.ToString();
        }
    }
}
