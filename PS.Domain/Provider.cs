using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Provider
    {
        public int id { get; set; }
        //public string ConfirmPassword { get; set; }
        private string confirmPassword;

        public DateTime dateCreated { get; set; }

        public string email { get; set; }

        public bool isApproved { get; set; }

        // public string Password { get; set; }

        private string password ;

        public string userName { get; set; }
      
        public List<Product> Products { get; set; }

        public string Password
        {
            get{
                return password;
            }
            set{
                if (value.Length > 20 || value.Length < 5)
                {
                    Console.WriteLine("password doit etre entre 5 et 20 caractéres");
                }
                else password = value;

            }
        }

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

    }
}
