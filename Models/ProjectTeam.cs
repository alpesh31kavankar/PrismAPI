using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class ProjectTeam
    {
        public int Id { get; set; }

        //Dynamic Dropdown
        public Employees Employees { get; set; }

        public Projects Projects { get; set; }

        public Designation Designation { get; set; }

        public Company Company { get; set; }

        public Department Department { get; set; }

       public SubDepartment SubDepartment { get; set; }

        public Client Client { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

       


        public string Status { get; set; }




        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}