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
using Otel_Rezervasyon_Sistemi.Service;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class FrmYoneticiGiris : Form
    {
        public FrmYoneticiGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new YoneticiService()).Yonetici(txtAd.Text,txtSifre.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmYoneticiSifreYenile f = new FrmYoneticiSifreYenile();
            f.Show();
            
        }
    }
}
