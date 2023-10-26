using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ProdTypeDAL
    {
        DbConnection conn = null;  
        public ProdTypeDAL()
        {
            conn = new DbConnection();
        }

        public List<ProdType> GetAllProdType()
        {
            List<ProdType> prodTypeList = new List<ProdType>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProdType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProdType prodType = new ProdType();
                prodType.Id = Convert.ToInt32(dr["Id"]);

                prodType.Title = Convert.ToString(dr["Title"]);
                prodType.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodType.Description = Convert.ToString(dr["Description"]);
                prodType.Image = Convert.ToString(dr["Image"]);
                prodType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                prodType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                prodTypeList.Add(prodType);
            }
            con.Close();
            return prodTypeList;
        }

        public ProdType GetProdTypeById(int Id)
        {
            ProdType prodType = new ProdType();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProdTypeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                prodType.Id = Convert.ToInt32(dr["Id"]);

                prodType.Title = Convert.ToString(dr["Title"]);
                prodType.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodType.Description = Convert.ToString(dr["Description"]);
                prodType.Image = Convert.ToString(dr["Image"]);
                prodType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                prodType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return prodType;
        }


        public string AddProdType(ProdType prodType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProdType", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;
            //clone1

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodType.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodType.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodType.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodType.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodType.UpdatedDate;


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


        public string UpdateProdType(ProdType prodType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProdType", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = prodType.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodType.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodType.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodType.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodType.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodType.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return prodType.Id.ToString();
        }


        public string DeleteProdType(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProdType", con);
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