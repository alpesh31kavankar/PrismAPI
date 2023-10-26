using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class NoticeDAL
    {
        DbConnection conn = null;
        public NoticeDAL()
        {
            conn = new DbConnection();
        }

        public List<Notice> GetAllNotice()
      {
            List<Notice> noticeList = new List<Notice>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllNotice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Notice notice = new Notice();


                notice.Id = Convert.ToInt32(dr["Id"]);
                notice.Title = Convert.ToString(dr["Title"]);
                notice.SubTitle = Convert.ToString(dr["SubTitle"]);
                notice.Description = Convert.ToString(dr["Description"]);
                notice.StartDate = Convert.ToString(dr["StartDate"]);
                notice.EndDate = Convert.ToString(dr["EndDate"]);
                notice.Image = Convert.ToString(dr["Image"]);
                notice.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                notice.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                notice.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                notice.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                //  calender.UpdatedBy = DateTime.Now.ToString("MM/dd/yyyy");


                noticeList.Add(notice);
            }
            con.Close();
            return noticeList;
        }

        public Notice GetNoticeById(int Id)
        {
            Notice notice = new Notice();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetNoticeById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                notice.Id = Convert.ToInt32(dr["Id"]);
                notice.Title = Convert.ToString(dr["Title"]);
                notice.SubTitle = Convert.ToString(dr["SubTitle"]);
                notice.Description = Convert.ToString(dr["Description"]);
                notice.StartDate = Convert.ToString(dr["StartDate"]);
                notice.EndDate = Convert.ToString(dr["EndDate"]);
                notice.Image = Convert.ToString(dr["Image"]);
                notice.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                notice.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                notice.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                notice.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

            }
            con.Close();
            return notice;
        }


        public string AddNotice(Notice notice)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddNotice", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = notice.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = notice.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = notice.Description;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = notice.StartDate;
            cmd.Parameters.Add("p_EndDate", MySqlDbType.VarChar).Value = notice.EndDate;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = notice.Image;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = notice.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = notice.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = notice.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = notice.UpdatedBy;





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


        public string UpdateNotice(Notice notice)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateNotice", con);

            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = notice.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = notice.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = notice.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = notice.Description;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = notice.StartDate;
            cmd.Parameters.Add("p_EndDate", MySqlDbType.VarChar).Value = notice.EndDate;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = notice.Image;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = notice.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = notice.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = notice.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = notice.UpdatedBy;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();
            var Id = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return notice.Id.ToString();
        }


        public string DeleteNotice(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteNotice", con);
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