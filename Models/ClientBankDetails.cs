using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class ClientBankDetails
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        public Service Service { get; set; }
        public int ClientId { get; set; }
        public string AccountNo { get; set; }

        public string Name { get; set; }
        public string IfsCode { get; set; }
        public string QRCode { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}