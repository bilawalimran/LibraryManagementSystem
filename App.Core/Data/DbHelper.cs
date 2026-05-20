using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public static class DbHelper 
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["LibraryDB"]
                .ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
