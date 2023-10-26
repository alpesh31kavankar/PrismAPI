using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class JobPost
    {
        public int Id { get; set; }

        public string Post { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }


        public string Experience { get; set; }

        public string Qualification { get; set; }

        public string Salary { get; set; }

        public string SkillRequirement { get; set; }

        public string Image { get; set; }

        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}