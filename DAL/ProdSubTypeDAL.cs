using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ProdSubTypeDAL
    {
        DbConnection conn = null;  
        public ProdSubTypeDAL()
        {
            conn = new DbConnection();
        }

        public List<ProdSubType> GetAllProdSubType()
        {
            List<ProdSubType> prodSubTypeList = new List<ProdSubType>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProdSubType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProdSubType prodSubType = new ProdSubType();
                //dynamic dropdown
                prodSubType.ProdType = new ProdType();
                prodSubType.Id = Convert.ToInt32(dr["Id"]);
                //dynamic dropdown
                prodSubType.ProdType.Id = Convert.ToInt32(dr["ProdTypeId"]);


                prodSubType.Title = Convert.ToString(dr["Title"]);
                prodSubType.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodSubType.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                prodSubType.Description = Convert.ToString(dr["Description"]);
                prodSubType.Image = Convert.ToString(dr["Image"]);

                //add list column

                prodSubType.ProdType.Title = Convert.ToString(dr["Title1"]);
                prodSubType.ProdType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                prodSubType.ProdType.Description = Convert.ToString(dr["Description1"]);
                prodSubType.ProdType.Image = Convert.ToString(dr["Image1"]);


                prodSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                prodSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


                prodSubTypeList.Add(prodSubType);
            }
            con.Close();
            return prodSubTypeList;
        }

        public ProdSubType GetProdSubTypeById(int Id)
        {
            ProdSubType prodSubType = new ProdSubType();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProdSubTypeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                //Dynamic Dropdown
                prodSubType.ProdType = new ProdType();

                prodSubType.Id = Convert.ToInt32(dr["Id"]);
                //Dynamic Dropdown
                prodSubType.ProdType.Id = Convert.ToInt32(dr["ProdTypeId"]);
                prodSubType.ProdType.Title = Convert.ToString(dr["Title1"]);
                prodSubType.ProdType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                prodSubType.ProdType.Description = Convert.ToString(dr["Description1"]);
                prodSubType.ProdType.Image = Convert.ToString(dr["Image1"]);

                prodSubType.Title = Convert.ToString(dr["Title"]);
                prodSubType.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodSubType.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                prodSubType.Description = Convert.ToString(dr["Description"]);
                prodSubType.Image = Convert.ToString(dr["Image"]);
                prodSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                prodSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return prodSubType;
        }


        public string AddProdSubType(ProdSubType prodSubType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProdSubType", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodSubType.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodSubType.SubTitle;
            cmd.Parameters.Add("p_ProdTypeId", MySqlDbType.Int32).Value = prodSubType.ProdTypeId;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodSubType.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodSubType.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodSubType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodSubType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodSubType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodSubType.UpdatedDate;


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


        public string UpdateProdSubType(ProdSubType prodSubType)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProdSubType", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = prodSubType.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodSubType.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodSubType.SubTitle;
            cmd.Parameters.Add("p_ProdTypeId", MySqlDbType.Int32).Value = prodSubType.ProdTypeId;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodSubType.Description;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodSubType.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodSubType.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodSubType.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodSubType.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodSubType.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return prodSubType.Id.ToString();
        }


        public string DeleteProdSubType(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProdSubType", con);
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