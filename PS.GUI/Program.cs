using PS.Domain;
using System;

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
                ConfirmPassword="hassen"
            };

            Console.WriteLine(pr.isApproved);
            //Console.WriteLine(pr.Password1);
            //Console.WriteLine(pr.ConfirmPassword1);

            //passage par ref
            //Provider.SetIsApproved(pr);
            //Console.WriteLine(pr.IsApproved);

            
            //passage par valeur
            Provider.SetIsApproved(pr.Password, pr.ConfirmPassword, pr.isApproved);

            Console.WriteLine(pr.isApproved);





        }
    }
}
