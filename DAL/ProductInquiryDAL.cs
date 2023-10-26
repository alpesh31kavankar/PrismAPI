using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ProductInquiryDAL
    {
        DbConnection conn = null;
        public ProductInquiryDAL()
        {
            conn = new DbConnection();
         }   

        public List<ProductInquiry> GetAllProductInquiry()
        {
            List<ProductInquiry> productInquiryList = new List<ProductInquiry>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProductInquiry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProductInquiry productInquiry = new ProductInquiry();
                productInquiry.Id = Convert.ToInt32(dr["Id"]);

                productInquiry.Name = Convert.ToString(dr["Name"]);
                productInquiry.Address = Convert.ToString(dr["Address"]);
                productInquiry.Contact = Convert.ToString(dr["Contact"]);
                productInquiry.Email = Convert.ToString(dr["Email"]);
                productInquiry.ProductId = Convert.ToInt32(dr["ProductId"]);
                productInquiry.TextMessage = Convert.ToString(dr["TextMessage"]);
                productInquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                productInquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                productInquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                productInquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                productInquiryList.Add(productInquiry);
            }
            con.Close();
            return productInquiryList;
        }

        public ProductInquiry GetProductInquiryById(int Id)
        {
            ProductInquiry productInquiry = new ProductInquiry();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProductInquiryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                productInquiry.Id = Convert.ToInt32(dr["Id"]);

                productInquiry.Name = Convert.ToString(dr["Name"]);
                productInquiry.Address = Convert.ToString(dr["Address"]);
                productInquiry.Contact = Convert.ToString(dr["Contact"]);
                productInquiry.Email = Convert.ToString(dr["Email"]);
                productInquiry.ProductId = Convert.ToInt32(dr["ProductId"]);
                productInquiry.TextMessage = Convert.ToString(dr["TextMessage"]);
                productInquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                productInquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                productInquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                productInquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return productInquiry;
        }


        public string AddProductInquiry(ProductInquiry productInquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProductInquiry", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = productInquiry.Name;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = productInquiry.Address;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = productInquiry.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = productInquiry.Email;
            cmd.Parameters.Add("p_ProductId", MySqlDbType.Int32).Value = productInquiry.ProductId;
            cmd.Parameters.Add("p_TextMessage", MySqlDbType.VarChar).Value = productInquiry.TextMessage;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = productInquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = productInquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = productInquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = productInquiry.UpdatedDate;


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


        public string UpdateProductInquiry(ProductInquiry productInquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProductInquiry", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = productInquiry.Id;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = productInquiry.Name;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = productInquiry.Address;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = productInquiry.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = productInquiry.Email;
            cmd.Parameters.Add("p_ProductId", MySqlDbType.Int32).Value = productInquiry.ProductId;
            cmd.Parameters.Add("p_TextMessage", MySqlDbType.VarChar).Value = productInquiry.TextMessage;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = productInquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = productInquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = productInquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = productInquiry.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }


        public string DeleteProductInquiry(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProductInquiry", con);
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