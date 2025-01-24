using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Otel_Rezervasyon_Sistemi.Domain
{
    public class YoneticiDomain
    {
        string yAd, ySifre,yTc;

        public string  YAD
        { 
            get { return yAd; } 
            set { yAd = value; }
        }
        public string YSIFRE
        {
            get { return ySifre; }
            set { ySifre= value; }
        }
        public string YTC
        {
            get { return yTc; }
            set { yTc = value; }
        }
    }
}
