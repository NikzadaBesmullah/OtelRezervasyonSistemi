using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;

namespace Otel_Rezervasyon_Sistemi.Service
{
    public class YoneticiService
    {
        public void Yonetici(string ad,string sifre)
        {
            (new YoneticiDao()).YoneticiGiris(ad,sifre);
        }
        public void YoneticiSifre(string ad1, string sifre1) 
        { 
            (new YoneticiDao()).YSifreYenile(ad1,sifre1);
        }

    }
}
