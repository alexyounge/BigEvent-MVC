using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BigEvent123.ViewModels
{
    public class ManagementStats
    {
        public DateTime? EventDate { get; set; }

        public int ticketsSold { get; set; }
    }
}