using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Domain;

namespace Otel_Rezervasyon_Sistemi.Dal
{
    public class YoneticiDao
    {
        baglanti bgl = new baglanti();  

        public void YoneticiGiris(string ad,string sifre)
        {
            //YoneticiDomain d = new YoneticiDomain();
            MySqlCommand k = new MySqlCommand("select * from Tbl_Yonetici where YoneticiTc=@p1 and YoneticiSifre=@p2", bgl.dbbaglanti());
            k.Parameters.AddWithValue("@p1",ad);
            k.Parameters.AddWithValue("@p2", sifre);
            k.ExecuteNonQuery();
           MySqlDataReader dr = k.ExecuteReader();
            if (dr.Read())
            { 
                FrmYoneticiAnaSayfa frm= new FrmYoneticiAnaSayfa();
                frm.Show();
            }
            else
            {
                MessageBox.Show("HATALI ŞİFRRE VEYA KULLANICI ADI GİRDİNİZ");
            }
            
        }
        public void YSifreYenile(string s,string a)
        {
            MySqlCommand k1 = new MySqlCommand("update Tbl_Yonetici set YoneticiSifre=@s where YoneticiTc=@a",bgl.dbbaglanti());
            k1.Parameters.AddWithValue("@s", s);
            k1.Parameters.AddWithValue("@a",a);
            k1.ExecuteNonQuery();
            MessageBox.Show("ŞİFRENİZ BAŞARIYLA DEĞİŞTİRİLMİŞTİR");
        }
    }
}
