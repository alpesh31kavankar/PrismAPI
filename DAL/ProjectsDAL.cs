using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Web;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class ProjectsDAL
    {
        DbConnection conn = null;  
        public ProjectsDAL()
        {
            conn = new DbConnection();
        }

        public List<Projects> GetAllProjects()
 {
            List<Projects> projectList = new List<Projects>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Projects project = new Projects();
                //Dynamic Dropdown
                project.Client = new Client();

                project.Client.Name = Convert.ToString(dr["Name"]);
                project.Client.Description = Convert.ToString(dr["Description1"]);
                project.Client.address = Convert.ToString(dr["address"]);
                project.Client.City = Convert.ToString(dr["City"]);
                project.Client.Logo = Convert.ToString(dr["Logo"]);
                project.Client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                project.Client.Contact = Convert.ToString(dr["Contact"]);
                project.Client.Email = Convert.ToString(dr["Email"]);
                project.Client.ClientType = Convert.ToString(dr["ClientType"]);
                project.Client.Website = Convert.ToString(dr["Website"]);
                project.Client.OwnerName = Convert.ToString(dr["OwnerName"]);
                project.Client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                project.Client.Facebook = Convert.ToString(dr["Facebook"]);
                project.Client.Instagram = Convert.ToString(dr["Instagram"]);
                project.Client.Tweeter = Convert.ToString(dr["Tweeter"]);
                project.Client.Status = Convert.ToString(dr["Status1"]);



                project.Id = Convert.ToInt32(dr["Id"]);
                project.Title = Convert.ToString(dr["Title"]);
                project.SubTitle = Convert.ToString(dr["SubTitle"]);
                project.Description = Convert.ToString(dr["Description2"]);
                project.ClientId = Convert.ToInt32(dr["ClientId"]);
                project.ProjectType = Convert.ToString(dr["ProjectType"]);
                project.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                project.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                project.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                project.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                project.TeamSize = Convert.ToString(dr["TeamSize"]);
                project.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                project.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                project.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                project.Domain = Convert.ToString(dr["Domain"]);
                project.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                project.ProImage = Convert.ToString(dr["ProImage"]);
                project.Status = Convert.ToString(dr["Status2"]);

                project.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                project.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                project.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                project.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

                projectList.Add(project);
            }
            con.Close();
            return projectList;
        }

        public Projects GetProjectsById(int Id)
        {
            Projects project = new Projects();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetProjectsById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Dynamic Dropdown
                project.Client = new Client();

                project.Client.Name = Convert.ToString(dr["Name"]);
                project.Client.Description = Convert.ToString(dr["Description1"]);
                project.Client.address = Convert.ToString(dr["address"]);
                project.Client.City = Convert.ToString(dr["City"]);
                project.Client.Logo = Convert.ToString(dr["Logo"]);
                project.Client.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                project.Client.Contact = Convert.ToString(dr["Contact"]);
                project.Client.Email = Convert.ToString(dr["Email"]);
                project.Client.ClientType = Convert.ToString(dr["ClientType"]);
                project.Client.Website = Convert.ToString(dr["Website"]);
                project.Client.OwnerName = Convert.ToString(dr["OwnerName"]);
                project.Client.OwnerPhoto = Convert.ToString(dr["OwnerPhoto"]);
                project.Client.Facebook = Convert.ToString(dr["Facebook"]);
                project.Client.Instagram = Convert.ToString(dr["Instagram"]);
                project.Client.Tweeter = Convert.ToString(dr["Tweeter"]);
                project.Client.Status = Convert.ToString(dr["Status1"]);


                project.Id = Convert.ToInt32(dr["Id"]);
                project.Title = Convert.ToString(dr["Title"]);
                project.SubTitle = Convert.ToString(dr["SubTitle"]);
                project.Description = Convert.ToString(dr["Description2"]);
                project.ClientId = Convert.ToInt32(dr["ClientId"]);
                project.ProjectType = Convert.ToString(dr["ProjectType"]);
                project.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                project.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                project.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                project.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                project.TeamSize = Convert.ToString(dr["TeamSize"]);
                project.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                project.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                project.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                project.Domain = Convert.ToString(dr["Domain"]);
                project.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                project.ProImage = Convert.ToString(dr["ProImage"]);
                project.Status = Convert.ToString(dr["Status2"]);

                project.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                project.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                project.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                project.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

            }
            con.Close();
            return project;
        }


        public string AddProjects(Projects project)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddProjects", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;

            //  cmd.Parameters.Add("Id", MySqlDbType.Int).Value = profileDataEntry.Id;

            cmd.Parameters.Add("p_title", MySqlDbType.VarChar).Value = project.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = project.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = project.Description;
            cmd.Parameters.Add("p_ClientId", MySqlDbType.Int32).Value = project.ClientId;
            cmd.Parameters.Add("p_ProjectType", MySqlDbType.VarChar).Value = project.ProjectType;
            cmd.Parameters.Add("p_ProjectStartDate", MySqlDbType.VarChar).Value = project.ProjectStartDate;
            cmd.Parameters.Add("p_ProjectDeadLine", MySqlDbType.VarChar).Value = project.ProjectDeadLine;
            cmd.Parameters.Add("p_ProjectEndDate", MySqlDbType.VarChar).Value = project.ProjectEndDate;
            cmd.Parameters.Add("p_ProjectManager", MySqlDbType.VarChar).Value = project.ProjectManager;
            cmd.Parameters.Add("p_TeamSize", MySqlDbType.VarChar).Value = project.TeamSize;
            cmd.Parameters.Add("p_LaunchDate", MySqlDbType.VarChar).Value = project.LaunchDate;
            cmd.Parameters.Add("p_LocalBackup", MySqlDbType.VarChar).Value = project.LocalBackup;
            cmd.Parameters.Add("p_ServerBackup", MySqlDbType.VarChar).Value = project.ServerBackup;
            cmd.Parameters.Add("p_Domain", MySqlDbType.VarChar).Value = project.Domain;
            cmd.Parameters.Add("p_ProjectLogo", MySqlDbType.VarChar).Value = project.ProjectLogo;
            cmd.Parameters.Add("p_ProImage", MySqlDbType.VarChar).Value = project.ProImage;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = project.Status;



            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = project.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = project.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = project.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = project.UpdatedBy;


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


        public string UpdateProjects(Projects project)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateProjects", con);

            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = project.Id;
            cmd.Parameters.Add("p_title", MySqlDbType.VarChar).Value = project.Title;
            cmd.Parameters.Add("p_SubTitle", MySqlDbType.VarChar).Value = project.SubTitle;
            cmd.Parameters.Add("p_Description", MySqlDbType.VarChar).Value = project.Description;
            cmd.Parameters.Add("p_ClientId", MySqlDbType.Int32).Value = project.ClientId;
            cmd.Parameters.Add("p_ProjectType", MySqlDbType.VarChar).Value = project.ProjectType;
            cmd.Parameters.Add("p_ProjectStartDate", MySqlDbType.VarChar).Value = project.ProjectStartDate;
            cmd.Parameters.Add("p_ProjectDeadLine", MySqlDbType.VarChar).Value = project.ProjectDeadLine;
            cmd.Parameters.Add("p_ProjectEndDate", MySqlDbType.VarChar).Value = project.ProjectEndDate;
            cmd.Parameters.Add("p_ProjectManager", MySqlDbType.VarChar).Value = project.ProjectManager;
            cmd.Parameters.Add("p_TeamSize", MySqlDbType.VarChar).Value = project.TeamSize;
            cmd.Parameters.Add("p_LaunchDate", MySqlDbType.VarChar).Value = project.LaunchDate;
            cmd.Parameters.Add("p_LocalBackup", MySqlDbType.VarChar).Value = project.LocalBackup;
            cmd.Parameters.Add("p_ServerBackup", MySqlDbType.VarChar).Value = project.ServerBackup;
            cmd.Parameters.Add("p_Domain", MySqlDbType.VarChar).Value = project.Domain;
            cmd.Parameters.Add("p_ProjectLogo", MySqlDbType.VarChar).Value = project.ProjectLogo;
            cmd.Parameters.Add("p_ProImage", MySqlDbType.VarChar).Value = project.ProImage;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = project.Status;



            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = project.CreatedDate;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = project.CreatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = project.UpdatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = project.UpdatedBy;



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
            return project.Id.ToString();
        }


        public string DeleteProjects(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteProjects", con);
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