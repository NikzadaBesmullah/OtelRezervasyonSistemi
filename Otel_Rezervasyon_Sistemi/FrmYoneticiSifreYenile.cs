using Otel_Rezervasyon_Sistemi.Dal;
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

namespace Otel_Rezervasyon_Sistemi
{
    public partial class FrmYoneticiSifreYenile : Form
    {
        public FrmYoneticiSifreYenile()
        {
            InitializeComponent();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            (new YoneticiService()).YoneticiSifre(txtSifre.Text,txtAd.Text);
        }
    }
}
