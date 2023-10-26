using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{  
    public class TestimonialDAL
    {
        DbConnection conn = null;
        public TestimonialDAL()
        {
            conn = new DbConnection();
        }  

        public List<Testimonial> GetAllTestimonial()
       {
            List<Testimonial> testimonialList = new List<Testimonial>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllTestimonial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Testimonial testimonial = new Testimonial();
                testimonial.Id = Convert.ToInt32(dr["Id"]);
                 
                testimonial.Name = Convert.ToString(dr["Name"]);
                testimonial.Message = Convert.ToString(dr["Message"]);
                testimonial.Profile = Convert.ToString(dr["Profile"]);
                testimonial.Photo = Convert.ToString(dr["Photo"]);

                testimonial.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                testimonial.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                testimonial.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                testimonial.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                testimonialList.Add(testimonial);
            }
            con.Close();
            return testimonialList;
        }

        public Testimonial GetTestimonialById(int Id)
        {
            Testimonial testimonial = new Testimonial();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetTestimonialById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                testimonial.Id = Convert.ToInt32(dr["Id"]);

                testimonial.Name = Convert.ToString(dr["Name"]);
                testimonial.Message = Convert.ToString(dr["Message"]);
                testimonial.Profile = Convert.ToString(dr["Profile"]);
                testimonial.Photo = Convert.ToString(dr["Photo"]);

                testimonial.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                testimonial.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                testimonial.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                testimonial.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return testimonial;
        }


        public string AddTestimonial(Testimonial testimonial)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddTestimonial", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = testimonial.Name;
            cmd.Parameters.Add("p_Message", MySqlDbType.VarChar).Value = testimonial.Message;
            cmd.Parameters.Add("p_Profile", MySqlDbType.VarChar).Value = testimonial.Profile;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = testimonial.Photo;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = testimonial.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = testimonial.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = testimonial.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = testimonial.UpdatedDate;


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


        public string UpdateTestimonial(Testimonial testimonial)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateTestimonial", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = testimonial.Id;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = testimonial.Name;
            cmd.Parameters.Add("p_Message", MySqlDbType.VarChar).Value = testimonial.Message;
            cmd.Parameters.Add("p_Profile", MySqlDbType.VarChar).Value = testimonial.Profile;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = testimonial.Photo;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = testimonial.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = testimonial.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = testimonial.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = testimonial.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return testimonial.Id.ToString();
        }


        public string DeleteTestimonial(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteTestimonial", con);
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