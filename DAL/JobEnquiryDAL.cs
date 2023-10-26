using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class JobEnquiryDAL
    {
        DbConnection conn = null;
        public JobEnquiryDAL()
        {
            conn = new DbConnection();
        }

        public List<JobEnquiry> GetAllJobEnquiry()
        {
            List<JobEnquiry> jobEnquiryList = new List<JobEnquiry>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllJobEnquiry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                JobEnquiry jobEnquiry = new JobEnquiry();
                jobEnquiry.Id = Convert.ToInt32(dr["Id"]);

                jobEnquiry.JobPostId = Convert.ToInt32(dr["JobPostId"]);
                jobEnquiry.Name = Convert.ToString(dr["Name"]);
                jobEnquiry.MobileNumber = Convert.ToString(dr["MobileNumber"]);
                jobEnquiry.Email = Convert.ToString(dr["Email"]);
                jobEnquiry.CV = Convert.ToString(dr["CV"]);
                jobEnquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                jobEnquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                jobEnquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                jobEnquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                jobEnquiryList.Add(jobEnquiry);
            }
            con.Close();
            return jobEnquiryList;
        }

        public JobEnquiry GetJobEnquiryById(int Id)
        {
            JobEnquiry jobEnquiry = new JobEnquiry();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetJobEnquiryById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                jobEnquiry.Id = Convert.ToInt32(dr["Id"]);

                jobEnquiry.JobPostId = Convert.ToInt32(dr["JobPostId"]);
                jobEnquiry.Name = Convert.ToString(dr["Name"]);
                jobEnquiry.MobileNumber = Convert.ToString(dr["MobileNumber"]);
                jobEnquiry.Email = Convert.ToString(dr["Email"]);
                jobEnquiry.CV = Convert.ToString(dr["CV"]);
                jobEnquiry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                jobEnquiry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                jobEnquiry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                jobEnquiry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return jobEnquiry;
        }


        public string AddJobEnquiry(JobEnquiry jobEnquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddJobEnquiry", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_JobPostId", MySqlDbType.Int32).Value = jobEnquiry.JobPostId;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = jobEnquiry.Name;
            cmd.Parameters.Add("p_MobileNumber", MySqlDbType.VarChar).Value = jobEnquiry.MobileNumber;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = jobEnquiry.Email;
            cmd.Parameters.Add("p_CV", MySqlDbType.VarChar).Value = jobEnquiry.CV;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = jobEnquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = jobEnquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = jobEnquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = jobEnquiry.UpdatedDate;


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


        public string UpdateJobEnquiry(JobEnquiry jobEnquiry)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateJobEnquiry", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = jobEnquiry.Id;

            cmd.Parameters.Add("p_JobPostId", MySqlDbType.Int32).Value = jobEnquiry.JobPostId;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = jobEnquiry.Name;
            cmd.Parameters.Add("p_MobileNumber", MySqlDbType.VarChar).Value = jobEnquiry.MobileNumber;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = jobEnquiry.Email;
            cmd.Parameters.Add("p_CV", MySqlDbType.VarChar).Value = jobEnquiry.CV;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = jobEnquiry.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = jobEnquiry.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = jobEnquiry.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = jobEnquiry.UpdatedDate;




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


        public string DeleteJobEnquiry(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteJobEnquiry", con);
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