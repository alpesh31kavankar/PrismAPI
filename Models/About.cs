using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class About
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public string AboutImage { get; set; }
        public string Vision { get; set; }
        public string VisionImage { get; set; }
        public string Mission { get; set; }
        public string MissionImage { get; set; }
        public string Valuess { get; set; }
        public string ValuesImage { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}