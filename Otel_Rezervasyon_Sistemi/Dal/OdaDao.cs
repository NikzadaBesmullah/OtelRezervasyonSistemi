using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Otel_Rezervasyon_Sistemi.Domain;
namespace Otel_Rezervasyon_Sistemi.Dal
{
    public class OdaDao
    {
        private string connectionString = "Server=172.21.54.253;Database=25_132330124;User=25_132330124;Password=!nif.ogr24NI;";

        public int Ekle(OdaDomain oda)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL sorgusunu düzeltelim, tüm gerekli alanları ekleyelim
                    string query = @"INSERT INTO Tbl_Oda (OdaNumara, OdaFiyat, OdaDurum,OdaTipi) 
                               VALUES (@odaNo, @fiyat, @durum,@odaTipi); 
                               SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parametreleri ekleyelim
                    cmd.Parameters.AddWithValue("@odaNo", oda.OdaNumarasi);
                    cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
                    cmd.Parameters.AddWithValue("@durum", oda.Durum);
                    cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi ?? "Standart");

                    // ExecuteScalar ile ID'yi alalım
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    // ID'yi kontrol edelim
                    if (id > 0)
                    {
                        oda.OdaId = id; // ID'yi oda nesnesine atayalım
                        return id;
                    }
                    return 0;
                }
                catch (MySqlException ex)
                {
                    // Hata mesajını gösterelim
                    MessageBox.Show($"Veritabanı hatası: {ex.Message}\nHata kodu: {ex.Number}");
                    return 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                    return 0;
                }
            }
        }

        public bool DurumGuncelle(int odaId, bool durum)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Tbl_Oda SET OdaDurum = @durum WHERE Odaid = @odaId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@durum", durum);
                    cmd.Parameters.AddWithValue("@odaId", odaId);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Durum güncelleme hatası: {ex.Message}");
                    return false;
                }
            }
        }
        public List<OdaDomain> BosOdalariGetir()
        {
            List<OdaDomain> bosOdalar = new List<OdaDomain>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT o.* 
                FROM Tbl_Oda o 
                LEFT JOIN Tbl_Rezervasyon r ON o.Odaid = r.Odaid 
                WHERE o.OdaDurum = true 
                AND (r.Odaid IS NULL 
                    OR r.CikisTarihi < CURDATE()
                    OR r.Rezervid IS NULL)
                GROUP BY o.Odaid";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bosOdalar.Add(new OdaDomain
                            {
                                OdaId = Convert.ToInt32(reader["Odaid"]),
                                OdaNumarasi = reader["OdaNumara"].ToString(),
                                Fiyat = Convert.ToDecimal(reader["OdaFiyat"]),
                                Durum = reader["OdaDurum"].ToString(),
                                OdaTipi = reader["OdaTipi"].ToString()
                            });
                        }
                    }
                    return bosOdalar;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Veritabanı hatası: {ex.Message}\nHata kodu: {ex.Number}");
                    return new List<OdaDomain>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                    return new List<OdaDomain>();
                }
            }
        }


        public int GetDoluOdaSayisi()
        {
            int doluSayisi = 0;
            string query = "SELECT COUNT(*) FROM Tbl_Oda WHERE OdaDurum = 0";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    doluSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabanı hatası: " + ex.Message);
                }
            }
            return doluSayisi;
        }

        // Boş odaların sayısını döndüren metod
        public int GetBosOdaSayisi()
        {
            int bosSayisi = 0;
            string query = "SELECT COUNT(*) FROM Tbl_Oda WHERE OdaDurum = 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    bosSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabanı hatası: " + ex.Message);
                }
            }
            return bosSayisi;
        }
        public int AddOda(OdaDomain oda)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Tbl_Oda (OdaNumara, OdaFiyat, OdaDurum, OdaTipi) 
                         VALUES (@odaNo, @fiyat, @durum, @odaTipi);
                         SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@odaNo", oda.OdaNumarasi);
                cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
                cmd.Parameters.AddWithValue("@durum", oda.Durum);
                cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi ?? "Standart");

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id > 0 ? id : 0;
            }
        }
        public List<OdaDomain> odalarıgoruntele()
        {
            List<OdaDomain> odalar = new List<OdaDomain>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Tbl_Oda"; // Tüm oda bilgilerini çeken sorgu

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            odalar.Add(new OdaDomain
                            {
                                OdaId = Convert.ToInt32(reader["Odaid"]),
                                OdaNumarasi = reader["OdaNumara"].ToString(),
                                Fiyat = Convert.ToDecimal(reader["OdaFiyat"]),
                                Durum = (reader["OdaDurum"].ToString()), // Durumun boolean olduğunu varsayıyorum
                                OdaTipi = reader["OdaTipi"].ToString()
                            });
                        }
                    }
                    return odalar;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Veritabanı hatası: {ex.Message}\nHata kodu: {ex.Number}");
                    return new List<OdaDomain>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                    return new List<OdaDomain>();
                }
            }
        }
        public bool SilById(int odaId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Önce ilişkili tüm tabloları kontrol et ve sil
                    string[] iliskiliTablolar = new string[]
                    {
                "Tbl_Rezervasyon",
                        // Diğer ilişkili tabloları buraya ekle
                    };

                    foreach (var tablo in iliskiliTablolar)
                    {
                        string deleteIliskiliQuery = $"DELETE FROM {tablo} WHERE Odaid = @odaId";
                        MySqlCommand deleteIliskiliCmd = new MySqlCommand(deleteIliskiliQuery, conn, transaction);
                        deleteIliskiliCmd.Parameters.AddWithValue("@odaId", odaId);
                        deleteIliskiliCmd.ExecuteNonQuery();
                    }

                    // 2. Sonra asıl odayı sil
                    string deleteOdaQuery = "DELETE FROM Tbl_Oda WHERE Odaid = @odaId";
                    MySqlCommand deleteOdaCmd = new MySqlCommand(deleteOdaQuery, conn, transaction);
                    deleteOdaCmd.Parameters.AddWithValue("@odaId", odaId);

                    int etkilenenSatirSayisi = deleteOdaCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return etkilenenSatirSayisi > 0;
                }
                catch (MySqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Detaylı Silme Hatası: {ex.Message}\nHata Kodu: {ex.Number}");
                    return false;
                }
                finally
                {
                    transaction?.Dispose();
                }
            }

        }
        public bool Guncelle(OdaDomain oda)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Tbl_Oda 
                             SET OdaNumara = @odaNo, 
                                 OdaFiyat = @fiyat, 
                                 OdaDurum = @durum, 
                                 OdaTipi = @odaTipi 
                             WHERE Odaid = @odaId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parametreleri ekleyelim
                    cmd.Parameters.AddWithValue("@odaId", oda.OdaId);
                    cmd.Parameters.AddWithValue("@odaNo", oda.OdaNumarasi);
                    cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
                    cmd.Parameters.AddWithValue("@durum", oda.Durum);
                    cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi ?? "Standart");

                    // Etkilenen satır sayısını kontrol edelim
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();

                    return etkilenenSatirSayisi > 0;
                }
                catch (MySqlException ex)
                {
                    // Hata mesajını gösterelim
                    MessageBox.Show($"Güncelleme hatası: {ex.Message}\nHata kodu: {ex.Number}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                    return false;
                }
            }
        }
    }
}



