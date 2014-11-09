using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetHotel.ViewModels;
namespace PetHotel.Infrastructure
{
    public class Repository
    {
        //costruct a list of reservations uses by session to demonstarate some example data
        public virtual ICollection<Reservation> listOfReservation { get; set; }
        public Repository()
        {
            listOfReservation = new List<Reservation>();
        }


    }
}