using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class SocialMediaDAL
    {

        DbConnection conn = null;
        public SocialMediaDAL()
        {
            conn = new DbConnection();
        }

        public List<SocialMedia> GetAllSocialMedia()
        {
            List<SocialMedia> socialMediaList = new List<SocialMedia>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllSocialMedia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SocialMedia socialMedia = new SocialMedia();
                 socialMedia.Company = new Company();


                socialMedia.Id = Convert.ToInt32(dr["Id"]);
                socialMedia.Title = Convert.ToString(dr["Title"]);
                socialMedia.Subtitle = Convert.ToString(dr["Subtitle"]);
                socialMedia.SocialLink = Convert.ToString(dr["SocialLink"]);
                socialMedia.Imgicon = Convert.ToString(dr["Imgicon"]);
                socialMedia.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                socialMedia.Status = Convert.ToString(dr["Status"]);
                socialMedia.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                socialMedia.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                socialMedia.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                socialMedia.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                socialMedia.Company.Id = Convert.ToInt32(dr["Id"]);
                socialMedia.Company.Title = Convert.ToString(dr["Title1"]);
                socialMedia.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                socialMedia.Company.Description = Convert.ToString(dr["Description"]);
                socialMedia.Company.Tagline = Convert.ToString(dr["Tagline"]);
                socialMedia.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                socialMedia.Company.bgImage = Convert.ToString(dr["bgImage"]);
                socialMedia.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                socialMedia.Company.Status = Convert.ToString(dr["Status1"]);
                socialMedia.Company.Address = Convert.ToString(dr["Address"]);
                socialMedia.Company.City = Convert.ToString(dr["City"]);
                socialMedia.Company.Contact = Convert.ToString(dr["Contact"]);
                socialMedia.Company.Website = Convert.ToString(dr["Website"]);
                socialMedia.Company.MapUrl = Convert.ToString(dr["MapUrl"]);






                socialMediaList.Add(socialMedia);
            }
            con.Close();
            return socialMediaList;
        }

        public SocialMedia GetSocialMediaById(int Id)
        {
            SocialMedia socialMedia = new SocialMedia();


            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetSocialMediaById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 socialMedia.Company = new Company();


                socialMedia.Id = Convert.ToInt32(dr["Id"]);
                socialMedia.Title = Convert.ToString(dr["Title"]);
                socialMedia.Subtitle = Convert.ToString(dr["Subtitle"]);
                socialMedia.SocialLink = Convert.ToString(dr["SocialLink"]);
                socialMedia.Imgicon = Convert.ToString(dr["Imgicon"]);
                socialMedia.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                socialMedia.Status = Convert.ToString(dr["Status"]);
                socialMedia.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                socialMedia.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                socialMedia.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                socialMedia.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                socialMedia.Company.Id = Convert.ToInt32(dr["Id"]);
                socialMedia.Company.Title = Convert.ToString(dr["Title1"]);
                socialMedia.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                socialMedia.Company.Description = Convert.ToString(dr["Description"]);
                socialMedia.Company.Tagline = Convert.ToString(dr["Tagline"]);
                socialMedia.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                socialMedia.Company.bgImage = Convert.ToString(dr["bgImage"]);
                socialMedia.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                socialMedia.Company.Status = Convert.ToString(dr["Status1"]);
                socialMedia.Company.Address = Convert.ToString(dr["Address"]);
                socialMedia.Company.City = Convert.ToString(dr["City"]);
                socialMedia.Company.Contact = Convert.ToString(dr["Contact"]);
                socialMedia.Company.Website = Convert.ToString(dr["Website"]);
                socialMedia.Company.MapUrl = Convert.ToString(dr["MapUrl"]);

            }
            con.Close();
            return socialMedia;
        }


        public string AddSocialMedia(SocialMedia socialMedia)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddSocialMedia", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = socialMedia.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = socialMedia.Subtitle;
            cmd.Parameters.Add("p_SocialLink", MySqlDbType.VarChar).Value = socialMedia.SocialLink;
            cmd.Parameters.Add("p_Imgicon", MySqlDbType.VarChar).Value = socialMedia.Imgicon;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = socialMedia.CompanyId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = socialMedia.Status;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = socialMedia.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = socialMedia.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = socialMedia.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = socialMedia.UpdatedBy;





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


        public string UpdateSocialMedia(SocialMedia socialMedia)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateSocialMedia", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = socialMedia.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = socialMedia.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = socialMedia.Subtitle;
            cmd.Parameters.Add("p_SocialLink", MySqlDbType.VarChar).Value = socialMedia.SocialLink;
            cmd.Parameters.Add("p_Imgicon", MySqlDbType.VarChar).Value = socialMedia.Imgicon;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = socialMedia.CompanyId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = socialMedia.Status;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = socialMedia.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = socialMedia.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = socialMedia.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = socialMedia.UpdatedBy;

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
            return socialMedia.Id.ToString();
        }


        public string DeleteSocialMedia(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteSocialMedia", con);
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