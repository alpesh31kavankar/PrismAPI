using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;  

namespace PrismAPI.DAL
{
    public class TaskAssignmentDAL
    {
        DbConnection conn = null;
        public TaskAssignmentDAL()
        {
            conn = new DbConnection();
        }

        public List<TaskAssignment> GetAllTaskAssignment()
        {
            List<TaskAssignment> taskAssignmentList = new List<TaskAssignment>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllTaskAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TaskAssignment taskAssignment = new TaskAssignment();
               
                //dynamic dropdown
                taskAssignment.Task = new Task();
                taskAssignment.ProjectTeam = new ProjectTeam();
                taskAssignment.Projects = new Projects();

                taskAssignment.Client = new Client();
                taskAssignment.Client.Name = Convert.ToString(dr["Name"]);
                taskAssignment.Employees = new Employees();

                taskAssignment.Employees.FName = Convert.ToString(dr["FName"]);
                //dynamic dropdown
                taskAssignment.Task.Id = Convert.ToInt32(dr["TaskId"]);
                taskAssignment.Task.Title = Convert.ToString(dr["Title2"]);
                taskAssignment.Task.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.Task.TaskWork = Convert.ToString(dr["TaskWork"]);
                taskAssignment.Task.StartDate = Convert.ToString(dr["StartDate"]);
                taskAssignment.Task.DeadlineDate = Convert.ToString(dr["DeadlineDate"]);
                taskAssignment.Task.CompleteDate = Convert.ToString(dr["CompleteDate"]);
                taskAssignment.Task.Status = Convert.ToString(dr["Status1"]);
                taskAssignment.Task.Note = Convert.ToString(dr["Note"]);

                //taskAssignment.ProjectTeam.Id = Convert.ToInt32(dr["ProjectTeamEmployeeId"]);
                taskAssignment.ProjectTeam.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.ProjectTeam.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                taskAssignment.ProjectTeam.Status = Convert.ToString(dr["Status2"]);

                taskAssignment.Projects.Id = Convert.ToInt32(dr["Id"]);
                taskAssignment.Projects.Title = Convert.ToString(dr["Title1"]);
                taskAssignment.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                taskAssignment.Projects.Description = Convert.ToString(dr["Description"]);
                taskAssignment.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                taskAssignment.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                taskAssignment.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                taskAssignment.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                taskAssignment.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                taskAssignment.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                taskAssignment.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                taskAssignment.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                taskAssignment.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                taskAssignment.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                taskAssignment.Projects.Domain = Convert.ToString(dr["Domain"]);
                taskAssignment.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                taskAssignment.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                taskAssignment.Projects.Status = Convert.ToString(dr["Status3"]);


                taskAssignment.Id = Convert.ToInt32(dr["TaskAssignmentId"]);
                taskAssignment.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.ProjectTeamEmployeeId = Convert.ToInt32(dr["ProjectTeamEmployeeId"]);
                taskAssignment.TaskId = Convert.ToInt32(dr["TaskId"]);
                taskAssignment.Status = Convert.ToString(dr["Status4"]);
               
                taskAssignment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                taskAssignment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                taskAssignment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                taskAssignment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                taskAssignmentList.Add(taskAssignment);
            }
            con.Close();
            return taskAssignmentList;
        }

        public TaskAssignment GetTaskAssignmentById(int Id)
        {
            TaskAssignment taskAssignment = new TaskAssignment();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetTaskAssignmentById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                taskAssignment.Id = Convert.ToInt32(dr["TaskAssignmentId"]);

                //dynamic dropdown
                taskAssignment.Task = new Task();
                taskAssignment.ProjectTeam = new ProjectTeam();
                taskAssignment.Projects = new Projects();

                taskAssignment.Client = new Client();
                taskAssignment.Client.Name = Convert.ToString(dr["Name"]);
                taskAssignment.Employees = new Employees();
                taskAssignment.Employees.FName = Convert.ToString(dr["FName"]);
                //dynamic dropdown
                taskAssignment.Task.Id = Convert.ToInt32(dr["TaskId"]);
                taskAssignment.Task.Title = Convert.ToString(dr["Title"]);
                taskAssignment.Task.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.Task.TaskWork = Convert.ToString(dr["TaskWork"]);
                taskAssignment.Task.StartDate = Convert.ToString(dr["StartDate"]);
                taskAssignment.Task.DeadlineDate = Convert.ToString(dr["DeadlineDate"]);
                taskAssignment.Task.CompleteDate = Convert.ToString(dr["CompleteDate"]);
                taskAssignment.Task.Status = Convert.ToString(dr["Status1"]);
                taskAssignment.Task.Note = Convert.ToString(dr["Note"]);

                taskAssignment.ProjectTeam.Id = Convert.ToInt32(dr["ProjectTeamEmployeeId"]);
                taskAssignment.ProjectTeam.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.ProjectTeam.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                taskAssignment.ProjectTeam.Status = Convert.ToString(dr["Status2"]);

                taskAssignment.Projects.Id = Convert.ToInt32(dr["Id"]);
                taskAssignment.Projects.Title = Convert.ToString(dr["Title1"]);
                taskAssignment.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                taskAssignment.Projects.Description = Convert.ToString(dr["Description"]);
                taskAssignment.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                taskAssignment.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                taskAssignment.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                taskAssignment.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                taskAssignment.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                taskAssignment.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                taskAssignment.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                taskAssignment.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                taskAssignment.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                taskAssignment.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                taskAssignment.Projects.Domain = Convert.ToString(dr["Domain"]);
                taskAssignment.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                taskAssignment.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                taskAssignment.Projects.Status = Convert.ToString(dr["Status3"]);

              

                taskAssignment.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                taskAssignment.ProjectTeamEmployeeId = Convert.ToInt32(dr["ProjectTeamEmployeeId"]);
                taskAssignment.TaskId = Convert.ToInt32(dr["TaskId"]);
                taskAssignment.Status = Convert.ToString(dr["Status4"]);

                taskAssignment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                taskAssignment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                taskAssignment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                taskAssignment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return taskAssignment;
        }


        public string AddTaskAssignment(TaskAssignment taskAssignment)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddTaskAssignment", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_ProjectId", MySqlDbType.VarChar).Value = taskAssignment.ProjectId;
            cmd.Parameters.Add("p_ProjectTeamEmployeeId", MySqlDbType.VarChar).Value = taskAssignment.ProjectTeamEmployeeId;
            cmd.Parameters.Add("p_TaskId", MySqlDbType.VarChar).Value = taskAssignment.TaskId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = taskAssignment.Status;
           
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = taskAssignment.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = taskAssignment.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = taskAssignment.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = taskAssignment.UpdatedDate;


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


        public string UpdateTaskAssignment(TaskAssignment taskAssignment)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateTaskAssignment", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = taskAssignment.Id;
            cmd.Parameters.Add("p_ProjectId", MySqlDbType.VarChar).Value = taskAssignment.ProjectId;
            cmd.Parameters.Add("p_ProjectTeamEmployeeId", MySqlDbType.VarChar).Value = taskAssignment.ProjectTeamEmployeeId;
            cmd.Parameters.Add("p_TaskId", MySqlDbType.VarChar).Value = taskAssignment.TaskId;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = taskAssignment.Status;

            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = taskAssignment.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = taskAssignment.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = taskAssignment.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = taskAssignment.UpdatedDate;



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


        public string DeleteTaskAssignment(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteTaskAssignment", con);
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
