using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class DepartmentDAL
    {
        DbConnection conn = null;
        public DepartmentDAL()
        {
            conn = new DbConnection();
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departmentList = new List<Department>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Department department = new Department();
                department.Company = new Company();


                department.Id = Convert.ToInt32(dr["DepartmentId"]);
                department.Title = Convert.ToString(dr["Title2"]);
                department.Subtitle = Convert.ToString(dr["Subtitle2"]);
                department.Description = Convert.ToString(dr["Description2"]);

                department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                department.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                department.Company.Title = Convert.ToString(dr["Title1"]);

                department.DeptImage = Convert.ToString(dr["DeptImage"]);
                department.HOD = Convert.ToString(dr["HOD"]);
                department.Status = Convert.ToString(dr["Status2"]);
                department.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                department.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                department.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                department.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                //Dynamic Dropdown

               
                
                department.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                department.Company.Description = Convert.ToString(dr["Description1"]);
                department.Company.Tagline = Convert.ToString(dr["Tagline"]);
                department.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                department.Company.bgImage = Convert.ToString(dr["bgImage"]);
                department.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                department.Company.Status = Convert.ToString(dr["Status1"]);
                department.Company.Address = Convert.ToString(dr["Address"]);
                department.Company.City = Convert.ToString(dr["City"]);
                department.Company.Contact = Convert.ToString(dr["Contact"]);
                department.Company.Website = Convert.ToString(dr["Website"]);
                department.Company.MapUrl = Convert.ToString(dr["MapUrl"]);


             





                departmentList.Add(department);
            }
            con.Close();
            return departmentList;
        }

        public Department GetDepartmentById(int Id)
        {
            Department department = new Department();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetDepartmentById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Dynamic Dropdown
                department.Company = new Company();

                department.Id = Convert.ToInt32(dr["DepartmentId"]);
                department.Title = Convert.ToString(dr["Title2"]);
                department.Subtitle = Convert.ToString(dr["Subtitle2"]);
                department.Description = Convert.ToString(dr["Description2"]);

                department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                department.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                department.Company.Title = Convert.ToString(dr["Title1"]);

                department.DeptImage = Convert.ToString(dr["DeptImage"]);
                department.HOD = Convert.ToString(dr["HOD"]);
                department.Status = Convert.ToString(dr["Status2"]);
                department.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                department.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                department.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                department.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                //Dynamic Dropdown



                department.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                department.Company.Description = Convert.ToString(dr["Description1"]);
                department.Company.Tagline = Convert.ToString(dr["Tagline"]);
                department.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                department.Company.bgImage = Convert.ToString(dr["bgImage"]);
                department.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                department.Company.Status = Convert.ToString(dr["Status1"]);
                department.Company.Address = Convert.ToString(dr["Address"]);
                department.Company.City = Convert.ToString(dr["City"]);
                department.Company.Contact = Convert.ToString(dr["Contact"]);
                department.Company.Website = Convert.ToString(dr["Website"]);
                department.Company.MapUrl = Convert.ToString(dr["MapUrl"]);


            }
            con.Close();
            return department;
        }


        public string AddDepartment(Department department)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddDepartment", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = department.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = department.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = department.Description;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = department.CompanyId;
            cmd.Parameters.Add("p_DeptImage", MySqlDbType.VarChar).Value = department.DeptImage;
            cmd.Parameters.Add("p_HOD", MySqlDbType.VarChar).Value = department.HOD;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = department.Status;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = department.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = department.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = department.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = department.UpdatedBy;





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


        public string UpdateDepartment(Department department)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateDepartment", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = department.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = department.Title;
            cmd.Parameters.Add("p_Subtitle", MySqlDbType.VarChar).Value = department.Subtitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = department.Description;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = department.CompanyId;
            cmd.Parameters.Add("p_DeptImage", MySqlDbType.VarChar).Value = department.DeptImage;
            cmd.Parameters.Add("p_HOD", MySqlDbType.VarChar).Value = department.HOD;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = department.Status;

            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = department.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = department.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = department.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = department.UpdatedBy;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return department.Id.ToString();
        }


        public string DeleteDepartment(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteDepartment", con);
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