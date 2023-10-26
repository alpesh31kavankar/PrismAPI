using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Technologies
    {
        public int Id { get; set; }

        public TechnologiesType TechnologiesType { get; set; }

        public int TechnologiesTypeId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Image { get; set; }


        public int TechnologyTypeId { get; set; }


        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }

    }
}