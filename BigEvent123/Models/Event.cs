using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BigEvent123.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }
        public string Venue { get; set; }
        public int SeatsRemaining { get; set; }
        public int ticketsSold { get; set; }
       // public decimal Price { get; set; }
       // public virtual EventType EventType { get; set; }
        public List<Tickets> Tickets { get; set; }
    }
}