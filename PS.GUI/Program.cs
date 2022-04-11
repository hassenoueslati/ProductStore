using PS.Data;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;

namespace PS.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            Product p2 = new Product()
            {
                Name = "hassen",
                Quantity = 20

            };

            p.Name = "fraise";
            //p.DateProd = new DateTime(2020, 01, 31);
            p.DateProd = DateTime.Now;

            //cw 2 tabulation 
            Console.WriteLine(p.Name);
            Console.WriteLine(p.DateProd);

            Console.WriteLine(p2);

            Provider pr = new Provider() {
                Password = "hassen" ,
                ConfirmPassword="hassen",
                email = "hassen@esprit.tn",
                userName = "hassen"
               
            };

            Console.WriteLine(pr.isApproved);
            //Console.WriteLine(pr.Password1);
            //Console.WriteLine(pr.ConfirmPassword1);
            Console.WriteLine("///////////");
            //passage par ref
            Provider.SetIsApproved(pr);
            //Console.WriteLine(pr.IsApproved);
            Console.WriteLine("///////////");

            //passage par valeur
            //Provider.SetIsApproved(pr.Password, pr.ConfirmPassword, pr.isApproved);

            Console.WriteLine(pr.isApproved);

            int i = 5;
            int j = 3;
            int k = 2;
            Console.WriteLine("///////////");
            Provider.Calculer(i, j, ref k);
            Console.WriteLine(k);
            Console.WriteLine("///////////");
            Console.WriteLine(pr.Login("hassen","hassen","hassen@esprit.tn"));
            Console.WriteLine("///////////");
            Console.WriteLine(pr.Login("hassen", "hassen"));

            Product prod = new Product();
            Chemical chem = new Chemical() {
                Name="Chemicall",
                Price=50
                
            };
            chem.MyAdress.City = "beb jdid";
            Chemical chem1 = new Chemical()
            {
                Name = "Chemicall",
                Price = 150
            };
            chem1.MyAdress.City = "manchester";
            Chemical chem2 = new Chemical()
            {
                Name = "Chemicall",
                Price = 20
               
            };
            chem2.MyAdress.City = "milon";
            Chemical chem3 = new Chemical()
            {
                Name = "Chemicall",
                Price = 50
             
            };
            chem3.MyAdress.City = "barcelone";
            Product bio = new Biological();

            prod.GetMyType();
            chem.GetMyType();
            bio.GetMyType();

            Console.WriteLine("///////////");
            Product p3 = new Product()
            {
                Name = "lait",
                Quantity = 20,
                Price = 1350,
                Description = "lait naturel"

            };
            Product p4 = new Product()
            {
                Name = "yaourt",
                Quantity = 25,
                Price = 450,
                DateProd = DateTime.Now,
                Description = "yaourt naturel"

            };

            Product p5 = new Product()
            {
                Name = "yaourt danette",
                Quantity = 25,
                DateProd = DateTime.Now,
                Price = 600,
                Description = "yaourt naturel"

            };

            //Collection 

            List<Product> products = new List<Product>
            {
                p3,p4,p5,
            };

            products.Add(p5);
            products.Add(p4);

            pr.Products = products;
            Console.WriteLine("\n");
            pr.GetDetails();

            Console.WriteLine("Get Products");
            pr.GetProducts("Price","600");

            Console.WriteLine("///////////deleguer////////////");

            ManageProduct mp = new ManageProduct();
            mp.LsProduct = products;
            foreach(Product pp in mp.FindProduct('l'))
            {
                Console.WriteLine(pp);
            }

            Console.WriteLine("///////////test les methodes de la classe manage product////////////");

            products.Add(chem);
            products.Add(chem1);
            products.Add(chem2);
            products.Add(chem3);

            foreach (Chemical ch in mp.Get3Chemical(10))
            {
                Console.WriteLine(ch);
            }
            Console.WriteLine("avg Price: "+ mp.GetAveragePrice());
            Console.WriteLine("Nb Product: " + mp.GetCountProduct());
            Console.WriteLine("max Price: " + mp.GetMaxPrice());
            Console.WriteLine("///////////test order by city////////////");

            foreach (Chemical ch in mp.GetChemicalCity())
            {
                Console.WriteLine(ch);
            }


            Console.WriteLine("///////////test group by city////////////");
            
            foreach(var g in mp.GetChemicalGroupByCity())
            {
                Console.WriteLine(g.Key);
                foreach(Chemical chm in g)
                {
                    Console.WriteLine(chm);
                }
                
            }


            Console.WriteLine("///////////methode d'extension////////////");

            String s = "bonjour";
            
            Console.WriteLine(s.Upper());

            Console.WriteLine("///////////insertion dans la base de donnee////////////");
            //PSContext ctx = new PSContext();
            ServiceProduct sp = new ServiceProduct();
            ServiceCategory sc = new ServiceCategory();
            sp.Add(p4);
            sp.Add(chem);
            Category C4 = new Category
            {
                Name = "Produit frais"
            };
            p4.Category = C4;
            sc.Add(C4);
            foreach(Product pro in sp.GetAll())
            {
                Console.WriteLine("Product Name :" + pro.Name + " Category :" + pro.Category.Name);
            }

            sp.Commit();
        }
    }
}
