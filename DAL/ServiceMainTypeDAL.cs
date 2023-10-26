using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ServiceMainTypeDAL
    {
        DbConnection conn = null;   
        public ServiceMainTypeDAL()
        {
            conn = new DbConnection();

        }
        public List<ServiceMainType> GetAllServiceMainType()
        
        {
            List<ServiceMainType> ServiceMainTypeList = new List<ServiceMainType>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllServiceMainType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ServiceMainType servicemaintype = new ServiceMainType();
                servicemaintype.Id = Convert.ToInt32(dr["Id"]);
                servicemaintype.Title = Convert.ToString(dr["Title"]);
                servicemaintype.SubTitle = Convert.ToString(dr["SubTitle"]);
                servicemaintype.Description = Convert.ToString(dr["Description"]);
                servicemaintype.Image = Convert.ToString(dr["Image"]);
                servicemaintype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                servicemaintype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                servicemaintype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                servicemaintype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                ServiceMainTypeList.Add(servicemaintype);
            }
            con.Close();
            return ServiceMainTypeList;
        }
        public ServiceMainType GetServiceMainTypeById(int Id)
        {
            ServiceMainType servicemaintype = new ServiceMainType();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetServiceMainTypeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                servicemaintype.Id = Convert.ToInt32(dr["Id"]);
                servicemaintype.Title = Convert.ToString(dr["Title"]);
                servicemaintype.SubTitle = Convert.ToString(dr["SubTitle"]);
                servicemaintype.Description = Convert.ToString(dr["Description"]);
                servicemaintype.Image = Convert.ToString(dr["Image"]);
                servicemaintype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                servicemaintype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                servicemaintype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                servicemaintype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


            }
            con.Close();
            return servicemaintype;
        }
        public string AddServiceMainType(ServiceMainType servicemaintype)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddServiceMainType", con);


            // cmd.Parameters.Add("Id", MySqlDbType.Int).Value = candidatewallet.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = servicemaintype.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = servicemaintype.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = servicemaintype.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = servicemaintype.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = servicemaintype.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = servicemaintype.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = servicemaintype.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = servicemaintype.UpdatedBy;


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
        public string UpdateServiceMainType(ServiceMainType servicemaintype)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateServiceMainType", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = servicemaintype.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = servicemaintype.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = servicemaintype.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = servicemaintype.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = servicemaintype.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = servicemaintype.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = servicemaintype.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = servicemaintype.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = servicemaintype.UpdatedBy;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return servicemaintype.Id.ToString();
        }
        public string DeleteServiceMainType(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteServiceMainType", con);
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