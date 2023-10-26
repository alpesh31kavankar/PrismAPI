using PrismAPI.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;

namespace PrismAPI.DAL
{
    public class ClientBankDetailsDAL
    {
        DbConnection conn = null;
        public ClientBankDetailsDAL()
        {
            conn = new DbConnection();
        }

        public List<ClientBankDetails> GetAllClientBankDetails()
        {
            List<ClientBankDetails> clientBankDetailsList = new List<ClientBankDetails>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllClientBankDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClientBankDetails clientBankDetails = new ClientBankDetails();
                //Dynamic Dropdown
                clientBankDetails.Client = new Client();
                clientBankDetails.Service = new Service();


                clientBankDetails.Id = Convert.ToInt32(dr["ClientBankDetailsId"]);
                //Dynamic Dropdown
                clientBankDetails.Service.Title = Convert.ToString(dr["Title3"]);
                clientBankDetails.Client.Id = Convert.ToInt32(dr["ClientId"]);
                clientBankDetails.Client.Name = Convert.ToString(dr["Name1"]);
                clientBankDetails.Client.Description = Convert.ToString(dr["Description"]);
                clientBankDetails.Client.address = Convert.ToString(dr["address"]);
                clientBankDetails.Client.City = Convert.ToString(dr["City"]);
                clientBankDetails.Client.Logo = Convert.ToString(dr["Logo"]);
                clientBankDetails.Client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                clientBankDetails.Client.Contact = Convert.ToString(dr["Contact"]);
                clientBankDetails.Client.Email = Convert.ToString(dr["Email"]);
                clientBankDetails.Client.ClientType = Convert.ToString(dr["ClientType"]);
                clientBankDetails.Client.Website = Convert.ToString(dr["Website"]);
                clientBankDetails.Client.OwnerName = Convert.ToString(dr["OwnerName"]);
                clientBankDetails.Client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                clientBankDetails.Client.Facebook = Convert.ToString(dr["Facebook"]);
                clientBankDetails.Client.Instagram = Convert.ToString(dr["Instagram"]);
                clientBankDetails.Client.Tweeter = Convert.ToString(dr["Tweeter"]);
                clientBankDetails.Client.Status = Convert.ToString(dr["Status"]);

                clientBankDetails.ClientId = Convert.ToInt32(dr["ClientId"]);

                clientBankDetails.AccountNo = Convert.ToString(dr["AccountNo"]);
                clientBankDetails.Name = Convert.ToString(dr["Name"]);
                clientBankDetails.IfsCode = Convert.ToString(dr["IfsCode"]);
                clientBankDetails.QRCode = Convert.ToString(dr["QRCode"]);
                clientBankDetails.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                clientBankDetails.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                clientBankDetails.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                clientBankDetails.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                clientBankDetailsList.Add(clientBankDetails);
            }
            con.Close();
            return clientBankDetailsList;
        }

        public ClientBankDetails GetClientBankDetailsById(int Id)
        {
            ClientBankDetails clientBankDetails = new ClientBankDetails();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetClientBankDetailsById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                //Dynamic Dropdown
                clientBankDetails.Client = new Client();
                clientBankDetails.Service = new Service();

                clientBankDetails.Id = Convert.ToInt32(dr["ClientBankDetailsId"]);
                //Dynamic Dropdown
                clientBankDetails.Service.Title = Convert.ToString(dr["Title3"]);
                clientBankDetails.Client.Id = Convert.ToInt32(dr["ClientId"]);

                clientBankDetails.Client.Name = Convert.ToString(dr["Name1"]);
                clientBankDetails.Client.Description = Convert.ToString(dr["Description"]);
                clientBankDetails.Client.address = Convert.ToString(dr["address"]);
                clientBankDetails.Client.City = Convert.ToString(dr["City"]);
                clientBankDetails.Client.Logo = Convert.ToString(dr["Logo"]);
                clientBankDetails.Client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                clientBankDetails.Client.Contact = Convert.ToString(dr["Contact"]);
                clientBankDetails.Client.Email = Convert.ToString(dr["Email"]);
                clientBankDetails.Client.ClientType = Convert.ToString(dr["ClientType"]);
                clientBankDetails.Client.Website = Convert.ToString(dr["Website"]);
                clientBankDetails.Client.OwnerName = Convert.ToString(dr["OwnerName"]);
                clientBankDetails.Client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                clientBankDetails.Client.Facebook = Convert.ToString(dr["Facebook"]);
                clientBankDetails.Client.Instagram = Convert.ToString(dr["Instagram"]);
                clientBankDetails.Client.Tweeter = Convert.ToString(dr["Tweeter"]);
                clientBankDetails.Client.Status = Convert.ToString(dr["Status"]);
                clientBankDetails.ClientId = Convert.ToInt32(dr["ClientId"]);
                clientBankDetails.AccountNo = Convert.ToString(dr["AccountNo"]);
                clientBankDetails.Name = Convert.ToString(dr["Name"]);
                clientBankDetails.IfsCode = Convert.ToString(dr["IfsCode"]);
                clientBankDetails.QRCode = Convert.ToString(dr["QRCode"]);
                clientBankDetails.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                clientBankDetails.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                clientBankDetails.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                clientBankDetails.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

            }
            con.Close();
            return clientBankDetails;
        }


        public string AddClientBankDetails(ClientBankDetails clientBankDetails)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddClientBankDetails", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;

            //  cmd.Parameters.Add("Id", MySqlDbType.Int).Value = profileDataEntry.Id;

            cmd.Parameters.Add("p_ClientId", MySqlDbType.Int32).Value = clientBankDetails.ClientId;
            cmd.Parameters.Add("p_AccountNo", MySqlDbType.VarChar).Value = clientBankDetails.AccountNo;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = clientBankDetails.Name;
            cmd.Parameters.Add("p_IfsCode", MySqlDbType.VarChar).Value = clientBankDetails.IfsCode;
            cmd.Parameters.Add("p_QRCode", MySqlDbType.VarChar).Value = clientBankDetails.QRCode;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = clientBankDetails.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = clientBankDetails.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = clientBankDetails.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = clientBankDetails.UpdatedBy;


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


        public string UpdateClientBankDetails(ClientBankDetails clientBankDetails)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateClientBankDetails", con);

            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = clientBankDetails.Id;
            cmd.Parameters.Add("p_ClientId", MySqlDbType.Int32).Value = clientBankDetails.ClientId;
            cmd.Parameters.Add("p_AccountNo", MySqlDbType.VarChar).Value = clientBankDetails.AccountNo;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = clientBankDetails.Name;
            cmd.Parameters.Add("p_IfsCode", MySqlDbType.VarChar).Value = clientBankDetails.IfsCode;
            cmd.Parameters.Add("p_QRCode", MySqlDbType.VarChar).Value = clientBankDetails.QRCode;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = clientBankDetails.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = clientBankDetails.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = clientBankDetails.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = clientBankDetails.UpdatedBy;




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
            return clientBankDetails.Id.ToString();
        }


        public string DeleteClientBankDetails(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteClientBankDetails", con);
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