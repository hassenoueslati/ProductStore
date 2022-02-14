using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
  public class ManageProvider
    {
        public List<Provider> LsProviders { get; set; }
        public List<Provider> GetProviderByName(string name)
        {
           /* List<Provider> req =(from p in LsProviders
                                 where p.userName.Contains(name)
                                 select p).ToList(); */
            //meme requette avec lamda expression
            var req2 = LsProviders.Where(prov => prov.userName.Contains(name)).ToList();
            return req2;
        }


        public List<String> GetProviderEmailByName(string name)
        {
            /*List<String> req = (from p in LsProviders
                                  where p.userName.Contains(name)
                                  select p.email).ToList(); */
            return LsProviders.Where(prov => prov.userName.Contains(name)).Select(prov=> prov.email).ToList();
        }

        public void DisplayProviderEmailAndPasswordByName(string name)
        {
            /*var req = (from p in LsProviders
                                where p.userName.Contains(name)
                                select (p.email, p.Password)).ToList();
            foreach (var p in req)
            {
                Console.WriteLine(p);
            }*/
            foreach (var p in LsProviders.Where(prov => prov.userName.Contains(name)).Select(prov => (prov.email, prov.Password)))
            {
                Console.WriteLine(p);
            }
        }

        public Provider GetFirstProviderByName (string name)
        {
            var req = (from p in LsProviders
                                where p.userName.StartsWith(name)
                                select p).ToList();
            return req.First();

        }






    }
}
