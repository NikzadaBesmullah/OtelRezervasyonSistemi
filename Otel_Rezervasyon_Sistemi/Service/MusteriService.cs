using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;

namespace Otel_Rezervasyon_Sistemi.Service
{
    public class MusteriService
    {
        private MusteriDao _musteriDal = new MusteriDao();

        public int MusteriEkle(Musteri musteri)
        {
            return _musteriDal.Ekle(musteri);
        }
        public List<Musteri> GetAllMusteriler()
        {
            return _musteriDal.GetAllMusteriler();
        }
        public int GetToplamMusteriSayisi()
        {
            return _musteriDal.GetToplamMusteriSayisi();
        }
    }
}
