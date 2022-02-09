using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Biological : Product
    {
        public string Herbs { get; set; }

        public void GetMyType()
        {
            base.GetMyType(); 
            Console.WriteLine("biologique");
        }
    }
}
