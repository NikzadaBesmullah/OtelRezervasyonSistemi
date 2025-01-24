using Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public  class MusteriDao
    {
        Baglanti bgl = new Baglanti();  
        
       
        public void Musteri_Kaydet( Domain_Musteri p)
        {
            MySqlCommand Kaydet = new MySqlCommand("insert into Tbl_Musteri (Musteri_Ad,Musteri_Soyad,Musteri_Telefon,Musteri_Sifre,Musteri_Tc) values (@p1,@p2,@p3,@p4,@p5 ",bgl.dbBaglanti());
            Kaydet.Parameters.AddWithValue("@p1", p.AD);
            Kaydet.Parameters.AddWithValue("@p2", p.SOYAD);
            Kaydet.Parameters.AddWithValue("@p3", p.TELEFON);
            Kaydet.Parameters.AddWithValue("@p4", p.SIFRE);
            Kaydet.Parameters.AddWithValue("@p5", p.TC);

        }
    }
}
