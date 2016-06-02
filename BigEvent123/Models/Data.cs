using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BigEvent123.Models
{
    public class Data : DropCreateDatabaseIfModelChanges<BigEventEntities>
    {
        protected override void Seed(BigEventEntities context)
        {
            var events = new List<Event>
            {
               new Event { EventName = "Men's 100m Sprint", EventType = "Running", SeatsRemaining = 500, Venue = "Wembley", EventDate = new DateTime(2008, 3, 12)},
            };


            new List<Tickets>
            {
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Adult Gold Ticket", Price = 100},
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Adult Silver Ticket", Price = 90},
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Adult Bronze Ticket", Price = 80},
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Child Gold Ticket", Price = 70},
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Child Silver Ticket", Price = 60},
                new Tickets {Event = events.Single(g => g.EventName == "Men's 100m Sprint"), TicketName = "Men's 100m Sprint Child Bronze Ticket", Price = 50},
            }.ForEach(a => context.Tickets.Add(a));
        }
    }
}