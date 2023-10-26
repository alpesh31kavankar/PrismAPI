using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class OnBoardMember
    {
        public int Id { get; set; }
        //Dynamic Dropdown
        public Designation Designation { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public SubDepartment SubDepartment { get; set; }

        public string FName { get; set; }

        public string MName { get; set; }

        public string LName { get; set; }

        public int DesignationId { get; set; }


        public string Address { get; set; }


        public string City { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public string JoiningDate { get; set; }

        public string LeavingDate { get; set; }

        public int CompanyId { get; set; }

        public string Birthdate { get; set; }



        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Tweeter { get; set; }

        public string Gmail { get; set; }
        public string Linkedin { get; set; }

        public string Status { get; set; }


        public int DepartmentId { get; set; }

        public int SubDepartmentId { get; set; }

        public string About { get; set; }

        public string Says { get; set; }





        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}