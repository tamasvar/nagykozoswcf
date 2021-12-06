using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.ServiceModel;
using System.Configuration;

namespace Server.DatabaseManagers
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager()
        {

        }
        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=localhost;" + "DATABASE=wcf_test;" +
                    "UID=root;" + "PASSWORD=;" + "SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }

        }
    }

}