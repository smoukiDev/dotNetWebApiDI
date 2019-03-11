using dotNetWebApiDI.Core;
using dotNetWebApiDI.Models;
using dotNetWebApiDI.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace dotNetWebApiDI.Persistance
{
    public class CustomesRepository : IRepository<Customer>
    {
        private readonly ShopDbContext context;
        public CustomesRepository()
        {
            this.context = new ShopDbContext();
        }
        public async Task<Customer> AddAsync(Customer item)
        {
            var result = this.context.Customers.Add(item);
            await this.context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var result = this.context.Customers.AsNoTracking();
            return await result.ToListAsync();
        }
    }
}