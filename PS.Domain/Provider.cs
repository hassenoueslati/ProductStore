using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Provider : Concept
    {
        [Key]
        public int ProviderCode { get; set; }
        //public string ConfirmPassword { get; set; }
        private string confirmPassword;

        public DateTime dateCreated { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }

        public bool isApproved { get; set; }

        // public string Password { get; set; }

        private string password;

        public string userName { get; set; }

        public virtual List<Product> Products { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password is required")]
        [MinLength(10)]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 20 || value.Length < 5)
                {
                    Console.WriteLine("password doit etre entre 5 et 20 caractéres");
                }
                else password = value;

            }
        }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        [NotMapped] 
        [Compare("Password", ErrorMessage = "ConfirmPassword must be equal to Password")]
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                if (value == Password)
                {
                    confirmPassword = value;

                }
                else Console.WriteLine("ConfirmPassword doit etre identique a Password");

            }
        }

        public static void SetIsApproved(Provider pr)
        {
            pr.isApproved = pr.Password.Equals(pr.ConfirmPassword);
        }
        public static void SetIsApproved(string pass, string confirmpass, bool isApproved)
        {
            isApproved = pass.Equals(confirmpass);
        }
        public static void Calculer(int a, int b, ref int c)
        {
            c = a + b;
        }


        /* public bool Login(String username, String password)
         {
             return (userName == username && Password == password);


         }
         public bool Login(String username, String password, String Email)
         {
             return (userName.Equals(username) && Password.Equals(password) && email.Equals(Email));

         }*/
        public bool Login(String username, String password, String Email=null)
        {
            if (Email == null)
                return (userName.Equals(username) && Password.Equals(password));
            else
                return (userName.Equals(username) && Password.Equals(password) && email.Equals(Email));

        }

        public override void GetDetails()
        {
            Console.WriteLine("Nom de provider : "+userName);
            /*for (int i=0; i<Products.Count; i++)
            {
                Console.WriteLine(Products[i]);
            }*/
            foreach(Product p in Products)
            {
                Console.WriteLine(p);
            }
        }
        public void GetProducts (string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Name":
                    foreach(Product p in Products)
                    {
                        if(p.Name == filterValue)
                        {
                            Console.WriteLine(p);
                        }
                    }

                    break;
                case "DateProd":
                    foreach (Product p in Products)
                    {
                        if (p.DateProd == DateTime.Parse (filterValue))
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;
                case "Price":
                    foreach (Product p in Products)
                    {
                        if (p.Price == Double.Parse(filterValue))
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;
            }
        }






    }
        
}
