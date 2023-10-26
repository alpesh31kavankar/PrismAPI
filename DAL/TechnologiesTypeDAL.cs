using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class TechnologiesTypeDAL
    {
        DbConnection conn = null;
        public TechnologiesTypeDAL()
        {
            conn = new DbConnection();   
        }

        public List<TechnologiesType> GetAllTechnologiesType()
        {
            List<TechnologiesType> technologiesTypeList = new List<TechnologiesType>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllTechnologiesType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TechnologiesType technologiesType = new TechnologiesType();
                technologiesType.Id = Convert.ToInt32(dr["Id"]);

                technologiesType.Title = Convert.ToString(dr["Title"]);
                technologiesType.Subtitle = Convert.ToString(dr["Subtitle"]);
                technologiesType.Image = Convert.ToString(dr["Image"]);


                technologiesType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                technologiesType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                technologiesType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                technologiesType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                technologiesTypeList.Add(technologiesType);
            }
            con.Close();
            return technologiesTypeList;
        }

        public TechnologiesType GetTechnologiesTypeById(int Id)
        {
            TechnologiesType technologiesType = new TechnologiesType();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetTechnologiesTypeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 


                technologiesType.Id = Convert.ToInt32(dr["Id"]);

                technologiesType.Title = Convert.ToString(dr["Title"]);
                technologiesType.Subtitle = Convert.ToString(dr["Subtitle"]);
                technologiesType.Image = Convert.ToString(dr["Image"]);


                technologiesType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                technologiesType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                technologiesType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                technologiesType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return technologiesType;
        }


        public string AddTechnologiesType(TechnologiesType technologiesType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddTechnologiesType", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = technologiesType.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = technologiesType.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = technologiesType.Image;


            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = technologiesType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = technologiesType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = technologiesType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = technologiesType.UpdatedDate;


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


        public string UpdateTechnologiesType(TechnologiesType technologiesType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateTechnologiesType", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = technologiesType.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = technologiesType.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = technologiesType.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = technologiesType.Image;


            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = technologiesType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = technologiesType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = technologiesType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = technologiesType.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return technologiesType.Id.ToString();
        }


        public string DeleteTechnologiesType(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteTechnologiesType", con);
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