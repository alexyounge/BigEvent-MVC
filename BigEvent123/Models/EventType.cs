using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigEvent123.Models
{
    public partial class EventType
    {
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public List<Event> Events { get; set; }
    }
}