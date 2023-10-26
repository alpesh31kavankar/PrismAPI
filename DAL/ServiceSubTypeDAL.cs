using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ServiceSubTypeDAL 
    {
        DbConnection conn = null;   
        public ServiceSubTypeDAL()
        {
            conn = new DbConnection();

        }
        public List<ServiceSubType> GetAllServiceSubType()
        {
            List<ServiceSubType> ServiceSubTypeList = new List<ServiceSubType>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllServiceSubType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ServiceSubType servicesubtype = new ServiceSubType();
                servicesubtype.ServiceMainType = new ServiceMainType();
                servicesubtype.Id = Convert.ToInt32(dr["Id"]);
                servicesubtype.Title = Convert.ToString(dr["Title"]);
                servicesubtype.SubTitle = Convert.ToString(dr["SubTitle"]);
                servicesubtype.Description = Convert.ToString(dr["Description"]);

                servicesubtype.ServiceMainType.Id = Convert.ToInt32(dr["ServiceMainTypeId"]);
                servicesubtype.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);

                servicesubtype.ServiceMainType.Title = Convert.ToString(dr["Title1"]);
                servicesubtype.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                servicesubtype.ServiceMainType.Description = Convert.ToString(dr["Description1"]);
                servicesubtype.ServiceMainType.Image = Convert.ToString(dr["Image1"]);




                servicesubtype.Image = Convert.ToString(dr["Image"]);
                servicesubtype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                servicesubtype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                servicesubtype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                servicesubtype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                ServiceSubTypeList.Add(servicesubtype);
            }
            con.Close();
            return ServiceSubTypeList;
        }
        public ServiceSubType GetServiceSubTypeById(int Id)
        {
            ServiceSubType servicesubtype = new ServiceSubType();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetServiceSubTypeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                servicesubtype.ServiceMainType = new ServiceMainType();
                servicesubtype.Id = Convert.ToInt32(dr["Id"]);
                servicesubtype.Title = Convert.ToString(dr["Title"]);
                servicesubtype.SubTitle = Convert.ToString(dr["SubTitle"]);
                servicesubtype.Description = Convert.ToString(dr["Description"]);
                servicesubtype.ServiceMainType.Id = Convert.ToInt32(dr["ServiceMainTypeId"]);
                servicesubtype.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);

                servicesubtype.ServiceMainType.Title = Convert.ToString(dr["Title1"]);
                servicesubtype.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                servicesubtype.ServiceMainType.Description = Convert.ToString(dr["Description1"]);
                servicesubtype.ServiceMainType.Image = Convert.ToString(dr["Image1"]);

                servicesubtype.Image = Convert.ToString(dr["Image"]);
                servicesubtype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                servicesubtype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                servicesubtype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                servicesubtype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


            }
            con.Close();
            return servicesubtype;
        }
        public string AddServiceSubType(ServiceSubType servicesubtype)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddServiceSubType", con);


            // cmd.Parameters.Add("Id", MySqlDbType.Int).Value = candidatewallet.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = servicesubtype.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = servicesubtype.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = servicesubtype.Description;
      
            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = servicesubtype.ServiceMainType.Id;
           

            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = servicesubtype.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = servicesubtype.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = servicesubtype.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = servicesubtype.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = servicesubtype.UpdatedBy;


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
        public string UpdateServiceSubType(ServiceSubType servicesubtype)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateServiceSubType", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = servicesubtype.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = servicesubtype.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = servicesubtype.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = servicesubtype.Description;

            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = servicesubtype.ServiceMainType.Id;


            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = servicesubtype.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = servicesubtype.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = servicesubtype.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = servicesubtype.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = servicesubtype.UpdatedBy;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return servicesubtype.Id.ToString();
        }
        public string DeleteServiceSubType(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteServiceSubType", con);
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