using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHotel.Infrastructure;
using System.Data.Entity;
using PetHotel.Models;
using DAL;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace PetHotel.Controllers
{
    public class AdminController : Controller
    {
        public ViewModelContext db = new ViewModelContext();
       
        
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            Repository rep = new Repository();
          
            return View("Admin",rep.listOfReservation);
        }

        public ActionResult price()
        {
            var price = db.Prices;
            return View(price.ToList());


        }
        public ActionResult invoice()
        {

            var invoice = db.Invoices.Include(c => c.Customer).Include(c => c.OrderItems);
            
            var mylist = new List<PriceLists>
            {
            new PriceLists {Spice="Dog",Price= 200},
            new PriceLists{Spice= "Cat",Price=140},
            new PriceLists{Spice= "Canary",Price= 60},
            new PriceLists{ Spice="Chinchila", Price= 180},
            new PriceLists{Spice="Iguana",Price= 160},
            new PriceLists{Spice="Rabbit",Price= 90},
            new PriceLists{Spice="Hamster",Price= 80}
             };
            //ViewBag.price = mylist;
            Repository rep = new Repository();
            if (Session["repository"] != null)
            {
                rep = (Repository)Session["repository"];

            }

            ViewBag.price = rep.listOfReservation;
            return View( invoice.ToList());


        }

        public ActionResult Price_Read([DataSourceRequest]DataSourceRequest request)
        {

            var price = db.Prices;
            DataSourceResult result = price.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      

	}
}