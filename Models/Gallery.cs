using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Gallery
    {

        public int Id { get; set; }
        //Dynamic dropdown 2 Line
        public GalleryCategory GalleryCategory { get; set; }
        public int GalleryCategoryId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }


       


        public int galleryCategoryId { get; set; }

        public string Image { get; set; }




        public string CreatedBy { get; set; }


        public string CreatedDate { get; set; }


        public string UpdatedBy { get; set; }


        public string UpdatedDate { get; set; }
    }
}