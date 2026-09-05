using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace pengkar_laura
{
    class koneksi
    {
        public static MySqlConnection Conn = new MySqlConnection(
         "server = 127.0.0.1;" +
         "username = root;" +
         "password= ;" +
         "database = db_pengkar;");
        public static DataSet DS = new DataSet();
        public static MySqlDataAdapter DA;
        public static MySqlCommand Perintah;

       
        public static void CRUD(string Query)
        {
            Console.WriteLine(Query);
            DS.Tables.Clear();
            Perintah = new MySqlCommand(Query, Conn);
            DA = new MySqlDataAdapter(Perintah);
            DA.Fill(DS);

        }
    }
}
    

