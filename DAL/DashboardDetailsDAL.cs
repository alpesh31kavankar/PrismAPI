using PrismAPI.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace PrismAPI.DAL
{
    public class DashboardDetailsDAL
    {
        DbConnection conn = null;
       public DashboardDetailsDAL()
        {
            conn = new DbConnection();
        }

        public DashboardDetails GetAllDashboardDetails()
        
        {
            DashboardDetails dashboarddetails = new DashboardDetails();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllDashboardDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                dashboarddetails.TotalBlog = Convert.ToInt32(dr["TotalBlog"]);
                dashboarddetails.TotalClient = Convert.ToInt32(dr["TotalClient"]);
                dashboarddetails.TotalEmployees = Convert.ToInt32(dr["TotalEmployees"]);
                dashboarddetails.TotalProduct = Convert.ToInt32(dr["TotalProduct"]);
                dashboarddetails.TotalProjects = Convert.ToInt32(dr["TotalProjects"]);
                dashboarddetails.TotalService = Convert.ToInt32(dr["TotalService"]);
                dashboarddetails.TotalServiceInquiry = Convert.ToInt32(dr["TotalServiceInquiry"]);



            }
            con.Close();
            return dashboarddetails;
        }

        public string TruncateAllTable()
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("TruncateAllTable", con);

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            //if (result.ToString() == "0")
            //{
            //    return "Failed";
            //}
            return "Success";
        }
    }
}