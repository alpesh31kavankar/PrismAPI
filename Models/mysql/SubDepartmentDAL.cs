using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class SubDepartmentDAL
    {
        DbConnection conn = null;
        public SubDepartmentDAL()
        {
            conn = new DbConnection();
        }

        public List<SubDepartment> GetAllSubDepartment()
        {
            List<SubDepartment> subDepartmentList = new List<SubDepartment>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllSubDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SubDepartment subDepartment = new SubDepartment();
                subDepartment.Department = new Department();
               // subDepartment.Company = new Company();


                subDepartment.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Title = Convert.ToString(dr["Title"]);
                subDepartment.Subtitle = Convert.ToString(dr["Subtitle"]);
                subDepartment.Description = Convert.ToString(dr["Description"]);
                subDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                subDepartment.Status = Convert.ToString(dr["Status"]);
               // subDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                subDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
                subDepartment.HOD = Convert.ToString(dr["HOD"]);
                subDepartment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                subDepartment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                subDepartment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                subDepartment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                subDepartment.Department.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Department.Title = Convert.ToString(dr["Title1"]);
                subDepartment.Department.Subtitle = Convert.ToString(dr["Subtitle1"]);
                subDepartment.Department.Description = Convert.ToString(dr["Description1"]);
                subDepartment.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                subDepartment.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                subDepartment.Department.HOD = Convert.ToString(dr["HOD1"]);
                subDepartment.Department.Status = Convert.ToString(dr["Status1"]);

               /* subDepartment.Company.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Company.Title = Convert.ToString(dr["Title2"]);
                subDepartment.Company.Subtitle = Convert.ToString(dr["Subtitle2"]);
                subDepartment.Company.Description = Convert.ToString(dr["Description2"]);
                subDepartment.Company.Tagline = Convert.ToString(dr["Tagline"]);
                subDepartment.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                subDepartment.Company.bgImage = Convert.ToString(dr["bgImage"]);
                subDepartment.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                subDepartment.Company.Status = Convert.ToString(dr["Status2"]);
                subDepartment.Company.Address = Convert.ToString(dr["Address"]);
                subDepartment.Company.City = Convert.ToString(dr["City"]);
                subDepartment.Company.Contact = Convert.ToString(dr["Contact"]);
                subDepartment.Company.Website = Convert.ToString(dr["Website"]);
                subDepartment.Company.MapUrl = Convert.ToString(dr["MapUrl"]);*/




                subDepartmentList.Add(subDepartment);
            }
            con.Close();
            return subDepartmentList;
        }

        public SubDepartment GetSubDepartmentById(int Id)
        {
            SubDepartment subDepartment = new SubDepartment();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetSubDepartmentById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                subDepartment.Department = new Department();
               // subDepartment.Company = new Company();


                subDepartment.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Title = Convert.ToString(dr["Title"]);
                subDepartment.Subtitle = Convert.ToString(dr["Subtitle"]);
                subDepartment.Description = Convert.ToString(dr["Description"]);
                subDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                subDepartment.Status = Convert.ToString(dr["Status"]);
               // subDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                subDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
                subDepartment.HOD = Convert.ToString(dr["HOD"]);
                subDepartment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                subDepartment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                subDepartment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                subDepartment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                subDepartment.Department.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Department.Title = Convert.ToString(dr["Title1"]);
                subDepartment.Department.Subtitle = Convert.ToString(dr["Subtitle1"]);
                subDepartment.Department.Description = Convert.ToString(dr["Description1"]);
                subDepartment.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                subDepartment.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                subDepartment.Department.HOD = Convert.ToString(dr["HOD1"]);
                subDepartment.Department.Status = Convert.ToString(dr["Status1"]);

               /* subDepartment.Company.Id = Convert.ToInt32(dr["Id"]);
                subDepartment.Company.Title = Convert.ToString(dr["Title2"]);
                subDepartment.Company.Subtitle = Convert.ToString(dr["Subtitle2"]);
                subDepartment.Company.Description = Convert.ToString(dr["Description2"]);
                subDepartment.Company.Tagline = Convert.ToString(dr["Tagline"]);
                subDepartment.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                subDepartment.Company.bgImage = Convert.ToString(dr["bgImage"]);
                subDepartment.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                subDepartment.Company.Status = Convert.ToString(dr["Status2"]);
                subDepartment.Company.Address = Convert.ToString(dr["Address"]);
                subDepartment.Company.City = Convert.ToString(dr["City"]);
                subDepartment.Company.Contact = Convert.ToString(dr["Contact"]);
                subDepartment.Company.Website = Convert.ToString(dr["Website"]);
                subDepartment.Company.MapUrl = Convert.ToString(dr["MapUrl"]);*/

            }
            con.Close();
            return subDepartment;
        }


        public string AddSubDepartment(SubDepartment subDepartment)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddSubDepartment", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = subDepartment.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = subDepartment.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = subDepartment.Description;
            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = subDepartment.DepartmentId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = subDepartment.Status;
           // cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = subDepartment.CompanyId;
            cmd.Parameters.Add("p_SubDeptImage", MySqlDbType.VarChar).Value = subDepartment.SubDeptImage;
            cmd.Parameters.Add("p_HOD", MySqlDbType.VarChar).Value = subDepartment.HOD;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = subDepartment.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = subDepartment.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = subDepartment.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = subDepartment.UpdatedBy;





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


        public string UpdateSubDepartment(SubDepartment subDepartment)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateSubDepartment", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = subDepartment.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = subDepartment.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = subDepartment.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = subDepartment.Description;
            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = subDepartment.DepartmentId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = subDepartment.Status;
          //  cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = subDepartment.CompanyId;
            cmd.Parameters.Add("p_SubDeptImage", MySqlDbType.VarChar).Value = subDepartment.SubDeptImage;
            cmd.Parameters.Add("p_HOD", MySqlDbType.VarChar).Value = subDepartment.HOD;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = subDepartment.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = subDepartment.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = subDepartment.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = subDepartment.UpdatedBy;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return subDepartment.Id.ToString();
        }


        public string DeleteSubDepartment(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteSubDepartment", con);
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