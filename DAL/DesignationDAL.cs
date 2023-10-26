using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class DesignationDAL
    {
        DbConnection conn = null;
        public DesignationDAL()
        {
            conn = new DbConnection();

        }
        public List<Designation> GetAllDesignation()
        {
            List<Designation> DesignationList = new List<Designation>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllDesignation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(dr["Id"]);
                designation.Title = Convert.ToString(dr["Title"]);
                designation.Subtitle = Convert.ToString(dr["Subtitle"]);
                designation.Image = Convert.ToString(dr["Image"]);
                designation.Status = Convert.ToString(dr["Status"]);
                designation.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                designation.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                designation.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                designation.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                DesignationList.Add(designation);
            }
            con.Close();
            return DesignationList;
        }
        public Designation GetDesignationById(int Id)
        {
            Designation designation = new Designation();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetDesignationById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                designation.Id = Convert.ToInt32(dr["Id"]);
                designation.Title = Convert.ToString(dr["Title"]);
                designation.Subtitle = Convert.ToString(dr["Subtitle"]);
                designation.Image = Convert.ToString(dr["Image"]);
                designation.Status = Convert.ToString(dr["Status"]);
                designation.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                designation.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                designation.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                designation.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


            }
            con.Close();
            return designation;
        }
        public string AddDesignation(Designation designation)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddDesignation", con);


            // cmd.Parameters.Add("Id", MySqlDbType.Int).Value = candidatewallet.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = designation.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = designation.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = designation.Image;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = designation.Status;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = designation.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = designation.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = designation.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = designation.UpdatedBy;


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
        public string UpdateDesignation(Designation designation)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateDesignation", con);

            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = designation.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = designation.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = designation.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = designation.Image;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = designation.Status;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = designation.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = designation.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = designation.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = designation.UpdatedBy;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return designation.Id.ToString();
        }
        public string DeleteDesignation(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteDesignation", con);
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