using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigEvent123.Models;

namespace BigEvent123.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index(ContactModel newModel)
        {
         
            return View();
        }

        public ActionResult ContactConfirm()
        {

            return View();
        }

    }
}
