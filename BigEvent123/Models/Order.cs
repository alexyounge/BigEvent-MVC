using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace BigEvent123.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [DisplayName("Card Type")]
        [StringLength(160)]
        public string CardType { get; set; }
        [DisplayName("Card Number")]
        [StringLength(160)]
        public string CardNumber { get; set; }
        //[Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Card Security Number")]
        public string CardSecurityNumber { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<Order> Orders { get; set; }
        public virtual Event Events { get; set; }



    }
}