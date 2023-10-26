using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using static Hephaestus.Prototypes;

namespace PrismAPI.DAL
{
    public class ProductDAL
    {        
        DbConnection conn = null;  
        public ProductDAL()
        {
            conn = new DbConnection();
        }

        public List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Product product = new Product();
                product.ProdType = new ProdType();
                product.ProdSubType = new ProdSubType();
                product.ServiceMainType = new ServiceMainType();
                product.ServiceSubType = new ServiceSubType();


                product.Id = Convert.ToInt32(dr["Id"]);
                product.Title = Convert.ToString(dr["Title"]);
                product.SubTitle = Convert.ToString(dr["SubTitle"]);
                product.Description = Convert.ToString(dr["Description"]);
                product.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                product.ProdSubTypeId = Convert.ToInt32(dr["ProdSubTypeId"]);
                product.MainImage = Convert.ToString(dr["MainImage"]);
                product.ProdIcon = Convert.ToString(dr["ProdIcon"]);
                product.Imageone = Convert.ToString(dr["Imageone"]);
                product.Imagetwo = Convert.ToString(dr["Imagetwo"]);
                product.Imagethree = Convert.ToString(dr["Imagethree"]);
                product.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                product.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                product.DemoLink = Convert.ToString(dr["DemoLink"]);
                product.PricingLink = Convert.ToString(dr["PricingLink"]);
                product.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                product.ProdType.Id = Convert.ToInt32(dr["Id1"]);
                product.ProdType.Title = Convert.ToString(dr["Title1"]);
                product.ProdType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                product.ProdType.Description = Convert.ToString(dr["Description1"]);
                product.ProdType.Image = Convert.ToString(dr["Image"]);
                product.ProdType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ProdType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ProdType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                product.ProdType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


                product.ProdSubType.Id = Convert.ToInt32(dr["Id2"]);
                product.ProdSubType.Title = Convert.ToString(dr["Title2"]);
                product.ProdSubType.SubTitle = Convert.ToString(dr["SubTitle2"]);
                product.ProdSubType.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                product.ProdSubType.Description = Convert.ToString(dr["Description2"]);
                product.ProdSubType.Image = Convert.ToString(dr["Image2"]);
                product.ProdSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ProdSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ProdSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                product.ProdSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


