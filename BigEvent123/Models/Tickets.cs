using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigEvent123.Models
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public int EventId { get; set; }
        public string TicketName { get; set; }
        public decimal Price { get; set; }
        public virtual Event Event { get; set; }
    }
}