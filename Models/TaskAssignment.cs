using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }

        //Dynamic Dropdown
        public Task Task { get; set; }
        public Employees Employees { get; set; }

        public ProjectTeam ProjectTeam { get; set; }
        public Client Client { get; set; }

        public Projects Projects { get; set; }

        public int ProjectId { get; set; }

        public int ProjectTeamEmployeeId { get; set; }

        public int TaskId { get; set; }


        public string Status { get; set; }


       

        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}