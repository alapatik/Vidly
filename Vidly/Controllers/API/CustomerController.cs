using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return context.CustomerDbSet.Select(Mapper.Map<Customer, CustomerDto>);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.CustomerDbSet.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.CustomerDbSet.Add(customer);
            context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = context.CustomerDbSet.FirstOrDefault(c => c.Id == id);
            if (customerDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerDb);
            context.SaveChanges();
            return Ok(customerDto);
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = context.CustomerDbSet.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.CustomerDbSet.Remove(customer);
            context.SaveChanges();
        }
    }
}
