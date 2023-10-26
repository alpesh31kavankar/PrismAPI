using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Projects
    {
        public Client Client { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }

        public string ProjectType { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectDeadLine { get; set; }
        public string ProjectEndDate { get; set; }
        public string ProjectManager { get; set; }
        public string TeamSize { get; set; }
        public string LaunchDate { get; set; }
        public string LocalBackup { get; set; }
        public string ServerBackup { get; set; }
        public string Domain { get; set; }

        public string ProjectLogo { get; set; }
        public string ProImage { get; set; }

        public string Status { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        }
}