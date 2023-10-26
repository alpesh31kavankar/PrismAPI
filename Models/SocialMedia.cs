using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class SocialMedia
    {

        public int Id { get; set; }

        public Company Company { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string SocialLink { get; set; }

        public string Imgicon { get; set; }
        public int CompanyId { get; set; }

        public string Status { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}