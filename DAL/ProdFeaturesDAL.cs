using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ProdFeaturesDAL
    {
        DbConnection conn = null;
        public ProdFeaturesDAL()  
        {
            conn = new DbConnection();
        }

        public List<ProdFeatures> GetAllProdFeatures()
          {
            List<ProdFeatures> prodFeaturesList = new List<ProdFeatures>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProdFeatures", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProdFeatures prodFeatures = new ProdFeatures();
                prodFeatures.Product = new Product();

                


                prodFeatures.Id = Convert.ToInt32(dr["Id"]);
                prodFeatures.Title = Convert.ToString(dr["Title"]);
                prodFeatures.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodFeatures.Description = Convert.ToString(dr["Description"]);
                prodFeatures.Image = Convert.ToString(dr["Image"]);
                prodFeatures.ProductId = Convert.ToInt32(dr["ProductId"]);

                prodFeatures.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodFeatures.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodFeatures.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                prodFeatures.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                prodFeatures.Product.Id = Convert.ToInt32(dr["Id"]);
                prodFeatures.Product.Title = Convert.ToString(dr["Title1"]);
                prodFeatures.Product.SubTitle = Convert.ToString(dr["SubTitle1"]);
                prodFeatures.Product.Description = Convert.ToString(dr["Description1"]);
                prodFeatures.Product.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                prodFeatures.Product.ProdSubTypeId = Convert.ToInt32(dr["ProdSubTypeId"]);
                prodFeatures.Product.MainImage = Convert.ToString(dr["MainImage"]);
                prodFeatures.Product.ProdIcon = Convert.ToString(dr["ProdIcon"]);
                prodFeatures.Product.Imageone = Convert.ToString(dr["Imageone"]);
                prodFeatures.Product.Imagetwo = Convert.ToString(dr["Imagetwo"]);
                prodFeatures.Product.Imagethree = Convert.ToString(dr["Imagethree"]);
                prodFeatures.Product.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                prodFeatures.Product.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                prodFeatures.Product.DemoLink = Convert.ToString(dr["DemoLink"]);
                prodFeatures.Product.PricingLink = Convert.ToString(dr["PricingLink"]);






                prodFeaturesList.Add(prodFeatures);
            }
            con.Close();
            return prodFeaturesList;
        }

        public ProdFeatures GetProdFeaturesById(int Id)
        {

            ProdFeatures prodFeatures = new ProdFeatures();


            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProdFeaturesById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                prodFeatures.Product = new Product();


                prodFeatures.Id = Convert.ToInt32(dr["Id"]);
                prodFeatures.Title = Convert.ToString(dr["Title"]);
                prodFeatures.SubTitle = Convert.ToString(dr["SubTitle"]);
                prodFeatures.Description = Convert.ToString(dr["Description"]);
                prodFeatures.Image = Convert.ToString(dr["Image"]);
                prodFeatures.ProductId = Convert.ToInt32(dr["ProductId"]);
                prodFeatures.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                prodFeatures.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                prodFeatures.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                prodFeatures.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                prodFeatures.Product.Id = Convert.ToInt32(dr["Id"]);
                prodFeatures.Product.Title = Convert.ToString(dr["Title1"]);
                prodFeatures.Product.SubTitle = Convert.ToString(dr["SubTitle1"]);
                prodFeatures.Product.Description = Convert.ToString(dr["Description1"]);
                prodFeatures.Product.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                prodFeatures.Product.ProdSubTypeId = Convert.ToInt32(dr["ProdSubTypeId"]);
                prodFeatures.Product.MainImage = Convert.ToString(dr["MainImage"]);
                prodFeatures.Product.ProdIcon = Convert.ToString(dr["ProdIcon"]);
                prodFeatures.Product.Imageone = Convert.ToString(dr["Imageone"]);
                prodFeatures.Product.Imagetwo = Convert.ToString(dr["Imagetwo"]);
                prodFeatures.Product.Imagethree = Convert.ToString(dr["Imagethree"]);
                prodFeatures.Product.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                prodFeatures.Product.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                prodFeatures.Product.DemoLink = Convert.ToString(dr["DemoLink"]);
                prodFeatures.Product.PricingLink = Convert.ToString(dr["PricingLink"]);

            }
            con.Close();
            return prodFeatures;
        }


        public string AddProdFeatures(ProdFeatures prodFeatures)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProdFeatures", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodFeatures.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodFeatures.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodFeatures.Description;
            cmd.Parameters.Add("p_ProductId", MySqlDbType.Int32).Value = prodFeatures.ProductId;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodFeatures.Image;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodFeatures.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodFeatures.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodFeatures.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodFeatures.UpdatedBy;





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


        public string UpdateProdFeatures(ProdFeatures prodFeatures)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProdFeatures", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = prodFeatures.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = prodFeatures.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = prodFeatures.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = prodFeatures.Description;
            cmd.Parameters.Add("p_ProductId", MySqlDbType.Int32).Value = prodFeatures.ProductId;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = prodFeatures.Image;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = prodFeatures.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = prodFeatures.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = prodFeatures.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = prodFeatures.UpdatedBy;



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
            return prodFeatures.Id.ToString();
        }

        public string DeleteProdFeatures(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProdFeatures", con);
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