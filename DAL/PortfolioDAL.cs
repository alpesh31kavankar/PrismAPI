using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class PortfolioDAL
    {
        DbConnection conn = null;
        public PortfolioDAL()
        {
            conn = new DbConnection();
        }

        public List<Portfolio> GetAllPortfolio()
        {
            List<Portfolio> portfolioList = new List<Portfolio>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllPortfolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Portfolio portfolio = new Portfolio();
                portfolio.Id = Convert.ToInt32(dr["Id"]);

                portfolio.Title = Convert.ToString(dr["Title"]);
                portfolio.Subtitle = Convert.ToString(dr["Subtitle"]);
                portfolio.Description = Convert.ToString(dr["Description"]);
                portfolio.Image = Convert.ToString(dr["Image"]);
                portfolio.Link = Convert.ToString(dr["Link"]);
                portfolio.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                portfolio.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                portfolio.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                portfolio.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                portfolioList.Add(portfolio);
            }
            con.Close();
            return portfolioList;
        }

        public Portfolio GetPortfolioById(int Id)
        {
            Portfolio portfolio = new Portfolio();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetPortfolioById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())  
            {



                portfolio.Id = Convert.ToInt32(dr["Id"]);

                portfolio.Title = Convert.ToString(dr["Title"]);
                portfolio.Subtitle = Convert.ToString(dr["Subtitle"]);
                portfolio.Description = Convert.ToString(dr["Description"]);
                portfolio.Image = Convert.ToString(dr["Image"]);
                portfolio.Link = Convert.ToString(dr["Link"]);
                portfolio.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                portfolio.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                portfolio.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                portfolio.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return portfolio;
        }


        public string AddPortfolio(Portfolio portfolio)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddPortfolio", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = portfolio.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = portfolio.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = portfolio.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = portfolio.Image;
            cmd.Parameters.Add("p_Link", MySqlDbType.VarChar).Value = portfolio.Link;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = portfolio.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = portfolio.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = portfolio.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = portfolio.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }


        public string UpdatePortfolio(Portfolio portfolio)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdatePortfolio", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = portfolio.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = portfolio.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = portfolio.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = portfolio.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = portfolio.Image;
            cmd.Parameters.Add("p_Link", MySqlDbType.VarChar).Value = portfolio.Link;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = portfolio.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = portfolio.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = portfolio.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = portfolio.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return portfolio.Id.ToString();
        }


        public string DeletePortfolio(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeletePortfolio", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }


    }
}