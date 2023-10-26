using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class CompanyDAL
    {
        DbConnection conn = null;
        public CompanyDAL()
        {
            conn = new DbConnection();
        }
        public List<Company> GetAllCompany()
        {
            List<Company> CompanyList = new List<Company>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllCompany", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(dr["Id"]);
                company.Title = Convert.ToString(dr["Title"]);
                company.Subtitle = Convert.ToString(dr["Subtitle"]);
                company.Description = Convert.ToString(dr["Description"]);
                company.Tagline = Convert.ToString(dr["Tagline"]);
                company.LogoImage = Convert.ToString(dr["LogoImage"]);
                company.bgImage = Convert.ToString(dr["bgImage"]);
                company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                company.Status = Convert.ToString(dr["Status"]);
                company.Address = Convert.ToString(dr["Address"]);
                company.City = Convert.ToString(dr["City"]);
                company.Contact = Convert.ToString(dr["Contact"]);
                company.Website = Convert.ToString(dr["Website"]);
                company.MapUrl = Convert.ToString(dr["MapUrl"]);
                company.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                company.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                company.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                company.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                CompanyList.Add(company);
            }
            con.Close();
            return CompanyList;
        }
        public Company GetCompanyById(int Id)
        {
            Company company = new Company();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetCompanyById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                company.Id = Convert.ToInt32(dr["Id"]);
                company.Title = Convert.ToString(dr["Title"]);
                company.Subtitle = Convert.ToString(dr["Subtitle"]);
                company.Description = Convert.ToString(dr["Description"]);
                company.Tagline = Convert.ToString(dr["Tagline"]);
                company.LogoImage = Convert.ToString(dr["LogoImage"]);
                company.bgImage = Convert.ToString(dr["bgImage"]);
                company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                company.Status = Convert.ToString(dr["Status"]);
                company.Address = Convert.ToString(dr["Address"]);
                company.City = Convert.ToString(dr["City"]);
                company.Contact = Convert.ToString(dr["Contact"]);
                company.Website = Convert.ToString(dr["Website"]);
                company.MapUrl = Convert.ToString(dr["MapUrl"]);
                company.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                company.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                company.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                company.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);






            }
            con.Close();
            return company;
        }
        public string AddCompany(Company company)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddCompany", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = company.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = company.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = company.Description;
            cmd.Parameters.Add("p_Tagline", MySqlDbType.VarChar).Value = company.Tagline;
            cmd.Parameters.Add("p_LogoImage", MySqlDbType.VarChar).Value = company.LogoImage;
            cmd.Parameters.Add("p_bgImage", MySqlDbType.VarChar).Value = company.bgImage;
            cmd.Parameters.Add("p_CompanyIncorporationDate", MySqlDbType.VarChar).Value = company.CompanyIncorporationDate;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = company.Status;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = company.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = company.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = company.Contact;
            cmd.Parameters.Add("p_Website", MySqlDbType.VarChar).Value = company.Website;
            cmd.Parameters.Add("p_MapUrl", MySqlDbType.VarChar).Value = company.MapUrl;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = company.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = company.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = company.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = company.UpdatedBy;



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
        public string UpdateCompany(Company company)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateCompany", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = company.Id;
            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = company.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = company.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = company.Description;
            cmd.Parameters.Add("p_Tagline", MySqlDbType.VarChar).Value = company.Tagline;
            cmd.Parameters.Add("p_LogoImage", MySqlDbType.VarChar).Value = company.LogoImage;
            cmd.Parameters.Add("p_bgImage", MySqlDbType.VarChar).Value = company.bgImage;
            cmd.Parameters.Add("p_CompanyIncorporationDate", MySqlDbType.VarChar).Value = company.CompanyIncorporationDate;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = company.Status;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = company.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = company.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = company.Contact;
            cmd.Parameters.Add("p_Website", MySqlDbType.VarChar).Value = company.Website;
            cmd.Parameters.Add("p_MapUrl", MySqlDbType.VarChar).Value = company.MapUrl;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = company.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = company.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = company.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = company.UpdatedBy;






            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return company.Id.ToString();
        }
        public string DeleteCompany(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteCompany", con);
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