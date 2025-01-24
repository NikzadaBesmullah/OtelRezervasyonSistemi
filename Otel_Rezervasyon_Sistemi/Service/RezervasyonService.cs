using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Dal;
using Otel_Rezervasyon_Sistemi.Domain;

namespace Otel_Rezervasyon_Sistemi.Service
{
    internal class RezervasyonService
    {
        private RezervasyonDao _rezervasyonDal = new RezervasyonDao();
        public RezervasyonDomain dom = new RezervasyonDomain();

        public bool RezervasyonEkle(RezervasyonDomain rezervasyon)
        {
            return _rezervasyonDal.Ekle(rezervasyon);
        }
        public List<RezervasyonDomain> GetAllRezervasyonlar()
        {
            try
            {
                return _rezervasyonDal.GetRezervasyonlar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon bilgileri alınırken hata oluştu: " + ex.Message);
                return new List<RezervasyonDomain>();
            }
        }
        private RezervasyonDao rezervasyonDao;

        public RezervasyonService()
        {
            rezervasyonDao = new RezervasyonDao();
        }

        public bool RezervasyonGuncelle(RezervasyonDomain rezervasyon)
        {
            return rezervasyonDao.Guncelle(rezervasyon);
        }
        public bool RezervasyonSil(string musteriAd, string musteriSoyad)
        {
            return _rezervasyonDal.Sil(musteriAd, musteriSoyad);
        }
    }
}


