using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Task
    {
        public Projects Projects { get; set; }

        public Client Client { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }
       
        public int ProjectId { get; set; }

        public string TaskWork { get; set; }
        
        public string StartDate { get; set; }

        public string DeadlineDate { get; set; }

        public string CompleteDate { get; set; }

        public string Status { get; set; }

        public string Note { get; set; }

        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}