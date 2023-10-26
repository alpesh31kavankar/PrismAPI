using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class BlogDAL
    {
        DbConnection conn = null;
        public BlogDAL()
        {
            conn = new DbConnection();
        }

        public List<Blog> GetAllBlog()
        {
            List<Blog> blogList = new List<Blog>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllBlog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Blog blog = new Blog();
                blog.BlogCategory = new BlogCategory();




                blog.Id = Convert.ToInt32(dr["Id"]);
                blog.Title = Convert.ToString(dr["Title"]);
                blog.Subtitle = Convert.ToString(dr["Subtitle"]);
                blog.Description = Convert.ToString(dr["Description"]);
                blog.BlogCategoryId = Convert.ToInt32(dr["BlogCategoryId"]);
                blog.Sectionone = Convert.ToString(dr["Sectionone"]);
                blog.Sectiontwo = Convert.ToString(dr["Sectiontwo"]);
                blog.Sectionthree = Convert.ToString(dr["Sectionthree"]);
                blog.BlogImg = Convert.ToString(dr["BlogImg"]);
                blog.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blog.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blog.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                blog.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                blog.BlogCategory.Id = Convert.ToInt32(dr["Id"]);
                blog.BlogCategory.Title = Convert.ToString(dr["Title1"]);
                blog.BlogCategory.Subtitle = Convert.ToString(dr["Subtitle1"]);
                blog.BlogCategory.Image = Convert.ToString(dr["Image"]);

                //  calender.UpdatedBy = DateTime.Now.ToString("MM/dd/yyyy");


                blogList.Add(blog);
            }
            con.Close();
            return blogList;
        }

        public Blog GetBlogById(int Id)
        {
            Blog blog = new Blog();
            blog.BlogCategory = new BlogCategory();


            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetBlogById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                blog.Id = Convert.ToInt32(dr["Id"]);
                blog.Title = Convert.ToString(dr["Title"]);
                blog.Subtitle = Convert.ToString(dr["Subtitle"]);
                blog.Description = Convert.ToString(dr["Description"]);
                blog.BlogCategoryId = Convert.ToInt32(dr["BlogCategoryId"]);
                blog.Sectionone = Convert.ToString(dr["Sectionone"]);
                blog.Sectiontwo = Convert.ToString(dr["Sectiontwo"]);
                blog.Sectionthree = Convert.ToString(dr["Sectionthree"]);
                blog.BlogImg = Convert.ToString(dr["BlogImg"]);
                blog.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blog.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blog.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                blog.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                blog.BlogCategory.Id = Convert.ToInt32(dr["Id"]);
                blog.BlogCategory.Title = Convert.ToString(dr["Title1"]);
                blog.BlogCategory.Subtitle = Convert.ToString(dr["Subtitle1"]);
                blog.BlogCategory.Image = Convert.ToString(dr["Image"]);

            }
            con.Close();
            return blog;
        }


        public string AddBlog(Blog blog)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddBlog", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = blog.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = blog.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = blog.Description;
            cmd.Parameters.Add("p_BlogCategoryId", MySqlDbType.Int32).Value = blog.BlogCategoryId;
            cmd.Parameters.Add("p_Sectionone", MySqlDbType.VarChar).Value = blog.Sectionone;
            cmd.Parameters.Add("p_Sectiontwo", MySqlDbType.VarChar).Value = blog.Sectiontwo;
            cmd.Parameters.Add("p_Sectionthree", MySqlDbType.VarChar).Value = blog.Sectionthree;
            cmd.Parameters.Add("p_BlogImg", MySqlDbType.VarChar).Value = blog.BlogImg;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = blog.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = blog.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = blog.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = blog.UpdatedBy;





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


        public string UpdateBlog(Blog blog)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateBlog", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = blog.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = blog.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = blog.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = blog.Description;
            cmd.Parameters.Add("p_BlogCategoryId", MySqlDbType.Int32).Value = blog.BlogCategoryId;
            cmd.Parameters.Add("p_Sectionone", MySqlDbType.VarChar).Value = blog.Sectionone;
            cmd.Parameters.Add("p_Sectiontwo", MySqlDbType.VarChar).Value = blog.Sectiontwo;
            cmd.Parameters.Add("p_Sectionthree", MySqlDbType.VarChar).Value = blog.Sectionthree;
            cmd.Parameters.Add("p_BlogImg", MySqlDbType.VarChar).Value = blog.BlogImg;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = blog.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = blog.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = blog.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = blog.UpdatedBy;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return blog.Id.ToString();
        }


        public string DeleteBlog(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteBlog", con);
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