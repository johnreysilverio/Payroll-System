using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System
{
    internal class DBConn
    {
        private MySqlConnection mySqlConnection = new MySqlConnection("server= 127.0.0.1; user = root; database=payroll; password=");
        public void openConnection()
        {
            if (mySqlConnection.State == System.Data.ConnectionState.Closed)
            {
                mySqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (mySqlConnection.State == System.Data.ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return mySqlConnection;
        }
    }
}
