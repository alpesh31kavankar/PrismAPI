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
    public class GalleryCategoryDAL
    {
        DbConnection conn = null;
        public GalleryCategoryDAL()
        {
            conn = new DbConnection();  
        }

        public List<GalleryCategory> GetAllGalleryCategory()
        {
            List<GalleryCategory> galleryCategoryList = new List<GalleryCategory>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllGalleryCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                GalleryCategory galleryCategory = new GalleryCategory();
                galleryCategory.Id = Convert.ToInt32(dr["Id"]);

                galleryCategory.Title = Convert.ToString(dr["Title"]);
                galleryCategory.Subtitle = Convert.ToString(dr["Subtitle"]);
                galleryCategory.Image = Convert.ToString(dr["Image"]);
                galleryCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                galleryCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                galleryCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                galleryCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                galleryCategoryList.Add(galleryCategory);
            }
            con.Close();
            return galleryCategoryList;
        }

        public GalleryCategory GetGalleryCategoryById(int Id)
        {
            GalleryCategory galleryCategory = new GalleryCategory();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetGalleryCategoryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;   
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                galleryCategory.Id = Convert.ToInt32(dr["Id"]);

                galleryCategory.Title = Convert.ToString(dr["Title"]);
                galleryCategory.Subtitle = Convert.ToString(dr["Subtitle"]);
                galleryCategory.Image = Convert.ToString(dr["Image"]);
                galleryCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                galleryCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                galleryCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                galleryCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return galleryCategory;
        }


        public string AddGalleryCategory(GalleryCategory galleryCategory)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddGalleryCategory", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = galleryCategory.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = galleryCategory.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = galleryCategory.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = galleryCategory.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = galleryCategory.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = galleryCategory.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = galleryCategory.UpdatedDate;


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


        public string UpdateGalleryCategory(GalleryCategory galleryCategory)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateGalleryCategory", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = galleryCategory.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = galleryCategory.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = galleryCategory.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = galleryCategory.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = galleryCategory.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = galleryCategory.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = galleryCategory.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = galleryCategory.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return galleryCategory.Id.ToString();
        }


        public string DeleteGalleryCategory(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteGalleryCategory", con);
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