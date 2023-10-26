using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class AboutDAL
    {
        DbConnection conn = null;
        public AboutDAL()
        {
            conn = new DbConnection();
        }
        public List<About> GetAllAbout()
        {
            List<About> AboutList = new List<About>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllAbout", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                About about = new About();
                about.Company = new Company();

                about.Id = Convert.ToInt32(dr["Id"]);
                about.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                about.Title = Convert.ToString(dr["Title"]);
                about.SubTitle = Convert.ToString(dr["SubTitle"]);
                about.Description = Convert.ToString(dr["Description"]);

               about.CompanyId = Convert.ToInt32(dr["CompanyId"]);

                about.Company.Title = Convert.ToString(dr["Title1"]);
                about.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                about.Company.Description = Convert.ToString(dr["Description1"]);
                about.Company.Tagline = Convert.ToString(dr["Tagline"]);
                about.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                about.Company.bgImage = Convert.ToString(dr["bgImage"]);
                about.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                about.Company.Status = Convert.ToString(dr["Status"]);
                about.Company.Address = Convert.ToString(dr["Address"]);
                about.Company.City = Convert.ToString(dr["City"]);
                about.Company.Contact = Convert.ToString(dr["Contact"]);
                about.Company.Website = Convert.ToString(dr["Website"]);
                about.Company.MapUrl = Convert.ToString(dr["MapUrl"]);






                about.AboutImage = Convert.ToString(dr["AboutImage"]);
                about.Vision = Convert.ToString(dr["Vision"]);
                about.VisionImage = Convert.ToString(dr["VisionImage"]);
                about.Mission = Convert.ToString(dr["Mission"]);
                about.MissionImage = Convert.ToString(dr["MissionImage"]);
                about.Valuess = Convert.ToString(dr["Valuess"]);
                about.ValuesImage = Convert.ToString(dr["ValuesImage"]);
                about.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                about.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                about.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                about.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                AboutList.Add(about);
            }
            con.Close();
            return AboutList;
        }
        public About GetAboutById(int Id)
        {
            About about = new About();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAboutById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                about.Company = new Company();

                about.Id = Convert.ToInt32(dr["Id"]);
                about.Title = Convert.ToString(dr["Title"]);
                about.SubTitle = Convert.ToString(dr["SubTitle"]);
                about.Description = Convert.ToString(dr["Description"]);
                about.Company.Id = Convert.ToInt32(dr["CompanyId"]);

             /*   about.Company.Title = Convert.ToString(dr["Title"]);*/
                about.CompanyId = Convert.ToInt32(dr["CompanyId"]);

                about.Company.Title = Convert.ToString(dr["Title1"]);
                about.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                about.Company.Description = Convert.ToString(dr["Description1"]);
                about.Company.Tagline = Convert.ToString(dr["Tagline"]);
                about.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                about.Company.bgImage = Convert.ToString(dr["bgImage"]);
                about.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                about.Company.Status = Convert.ToString(dr["Status"]);
                about.Company.Address = Convert.ToString(dr["Address"]);
                about.Company.City = Convert.ToString(dr["City"]);
                about.Company.Contact = Convert.ToString(dr["Contact"]);
                about.Company.Website = Convert.ToString(dr["Website"]);
                about.Company.MapUrl = Convert.ToString(dr["MapUrl"]);

                about.AboutImage = Convert.ToString(dr["AboutImage"]);
                about.Vision = Convert.ToString(dr["Vision"]);
                about.VisionImage = Convert.ToString(dr["VisionImage"]);
                about.Mission = Convert.ToString(dr["Mission"]);
                about.MissionImage = Convert.ToString(dr["MissionImage"]);
                about.Valuess = Convert.ToString(dr["Valuess"]);
                about.ValuesImage = Convert.ToString(dr["ValuesImage"]);
                about.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                about.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                about.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                about.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);






            }
            con.Close();
            return about;
        }
        public string AddAbout(About about)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddAbout", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = about.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = about.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = about.Description;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = about.Company.Id;
            cmd.Parameters.Add("p_AboutImage", MySqlDbType.VarChar).Value = about.AboutImage;
            cmd.Parameters.Add("p_Vision", MySqlDbType.VarChar).Value = about.Vision;
            cmd.Parameters.Add("p_VisionImage", MySqlDbType.VarChar).Value = about.VisionImage;
            cmd.Parameters.Add("p_Mission", MySqlDbType.VarChar).Value = about.Mission;
            cmd.Parameters.Add("p_MissionImage", MySqlDbType.VarChar).Value = about.MissionImage;
            cmd.Parameters.Add("p_Valuess", MySqlDbType.VarChar).Value = about.Valuess;
            cmd.Parameters.Add("p_ValuesImage", MySqlDbType.VarChar).Value = about.ValuesImage;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = about.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = about.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = about.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = about.UpdatedBy;



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
        public string UpdateAbout(About about)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateAbout", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = about.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = about.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = about.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = about.Description;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = about.Company.Id;
            cmd.Parameters.Add("p_AboutImage", MySqlDbType.VarChar).Value = about.AboutImage;
            cmd.Parameters.Add("p_Vision", MySqlDbType.VarChar).Value = about.Vision;
            cmd.Parameters.Add("p_VisionImage", MySqlDbType.VarChar).Value = about.VisionImage;
            cmd.Parameters.Add("p_Mission", MySqlDbType.VarChar).Value = about.Mission;
            cmd.Parameters.Add("p_MissionImage", MySqlDbType.VarChar).Value = about.MissionImage;
            cmd.Parameters.Add("p_Valuess", MySqlDbType.VarChar).Value = about.Valuess;
            cmd.Parameters.Add("p_ValuesImage", MySqlDbType.VarChar).Value = about.ValuesImage;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = about.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = about.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = about.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = about.UpdatedBy;






            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return about.Id.ToString();
        }
        public string DeleteAbout(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteAbout", con);
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