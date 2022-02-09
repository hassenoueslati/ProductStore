using PS.Domain;
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
            Chemical chem = new Chemical();
            Biological bio = new Biological();

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





        }
    }
}
