using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;


namespace PrismAPI.DAL
{
    public class DbConnection
    {
        public readonly string connectionString = string.Empty;

        public DbConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
        }

        public MySqlConnection OpenDbConnection()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
          con.Open();
            return con;
        }
    }
}