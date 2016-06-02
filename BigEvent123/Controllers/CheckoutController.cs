using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using BigEvent123.Models;

namespace BigEvent123.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        BigEventEntities storeDB = new BigEventEntities();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/

        public ActionResult Payment()
        {
            return View();
        }


        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult Payment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            var eventId = new Event();
            var cart = ShoppingCart.GetCart(this.HttpContext);


            order.Username = User.Identity.Name;
            order.OrderDate = DateTime.Now;
            order.Total = cart.GetTotal();

            //Save Order
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            //Process the order
            cart.CreateOrder(order);

            return RedirectToAction("Complete", new { id = order.OrderId, orderId = order.OrderId });

        }


        [HttpPost]
        public ActionResult ReturnFromPayPal()
        {
            var order = new Order();
            TryUpdateModel(order);
            var eventId = new Event();
            var cart = ShoppingCart.GetCart(this.HttpContext);


            order.Username = User.Identity.Name;
            order.OrderDate = DateTime.Now;
            order.Total = cart.GetTotal();

            //Save Order
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            //Process the order
            cart.CreateOrder(order);

            return RedirectToAction("Complete", new { id = order.OrderId, orderId = order.OrderId });

        }


        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id, int orderId)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }



        public ActionResult PostToPayPal(string item, string amount)
        {
            BigEvent123.Models.Paypal paypal = new Models.Paypal();
            paypal.cmd = "_xclick";
            paypal.business = ConfigurationManager.AppSettings["BusinessAccountKey"];

            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["UseSandbox"]);
            if (useSandbox)
                ViewBag.actionURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            else
                ViewBag.actionURL = "https://www.paypal.com/cgi-bin/webscr";

            paypal.cancel_return = System.Configuration.ConfigurationManager.AppSettings["CancelURL"];
            paypal.@return = ConfigurationManager.AppSettings["ReturnURL"];
            paypal.notify_url = ConfigurationManager.AppSettings["NotifyURL"];

            paypal.currency_code = ConfigurationManager.AppSettings["CurrencyCode"];

            paypal.item_name = item;
            paypal.amount = amount;
            return View(paypal);
        }

    }
}
