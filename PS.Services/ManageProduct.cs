using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
   public class ManageProduct
    {
        public Func<Char, List<Product>> FindProduct;

        public Action<Category> ScanProduct;

        public List<Product> LsProduct { get; set; }

        public ManageProduct()
        {
            //FindProduct = Methode1;

            FindProduct = c =>
            {
                List<Product> Ls2Product = new List<Product>();
                foreach (Product p in LsProduct)
                {
                    if (p.Name.StartsWith(c))
                    {
                        Ls2Product.Add(p);
                    }
                }
                return Ls2Product;
            };
            ScanProduct = cat =>
            {
                foreach (Product p in LsProduct)
                {
                    if (p.Category.CategoryId == cat.CategoryId)
                    {
                        Console.WriteLine(p);
                    }
                }
            };

        }

        public List<Product> Methode1(char c)
        {
            List<Product> Ls2Product = new List<Product>();
            foreach(Product p in LsProduct)
            {
                if (p.Name.StartsWith("c"))
                {
                    Ls2Product.Add(p);
                }
            }
            return Ls2Product;
        }

       public IEnumerable<Chemical> Get5Chemical(double price)
        {
            var req = from p in LsProduct.OfType<Chemical>()
                      where p.Price > price
                      select p;
            return req.Take(5);
            //ignorer les 2 premiers produits
            // return req.Skip(2)

        }

        public Double GetAveragePrice()
        {
            return LsProduct.Average(p => p.Price);
        }

        public Double GetMaxPrice()
        {
            return LsProduct.Max(p => p.Price);
        }

        public int GetCountProduct()
        {
            return LsProduct.OfType<Chemical>().Count();
        }



    }
}
