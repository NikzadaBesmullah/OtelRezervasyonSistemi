using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Otel_Rezervasyon_Sistemi.Domain
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
    }
}
