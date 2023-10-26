using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public BlogCategory BlogCategory { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }
        public int BlogCategoryId { get; set; }
        public string Sectionone { get; set; }
        public string Sectiontwo { get; set; }
        public string Sectionthree { get; set; }

        public string BlogImg { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}