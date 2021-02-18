using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_WebApplication.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        [Required]
        public string Delivery_address { get; set; }

        public string Parcel_weight { get; set; }
        [Required]
        public string Content_type { get; set; }
        public Decimal Shipping_cost { get; set; }
        public int SenderId { get; set; }
        public Senderdetail Senderdetail { get; set; }

        public int CompanyId { get; set; }
        public Companydetail Compantdetail { get; set; }

        public int RecieverId { get; set; }
        public Recieverdetail Recieverdetail { get; set; }
    }
}
