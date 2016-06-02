using System.Linq;
using System.Web.Mvc;
using BigEvent123.Models;
using BigEvent123.ViewModels;

namespace BigEvent123.Controllers
{
    public class ShoppingCartController : Controller
    {
        BigEventEntities storeDB = new BigEventEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }


        public ActionResult ExceedingQuantity()
        {
            return View();
        }


        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id, int eventid)
        {

            //  var eventName = storeDB.Events.Single(a => a.EventId == eventid);
            //  --eventName.SeatsRemaining;

            // Retrieve the album from the database
            var addedTicket = storeDB.Tickets
                .Single(tickets => tickets.TicketsId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            if (cart.GetCount() >= 15)
            {
                return RedirectToAction("ExceedingQuantity");
            }
            else
            {
                cart.AddToCart(addedTicket);
                storeDB.SaveChanges();


                // Go back to the main store page for more shopping
                return RedirectToAction("Index");
            }

        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            //   var eventName = storeDB.Events.FirstOrDefault(a => a.EventId == eventid);
            // ++eventName.SeatsRemaining;

            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);


            // Get the name of the album to display confirmation
            string ticketName = storeDB.Carts
                .Single(item => item.RecordId == id).Ticket.TicketName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = ticketName +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            //storeDB.SaveChanges();
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            ViewData["CartTotal"] = cart.GetTotal();
            return PartialView("CartSummary");
        }
    }
}