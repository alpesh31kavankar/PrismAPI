using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace PrismAPI.DAL
{
    public class TaskDAL
    {
        DbConnection conn = null;
        public TaskDAL()
        {
            conn = new DbConnection();
        }

        public List<Task> GetAllTask()
        { 
            List<Task> taskList = new List<Task>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllTask", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Task task = new Task();  
                task.Projects = new Projects();
                task.Client = new Client();
                task.Client.Name = Convert.ToString(dr["Name"]);

                task.Projects.Title = Convert.ToString(dr["Title1"]);
                task.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                task.Projects.Description = Convert.ToString(dr["Description"]);
                task.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                 task.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                task.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                task.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                task.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                task.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                task.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                task.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                task.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                task.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                task.Projects.Domain = Convert.ToString(dr["Domain"]);
                task.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                task.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                task.Projects.Status = Convert.ToString(dr["Status1"]);

                task.Id = Convert.ToInt32(dr["TaskId"]);

                task.Title = Convert.ToString(dr["Title2"]);
                task.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                task.TaskWork = Convert.ToString(dr["TaskWork"]);
                task.StartDate = Convert.ToString(dr["StartDate"]);
                task.DeadlineDate = Convert.ToString(dr["DeadlineDate"]);
                task.CompleteDate = Convert.ToString(dr["CompleteDate"]);
                task.Status = Convert.ToString(dr["Status2"]);
                task.Note = Convert.ToString(dr["Note"]);
                task.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                task.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                task.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                task.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                taskList.Add(task);
            }
            con.Close();
            return taskList;
        }

        public Task GetTaskById(int Id)
        {
            Task task = new Task();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetTaskById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                task.Projects = new Projects();
                task.Client = new Client();
                task.Client.Name = Convert.ToString(dr["Name"]);
                task.Projects.Title = Convert.ToString(dr["Title1"]);
                task.Projects.SubTitle = Convert.ToString(dr["SubTitle"]);
                task.Projects.Description = Convert.ToString(dr["Description"]);
                task.Projects.ClientId = Convert.ToInt32(dr["ClientId"]);
                task.Projects.ProjectType = Convert.ToString(dr["ProjectType"]);
                task.Projects.ProjectStartDate = Convert.ToString(dr["ProjectStartDate"]);
                task.Projects.ProjectDeadLine = Convert.ToString(dr["ProjectDeadLine"]);
                task.Projects.ProjectEndDate = Convert.ToString(dr["ProjectEndDate"]);
                task.Projects.ProjectManager = Convert.ToString(dr["ProjectManager"]);
                task.Projects.TeamSize = Convert.ToString(dr["TeamSize"]);
                task.Projects.LaunchDate = Convert.ToString(dr["LaunchDate"]);
                task.Projects.LocalBackup = Convert.ToString(dr["LocalBackup"]);
                task.Projects.ServerBackup = Convert.ToString(dr["ServerBackup"]);
                task.Projects.Domain = Convert.ToString(dr["Domain"]);
                task.Projects.ProjectLogo = Convert.ToString(dr["ProjectLogo"]);
                task.Projects.ProImage = Convert.ToString(dr["ProImage"]);
                task.Projects.Status = Convert.ToString(dr["Status1"]);

                task.Id = Convert.ToInt32(dr["TaskId"]);

                task.Title = Convert.ToString(dr["Title2"]);
                task.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                task.TaskWork = Convert.ToString(dr["TaskWork"]);
                task.StartDate = Convert.ToString(dr["StartDate"]);
                task.DeadlineDate = Convert.ToString(dr["DeadlineDate"]);
                task.CompleteDate = Convert.ToString(dr["CompleteDate"]);
                task.Status = Convert.ToString(dr["Status2"]);
                task.Note = Convert.ToString(dr["Note"]);
                task.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                task.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                task.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                task.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



            }
            con.Close();
            return task;
        }


        public string AddTask(Task task)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddTask", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = wishlist.Id;


            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = task.Title;
            cmd.Parameters.Add("p_ProjectId", MySqlDbType.Int32).Value = task.ProjectId;
            cmd.Parameters.Add("p_TaskWork", MySqlDbType.VarChar).Value = task.TaskWork;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = task.StartDate;
            cmd.Parameters.Add("p_DeadlineDate", MySqlDbType.VarChar).Value = task.DeadlineDate;
            cmd.Parameters.Add("p_CompleteDate", MySqlDbType.VarChar).Value = task.CompleteDate;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = task.Status;
            cmd.Parameters.Add("p_Note", MySqlDbType.VarChar).Value = task.Note;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = task.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = task.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = task.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = task.UpdatedDate;


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


        public string UpdateTask(Task task)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateTask", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = task.Id;

            cmd.Parameters.Add("p_Title", MySqlDbType.VarChar).Value = task.Title;
            cmd.Parameters.Add("p_ProjectId", MySqlDbType.Int32).Value = task.ProjectId;
            cmd.Parameters.Add("p_TaskWork", MySqlDbType.VarChar).Value = task.TaskWork;
            cmd.Parameters.Add("p_StartDate", MySqlDbType.VarChar).Value = task.StartDate;
            cmd.Parameters.Add("p_DeadlineDate", MySqlDbType.VarChar).Value = task.DeadlineDate;
            cmd.Parameters.Add("p_CompleteDate", MySqlDbType.VarChar).Value = task.CompleteDate;
            cmd.Parameters.Add("p_Status", MySqlDbType.VarChar).Value = task.Status;
            cmd.Parameters.Add("p_Note", MySqlDbType.VarChar).Value = task.Note;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = task.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = task.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = task.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = task.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return task.Id.ToString();
        }


        public string DeleteTask(int Id)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("DeleteTask", con);
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