using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHotel.ViewModels;
using PetHotel.Models;
using PetHotel.Infrastructure;
using DAL;




namespace PetHotel.Controllers
{
    public class ReservationController : Controller
    {
        public ViewModelContext Db = new ViewModelContext();
        //
        // GET: /Reservation/
       
        public ActionResult Index()
        {
            ViewBag.amount = 1;
            var data = Db.Invoices.Include(r => r.Customer).Include(n => n.OrderItems);
         
            return View(data.ToList());

        }
            private decimal TotalPrice(string to,string from, string specie)
            {
                decimal tprice;
                Reservation res = new Reservation();
                var start = Convert.ToDateTime(from);
                var end = Convert.ToDateTime(to);
                int total = (end - start).Days;
                decimal pr = res.PriceList.PriceList[specie];
                tprice=pr*total;

                return tprice;
            }
         

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Reservation reser = new Reservation();

            ViewBag.url = Request.UrlReferrer.AbsoluteUri;

            if (Request.UrlReferrer.AbsoluteUri == "http://localhost:56667/Reservation/prices")
            {
                ViewBag.url = Request.UrlReferrer.Host;
                if (collection["sub-btn"] == "Check Price")
                {

                    var specie = collection["spe"];
                    var from = collection["startDate"];
                    var to = collection["endDate"];
                    var amount = collection["Amount"];
                    decimal price = TotalPrice(to, from, specie) * Convert.ToDecimal(amount);
                    double total = Convert.ToDouble(amount);
                    return RedirectToAction("prices", new { id = price });


                }


            }

            if (Request.UrlReferrer.AbsoluteUri == "http://localhost:56667/home/index")
            {
                ViewBag.url = Request.UrlReferrer.Host;
                if (collection["sub-btn"] == "Check Price")
                {

                    var specie = collection["spe"];
                    var from = collection["startDate"];
                    var to = collection["endDate"];
                    var amount = collection["Amount"];
                    decimal price = TotalPrice(to, from, specie) * Convert.ToDecimal(amount);
                    double  total = Convert.ToDouble(amount);
                    return RedirectToAction("index", "Home", new { id = price });
                
                
                }

               
            }
           
                if (collection["sub-btn"] == "Check Price")
                {
                    var specie = collection["spe"];
                    var from = collection["startDate"];
                    var to = collection["endDate"];
                    var amount = collection["Amount"];
                    ViewBag.amount = Convert.ToDouble(amount);

                    //decimal pr = Convert.ToDecimal(spice) * total;


                    ViewBag.price = TotalPrice(to, from, specie) * Convert.ToDecimal(amount);
                    return View(reser);
                }
                if (collection["sub-btn"] == "Book")
                {
                    var specie = collection["spe"];
                    var from = collection["startDate"];
                    var to = collection["endDate"];
                    var amount = collection["Amount"];
                    ViewBag.from = from;
                    ViewBag.to = to;
                    ViewBag.specie = specie;
                    ViewBag.price =TotalPrice(to, from, specie) * Convert.ToDecimal(amount);
                    ViewBag.NumberOfDays =(Convert.ToDateTime(to) -Convert.ToDateTime(from)).Days;
                    Reservation res = new Reservation();
                    ViewBag.pricePerday = res.PriceList.PriceList[specie];
                    return View("Pet", reser);
                }

            
            return View(reser);
        }

         
 
        public ActionResult Pet()
        {

            Reservation reservation = new Reservation();
           

            return View(reservation);
        }
        [HttpPost]
        public ActionResult Pet([Bind(Include = "OrderItemID,Spiece,Petname,NumberOfDays,Arrival,Departure,PricePerDay,Customer,Invoice,OrderItem,OrderDate,CustomerID,FirstName,LastName,Address,City,Zip,Email,Phone,Totalprice")]Reservation reserv)
        {
           
            //Repository rep = new Repository();
            Reservation reservation = new Reservation();
            if (ModelState.IsValid)
            {
                if (Db.Customers.Any(c=>c.Email==reserv.Customer.Email))
                {
                    reserv.Customer = Db.Customers.Where(c => c.Email == reserv.Customer.Email).First();
                    Db.Entry(reserv.Customer).State = EntityState.Modified;
                    reserv.Invoice.Customer = reserv.Customer;
                }
                else
                {
                    Db.Customers.Add(reserv.Customer);

                }
               



                Db.Invoices.Add(reserv.Invoice);
                Db.OrderItems.Add(reserv.OrderItem);
                Db.SaveChanges();
                return RedirectToAction("ConfirmationPage", new {id=reserv.Invoice.InvoiceId});


            }
            ViewBag.from = reserv.OrderItem.Arrival;
            ViewBag.to = reserv.OrderItem.Departure;
            ViewBag.specie = reserv.OrderItem.Spiece;
            ViewBag.price = reserv.Invoice.Totalprice;
            ViewBag.pricePerday = reserv.OrderItem.PricePerDay;
            return View(reservation);

        }
        public ActionResult ConfirmationPage(int ?id)
        {
            if (id!=null)
            {
                var invoice = Db.Invoices.Where(c => c.InvoiceId == id);
                return View(invoice);
            }
            return View();
          
        }

        public ActionResult Prices(int?id)
        {
            if (id != null)
            {
                ViewBag.price = id;
            }
            ViewBag.amount = 1;
            Reservation reservation = new Reservation();
            return View(reservation);
        }
        [ChildActionOnly]
        public ActionResult ListOfprices()
        {
            PriceLists prices = new PriceLists();
            ViewBag.price = prices.PriceList;
            return View();

        }

       
      
    }
}