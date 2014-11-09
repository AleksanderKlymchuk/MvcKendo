using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetHotel.Models;
using PetHotel.Infrastructure;
using DAL;

namespace PetHotel.ViewModels
{
    public class Reservation
    {
        
        
        public Customer Customer { get; set; } 
        public Invoice Invoice { get; set; } 
        public OrderItem OrderItem { get; set; }
        public PriceLists PriceList { get; set; }
       
        public Reservation() { 
        Customer = new Customer(); 
        Invoice = new Invoice(); 
        OrderItem = new OrderItem();
        PriceList = new PriceLists();
       
      
        }


        

    }
}