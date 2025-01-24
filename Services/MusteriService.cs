using Dal;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MusteriService
    {
        internal void MusteriKaydet()
        {
            (new MusteriDao()).Musteri_Kaydet(new Domain_Musteri());

        }
    }
}
