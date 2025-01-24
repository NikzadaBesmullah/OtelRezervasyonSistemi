using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Domain_Musteri
    {
        string Ad, Soyad, Tel, sifre, tc;
        public string AD
        {
            get { return Ad; }
            set { Ad = value; }

        }
        public string SOYAD
        {
            get { return Soyad; }
            set { Soyad = value; }

        }
        public string TELEFON
        {
            get { return Tel; }
            set { Tel = value; }

        }
        public string SIFRE
        {
            get { return sifre; }
            set { sifre = value; }

        }
        public string TC
        {
            get { return tc; }
            set { tc = value; }
        }
        public override string ToString()
        {
            return Ad+Soyad+tc+Tel+sifre;   
        }
    }

}
