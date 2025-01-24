using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Domain;
using Otel_Rezervasyon_Sistemi.Service;

namespace Otel_Rezervasyon_Sistemi.Dal
{
    public class RezervasyonDao
    {
        private string connectionString = "Server=172.21.54.253;Database=25_132330124;User=25_132330124;Password=!nif.ogr24NI;";

        public bool Ekle(RezervasyonDomain rezervasyon)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Tbl_Rezervasyon (Musteriid, Odaid, GirisTarihi, CikisTarihi, ToplamFiyat) VALUES (@musteriId, @odaId, @girisTarihi, @cikisTarihi, @toplamFiyat)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@musteriId", rezervasyon.MusteriId);
                    cmd.Parameters.AddWithValue("@odaId", rezervasyon.OdaId);
                    cmd.Parameters.AddWithValue("@girisTarihi", rezervasyon.GirisTarihi);
                    cmd.Parameters.AddWithValue("@cikisTarihi", rezervasyon.CikisTarihi);
                    cmd.Parameters.AddWithValue("@toplamFiyat", rezervasyon.ToplamFiyat);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public List<RezervasyonDomain> GetRezervasyonlar()
        {
            List<RezervasyonDomain> rezervasyonlar = new List<RezervasyonDomain>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT 
                                m.MusteriAd, 
                                m.MusteriSoyad, 
                                o.OdaNumara,
                                r.GirisTarihi,
                                r.CikisTarihi,
                                r.ToplamFiyat
                           FROM Tbl_Rezervasyon r
                           INNER JOIN Tbl_Musteri m ON r.Musteriid = m.Musteriid
                           INNER JOIN Tbl_Oda o ON r.Odaid = o.Odaid";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rezervasyonlar.Add(new RezervasyonDomain
                            {
                                MusteriAd = reader["MusteriAd"].ToString(),
                                MusteriSoyad = reader["MusteriSoyad"].ToString(),
                                OdaNumara = reader["OdaNumara"].ToString(),
                                GirisTarihi = Convert.ToDateTime(reader["GirisTarihi"]),
                                CikisTarihi = Convert.ToDateTime(reader["CikisTarihi"]),
                                ToplamFiyat = Convert.ToDecimal(reader["ToplamFiyat"])

                            });
                        }
                    }
                }
            }
            return rezervasyonlar;

        }
        public bool Guncelle(RezervasyonDomain rezervasyon)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Tbl_Rezervasyon r
                           INNER JOIN Tbl_Musteri m ON r.Musteriid = m.Musteriid
                           SET r.Odaid = (SELECT Odaid FROM Tbl_Oda WHERE OdaNumara = @odaNumara),
                               r.GirisTarihi = @girisTarihi,
                               r.CikisTarihi = @cikisTarihi,
                               r.ToplamFiyat = @toplamFiyat
                           WHERE m.MusteriAd = @musteriAd 
                           AND m.MusteriSoyad = @musteriSoyad";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@musteriAd", rezervasyon.MusteriAd);
                    cmd.Parameters.AddWithValue("@musteriSoyad", rezervasyon.MusteriSoyad);
                    cmd.Parameters.AddWithValue("@odaNumara", rezervasyon.OdaNumara);
                    cmd.Parameters.AddWithValue("@girisTarihi", rezervasyon.GirisTarihi);
                    cmd.Parameters.AddWithValue("@cikisTarihi", rezervasyon.CikisTarihi);
                    cmd.Parameters.AddWithValue("@toplamFiyat", rezervasyon.ToplamFiyat);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Sil(string musteriAd, string musteriSoyad)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // First, find the reservation ID based on customer name and surname
                    string query = @"
                SELECT r.Rezervid, r.Odaid 
                FROM Tbl_Rezervasyon r 
                JOIN Tbl_Musteri m ON r.Musteriid = m.Musteriid 
                WHERE m.MusteriAd = @musteriAd AND m.MusteriSoyad = @musteriSoyad";

                    MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@musteriAd", musteriAd);
                    cmd.Parameters.AddWithValue("@musteriSoyad", musteriSoyad);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int rezervasyonId = reader.GetInt32("Rezervid");
                            int odaId = reader.GetInt32("Odaid");
                            reader.Close();

                            // Delete reservation
                            string silQuery = "DELETE FROM Tbl_Rezervasyon WHERE Rezervid = @rezervasyonId";
                            MySqlCommand silCmd = new MySqlCommand(silQuery, conn, transaction);
                            silCmd.Parameters.AddWithValue("@rezervasyonId", rezervasyonId);
                            int etkilenenSatirSayisi = silCmd.ExecuteNonQuery();

                            // Update room status
                            string odaGuncelleQuery = "UPDATE Tbl_Oda SET OdaDurum = 1 WHERE Odaid = @odaId";
                            MySqlCommand odaGuncelleCmd = new MySqlCommand(odaGuncelleQuery, conn, transaction);
                            odaGuncelleCmd.Parameters.AddWithValue("@odaId", odaId);
                            odaGuncelleCmd.ExecuteNonQuery();

                            transaction.Commit();
                            return etkilenenSatirSayisi > 0;
                        }
                    }

                    transaction.Rollback();
                    return false;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Silme hatası: {ex.Message}");
                    return false;
                }
            }
        }
    }
}


