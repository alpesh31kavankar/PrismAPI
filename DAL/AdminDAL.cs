using PrismAPI.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class AdminDAL
    {
        DbConnection conn = null;
        public AdminDAL()
        {
            conn = new DbConnection();
        }

        public List<Admin> GetAllAdmin()
        {
            List<Admin> adminList = new List<Admin>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Admin admin = new Admin();
                admin.Id = Convert.ToInt32(dr["Id"]);

                admin.FName = Convert.ToString(dr["FName"]);
                admin.LName = Convert.ToString(dr["LName"]);
                admin.Email = Convert.ToString(dr["Email"]);
                admin.Contact = Convert.ToString(dr["Contact"]);
                admin.Address = Convert.ToString(dr["Address"]);
                admin.Password = Convert.ToString(dr["Password"]);
                admin.Photo = Convert.ToString(dr["Photo"]);
                admin.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                admin.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                admin.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                admin.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                adminList.Add(admin);
            }
            con.Close();
            return adminList;
        }

        public Admin GetAdminById(int Id)
        {
            Admin admin = new Admin();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAdminById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                admin.Id = Convert.ToInt32(dr["Id"]);

                admin.FName = Convert.ToString(dr["FName"]);
                admin.LName = Convert.ToString(dr["LName"]);
                admin.Email = Convert.ToString(dr["Email"]);
                admin.Contact = Convert.ToString(dr["Contact"]);
                admin.Address = Convert.ToString(dr["Address"]);
                admin.Password = Convert.ToString(dr["Password"]);
                admin.Photo = Convert.ToString(dr["Photo"]);
                admin.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                admin.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                admin.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                admin.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return admin;
        }


        public string AddAdmin(Admin admin)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddAdmin", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = admin.FName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = admin.LName;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = admin.Email;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = admin.Contact;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = admin.Address;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = admin.Password;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = admin.Photo;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = admin.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = admin.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = admin.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = admin.UpdatedDate;


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

        public Logins Logins(string Email, string Password)
        {
            Logins user = new Logins();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAdminByEmailAndPassword",con);
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }

            return user;
        }


        public string UpdateAdmin(Admin admin)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateAdmin", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = admin.Id;
            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = admin.FName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = admin.LName;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = admin.Email;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = admin.Contact;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = admin.Address;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = admin.Password;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = admin.Photo;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = admin.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = admin.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = admin.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = admin.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return admin.Id.ToString();
        }


        public string DeleteAdmin(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteAdmin", con);
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