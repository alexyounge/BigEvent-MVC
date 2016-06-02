using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BigEvent123.Models
{
    public class ManagementStats
    {
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public virtual Event ticketsSold { get; set; }
    }

    public class ManagementStatsContext : DbContext
    {
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public virtual Event ticketsSold { get; set; }
    }
}