                product.ServiceMainType.Id = Convert.ToInt32(dr["Id3"]);
                product.ServiceMainType.Title = Convert.ToString(dr["Title3"]);
                product.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle3"]);
                product.ServiceMainType.Description = Convert.ToString(dr["Description3"]);
                product.ServiceMainType.Image = Convert.ToString(dr["Image3"]);
                product.ServiceMainType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ServiceMainType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ServiceMainType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.ServiceMainType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                product.ServiceSubType.Id = Convert.ToInt32(dr["Id4"]);
                product.ServiceSubType.Title = Convert.ToString(dr["Title4"]);
                product.ServiceSubType.SubTitle = Convert.ToString(dr["SubTitle4"]);
                product.ServiceSubType.Description = Convert.ToString(dr["Description4"]);
                product.ServiceSubType.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                product.ServiceSubType.Image = Convert.ToString(dr["Image4"]);
                product.ServiceSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ServiceSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ServiceSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.ServiceSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                productList.Add(product);
            }
            con.Close();
            return productList;
        }

        public Product GetProductById(int Id)
        {

            Product product = new Product();
            product.ProdType = new ProdType();
            product.ProdSubType = new ProdSubType();
            product.ServiceMainType = new ServiceMainType();
            product.ServiceSubType = new ServiceSubType();


            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProductById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                product.Id = Convert.ToInt32(dr["Id"]);
                product.Title = Convert.ToString(dr["Title"]);
                product.SubTitle = Convert.ToString(dr["SubTitle"]);
                product.Description = Convert.ToString(dr["Description"]);
                product.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                product.ProdSubTypeId = Convert.ToInt32(dr["ProdSubTypeId"]);
                product.MainImage = Convert.ToString(dr["MainImage"]);
                product.ProdIcon = Convert.ToString(dr["ProdIcon"]);
                product.Imageone = Convert.ToString(dr["Imageone"]);
                product.Imagetwo = Convert.ToString(dr["Imagetwo"]);
                product.Imagethree = Convert.ToString(dr["Imagethree"]);
                product.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                product.ServiceSubTypeId = Convert.ToInt32(dr["ServiceSubTypeId"]);
                product.DemoLink = Convert.ToString(dr["DemoLink"]);
                product.PricingLink = Convert.ToString(dr["PricingLink"]);

                product.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                product.ProdType.Id = Convert.ToInt32(dr["Id1"]);
                product.ProdType.Title = Convert.ToString(dr["Title1"]);
                product.ProdType.SubTitle = Convert.ToString(dr["SubTitle1"]);
                product.ProdType.Description = Convert.ToString(dr["Description1"]);
                product.ProdType.Image = Convert.ToString(dr["Image"]);
                product.ProdType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ProdType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ProdType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                product.ProdType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


                product.ProdSubType.Id = Convert.ToInt32(dr["Id2"]);
                product.ProdSubType.Title = Convert.ToString(dr["Title2"]);
                product.ProdSubType.SubTitle = Convert.ToString(dr["SubTitle2"]);
                product.ProdSubType.ProdTypeId = Convert.ToInt32(dr["ProdTypeId"]);
                product.ProdSubType.Description = Convert.ToString(dr["Description2"]);
                product.ProdSubType.Image = Convert.ToString(dr["Image2"]);
                product.ProdSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ProdSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ProdSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                product.ProdSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


                product.ServiceMainType.Id = Convert.ToInt32(dr["Id3"]);
                product.ServiceMainType.Title = Convert.ToString(dr["Title3"]);
                product.ServiceMainType.SubTitle = Convert.ToString(dr["SubTitle3"]);
                product.ServiceMainType.Description = Convert.ToString(dr["Description3"]);
                product.ServiceMainType.Image = Convert.ToString(dr["Image3"]);
                product.ServiceMainType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ServiceMainType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ServiceMainType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.ServiceMainType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                product.ServiceSubType.Id = Convert.ToInt32(dr["Id4"]);
                product.ServiceSubType.Title = Convert.ToString(dr["Title4"]);
                product.ServiceSubType.SubTitle = Convert.ToString(dr["SubTitle4"]);
                product.ServiceSubType.Description = Convert.ToString(dr["Description4"]);
                product.ServiceSubType.ServiceMainTypeId = Convert.ToInt32(dr["ServiceMainTypeId"]);
                product.ServiceSubType.Image = Convert.ToString(dr["Image4"]);
                product.ServiceSubType.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                product.ServiceSubType.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                product.ServiceSubType.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                product.ServiceSubType.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


            }
            con.Close();
            return product;
        }


        public string AddProduct(Product product)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProduct", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = product.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = product.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = product.Description;
            cmd.Parameters.Add("p_ProdTypeId", MySqlDbType.Int32).Value = product.ProdTypeId;
            cmd.Parameters.Add("p_ProdSubTypeId", MySqlDbType.Int32).Value = product.ProdSubTypeId;
            cmd.Parameters.Add("p_MainImage", MySqlDbType.VarChar).Value = product.MainImage;
            cmd.Parameters.Add("p_ProdIcon", MySqlDbType.VarChar).Value = product.ProdIcon;
            cmd.Parameters.Add("p_Imageone", MySqlDbType.VarChar).Value = product.Imageone;
            cmd.Parameters.Add("p_Imagetwo", MySqlDbType.VarChar).Value = product.Imagetwo;
            cmd.Parameters.Add("p_Imagethree", MySqlDbType.VarChar).Value = product.Imagethree;
            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = product.ServiceMainTypeId;
            cmd.Parameters.Add("p_ServiceSubTypeId", MySqlDbType.Int32).Value = product.ServiceSubTypeId;
            cmd.Parameters.Add("p_DemoLink", MySqlDbType.VarChar).Value = product.DemoLink;
            cmd.Parameters.Add("p_PricingLink", MySqlDbType.VarChar).Value = product.PricingLink;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = product.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = product.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = product.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = product.UpdatedBy;





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


        public string UpdateProduct(Product product)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProduct", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = product.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = product.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = product.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = product.Description;
            cmd.Parameters.Add("p_ProdTypeId", MySqlDbType.Int32).Value = product.ProdTypeId;
            cmd.Parameters.Add("p_ProdSubTypeId", MySqlDbType.Int32).Value = product.ProdSubTypeId;
            cmd.Parameters.Add("p_MainImage", MySqlDbType.VarChar).Value = product.MainImage;
            cmd.Parameters.Add("p_ProdIcon", MySqlDbType.VarChar).Value = product.ProdIcon;
            cmd.Parameters.Add("p_Imageone", MySqlDbType.VarChar).Value = product.Imageone;
            cmd.Parameters.Add("p_Imagetwo", MySqlDbType.VarChar).Value = product.Imagetwo;
            cmd.Parameters.Add("p_Imagethree", MySqlDbType.VarChar).Value = product.Imagethree;
            cmd.Parameters.Add("p_ServiceMainTypeId", MySqlDbType.Int32).Value = product.ServiceMainTypeId;
            cmd.Parameters.Add("p_ServiceSubTypeId", MySqlDbType.Int32).Value = product.ServiceSubTypeId;
            cmd.Parameters.Add("p_DemoLink", MySqlDbType.VarChar).Value = product.DemoLink;
            cmd.Parameters.Add("p_PricingLink", MySqlDbType.VarChar).Value = product.PricingLink;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = product.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = product.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = product.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = product.UpdatedBy;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return product.Id.ToString();
        }


        public string DeleteProduct(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProduct", con);
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