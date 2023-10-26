using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class DashboardDetails
    {
        public int TotalBlog { get; set; }
        public int TotalClient { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalProduct { get; set; }
        public int TotalProjects { get; set; }
        public int TotalService { get; set; }
        public int TotalServiceInquiry { get; set; }

    }
}