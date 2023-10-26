using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ClientDAL
    {
        DbConnection conn = null;
        public ClientDAL()
        {
            conn = new DbConnection();
        }

        public List<Client> GetAllClient()
        {
            List<Client> clientList = new List<Client>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Client client = new Client();
                //Dynamic
                client.Service = new Service();
                client.ServiceMainType = new ServiceMainType();
                client.ServiceSubType = new ServiceSubType();

                client.Id = Convert.ToInt32(dr["Id"]);

                client.ServiceMainType.Title = Convert.ToString(dr["Title2"]);
                client.ServiceSubType.Title = Convert.ToString(dr["Title3"]);

                client.Service.Id = Convert.ToInt32(dr["ServiceId"]);

                client.Service.Title = Convert.ToString(dr["Title"]);
                client.Service.SubTitle = Convert.ToString(dr["Subtitle"]);
                client.Service.Description = Convert.ToString(dr["Description1"]);
                client.Service.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                client.Service.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                client.Service.Image = Convert.ToString(dr["Image"]);


                client.Name = Convert.ToString(dr["Name"]);
                client.Description = Convert.ToString(dr["Description"]);
                client.address = Convert.ToString(dr["address"]);
                client.City = Convert.ToString(dr["City"]);
                client.Logo = Convert.ToString(dr["Logo"]);
                client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                client.Contact = Convert.ToString(dr["Contact"]);
                client.Email = Convert.ToString(dr["Email"]);
                client.ClientType = Convert.ToString(dr["ClientType"]);
                client.Website = Convert.ToString(dr["Website"]);
                client.OwnerName = Convert.ToString(dr["OwnerName"]);
                client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                client.Facebook = Convert.ToString(dr["Facebook"]);
                client.Instagram = Convert.ToString(dr["Instagram"]);
                client.Tweeter = Convert.ToString(dr["Tweeter"]);
                client.Status = Convert.ToString(dr["Status"]);
                client.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                client.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                client.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                client.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                clientList.Add(client);
            }
            con.Close();
            return clientList;
        }

        public Client GetClientById(int Id)
        {
            Client client = new Client();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetClientById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                //Dynamic Dropdown
                client.Service = new Service();
                client.ServiceMainType = new ServiceMainType();
                client.ServiceSubType = new ServiceSubType();
                client.Id = Convert.ToInt32(dr["Id"]);
                client.ServiceMainType.Title = Convert.ToString(dr["Title2"]);
                client.ServiceSubType.Title = Convert.ToString(dr["Title3"]);
                //dynamic Dropdown
                client.Service.Id = Convert.ToInt32(dr["ServiceId"]);

                client.Service.Title = Convert.ToString(dr["Title"]);
                client.Service.SubTitle = Convert.ToString(dr["Subtitle"]);
                client.Service.Description = Convert.ToString(dr["Description1"]);
                client.Service.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                client.Service.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                client.Service.Image = Convert.ToString(dr["Image"]);


                client.Name = Convert.ToString(dr["Name"]);
                client.Description = Convert.ToString(dr["Description"]);
                client.address = Convert.ToString(dr["address"]);
                client.City = Convert.ToString(dr["City"]);
                client.Logo = Convert.ToString(dr["Logo"]);
                client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                client.Contact = Convert.ToString(dr["Contact"]);
                client.Email = Convert.ToString(dr["Email"]);
                client.ClientType = Convert.ToString(dr["ClientType"]);
                client.Website = Convert.ToString(dr["Website"]);
                client.OwnerName = Convert.ToString(dr["OwnerName"]);
                client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                client.Facebook = Convert.ToString(dr["Facebook"]);
                client.Instagram = Convert.ToString(dr["Instagram"]);
                client.Tweeter = Convert.ToString(dr["Tweeter"]);
                client.Status = Convert.ToString(dr["Status"]);
                client.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                client.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                client.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                client.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return client;
        }


        public string AddClient(Client client)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddClient", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = client.Name;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = client.Description;
            cmd.Parameters.Add("p_address", MySqlDbType.VarChar).Value = client.address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = client.City;
            cmd.Parameters.Add("p_Logo", MySqlDbType.VarChar).Value = client.Logo;
            cmd.Parameters.Add("p_ServiceId", MySqlDbType.Int32).Value = client.ServiceId;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = client.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = client.Email;
            cmd.Parameters.Add("p_ClientType", MySqlDbType.VarChar).Value = client.ClientType;
            cmd.Parameters.Add("p_Website", MySqlDbType.VarChar).Value = client.Website;
            cmd.Parameters.Add("p_OwnerName", MySqlDbType.VarChar).Value = client.OwnerName;
            cmd.Parameters.Add("p_OwnerPhoto", MySqlDbType.VarChar).Value = client.OwnerPhoto;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = client.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = client.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = client.Tweeter;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = client.Status;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = client.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = client.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = client.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = client.UpdatedDate;


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


        public string UpdateClient(Client client)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateClient", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = client.Id;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = client.Name;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = client.Description;
            cmd.Parameters.Add("p_address", MySqlDbType.VarChar).Value = client.address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = client.City;
            cmd.Parameters.Add("p_Logo", MySqlDbType.VarChar).Value = client.Logo;
            cmd.Parameters.Add("p_ServiceId", MySqlDbType.Int32).Value = client.ServiceId;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = client.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = client.Email;
            cmd.Parameters.Add("p_ClientType", MySqlDbType.VarChar).Value = client.ClientType;
            cmd.Parameters.Add("p_Website", MySqlDbType.VarChar).Value = client.Website;
            cmd.Parameters.Add("p_OwnerName", MySqlDbType.VarChar).Value = client.OwnerName;
            cmd.Parameters.Add("p_OwnerPhoto", MySqlDbType.VarChar).Value = client.OwnerPhoto;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = client.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = client.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = client.Tweeter;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = client.Status;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = client.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = client.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = client.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = client.UpdatedDate;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return client.Id.ToString();
        }


        public string DeleteClient(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteClient", con);
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