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
    public class HomeSliderDAL
    {
        DbConnection conn = null;
        public HomeSliderDAL()
        {
            conn = new DbConnection();
        }

        public List<HomeSlider> GetAllHomeSlider()
        {
            List<HomeSlider> homeSliderList = new List<HomeSlider>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllHomeSlider", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                HomeSlider homeSliders = new HomeSlider();


                homeSliders.Id = Convert.ToInt32(dr["Id"]);
                homeSliders.Title = Convert.ToString(dr["Title"]);
                homeSliders.SubTitle = Convert.ToString(dr["SubTitle"]);
                homeSliders.Image = Convert.ToString(dr["Image"]);

                homeSliders.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                homeSliders.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                homeSliders.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                homeSliders.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);






                homeSliderList.Add(homeSliders);
            }
            con.Close();
            return homeSliderList;
        }

        public HomeSlider GetHomeSliderById(int Id)
        {

            HomeSlider homeSlider = new HomeSlider();


            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetHomeSliderById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                homeSlider.Id = Convert.ToInt32(dr["Id"]);
                homeSlider.Title = Convert.ToString(dr["Title"]);
                homeSlider.SubTitle = Convert.ToString(dr["SubTitle"]);
                homeSlider.Image = Convert.ToString(dr["Image"]);

                homeSlider.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                homeSlider.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                homeSlider.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                homeSlider.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

            }
            con.Close();
            return homeSlider;
        }


        public string AddHomeSlider(HomeSlider homeSlider)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddHomeSlider", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = homeSlider.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = homeSlider.SubTitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = homeSlider.Image;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = homeSlider.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = homeSlider.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = homeSlider.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = homeSlider.UpdatedBy;





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


        public string UpdateHomeSlider(HomeSlider homeSlider)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateHomeSlider", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = homeSlider.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = homeSlider.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = homeSlider.SubTitle;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = homeSlider.Image;


            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = homeSlider.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = homeSlider.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = homeSlider.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = homeSlider.UpdatedBy;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return homeSlider.Id.ToString();
        }


        public string DeleteHomeSlider(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteHomeSlider", con);
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