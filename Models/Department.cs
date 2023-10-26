using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Department
    {
        //Dynamic Dropdown
        public Company Company { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public int CompanyId { get; set; }

        public string DeptImage { get; set; }

   

        public string HOD { get; set; }

        public string Status { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}