using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class EmployeesDAL
    {
        DbConnection conn = null;
        public EmployeesDAL()
        {
            conn = new DbConnection();
        }
        public List<Employees> GetAllEmployees()
        {
            List<Employees> EmployeesList = new List<Employees>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Employees employees = new Employees();
                employees.Designation = new Designation();
                employees.Company = new Company();
                employees.Department = new Department();
                employees.SubDepartment = new SubDepartment();



                employees.Id = Convert.ToInt32(dr["EmployeeId"]);
              
                employees.FName = Convert.ToString(dr["FName"]);
                employees.MName = Convert.ToString(dr["MName"]);
                employees.LName = Convert.ToString(dr["LName"]);

                employees.Designation.Id = Convert.ToInt32(dr["DesignationId"]);
                employees.DesignationId = Convert.ToInt32(dr["DesignationId"]);
                employees.Designation.Title = Convert.ToString(dr["Title4"]);
               employees.Designation.Subtitle = Convert.ToString(dr["Subtitle4"]);
                employees.Designation.Image = Convert.ToString(dr["Image"]);
                employees.Designation.Status = Convert.ToString(dr["Status4"]);
             




                employees.DateofBirth = Convert.ToString(dr["DateofBirth"]);
                employees.Address = Convert.ToString(dr["Address"]);
                employees.City = Convert.ToString(dr["City"]);
                employees.Contact = Convert.ToString(dr["Contact"]);
                employees.Email = Convert.ToString(dr["Email"]);
                employees.Photo = Convert.ToString(dr["Photo"]);
                employees.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                employees.LeavingDate = Convert.ToString(dr["LeavingDate"]);

                employees.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                employees.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                employees.Company.Title = Convert.ToString(dr["Title1"]);
                employees.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                employees.Company.Description = Convert.ToString(dr["Description1"]);
                employees.Company.Tagline = Convert.ToString(dr["Tagline"]);
                employees.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                employees.Company.bgImage = Convert.ToString(dr["bgImage"]);
                employees.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                employees.Company.Status = Convert.ToString(dr["Status1"]);
                employees.Company.Address = Convert.ToString(dr["Address1"]);
              employees.Company.City = Convert.ToString(dr["City1"]);
               employees.Company.Contact = Convert.ToString(dr["Contact1"]);
                employees.Company.Website = Convert.ToString(dr["Website"]);
               employees.Company.MapUrl = Convert.ToString(dr["MapUrl"]);
          



                employees.TotalExperience = Convert.ToString(dr["TotalExperience"]);
                employees.Qualification = Convert.ToString(dr["Qualification"]);
                employees.Facebook = Convert.ToString(dr["Facebook"]);
                employees.Instagram = Convert.ToString(dr["Instagram"]);
                employees.Tweeter = Convert.ToString(dr["Tweeter"]);
                employees.Gmail = Convert.ToString(dr["Gmail"]);
                employees.Linkedin = Convert.ToString(dr["Linkedin"]);
             
                employees.Status = Convert.ToString(dr["Status"]);
                employees.Password = Convert.ToString(dr["Password"]);

                employees.Department.Id = Convert.ToInt32(dr["DepartmentId"]);
                employees.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                employees.Department.Title = Convert.ToString(dr["Title2"]);
             employees.Department.Subtitle = Convert.ToString(dr["Subtitle2"]);
               employees.Department.Description = Convert.ToString(dr["Description2"]);
                employees.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                employees.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                employees.Department.HOD = Convert.ToString(dr["HOD"]);
                employees.Department.Status = Convert.ToString(dr["Status2"]);




                employees.SubDepartment.Id = Convert.ToInt32(dr["SubDepartmentId"]);
                employees.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                                                                                                                                                                           
               employees.SubDepartment.Title = Convert.ToString(dr["Title3"]);
              employees.SubDepartment.Subtitle = Convert.ToString(dr["Subtitle3"]);
                employees.SubDepartment.Description = Convert.ToString(dr["Description3"]);
                employees.SubDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                employees.SubDepartment.Status = Convert.ToString(dr["Status3"]);
               employees.SubDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
               employees.SubDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
               employees.SubDepartment.HOD = Convert.ToString(dr["HOD1"]);
       

                employees.SalaryAmount = Convert.ToString(dr["SalaryAmount"]);
                employees.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employees.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employees.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                employees.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);


                EmployeesList.Add(employees);
            }
            con.Close();
            return EmployeesList;
        }
        public Employees GetEmployeesById(int Id)
        {
            Employees employees = new Employees();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetEmployeesById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                employees.Designation = new Designation();
                employees.Company = new Company();
                employees.Department = new Department();
                employees.SubDepartment = new SubDepartment();
                employees.Status = Convert.ToString(dr["Status"]);
                employees.Password = Convert.ToString(dr["Password"]);

                employees.Id = Convert.ToInt32(dr["EmployeeId"]);
                employees.FName = Convert.ToString(dr["FName"]);
                employees.MName = Convert.ToString(dr["MName"]);
                employees.LName = Convert.ToString(dr["LName"]);

                employees.Designation.Id = Convert.ToInt32(dr["DesignationId"]);
                employees.DesignationId = Convert.ToInt32(dr["DesignationId"]);
       
                employees.DateofBirth = Convert.ToString(dr["DateofBirth"]);
                employees.Address = Convert.ToString(dr["Address"]);
                employees.City = Convert.ToString(dr["City"]);
                employees.Contact = Convert.ToString(dr["Contact"]);
                employees.Email = Convert.ToString(dr["Email"]);
                employees.Photo = Convert.ToString(dr["Photo"]);
                employees.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                employees.LeavingDate = Convert.ToString(dr["LeavingDate"]);
                employees.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                employees.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                employees.TotalExperience = Convert.ToString(dr["TotalExperience"]);
                employees.Qualification = Convert.ToString(dr["Qualification"]);
                employees.Facebook = Convert.ToString(dr["Facebook"]);
                employees.Instagram = Convert.ToString(dr["Instagram"]);
                employees.Tweeter = Convert.ToString(dr["Tweeter"]);
                employees.Gmail = Convert.ToString(dr["Gmail"]);
                employees.Linkedin = Convert.ToString(dr["Linkedin"]);
            
                employees.Department.Id = Convert.ToInt32(dr["DepartmentId"]);
                employees.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                employees.SubDepartment.Id = Convert.ToInt32(dr["SubDepartmentId"]);
                employees.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                employees.SalaryAmount = Convert.ToString(dr["SalaryAmount"]);
                employees.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employees.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employees.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                employees.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                employees.Designation.Title = Convert.ToString(dr["Title4"]);
                employees.Designation.Subtitle = Convert.ToString(dr["Subtitle4"]);
                employees.Designation.Image = Convert.ToString(dr["Image"]);
                employees.Designation.Status = Convert.ToString(dr["Status4"]);




             
                employees.Company.Title = Convert.ToString(dr["Title1"]);
                employees.Company.Subtitle = Convert.ToString(dr["Subtitle1"]);
                employees.Company.Description = Convert.ToString(dr["Description1"]);
                employees.Company.Tagline = Convert.ToString(dr["Tagline"]);
                employees.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                employees.Company.bgImage = Convert.ToString(dr["bgImage"]);
                employees.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                employees.Company.Status = Convert.ToString(dr["Status1"]);
                employees.Company.Address = Convert.ToString(dr["Address1"]);
                employees.Company.City = Convert.ToString(dr["City1"]);
                employees.Company.Contact = Convert.ToString(dr["Contact1"]);
                employees.Company.Website = Convert.ToString(dr["Website"]);
                employees.Company.MapUrl = Convert.ToString(dr["MapUrl"]);


            


             
                employees.Department.Title = Convert.ToString(dr["Title2"]);
                employees.Department.Subtitle = Convert.ToString(dr["Subtitle2"]);
                employees.Department.Description = Convert.ToString(dr["Description2"]);
                employees.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                employees.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                employees.Department.HOD = Convert.ToString(dr["HOD"]);
                employees.Department.Status = Convert.ToString(dr["Status2"]);


                
                employees.SubDepartment.Title = Convert.ToString(dr["Title3"]);
                employees.SubDepartment.Subtitle = Convert.ToString(dr["Subtitle3"]);
                employees.SubDepartment.Description = Convert.ToString(dr["Description3"]);
                employees.SubDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                employees.SubDepartment.Status = Convert.ToString(dr["Status3"]);
                employees.SubDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                employees.SubDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
                employees.SubDepartment.HOD = Convert.ToString(dr["HOD1"]);

           

            }
            con.Close();
            return employees;
        }
        public string AddEmployees(Employees employees)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddEmployees", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = employees.FName;
            cmd.Parameters.Add("p_MName", MySqlDbType.VarChar).Value = employees.MName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = employees.LName;

            cmd.Parameters.Add("p_DesignationId", MySqlDbType.Int32).Value = employees.Designation.Id;

           cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = employees.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = employees.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = employees.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = employees.Email;
           cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = employees.Photo;
            cmd.Parameters.Add("p_JoiningDate", MySqlDbType.VarChar).Value = employees.JoiningDate;
            cmd.Parameters.Add("p_LeavingDate", MySqlDbType.VarChar).Value = employees.LeavingDate;

            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = employees.Company.Id;

            cmd.Parameters.Add("p_DateofBirth", MySqlDbType.VarChar).Value = employees.DateofBirth;
            cmd.Parameters.Add("p_TotalExperience", MySqlDbType.VarChar).Value = employees.TotalExperience;
            cmd.Parameters.Add("p_Qualification", MySqlDbType.VarChar).Value = employees.Qualification;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = employees.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = employees.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = employees.Tweeter;
            cmd.Parameters.Add("p_Gmail", MySqlDbType.VarChar).Value = employees.Gmail;
            cmd.Parameters.Add("p_Linkedin", MySqlDbType.VarChar).Value = employees.Linkedin;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = employees.Status;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = employees.Password;


            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = employees.Department.Id;

            cmd.Parameters.Add("p_SubDepartmentId", MySqlDbType.Int32).Value = employees.SubDepartment.Id;

            cmd.Parameters.Add("p_SalaryAmount", MySqlDbType.VarChar).Value = employees.SalaryAmount;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = employees.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = employees.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = employees.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = employees.UpdatedBy;



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
        public Login Login(string Email, string Password)
        {
            Login user = new Login();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetEmployeesByEmailAndPassword", con);
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }

            return user;
        }
        public string UpdateEmployees(Employees employees)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateEmployees", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = employees.Id;
            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = employees.FName;
            cmd.Parameters.Add("p_MName", MySqlDbType.VarChar).Value = employees.MName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = employees.LName;

            cmd.Parameters.Add("p_DesignationId", MySqlDbType.Int32).Value = employees.Designation.Id;

            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = employees.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = employees.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = employees.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = employees.Email;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = employees.Photo;
            cmd.Parameters.Add("p_JoiningDate", MySqlDbType.VarChar).Value = employees.JoiningDate;
            cmd.Parameters.Add("p_LeavingDate", MySqlDbType.VarChar).Value = employees.LeavingDate;

            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = employees.Company.Id;

            cmd.Parameters.Add("p_DateofBirth", MySqlDbType.VarChar).Value = employees.DateofBirth;
            cmd.Parameters.Add("p_TotalExperience", MySqlDbType.VarChar).Value = employees.TotalExperience;
            cmd.Parameters.Add("p_Qualification", MySqlDbType.VarChar).Value = employees.Qualification;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = employees.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = employees.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = employees.Tweeter;
            cmd.Parameters.Add("p_Gmail", MySqlDbType.VarChar).Value = employees.Gmail;
            cmd.Parameters.Add("p_Linkedin", MySqlDbType.VarChar).Value = employees.Linkedin;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = employees.Status;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = employees.Password;


            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = employees.Department.Id;

            cmd.Parameters.Add("p_SubDepartmentId", MySqlDbType.Int32).Value = employees.SubDepartment.Id;

            cmd.Parameters.Add("p_SalaryAmount", MySqlDbType.VarChar).Value = employees.SalaryAmount;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = employees.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = employees.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = employees.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = employees.UpdatedBy;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();


            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return employees.Id.ToString();
        }
        public string DeleteEmployees(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteEmployees", con);
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