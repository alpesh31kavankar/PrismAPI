using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ContactDAL
    {
        DbConnection conn = null;
        public ContactDAL()
        {
            conn = new DbConnection();
        }

        public List<Contact> GetAllContact()
        {
            List<Contact> contactList = new List<Contact>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllContact", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Contact contact = new Contact();
                contact.Id = Convert.ToInt32(dr["Id"]);

                contact.Name = Convert.ToString(dr["Name"]);
                contact.Email = Convert.ToString(dr["Email"]);
                contact.Subject = Convert.ToString(dr["Subject"]);
                contact.ContactNo = Convert.ToString(dr["ContactNo"]);
                contact.Message = Convert.ToString(dr["Message"]);
                contact.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                contact.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                contact.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                contact.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                contactList.Add(contact);
            }
            con.Close();
            return contactList;
        }

        public Contact GetContactById(int Id)
        {
            Contact contact = new Contact();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetContactById", con);
            cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                contact.Id = Convert.ToInt32(dr["Id"]);

                contact.Name = Convert.ToString(dr["Name"]);
                contact.Email = Convert.ToString(dr["Email"]);
                contact.Subject = Convert.ToString(dr["Subject"]);
                contact.ContactNo = Convert.ToString(dr["ContactNo"]);
                contact.Message = Convert.ToString(dr["Message"]);
                contact.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                contact.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                contact.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                contact.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return contact;
        }


        public string AddContact(Contact contact)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddContact", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = contact.Name;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = contact.Email;

            cmd.Parameters.Add("p_Subject", MySqlDbType.VarChar).Value = contact.Subject;
            cmd.Parameters.Add("p_ContactNo", MySqlDbType.VarChar).Value = contact.ContactNo;
            cmd.Parameters.Add("p_Message", MySqlDbType.VarChar).Value = contact.Message;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = contact.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = contact.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = contact.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = contact.UpdatedDate;


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


        public string UpdateContact(Contact contact)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateContact", con);
            cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = contact.Id;
            cmd.Parameters.Add("Name", MySqlDbType.VarChar).Value = contact.Name;
            cmd.Parameters.Add("Email", MySqlDbType.VarChar).Value = contact.Email;
            cmd.Parameters.Add("Subject", MySqlDbType.VarChar).Value = contact.Subject;
            cmd.Parameters.Add("ContactNo", MySqlDbType.VarChar).Value = contact.ContactNo;
            cmd.Parameters.Add("Message", MySqlDbType.VarChar).Value = contact.Message;
            cmd.Parameters.Add("CreatedBy", MySqlDbType.VarChar).Value = contact.CreatedBy;
            cmd.Parameters.Add("CreatedDate", MySqlDbType.VarChar).Value = contact.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", MySqlDbType.VarChar).Value = contact.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", MySqlDbType.VarChar).Value = contact.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }


        public string DeleteContact(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteContact", con);
            cmd.Parameters.Add("Id", MySqlDbType.Int32).Value = Id;
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