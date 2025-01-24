using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Domain;

namespace Otel_Rezervasyon_Sistemi.Dal
{
    internal class MusteriDao
    {

        private string connectionString = "Server=172.21.54.253;Database=25_132330124;User=25_132330124;Password=!nif.ogr24NI;";
        public int Ekle(Musteri musteri)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Tbl_Musteri (MusteriAd, MusteriSoyad, MusteriTelefon) VALUES (@ad, @soyad,  @telefon); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ad", musteri.Ad);
                    cmd.Parameters.AddWithValue("@soyad", musteri.Soyad);
                    cmd.Parameters.AddWithValue("@telefon", musteri.Telefon);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<Musteri> GetAllMusteriler()
        {
            List<Musteri> musteriler = new List<Musteri>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Musteriid, MusteriAd, MusteriSoyad, MusteriTelefon FROM Tbl_Musteri";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Musteri musteri = new Musteri
                    {
                        MusteriId = reader.GetInt32("Musteriid"),
                        Ad = reader.GetString("MusteriAd"),
                        Soyad = reader.GetString("MusteriSoyad"),
                        Telefon = reader.GetString("MusteriTelefon"),
                    };
                    musteriler.Add(musteri);
                }
            }

            return musteriler;
        }
        public int GetToplamMusteriSayisi()
        {
            int musteriSayisi = 0;
            string query = "SELECT COUNT(*) FROM Tbl_Musteri";  // Musteriler tablosundaki toplam müşteri sayısı

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    musteriSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabanı hatası: " + ex.Message);
                }
            }

            return musteriSayisi;
        }


    }

}
