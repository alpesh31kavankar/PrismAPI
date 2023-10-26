using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public ProdType ProdType { get; set; }

        public ProdSubType ProdSubType { get; set; }

        public ServiceMainType ServiceMainType { get; set; }

        public ServiceSubType ServiceSubType { get; set; }

        
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public int ProdTypeId { get; set; }
        public int ProdSubTypeId { get; set; }

        public string MainImage { get; set; }

        public string ProdIcon { get; set; }

        public string Imageone { get; set; }

        public string Imagetwo { get; set; }

        public string Imagethree { get; set; }

        public int ServiceMainTypeId { get; set; }

        public int ServiceSubTypeId { get; set; }

        public string DemoLink { get; set; }

        public string PricingLink { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}