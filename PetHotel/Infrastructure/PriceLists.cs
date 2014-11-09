using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetHotel.Infrastructure
{
    public class PriceLists
    {
        private Dictionary<string, decimal> pricelist = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> PriceList { get { return pricelist; } }
      
        public int ID { get; set; }
        public string Spice { get; set; }
        public decimal Price { get; set; }



        public PriceLists(string spiece, decimal price)
        {
            this.Spice = spiece;
            this.Price = price;

        }        
        public PriceLists()
        { 
          
            pricelist.Add("Dog", 200);
            pricelist.Add("Cat", 140);
            pricelist.Add("Canary", 60);
            pricelist.Add("Chinchila", 180);
            pricelist.Add("Iguana", 160);
            pricelist.Add("Rabbit", 90);
            pricelist.Add("Hamster", 80);


        }


    }
}