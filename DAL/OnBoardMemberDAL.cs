using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class OnBoardMemberDAL
    {  
        DbConnection conn = null;
        public OnBoardMemberDAL()
        {
            conn = new DbConnection();
        }

        public List<OnBoardMember> GetAllOnBoardMember()
        {
            List<OnBoardMember> onBoardMemberList = new List<OnBoardMember>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllOnBoardMember", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                OnBoardMember onBoardMember = new OnBoardMember();
                //dynamic dropdown
                onBoardMember.Designation = new Designation();
                onBoardMember.Company = new Company();
                onBoardMember.Department = new Department();
                onBoardMember.SubDepartment = new SubDepartment();
                onBoardMember.Id = Convert.ToInt32(dr["OnBoardMemberId"]);
                //dynamic dropdown
                onBoardMember.Designation.Id = Convert.ToInt32(dr["DesignationId"]);
                onBoardMember.Designation.Title = Convert.ToString(dr["Title1"]);
                onBoardMember.Designation.Subtitle = Convert.ToString(dr["Subtitle1"]);
                onBoardMember.Designation.Image = Convert.ToString(dr["Image"]);
                onBoardMember.Designation.Status = Convert.ToString(dr["Status1"]);

                onBoardMember.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Company.Title = Convert.ToString(dr["Title2"]);

                onBoardMember.Company.Subtitle = Convert.ToString(dr["Subtitle2"]);
                onBoardMember.Company.Description = Convert.ToString(dr["Description1"]);
                onBoardMember.Company.Tagline = Convert.ToString(dr["Tagline"]);
                onBoardMember.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                onBoardMember.Company.bgImage = Convert.ToString(dr["bgImage"]);
                onBoardMember.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                onBoardMember.Company.Status = Convert.ToString(dr["Status2"]);
                onBoardMember.Company.Address = Convert.ToString(dr["Address1"]);
                onBoardMember.Company.City = Convert.ToString(dr["City1"]);
                onBoardMember.Company.Contact = Convert.ToString(dr["Contact1"]);
                onBoardMember.Company.Website = Convert.ToString(dr["Website"]);
                onBoardMember.Company.MapUrl = Convert.ToString(dr["MapUrl"]);


                onBoardMember.Department.Id = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.Department.Title = Convert.ToString(dr["Title3"]);
                onBoardMember.Department.Subtitle = Convert.ToString(dr["Subtitle3"]);
                onBoardMember.Department.Description = Convert.ToString(dr["Description2"]);
                onBoardMember.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                onBoardMember.Department.HOD = Convert.ToString(dr["HOD1"]);
                onBoardMember.Department.Status = Convert.ToString(dr["Status3"]);

                onBoardMember.SubDepartment.Id = Convert.ToInt32(dr["SubDepartmentId"]);
                onBoardMember.SubDepartment.Title = Convert.ToString(dr["Title4"]);
                onBoardMember.SubDepartment.Subtitle = Convert.ToString(dr["SubTitle4"]);
                onBoardMember.SubDepartment.Description = Convert.ToString(dr["Description3"]);
                onBoardMember.SubDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.SubDepartment.Status = Convert.ToString(dr["Status4"]);
                onBoardMember.SubDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.SubDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
                onBoardMember.SubDepartment.HOD = Convert.ToString(dr["HOD2"]);


               
                //Dynamic End
                onBoardMember.FName = Convert.ToString(dr["FName"]);
                onBoardMember.MName = Convert.ToString(dr["MName"]);
                onBoardMember.LName = Convert.ToString(dr["LName"]);
                onBoardMember.DesignationId = Convert.ToInt32(dr["DesignationId"]);
                onBoardMember.Address = Convert.ToString(dr["Address"]);
                onBoardMember.City = Convert.ToString(dr["City"]);
                onBoardMember.Contact = Convert.ToString(dr["Contact"]);
                onBoardMember.Email = Convert.ToString(dr["Email"]);
                onBoardMember.Photo = Convert.ToString(dr["Photo"]);
                onBoardMember.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                onBoardMember.LeavingDate = Convert.ToString(dr["LeavingDate"]);
                onBoardMember.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Birthdate = Convert.ToString(dr["Birthdate"]);
                onBoardMember.Facebook = Convert.ToString(dr["Facebook"]);
                onBoardMember.Instagram = Convert.ToString(dr["Instagram"]);
                onBoardMember.Tweeter = Convert.ToString(dr["Tweeter"]);
                onBoardMember.Gmail = Convert.ToString(dr["Gmail"]);
                onBoardMember.Linkedin = Convert.ToString(dr["Linkedin"]);
                onBoardMember.Status = Convert.ToString(dr["Status"]);
                onBoardMember.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                onBoardMember.About = Convert.ToString(dr["About"]);
                onBoardMember.Says = Convert.ToString(dr["Says"]);
                onBoardMember.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                onBoardMember.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                onBoardMember.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                onBoardMember.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                onBoardMemberList.Add(onBoardMember);
            }
            con.Close();
            return onBoardMemberList;
        }

        public OnBoardMember GetOnBoardMemberById(int Id)
        {
            OnBoardMember onBoardMember = new OnBoardMember();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetOnBoardMemberById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                //dynamic dropdown
                onBoardMember.Designation = new Designation();
                onBoardMember.Company = new Company();
                onBoardMember.Department = new Department();
                onBoardMember.SubDepartment = new SubDepartment();
                onBoardMember.Id = Convert.ToInt32(dr["OnBoardMemberId"]);

                onBoardMember.Designation.Id = Convert.ToInt32(dr["DesignationId"]);
                onBoardMember.Designation.Title = Convert.ToString(dr["Title1"]);
                onBoardMember.Designation.Subtitle = Convert.ToString(dr["Subtitle1"]);
                onBoardMember.Designation.Image = Convert.ToString(dr["Image"]);
                onBoardMember.Designation.Status = Convert.ToString(dr["Status1"]);

                //dynamic dropdown

                onBoardMember.Company.Id = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Company.Title = Convert.ToString(dr["Title2"]);

                onBoardMember.Company.Subtitle = Convert.ToString(dr["Subtitle2"]);
                onBoardMember.Company.Description = Convert.ToString(dr["Description1"]);
                onBoardMember.Company.Tagline = Convert.ToString(dr["Tagline"]);
                onBoardMember.Company.LogoImage = Convert.ToString(dr["LogoImage"]);
                onBoardMember.Company.bgImage = Convert.ToString(dr["bgImage"]);
                onBoardMember.Company.CompanyIncorporationDate = Convert.ToString(dr["CompanyIncorporationDate"]);
                onBoardMember.Company.Status = Convert.ToString(dr["Status2"]);
                onBoardMember.Company.Address = Convert.ToString(dr["Address1"]);
                onBoardMember.Company.City = Convert.ToString(dr["City1"]);
                onBoardMember.Company.Contact = Convert.ToString(dr["Contact1"]);
                onBoardMember.Company.Website = Convert.ToString(dr["Website"]);
                onBoardMember.Company.MapUrl = Convert.ToString(dr["MapUrl"]);


                onBoardMember.Department.Id = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.Department.Title = Convert.ToString(dr["Title3"]);
                onBoardMember.Department.Subtitle = Convert.ToString(dr["Subtitle3"]);
                onBoardMember.Department.Description = Convert.ToString(dr["Description2"]);
                onBoardMember.Department.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Department.DeptImage = Convert.ToString(dr["DeptImage"]);
                onBoardMember.Department.HOD = Convert.ToString(dr["HOD1"]);
                onBoardMember.Department.Status = Convert.ToString(dr["Status3"]);


                onBoardMember.SubDepartment.Id = Convert.ToInt32(dr["SubDepartmentId"]);
                onBoardMember.SubDepartment.Title = Convert.ToString(dr["Title4"]);
                onBoardMember.SubDepartment.Subtitle = Convert.ToString(dr["SubTitle4"]);
                onBoardMember.SubDepartment.Description = Convert.ToString(dr["Description3"]);
                onBoardMember.SubDepartment.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.SubDepartment.Status = Convert.ToString(dr["Status4"]);
                onBoardMember.SubDepartment.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.SubDepartment.SubDeptImage = Convert.ToString(dr["SubDeptImage"]);
                onBoardMember.SubDepartment.HOD = Convert.ToString(dr["HOD2"]);

                //Dynmic end
                onBoardMember.FName = Convert.ToString(dr["FName"]);
                onBoardMember.MName = Convert.ToString(dr["MName"]);
                onBoardMember.LName = Convert.ToString(dr["LName"]);
                onBoardMember.DesignationId = Convert.ToInt32(dr["DesignationId"]);
                onBoardMember.Address = Convert.ToString(dr["Address"]);
                onBoardMember.City = Convert.ToString(dr["City"]);
                onBoardMember.Contact = Convert.ToString(dr["Contact"]);
                onBoardMember.Email = Convert.ToString(dr["Email"]);
                onBoardMember.Photo = Convert.ToString(dr["Photo"]);
                onBoardMember.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                onBoardMember.LeavingDate = Convert.ToString(dr["LeavingDate"]);
                onBoardMember.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                onBoardMember.Birthdate = Convert.ToString(dr["Birthdate"]);
                onBoardMember.Facebook = Convert.ToString(dr["Facebook"]);
                onBoardMember.Instagram = Convert.ToString(dr["Instagram"]);
                onBoardMember.Tweeter = Convert.ToString(dr["Tweeter"]);
                onBoardMember.Gmail = Convert.ToString(dr["Gmail"]);
                onBoardMember.Linkedin = Convert.ToString(dr["Linkedin"]);
                onBoardMember.Status = Convert.ToString(dr["Status"]);
                onBoardMember.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                onBoardMember.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                onBoardMember.About = Convert.ToString(dr["About"]);
                onBoardMember.Says = Convert.ToString(dr["Says"]);
                onBoardMember.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                onBoardMember.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                onBoardMember.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                onBoardMember.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return onBoardMember;
        }


        public string AddOnBoardMember(OnBoardMember onBoardMember)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddOnBoardMember", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = onBoardMember.FName;
            cmd.Parameters.Add("p_MName", MySqlDbType.VarChar).Value = onBoardMember.MName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = onBoardMember.LName;
            cmd.Parameters.Add("p_DesignationId", MySqlDbType.Int32).Value = onBoardMember.DesignationId;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = onBoardMember.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = onBoardMember.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = onBoardMember.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = onBoardMember.Email;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = onBoardMember.Photo;
            cmd.Parameters.Add("p_JoiningDate", MySqlDbType.VarChar).Value = onBoardMember.JoiningDate;
            cmd.Parameters.Add("p_LeavingDate", MySqlDbType.VarChar).Value = onBoardMember.LeavingDate;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = onBoardMember.CompanyId;
            cmd.Parameters.Add("p_Birthdate", MySqlDbType.VarChar).Value = onBoardMember.Birthdate;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = onBoardMember.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = onBoardMember.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = onBoardMember.Tweeter;
            cmd.Parameters.Add("p_Gmail", MySqlDbType.VarChar).Value = onBoardMember.Gmail;
            cmd.Parameters.Add("p_Linkedin", MySqlDbType.VarChar).Value = onBoardMember.Linkedin;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = onBoardMember.Status;
            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = onBoardMember.DepartmentId;
            cmd.Parameters.Add("p_SubDepartmentId", MySqlDbType.Int32).Value = onBoardMember.SubDepartmentId;
            cmd.Parameters.Add("p_About", MySqlDbType.VarChar).Value = onBoardMember.About;
            cmd.Parameters.Add("p_Says", MySqlDbType.VarChar).Value = onBoardMember.Says;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = onBoardMember.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = onBoardMember.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = onBoardMember.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = onBoardMember.UpdatedDate;


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


        public string UpdateOnBoardMember(OnBoardMember onBoardMember)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateOnBoardMember", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = onBoardMember.Id;
            cmd.Parameters.Add("p_FName", MySqlDbType.VarChar).Value = onBoardMember.FName;
            cmd.Parameters.Add("p_MName", MySqlDbType.VarChar).Value = onBoardMember.MName;
            cmd.Parameters.Add("p_LName", MySqlDbType.VarChar).Value = onBoardMember.LName;
            cmd.Parameters.Add("p_DesignationId", MySqlDbType.Int32).Value = onBoardMember.DesignationId;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = onBoardMember.Address;
            cmd.Parameters.Add("p_City", MySqlDbType.VarChar).Value = onBoardMember.City;
            cmd.Parameters.Add("p_Contact", MySqlDbType.VarChar).Value = onBoardMember.Contact;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = onBoardMember.Email;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = onBoardMember.Photo;
            cmd.Parameters.Add("p_JoiningDate", MySqlDbType.VarChar).Value = onBoardMember.JoiningDate;
            cmd.Parameters.Add("p_LeavingDate", MySqlDbType.VarChar).Value = onBoardMember.LeavingDate;
            cmd.Parameters.Add("p_CompanyId", MySqlDbType.Int32).Value = onBoardMember.CompanyId;
            cmd.Parameters.Add("p_Birthdate", MySqlDbType.VarChar).Value = onBoardMember.Birthdate;
            cmd.Parameters.Add("p_Facebook", MySqlDbType.VarChar).Value = onBoardMember.Facebook;
            cmd.Parameters.Add("p_Instagram", MySqlDbType.VarChar).Value = onBoardMember.Instagram;
            cmd.Parameters.Add("p_Tweeter", MySqlDbType.VarChar).Value = onBoardMember.Tweeter;
            cmd.Parameters.Add("p_Gmail", MySqlDbType.VarChar).Value = onBoardMember.Gmail;
            cmd.Parameters.Add("p_Linkedin", MySqlDbType.VarChar).Value = onBoardMember.Linkedin;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = onBoardMember.Status;
            cmd.Parameters.Add("p_DepartmentId", MySqlDbType.Int32).Value = onBoardMember.DepartmentId;
            cmd.Parameters.Add("p_SubDepartmentId", MySqlDbType.Int32).Value = onBoardMember.SubDepartmentId;
            cmd.Parameters.Add("p_About", MySqlDbType.VarChar).Value = onBoardMember.About;
            cmd.Parameters.Add("p_Says", MySqlDbType.VarChar).Value = onBoardMember.Says;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = onBoardMember.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = onBoardMember.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = onBoardMember.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = onBoardMember.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return onBoardMember.Id.ToString();
        }


        public string DeleteOnBoardMember(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteOnBoardMember", con);
            cmd.Parameters.Add("p_OnBoardMemberId", MySqlDbType.Int32).Value = Id;
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