using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BigEvent123.Models
{
    public class BigEventEntities : DbContext
    {
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }        
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}

