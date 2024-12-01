using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Server
{
    internal class DBConn
    {
        private MySqlConnection mySqlConnection = new MySqlConnection("server= 127.0.0.1; user = root; database=payroll; password=");
        public void openConnection()
        {
            mySqlConnection.Open();

        }
        public void closeConnection()
        {
            mySqlConnection.Close();
        }
        public MySqlConnection getConnection()
        {
            return mySqlConnection;
        }
    }
}
