using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;  

namespace PrismAPI.DAL
{
    public class JobPostDAL
    {
        DbConnection conn = null;
        public JobPostDAL()
        {
            conn = new DbConnection();
        }

        public List<JobPost> GetAllJobPost()
        {
            List<JobPost> jobPostList = new List<JobPost>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllJobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                JobPost jobPost = new JobPost();
                jobPost.Id = Convert.ToInt32(dr["Id"]);

                jobPost.Post = Convert.ToString(dr["Post"]);
                jobPost.SubTitle = Convert.ToString(dr["SubTitle"]);
                jobPost.Description = Convert.ToString(dr["Description"]);
                jobPost.Experience = Convert.ToString(dr["Experience"]);
                jobPost.Qualification = Convert.ToString(dr["Qualification"]);
                jobPost.Salary = Convert.ToString(dr["Salary"]);
                jobPost.SkillRequirement = Convert.ToString(dr["SkillRequirement"]);
                jobPost.Image = Convert.ToString(dr["Image"]);
                jobPost.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                jobPost.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                jobPost.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                jobPost.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                jobPostList.Add(jobPost);
            }
            con.Close();
            return jobPostList;
        }

        public JobPost GetJobPostById(int Id)
        {
            JobPost jobPost = new JobPost();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetJobPostById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                jobPost.Id = Convert.ToInt32(dr["Id"]);

                jobPost.Post = Convert.ToString(dr["Post"]);
                jobPost.SubTitle = Convert.ToString(dr["SubTitle"]);
                jobPost.Description = Convert.ToString(dr["Description"]);
                jobPost.Experience = Convert.ToString(dr["Experience"]);
                jobPost.Qualification = Convert.ToString(dr["Qualification"]);
                jobPost.Salary = Convert.ToString(dr["Salary"]);
                jobPost.SkillRequirement = Convert.ToString(dr["SkillRequirement"]);
                jobPost.Image = Convert.ToString(dr["Image"]);
                jobPost.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                jobPost.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                jobPost.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                jobPost.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return jobPost;
        }


        public string AddJobPost(JobPost jobPost)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddJobPost", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Post", MySqlDbType.VarChar).Value = jobPost.Post;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = jobPost.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = jobPost.Description;
            cmd.Parameters.Add("p_Experience", MySqlDbType.VarChar).Value = jobPost.Experience;
            cmd.Parameters.Add("p_Qualification", MySqlDbType.VarChar).Value = jobPost.Qualification;
            cmd.Parameters.Add("p_Salary", MySqlDbType.VarChar).Value = jobPost.Salary;
            cmd.Parameters.Add("p_SkillRequirement", MySqlDbType.VarChar).Value = jobPost.SkillRequirement;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = jobPost.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = jobPost.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = jobPost.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = jobPost.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = jobPost.UpdatedDate;


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


        public string UpdateJobPost(JobPost jobPost)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateJobPost", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = jobPost.Id;

            cmd.Parameters.Add("p_Post", MySqlDbType.VarChar).Value = jobPost.Post;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = jobPost.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = jobPost.Description;
            cmd.Parameters.Add("p_Experience", MySqlDbType.VarChar).Value = jobPost.Experience;
            cmd.Parameters.Add("p_Qualification", MySqlDbType.VarChar).Value = jobPost.Qualification;
            cmd.Parameters.Add("p_Salary", MySqlDbType.VarChar).Value = jobPost.Salary;
            cmd.Parameters.Add("p_SkillRequirement", MySqlDbType.VarChar).Value = jobPost.SkillRequirement;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = jobPost.Image;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = jobPost.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = jobPost.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = jobPost.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = jobPost.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return jobPost.Id.ToString();
        }


        public string DeleteJobPost(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteJobPost", con);
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