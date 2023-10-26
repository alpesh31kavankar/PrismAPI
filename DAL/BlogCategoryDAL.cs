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
    public class BlogCategoryDAL
    {
        DbConnection conn = null;
        public BlogCategoryDAL()
        {
            conn = new DbConnection();
        }

        public List<BlogCategory> GetAllBlogCategory()
        {
            List<BlogCategory> blogCategoryList = new List<BlogCategory>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllBlogCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BlogCategory blogCategory = new BlogCategory();
                blogCategory.Id = Convert.ToInt32(dr["Id"]);

                blogCategory.Title = Convert.ToString(dr["Title"]);
                blogCategory.Subtitle = Convert.ToString(dr["Subtitle"]);
                blogCategory.Image = Convert.ToString(dr["Image"]);
                blogCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blogCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blogCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                blogCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                blogCategoryList.Add(blogCategory);
            }
            con.Close();
            return blogCategoryList;
        }

        public BlogCategory GetBlogCategoryById(int Id)
        {
            BlogCategory blogCategory = new BlogCategory();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetBlogCategoryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                blogCategory.Id = Convert.ToInt32(dr["Id"]);

                blogCategory.Title = Convert.ToString(dr["Title"]);
                blogCategory.Subtitle = Convert.ToString(dr["Subtitle"]);
                blogCategory.Image = Convert.ToString(dr["Image"]);
                blogCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blogCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blogCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                blogCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return blogCategory;
        }


        public string AddBlogCategory(BlogCategory blogCategory)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddBlogCategory", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = blogCategory.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = blogCategory.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = blogCategory.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = blogCategory.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = blogCategory.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = blogCategory.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = blogCategory.UpdatedDate;


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


        public string UpdateBlogCategory(BlogCategory blogCategory)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateBlogCategory", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = blogCategory.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = blogCategory.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = blogCategory.Subtitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = blogCategory.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = blogCategory.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = blogCategory.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = blogCategory.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = blogCategory.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return blogCategory.Id.ToString();
        }


        public string DeleteBlogCategory(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteBlogCategory", con);
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