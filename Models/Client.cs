using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
       
        //Dynamic DropDown
        public Service Service { get; set; }

        public ServiceMainType ServiceMainType { get; set; }


        public ServiceSubType ServiceSubType { get; set; }
        //public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string address { get; set; }


        public string City { get; set; }


        public string Logo { get; set; }

        public int ServiceId { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string ClientType { get; set; }

        public string Website { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhoto { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Tweeter { get; set; }

        public string Status { get; set; }





        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}