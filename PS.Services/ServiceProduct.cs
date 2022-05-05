using PS.Data;
using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    public class ServiceProduct : Service<Product>, IServiceProduct
    {
        public ServiceProduct(IUnitOfWork uow):base(uow)
        {

        }
        public IEnumerable<Product> FindMostExpensiveFiveProds()
        {
          return  GetMany().OrderByDescending(p => p.Price).Take(5);
        }

        public float UnavailableProductsPercentage()
        {
            int nbUnavailable = (from p in GetMany(p => p.Quantity == 0)
                                 select p).Count();
            int nbProds = GetMany().Count();
            return ((float)nbUnavailable / nbProds) * 100;
        }
        public IEnumerable<Product> GetProdsByClient(Client c)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            ServiceAchat sa = new ServiceAchat(uow);
            return sa.GetMany(a => a.ClientFK == c.CIN).Select(a => a.Product);
        }

        public void DeleteOldProds()
        {

            Delete(p => (DateTime.Now - p.DateProd).TotalDays > 365);
        }
    }
}
