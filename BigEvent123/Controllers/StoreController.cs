using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigEvent123.Models;
using System.Globalization;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        BigEventEntities storeDB = new BigEventEntities();


        public ActionResult Index(string eventType, string eventVenue, string searchString, string searchDateString)
        {
            var eventList = new List<string>();

            var eventQry = from d in storeDB.Events
                           orderby d.EventType
                           select d.EventType;

            eventList.AddRange(eventQry.Distinct());
            ViewBag.eventType = new SelectList(eventList);

            var eventList2 = new List<string>();

            var eventQry2 = from d in storeDB.Events
                           orderby d.Venue
                           select d.Venue;

            eventList2.AddRange(eventQry2.Distinct());
            ViewBag.eventVenue = new SelectList(eventList2);

            var eventDates = from x in storeDB.Events
                             select x;

            var events = from m in storeDB.Events
                         select m;

           if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(eventType))
            {
                events = events.Where(x => x.EventType == eventType);
            }

            if (!String.IsNullOrEmpty(eventVenue))
            {
                events = events.Where(y => y.Venue.Contains(eventVenue));
            }


            if (!String.IsNullOrEmpty(searchDateString))
            {
                var date = DateTime.ParseExact(searchDateString, "MM/dd/yyyy", null).AddHours(15);
                events = events.Where(z => z.EventDate.Value == date);
            }

            return View(events);
        }




        public ActionResult Browse(string events)
        {

            var eventName = storeDB.Events.Single(g => g.EventName == events);
            if (eventName.SeatsRemaining <= 0)
            {
                eventName.SeatsRemaining = 0;
                return RedirectToAction("SoldOut", "Store");
            }
            else
            {
                var eventModel = storeDB.Events.Include("Tickets")
                    .Single(g => g.EventName == events);

                return View(eventModel);
            }
        }




        public ActionResult Details(int id)
        {
            var tickets = storeDB.Tickets.Find(id);

            return View(tickets);
        }


        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult TicketTypeMenu()
        {
            var ticketTypes = storeDB.Events.ToList();
            return PartialView(ticketTypes);
        }
    }
}