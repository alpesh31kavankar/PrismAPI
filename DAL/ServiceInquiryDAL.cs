using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ServiceInquiryDAL
    {
        DbConnection conn = null;
        public ServiceInquiryDAL()
        {
            conn = new DbConnection();
        }

        public List<ServiceInquiry> GetAllServiceInquiry()
        {
            List<ServiceInquiry> serviceInquiryList = new List<ServiceInquiry>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllServiceInquiry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ServiceInquiry serviceInquiry = new ServiceInquiry();
                serviceInquiry.Id = Convert.ToInt32(dr["Id"]);

                serviceInquiry.Name = Convert.ToString(dr["Name"]);
                serviceInquiry.Address = Convert.ToString(dr["Address"]);
                serviceInquiry.Contact = Convert.ToString(dr["Contact"]);
                serviceInquiry.Email = Convert.ToString(dr["Email"]);
                serviceInquiry.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                serviceInquiry.TextMessage = Convert.ToString(dr["TextMessage"]);
                serviceInquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                serviceInquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                serviceInquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                serviceInquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                serviceInquiryList.Add(serviceInquiry);
            }
            con.Close();
            return serviceInquiryList;
        }

        public ServiceInquiry GetServiceInquiryById(int Id)
        {
            ServiceInquiry serviceInquiry = new ServiceInquiry();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetServiceInquiryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                serviceInquiry.Id = Convert.ToInt32(dr["Id"]);

                serviceInquiry.Name = Convert.ToString(dr["Name"]);
                serviceInquiry.Address = Convert.ToString(dr["Address"]);
                serviceInquiry.Contact = Convert.ToString(dr["Contact"]);
                serviceInquiry.Email = Convert.ToString(dr["Email"]);
                serviceInquiry.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                serviceInquiry.TextMessage = Convert.ToString(dr["TextMessage"]);
                serviceInquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                serviceInquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                serviceInquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                serviceInquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return serviceInquiry;
        }


        public string AddServiceInquiry(ServiceInquiry serviceInquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddServiceInquiry", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = serviceInquiry.Name;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = serviceInquiry.Address;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = serviceInquiry.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = serviceInquiry.Email;
            cmd.Parameters.Add("p_ServiceId", MySqlDbType.Int32).Value = serviceInquiry.ServiceId;
            cmd.Parameters.Add("p_TextMessage", MySqlDbType.VarChar).Value = serviceInquiry.TextMessage;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = serviceInquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = serviceInquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = serviceInquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = serviceInquiry.UpdatedDate;


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


        public string UpdateServiceInquiry(ServiceInquiry serviceInquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateContact", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = serviceInquiry.Id;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = serviceInquiry.Name;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = serviceInquiry.Address;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = serviceInquiry.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = serviceInquiry.Email;
            cmd.Parameters.Add("p_ServiceId", MySqlDbType.Int32).Value = serviceInquiry.ServiceId;
            cmd.Parameters.Add("p_TextMessage", MySqlDbType.VarChar).Value = serviceInquiry.TextMessage;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = serviceInquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = serviceInquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = serviceInquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = serviceInquiry.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }


        public string DeleteServiceInquiry(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteServiceInquiry", con);
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