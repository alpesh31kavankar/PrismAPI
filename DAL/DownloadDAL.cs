using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class DownloadDAL
    {
        DbConnection conn = null;
        public DownloadDAL()  
        {
            conn = new DbConnection();
        }

        public List<Download> GetAllDownload()
        {
            List<Download> downloadList = new List<Download>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllDownload", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Download download = new Download();
                download.Id = Convert.ToInt32(dr["Id"]);

                download.Title = Convert.ToString(dr["Title"]);
                download.Subtitle = Convert.ToString(dr["Subtitle"]);
                download.FileLink = Convert.ToString(dr["FileLink"]);
                download.Image = Convert.ToString(dr["Image"]);

                download.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                download.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                download.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                download.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                downloadList.Add(download);
            }
            con.Close();
            return downloadList;
        }

        public Download GetDownloadById(int Id)
        {
            Download download = new Download();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetDownloadById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                download.Id = Convert.ToInt32(dr["Id"]);

                download.Title = Convert.ToString(dr["Title"]);
                download.Subtitle = Convert.ToString(dr["Subtitle"]);
                download.FileLink = Convert.ToString(dr["FileLink"]);
                download.Image = Convert.ToString(dr["Image"]);

                download.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                download.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                download.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                download.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return download;
        }


        public string AddDownload(Download download)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddDownload", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = download.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = download.Subtitle;
            cmd.Parameters.Add("p_FileLink", MySqlDbType.VarChar).Value = download.FileLink;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = download.Image;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = download.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = download.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = download.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = download.UpdatedDate;


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


        public string UpdateDownload(Download download)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateDownload", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = download.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = download.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = download.Subtitle;
            cmd.Parameters.Add("p_FileLink", MySqlDbType.VarChar).Value = download.FileLink;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = download.Image;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = download.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = download.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = download.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = download.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return download.Id.ToString();
        }


        public string DeleteDownload(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteDownload", con);
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