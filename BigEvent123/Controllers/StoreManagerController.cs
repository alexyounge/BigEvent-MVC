using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigEvent123.Models;

namespace BigEvent123.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private BigEventEntities db = new BigEventEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var tickets = db.Tickets.Include(e => e.Event);
            return View(tickets.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            return View(tickets);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Tickets tickets)
        {
            if (ModelState.IsValid)     
            {
                db.Tickets.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", tickets.EventId);
            return View(tickets);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", tickets.EventId);
            return View(tickets);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", tickets.EventId);
            return View(tickets);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            return View(tickets);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tickets tickets = db.Tickets.Find(id);
            db.Tickets.Remove(tickets);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        //
        // GET: /StoreManager/Create

        public ActionResult CreateEvent()
        {
           // ViewBag.EventTypeId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        }


        public ActionResult Stats()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        } 
    }
}