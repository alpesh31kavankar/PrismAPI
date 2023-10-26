using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class TechnologiesDAL 
    {
        DbConnection conn = null;
        public TechnologiesDAL()
        {
            conn = new DbConnection();
        }

        public List<Technologies> GetAllTechnologies()
        
        {
            List<Technologies> technologiesList = new List<Technologies>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Technologies technologies = new Technologies();
                //dynamic dropdown
                technologies.TechnologiesType = new TechnologiesType();
                technologies.Id = Convert.ToInt32(dr["Id"]);
                 //dynamic dropdown
                technologies.TechnologiesType.Id = Convert.ToInt32(dr["TechnologiesTypeId"]);

                technologies.Title = Convert.ToString(dr["Title"]);
                technologies.Subtitle = Convert.ToString(dr["Subtitle"]);
                technologies.Image = Convert.ToString(dr["Image"]);
                technologies.TechnologyTypeId = Convert.ToInt32(dr["TechnologyTypeId"]);

                //add list column

                technologies.TechnologiesType.Title = Convert.ToString(dr["Title1"]);
                technologies.TechnologiesType.Subtitle = Convert.ToString(dr["Subtitle1"]);
                technologies.TechnologiesType.Image = Convert.ToString(dr["Image1"]);

                technologies.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                technologies.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                technologies.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                technologies.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                technologiesList.Add(technologies);
            }
            con.Close();
            return technologiesList;
        }

        public Technologies GetTechnologiesById(int Id)
        {
            Technologies technologies = new Technologies();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetTechnologiesById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {  

                //Dynamic Dropdown
                technologies.TechnologiesType = new TechnologiesType();
                technologies.Id = Convert.ToInt32(dr["Id"]);
                //Dynamic Dropdown
                technologies.TechnologiesType.Id = Convert.ToInt32(dr["TechnologiesTypeId"]);
                //add list column

                technologies.TechnologiesType.Title = Convert.ToString(dr["Title1"]);
                technologies.TechnologiesType.Subtitle = Convert.ToString(dr["Subtitle1"]);
                technologies.TechnologiesType.Image = Convert.ToString(dr["Image1"]);

                technologies.Title = Convert.ToString(dr["Title"]);
                technologies.Subtitle = Convert.ToString(dr["Subtitle"]);
                technologies.Image = Convert.ToString(dr["Image"]);
                technologies.TechnologyTypeId = Convert.ToInt32(dr["TechnologyTypeId"]);

                technologies.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                technologies.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                technologies.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                technologies.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return technologies;
        }


        public string AddTechnologies(Technologies technologies)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddTechnologies", con);
            //cmd.Parameters.Add("Id", MyMySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = technologies.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = technologies.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = technologies.Image;
            cmd.Parameters.Add("p_TechnologyTypeId", MySqlDbType.Int32).Value = technologies.TechnologyTypeId;
            //cmd.Parameters.Add("TechnologyTypeId", MySqlDbType.Int).Value = technologies.TechnologiesType.Id;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = technologies.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = technologies.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = technologies.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = technologies.UpdatedDate;


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


        public string UpdateTechnologies(Technologies technologies)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateTechnologies", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = technologies.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = technologies.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = technologies.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = technologies.Image;
            cmd.Parameters.Add("p_TechnologyTypeId", MySqlDbType.Int32).Value = technologies.TechnologyTypeId;
            //cmd.Parameters.Add("TechnologyTypeId", MySqlDbType.Int).Value = technologies.TechnologiesType.Id;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = technologies.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = technologies.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = technologies.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = technologies.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return technologies.Id.ToString();
        }


        public string DeleteTechnologies(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteTechnologies", con);
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