using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Chemical : Product
    {
        public string City { get; set; }

        public string LabName { get; set; }

        public string StreetAddress { get; set; }

        public void GetMyType()
        {
            base.GetMyType();
            Console.WriteLine("chemical");
        }
    }
    
}
