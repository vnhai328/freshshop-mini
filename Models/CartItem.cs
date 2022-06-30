using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjFresh.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}