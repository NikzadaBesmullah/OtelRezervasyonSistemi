using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Otel_Rezervasyon_Sistemi.Domain
{
    public class OdaDomain
    {
        public int OdaId { get; set; }
        public string OdaNumarasi { get; set; }
        public string OdaTipi { get; set; }
        public decimal Fiyat { get; set; }
        public string Durum { get; set; }
    }
}
