using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public interface IServiceProduct
    {
        void Add(Product p);
        void Remove(Product p);
        IEnumerable<Product> GetAll();
        void Commit();

    }
}
