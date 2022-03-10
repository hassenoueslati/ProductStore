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

       public IEnumerable<Chemical> Get3Chemical(double price)
        {
            var req = from p in LsProduct.OfType<Chemical>()
                      where p.Price > price
                      select p;
            return req.Take(3);
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

        public IEnumerable<Chemical> GetChemicalCity()
        {
            /*var req = from c in LsProduct.OfType<Chemical>()
                      orderby c.City 
                      //descending  //<=  pour order descendent
                      select c;*/
            var req2 = LsProduct.OfType<Chemical>().OrderBy(ch => ch.MyAdress.City);
            return req2;
        }

        public IEnumerable <IGrouping<String,Chemical>> GetChemicalGroupByCity()
        {
            var req = from c in LsProduct.OfType<Chemical>()
                      orderby c.MyAdress.City
                      group c by c.MyAdress.City;
            var req2 = LsProduct.OfType<Chemical>().OrderBy(ch => ch.MyAdress.City).GroupBy(ch => ch.MyAdress.City);
            return req2;
        }



    }
}
