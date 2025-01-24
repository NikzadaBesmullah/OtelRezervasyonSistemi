using Otel_Rezervasyon_Sistemi.Domain;
using Otel_Rezervasyon_Sistemi.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        private MusteriService musteriService = new MusteriService();

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            List<Musteri> musteriler = musteriService.GetAllMusteriler();

            dataGridView1.DataSource = musteriler;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            string searchText = textBox1.Text.ToLower().Trim();

            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if (row.IsNewRow) continue;

                bool isMatch = false;
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[j].Value != null &&
                        row.Cells[j].Value.ToString().ToLower().Contains(searchText))
                    {
                        isMatch = true;
                        break;
                    }
                }

                row.Visible = isMatch;
            }

            dataGridView1.Refresh();
        }
    }
    }


