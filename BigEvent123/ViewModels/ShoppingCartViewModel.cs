using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigEvent123.Models;   

namespace BigEvent123.ViewModels
{
    public class ShoppingCartViewModel
    {

        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public virtual Event Event { get; set; }

    }
}
