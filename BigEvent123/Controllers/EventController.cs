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
    public class EventController : Controller
    {
        private BigEventEntities db = new BigEventEntities();

        //
        // GET: /Event/

        public ActionResult Index(string eventType, string searchString)
        {
            var eventList = new List<string>();

            var eventQry = from d in db.Events
                           orderby d.EventType
                           select d.EventType;

            eventList.AddRange(eventQry.Distinct());
            ViewBag.eventType = new SelectList(eventList);

            var events = from m in db.Events
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(eventType))
            {
                events = events.Where(x => x.EventType == eventType);
            }

            return View(events);
        }

        //
        // GET: /Event/Details/5

        public ViewResult Details(int id)
        {
            Event events = db.Events.Find(id);
            return View(events);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(events);
        }
        
        //
        // GET: /Event/Edit/5
 
        public ActionResult Edit(int id)
        {
            Event events = db.Events.Find(id);
            return View(events);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        //
        // GET: /Event/Delete/5
 
        public ActionResult Delete(int id)
        {
            Event events = db.Events.Find(id);
            return View(events);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}