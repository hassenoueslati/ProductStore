﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    //sealed pour bloquer l'heritage
    public class Product
    {
  
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime DateProd { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public Category Category { get; set; }

        public List<Provider> Providers { get; set; }

        public override string ToString()
        {
            return "Name : "+ Name + " Quantity : " + Quantity + "Price :" + Price + "DateProd : " + DateProd;
        }
        public virtual void GetMyType()
        {
            Console.Write("Je suis un produit");
        }
    }
}
