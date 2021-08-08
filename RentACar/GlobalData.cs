using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    static class GlobalData
    {
        public static MySqlConnection connection = null;

        public static DataTable ExecSQL(string sql)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand(sql, connection);
            da.Fill(dt);
            return dt;
        }
    }
}
