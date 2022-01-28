using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public DateTime DateProd { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        
    }
}
