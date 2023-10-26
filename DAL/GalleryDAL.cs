using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using static Hephaestus.Logs;

namespace PrismAPI.DAL  
{
    public class GalleryDAL
    {
        DbConnection conn = null;
        public GalleryDAL()
        {
            conn = new DbConnection();
        }

        public List<Gallery> GetAllGallery()
        {
            List<Gallery> galleryList = new List<Gallery>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllGallery", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Gallery gallery = new Gallery();
                //Dynamic
                gallery.GalleryCategory = new GalleryCategory();
                gallery.Id = Convert.ToInt32(dr["Id"]);
                //dynamic Dropdown
                gallery.GalleryCategory.Id = Convert.ToInt32(dr["GalleryCategoryId"]);
                gallery.GalleryCategory.Title = Convert.ToString(dr["Title1"]);
                gallery.GalleryCategory.Subtitle = Convert.ToString(dr["Subtitle1"]);
                gallery.GalleryCategory.Image = Convert.ToString(dr["Image1"]);
                


                gallery.Title = Convert.ToString(dr["Title"]);
                gallery.Subtitle = Convert.ToString(dr["Subtitle"]);
                gallery.Description = Convert.ToString(dr["Description"]);
                gallery.galleryCategoryId = Convert.ToInt32(dr["galleryCategoryId"]);
                gallery.Image = Convert.ToString(dr["Image"]);
                gallery.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                gallery.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                gallery.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                gallery.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                galleryList.Add(gallery);
            }
            con.Close();
            return galleryList;
        }

        public Gallery GetGalleryById(int Id)
        {
            Gallery gallery = new Gallery();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetGalleryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                //Dynamic Dropdown
                gallery.GalleryCategory = new GalleryCategory();
                gallery.Id = Convert.ToInt32(dr["Id"]);
                //Dynamic Dropdown 
                gallery.GalleryCategory.Id = Convert.ToInt32(dr["GalleryCategoryId"]);
                gallery.GalleryCategory.Title = Convert.ToString(dr["Title1"]);
                gallery.GalleryCategory.Subtitle = Convert.ToString(dr["Subtitle1"]);
                gallery.GalleryCategory.Image = Convert.ToString(dr["Image1"]);
                gallery.Title = Convert.ToString(dr["Title"]);
                gallery.Subtitle = Convert.ToString(dr["Subtitle"]);
                gallery.Description = Convert.ToString(dr["Description"]);
                gallery.galleryCategoryId = Convert.ToInt32(dr["galleryCategoryId"]);
                gallery.Image = Convert.ToString(dr["Image"]);
                gallery.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                gallery.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                gallery.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                gallery.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return gallery;
        }


        public string AddGallery(Gallery gallery)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddGallery", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = gallery.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = gallery.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = gallery.Description;
            cmd.Parameters.Add("p_galleryCategoryId", MySqlDbType.Int32).Value = gallery.galleryCategoryId;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = gallery.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = gallery.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = gallery.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = gallery.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = gallery.UpdatedDate;


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


        public string UpdateGallery(Gallery gallery)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateGallery", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = gallery.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = gallery.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = gallery.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = gallery.Description;
            cmd.Parameters.Add("p_galleryCategoryId", MySqlDbType.Int32).Value = gallery.galleryCategoryId;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = gallery.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = gallery.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = gallery.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = gallery.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = gallery.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return gallery.Id.ToString();
        }


        public string DeleteGallery(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteGallery", con);
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