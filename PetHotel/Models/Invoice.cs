using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PetHotel.Models
{
    public class Invoice
    {
        [Required]
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public decimal Totalprice  {get;set;}

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
       
        
        
        public Invoice()
        {

            OrderItems = new List<OrderItem>();
           


        }
       




    }
}
