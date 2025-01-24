using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;
namespace Otel_Rezervasyon_Sistemi.Service
{
    public class OdaService
    {
        private OdaDao _odaDal = new OdaDao();


        public int OdaEkle(OdaDomain oda)
        {
            return _odaDal.Ekle(oda);
        }

        public bool OdaDurumGuncelle(int odaId, bool durum)
        {
            return _odaDal.DurumGuncelle(odaId, durum);
        }
        public List<OdaDomain> BosOdalariGetir()
        {
            return _odaDal.BosOdalariGetir();
        }
       
        public int GetDoluOdaSayisi()
        {
            return _odaDal.GetDoluOdaSayisi();
        }

        public int GetBosOdaSayisi()
        {
            return _odaDal.GetBosOdaSayisi();
        }
        public int AddOda(OdaDomain oda)
        {
            return _odaDal.AddOda(oda);
        }
        public List<OdaDomain> GetAllOdalar()
        {
            return _odaDal.odalarıgoruntele(); // OdaDao'dan odaları al
        }
        public bool OdaSil(int odaId)
        {
            if (odaId <= 0)
            {
                throw new ArgumentException("Geçersiz oda ID'si");
            }

            // Silme öncesi ek kontroller eklenebilir
            // Örneğin: Odanın rezervasyonu var mı kontrolü

            return _odaDal.SilById(odaId);
        }
        public bool Guncelle(OdaDomain oda)
        {
            if (oda == null || oda.OdaId <= 0)
            {
                return false;
            }

            return _odaDal.Guncelle(oda);
        }

    }
}

