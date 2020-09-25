using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace InvestmentApp.Repository.DbConfig
{
    public static class DataBaseSettings
    {
        private static string ConnectionString = @"Server=.\SQLEXPRESS; Database=InvestmentApp; Integrated Security=True;";
        public static SqlConnection sqlConnection = new SqlConnection(ConnectionString);
    }
}
