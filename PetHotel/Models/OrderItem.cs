using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetHotel.Models
{
    public class OrderItem

    {
        public int OrderItemID { get; set; }
        public string Spiece { get; set; }
        [Required]
        public string Petname { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public decimal PricePerDay { get; set; }
        public int NumberOfDays { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public OrderItem()
        {
           
           
        }



    }
}
