using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public static class DbHelper 
    {
        private static readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LibraryDB;Trusted_Connection=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
