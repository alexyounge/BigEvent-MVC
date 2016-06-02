using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigEvent123.ViewModels;
using BigEvent123.Models;

namespace BigEvent123.Controllers
{
    public class OrderController : Controller
    {
        BigEventEntities storeDB = new BigEventEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderDetails(string username)
        {
            var orderModel = storeDB.Orders.Include("Orders").Where(g => g.Username == username);

            return View(orderModel);

        }

    }
}
