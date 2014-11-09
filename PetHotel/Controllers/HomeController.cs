using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHotel.Infrastructure;
using PetHotel.ViewModels;

namespace PetHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int?id)
        {
            if(id!=null)
            {
                ViewBag.price ="Here is your price:" + id;

            }
            ViewBag.amount = 1;
            Reservation reservation = new Reservation();
            return View(reservation);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}