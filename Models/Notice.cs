using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Notice
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}