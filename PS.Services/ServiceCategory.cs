using PS.Data;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class ServiceCategory : IServiceCategory
    {
        PSContext ctx = new PSContext();
        public void Add(Category c)
        {
            ctx.Categories.Add(c);
        }

        public IEnumerable<Category> GetAll()
        {
            return ctx.Categories;

        }

        public void Remove(Category c)
        {
            ctx.Categories.Remove(c);
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }
    }
}
