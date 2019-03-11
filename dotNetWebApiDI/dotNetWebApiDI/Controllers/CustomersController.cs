using dotNetWebApiDI.Core;
using dotNetWebApiDI.Models;
using dotNetWebApiDI.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace dotNetWebApiDI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IRepository<Customer> repository;

        public CustomersController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }
        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            var result = await this.repository.GetAllAsync();
            return this.Ok(result);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]Customer customer)
        {
            var result = await this.repository.AddAsync(customer);
            return this.Created("/api/customers", result);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}