﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigEvent123.Models
{
    public class Paypal
    {
        public Paypal()
        {
        }

        public string cmd { get; set; }
        public string business { get; set; }
        public string no_shipping { get; set; }
        public string @return { get; set; }
        public string cancel_return { get; set; }
        public string notify_url { get; set; }
        public string currency_code { get; set; }
        public string item_name { get; set; }
        public string amount { get; set; }
    }
}