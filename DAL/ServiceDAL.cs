using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ServiceDAL
    {
        DbConnection conn = null;
        public ServiceDAL()
        {
            conn = new DbConnection();

        }   
        public List<Service> GetAllService() 
         {
            List<Service> ServiceList = new List<Service>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Service service = new Service();
                service.ServiceMainType = new ServiceMainType();
                service.ServiceSubType = new ServiceSubType();

                service.Id = Convert.ToInt32(dr["ServiceId"]);
                service.Title = Convert.ToString(dr["Title"]);
                service.SubTitle = Convert.ToString(dr["SubTitle"]);
                service.Description = Convert.ToString(dr["Description"]);

                service.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                service.ServiceMainType.Id = Convert.ToInt32(dr["ServiceMainTypeId"]);

               service.ServiceMainType.Title = Convert.ToString(dr["Title1"]);
               service.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                service.ServiceMainType.Description = Convert.ToString(dr["Description1"]);
                service.ServiceMainType.Image = Convert.ToString(dr["Image1"]);





                service.ServiceSubType.Id = Convert.ToInt32(dr["ServiceSubTypeId"]);
                service.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);


               service.ServiceSubType.Title = Convert.ToString(dr["Title2"]);
               service.ServiceSubType.SubTitle = Convert.ToString(dr["SubTitle2"]);
              service.ServiceSubType.Description = Convert.ToString(dr["Description2"]);
               

                service.ServiceSubType.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                service.ServiceSubType.Image = Convert.ToString(dr["Image2"]);




                service.Image = Convert.ToString(dr["Image"]);
                service.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                service.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                service.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                service.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                ServiceList.Add(service);
            }
            con.Close();
            return ServiceList;
        }
        public Service GetServiceById(int Id)
        {
            Service service = new Service();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetServiceById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                service.ServiceMainType = new ServiceMainType();
                service.ServiceSubType = new ServiceSubType();
                service.Id = Convert.ToInt32(dr["ServiceId"]);
                service.Title = Convert.ToString(dr["Title"]);
                service.SubTitle = Convert.ToString(dr["SubTitle"]);
                service.Description = Convert.ToString(dr["Description"]);

                service.ServiceMainType.Id = Convert.ToInt32(dr["ServiceMainTypeId"]);
                service.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);

                service.ServiceMainType.Title = Convert.ToString(dr["Title1"]);
               service.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle1"]);
               service.ServiceMainType.Description = Convert.ToString(dr["Description1"]);
                service.ServiceMainType.Image = Convert.ToString(dr["Image1"]);

                service.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
               service.ServiceSubType.Id = Convert.ToInt32(dr["ServiceSubTypeId"]);
                service.ServiceSubType.Title = Convert.ToString(dr["Title2"]);
                service.ServiceSubType.SubTitle = Convert.ToString(dr["SubTitle2"]);
                service.ServiceSubType.Description = Convert.ToString(dr["Description2"]);
                service.ServiceSubType.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
               service.ServiceSubType.Image = Convert.ToString(dr["Image2"]);

                service.Image = Convert.ToString(dr["Image"]);
                service.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                service.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                service.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                service.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


            }
            con.Close();
            return service;
        }
        public string AddService(Service service)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddService", con);


            // cmd.Parameters.Add("Id", MySqlDbType.Int).Value = candidatewallet.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = service.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = service.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = service.Description;
            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = service.ServiceMainType.Id;
            cmd.Parameters.Add("p_ServiceSubTypeId", MySqlDbType.Int32).Value = service.ServiceSubType.Id;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = service.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = service.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = service.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = service.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = service.UpdatedBy;


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
        public string UpdateService(Service service)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateService", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = service.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = service.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = service.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = service.Description;
            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = service.ServiceMainType.Id;
            cmd.Parameters.Add("p_ServiceSubTypeId", MySqlDbType.Int32).Value = service.ServiceSubType.Id;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = service.Image;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = service.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = service.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = service.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = service.UpdatedBy;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return service.Id.ToString();
        }
        public string DeleteService(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteService",con);
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