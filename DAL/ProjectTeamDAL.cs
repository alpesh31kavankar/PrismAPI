using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class ProjectTeamDAL
    {
        DbConnection conn = null;
        public ProjectTeamDAL()
        {   
            conn = new DbConnection();
        }   

        public List<ProjectTeam> GetAllProjectTeam()
        {
            List<ProjectTeam> projectTeamList = new List<ProjectTeam>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProjectTeam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProjectTeam projectTeam = new ProjectTeam();
                //dynamic dropdown
                projectTeam.Employees = new Employees();
                projectTeam.Projects = new Projects();
                projectTeam.Designation = new Designation();
                projectTeam.Company = new Company();
                projectTeam.Department = new Department();
                projectTeam.SubDepartment = new SubDepartment();
                projectTeam.Client = new Client();
                //dynamic dropdown
                projectTeam.Designation.Title = Convert.ToString(dr["Title1"]);
                projectTeam.Company.Title = Convert.ToString(dr["Title2"]);
                projectTeam.Department.Title = Convert.ToString(dr["Title3"]);
                projectTeam.SubDepartment.Title = Convert.ToString(dr["Title4"]);
                projectTeam.Client.Name = Convert.ToString(dr["Name"]);

                projectTeam.Employees.Id = Convert.ToInt32(dr["EmployeeId"]);
                projectTeam.Employees.FName = Convert.ToString(dr["FName"]);
                projectTeam.Employees.MName = Convert.ToString(dr["MName"]);
                projectTeam.Employees.LName = Convert.ToString(dr["LName"]);
                projectTeam.Employees.DesignationId = Convert.ToInt32(dr["DesignationId"]);
                projectTeam.Employees.DateofBirth = Convert.ToString(dr["DateofBirth"]);
                projectTeam.Employees.Address = Convert.ToString(dr["Address"]);
                projectTeam.Employees.City = Convert.ToString(dr["City"]);
                projectTeam.Employees.Contact = Convert.ToString(dr["Contact"]);
                projectTeam.Employees.Email = Convert.ToString(dr["Email"]);
                projectTeam.Employees.Photo = Convert.ToString(dr["Photo"]);
                projectTeam.Employees.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                projectTeam.Employees.LeavingDate = Convert.ToString(dr["LeavingDate"]);
                projectTeam.Employees.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                projectTeam.Employees.TotalExperience = Convert.ToString(dr["TotalExperience"]);
                projectTeam.Employees.Qualification = Convert.ToString(dr["Qualification"]);
                projectTeam.Employees.Facebook = Convert.ToString(dr["Facebook"]);
                projectTeam.Employees.Instagram = Convert.ToString(dr["Instagram"]);
                projectTeam.Employees.Tweeter = Convert.ToString(dr["Tweeter"]);
                projectTeam.Employees.Gmail = Convert.ToString(dr["Gmail"]);
                projectTeam.Employees.Linkedin = Convert.ToString(dr["Linkedin"]);
                projectTeam.Employees.Status = Convert.ToString(dr["Status1"]);
                projectTeam.Employees.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                projectTeam.Employees.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                projectTeam.Employees.Password = Convert.ToString(dr["Password"]);
                projectTeam.Employees.SalaryAmount = Convert.ToString(dr["SalaryAmount"]);

                projectTeam.Projects.Id = Convert.ToInt32(dr["ProjectId"]);
                projectTeam.Projects.Title = Convert.ToString(dr["Title"]);
                projectTeam.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                projectTeam.Projects.Description = Convert.ToString(dr["Description"]);
                projectTeam.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                projectTeam.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                projectTeam.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                projectTeam.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                projectTeam.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                projectTeam.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                projectTeam.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                projectTeam.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                projectTeam.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                projectTeam.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                projectTeam.Projects.Domain = Convert.ToString(dr["Domain"]);
                projectTeam.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                projectTeam.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                projectTeam.Projects.Status = Convert.ToString(dr["Status2"]);

                projectTeam.Id = Convert.ToInt32(dr["ProjectTeamId"]);

                projectTeam.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                projectTeam.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
               
                projectTeam.Status = Convert.ToString(dr["Status3"]);

                projectTeam.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                projectTeam.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                projectTeam.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                projectTeam.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                projectTeamList.Add(projectTeam);
            }
            con.Close();
            return projectTeamList;
        }

        public ProjectTeam GetProjectTeamById(int Id)
        {
            ProjectTeam projectTeam = new ProjectTeam();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProjectTeamById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                projectTeam.Id = Convert.ToInt32(dr["ProjectTeamId"]);
                //dynamic dropdown
                projectTeam.Employees = new Employees();
                projectTeam.Projects = new Projects();
                projectTeam.Designation = new Designation();
                projectTeam.Company = new Company();
                projectTeam.Department = new Department();
                projectTeam.SubDepartment = new SubDepartment();
                projectTeam.Client = new Client();
                //dynamic dropdown
                projectTeam.Designation.Title = Convert.ToString(dr["Title1"]);
                projectTeam.Company.Title = Convert.ToString(dr["Title2"]);
                projectTeam.Department.Title = Convert.ToString(dr["Title3"]);
                projectTeam.SubDepartment.Title = Convert.ToString(dr["Title4"]);
                projectTeam.Client.Name = Convert.ToString(dr["Name"]);


                projectTeam.Employees.Id = Convert.ToInt32(dr["EmployeeId"]);
                projectTeam.Employees.FName = Convert.ToString(dr["FName"]);
                projectTeam.Employees.MName = Convert.ToString(dr["MName"]);
                projectTeam.Employees.LName = Convert.ToString(dr["LName"]);
                projectTeam.Employees.DesignationId = Convert.ToInt32(dr["DesignationId"]);
                projectTeam.Employees.DateofBirth = Convert.ToString(dr["DateofBirth"]);
                projectTeam.Employees.Address = Convert.ToString(dr["Address"]);
                projectTeam.Employees.City = Convert.ToString(dr["City"]);
                projectTeam.Employees.Contact = Convert.ToString(dr["Contact"]);
                projectTeam.Employees.Email = Convert.ToString(dr["Email"]);
                projectTeam.Employees.Photo = Convert.ToString(dr["Photo"]);
                projectTeam.Employees.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                projectTeam.Employees.LeavingDate = Convert.ToString(dr["LeavingDate"]);
                projectTeam.Employees.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                projectTeam.Employees.TotalExperience = Convert.ToString(dr["TotalExperience"]);
                projectTeam.Employees.Qualification = Convert.ToString(dr["Qualification"]);
                projectTeam.Employees.Facebook = Convert.ToString(dr["Facebook"]);
                projectTeam.Employees.Instagram = Convert.ToString(dr["Instagram"]);
                projectTeam.Employees.Tweeter = Convert.ToString(dr["Tweeter"]);
                projectTeam.Employees.Gmail = Convert.ToString(dr["Gmail"]);
                projectTeam.Employees.Linkedin = Convert.ToString(dr["Linkedin"]);
                projectTeam.Employees.Status = Convert.ToString(dr["Status1"]);
                projectTeam.Employees.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                projectTeam.Employees.SubDepartmentId = Convert.ToInt32(dr["SubDepartmentId"]);
                projectTeam.Employees.Password = Convert.ToString(dr["Password"]);
                projectTeam.Employees.SalaryAmount = Convert.ToString(dr["SalaryAmount"]);

                projectTeam.Projects.Id = Convert.ToInt32(dr["ProjectId"]);
                projectTeam.Projects.Title = Convert.ToString(dr["Title"]);
                projectTeam.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                projectTeam.Projects.Description = Convert.ToString(dr["Description"]);
                projectTeam.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                projectTeam.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                projectTeam.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                projectTeam.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                projectTeam.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                projectTeam.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                projectTeam.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                projectTeam.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                projectTeam.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                projectTeam.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                projectTeam.Projects.Domain = Convert.ToString(dr["Domain"]);
                projectTeam.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                projectTeam.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                projectTeam.Projects.Status = Convert.ToString(dr["Status2"]);


                projectTeam.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                projectTeam.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);

                projectTeam.Status = Convert.ToString(dr["Status3"]);

                projectTeam.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                projectTeam.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                projectTeam.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                projectTeam.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return projectTeam;
        }


        public string AddProjectTeam(ProjectTeam projectTeam)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProjectTeam", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_ProjectId", MySqlDbType.VarChar).Value = projectTeam.ProjectId;
            cmd.Parameters.Add("p_EmployeeId", MySqlDbType.VarChar).Value = projectTeam.EmployeeId;
           
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = projectTeam.Status;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = projectTeam.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = projectTeam.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = projectTeam.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = projectTeam.UpdatedDate;


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


        public string UpdateProjectTeam(ProjectTeam projectTeam)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProjectTeam", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = projectTeam.Id;
            cmd.Parameters.Add("p_ProjectId", MySqlDbType.VarChar).Value = projectTeam.ProjectId;
            cmd.Parameters.Add("p_EmployeeId", MySqlDbType.VarChar).Value = projectTeam.EmployeeId;

            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = projectTeam.Status;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = projectTeam.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = projectTeam.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = projectTeam.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = projectTeam.UpdatedDate;



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

        public string DeleteProjectTeam(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProjectTeam", con);
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