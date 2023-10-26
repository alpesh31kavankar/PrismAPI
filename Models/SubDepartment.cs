using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class SubDepartment
    {
        public int Id { get; set; }

        public Department Department { get; set; }  

      //  public Company Company { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }

        public string HOD { get; set; }

        public string Status { get; set; }

        public string SubDeptImage { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}