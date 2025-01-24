
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
    public partial class FrmYoneticiAnaSayfa : Form
    {
        public FrmYoneticiAnaSayfa()
        {
            InitializeComponent();
        }
        OdaService oda = new OdaService();
        MusteriService musteriService = new MusteriService();
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void FrmYoneticiAnaSayfa_Load(object sender, EventArgs e)
        {
            OdalariSay();
            ToplamMusteriSayisiniGoster();

        }
        private void OdalariSay()
        {
            try
            {
                int doluSayisi = oda.GetDoluOdaSayisi();
                int bosSayisi = oda.GetBosOdaSayisi();

                label9.Text = doluSayisi.ToString();
                label8.Text = bosSayisi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void ToplamMusteriSayisiniGoster()
        {
            
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrmRezervasyonlar FrmRez = new FrmRezervasyonlar();
            FrmRez.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMusteriler f = new FrmMusteriler();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmodalar frmodalar = new Frmodalar();
            frmodalar.Show();
        }

        private void btnCiikis_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
