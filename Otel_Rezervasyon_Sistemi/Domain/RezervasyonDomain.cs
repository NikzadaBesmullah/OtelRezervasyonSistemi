using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
namespace Otel_Rezervasyon_Sistemi.Domain
{
    public  class RezervasyonDomain
    {
        public int RezervasyonId { get; set; }
        public int MusteriId { get; set; }
        public int OdaId { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public decimal ToplamFiyat { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }  
        public string OdaNumara { get; set; }
        public string Musteritel { get; set; }

    }
}

