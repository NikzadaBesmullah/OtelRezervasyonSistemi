using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dal
{
    public class Baglanti
    {
            public MySqlConnection dbBaglanti()
        {
            MySqlConnection bgl = new MySqlConnection("Server=172.21.54.253;Database=25_132330124;User=25_132330124;Password=!nif.ogr24NI;");
            bgl.Open();
            return bgl; 
        }
    }
}
