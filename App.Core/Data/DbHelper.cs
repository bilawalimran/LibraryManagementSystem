using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public static class DbHelper 
    {
        private static readonly string connectionString = @"Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
