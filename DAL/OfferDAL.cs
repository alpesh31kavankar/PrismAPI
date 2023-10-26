using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class OfferDAL
    {
        DbConnection conn = null;
        public OfferDAL()
        {
            conn = new DbConnection();
        }

        public List<Offer> GetAllOffer()
        {
            List<Offer> offerList = new List<Offer>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllOffer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Offer offer = new Offer();


                offer.Id = Convert.ToInt32(dr["Id"]);
                offer.Title = Convert.ToString(dr["Title"]);
                offer.SubTitle = Convert.ToString(dr["SubTitle"]);
                offer.Description = Convert.ToString(dr["Description"]);
                offer.StartDate = Convert.ToString(dr["StartDate"]);
                offer.EndDate = Convert.ToString(dr["EndDate"]);
                offer.Discount = Convert.ToString(dr["Discount"]);
                offer.Image = Convert.ToString(dr["Image"]);
                offer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                offer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                offer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                offer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);



                //  calender.UpdatedBy = DateTime.Now.ToString("MM/dd/yyyy");


                offerList.Add(offer);
            }
            con.Close();
            return offerList;
        }

        public Offer GetOfferById(int Id)
        {
            Offer offer = new Offer();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetOfferById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                offer.Id = Convert.ToInt32(dr["Id"]);
                offer.Title = Convert.ToString(dr["Title"]);
                offer.SubTitle = Convert.ToString(dr["SubTitle"]);
                offer.Description = Convert.ToString(dr["Description"]);
                offer.StartDate = Convert.ToString(dr["StartDate"]);
                offer.EndDate = Convert.ToString(dr["EndDate"]);
                offer.Discount = Convert.ToString(dr["Discount"]);
                offer.Image = Convert.ToString(dr["Image"]);
                offer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                offer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                offer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                offer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
            }
            con.Close();
            return offer;
        }


        public string AddOffer(Offer offer)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddOffer", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = offer.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = offer.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = offer.Description;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = offer.StartDate;
            cmd.Parameters.Add("p_EndDate", MySqlDbType.VarChar).Value = offer.EndDate;
            cmd.Parameters.Add("p_Discount", MySqlDbType.VarChar).Value = offer.Discount;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = offer.Image;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = offer.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = offer.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = offer.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = offer.UpdatedBy;





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


        public string UpdateOffer(Offer offer)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateOffer", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = offer.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = offer.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = offer.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = offer.Description;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = offer.StartDate;
            cmd.Parameters.Add("p_EndDate", MySqlDbType.VarChar).Value = offer.EndDate;
            cmd.Parameters.Add("p_Discount", MySqlDbType.VarChar).Value = offer.Discount;
            cmd.Parameters.Add("p_Image", MySqlDbType.VarChar).Value = offer.Image;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = offer.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = offer.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = offer.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = offer.UpdatedBy;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();
            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return offer.Id.ToString();
        }


        public string DeleteOffer(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteOffer", con);
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