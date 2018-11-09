using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = context.CustomerDbSet.Include(c => c.MembershipType);
            return View(customers);
        }
        public ActionResult CustomerById(int id)
        {
            var customer = context.CustomerDbSet.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = context.CustomerDbSet.FirstOrDefault(c => c.Id == id);
            var customerFormViewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = context.MembershipTypeDbSet.ToList()
            };
            return View("CustomerForm", customerFormViewModel);
        }
        public ActionResult New()
        {
            var customerFormViewModel = new CustomerFormViewModel
            {
                MembershipTypes = context.MembershipTypeDbSet.ToList()
            };
            return View("CustomerForm", customerFormViewModel);
        }
        [HttpPost]
        public ActionResult Save([Bind(Exclude = "Id")]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var customerFormViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypeDbSet.ToList()
                };
                return View("CustomerForm", customerFormViewModel);
            }
            if (customer.Id == 0)
            {
                context.CustomerDbSet.Add(customer);
            }
            else
            {
                var editCustomer = context.CustomerDbSet.FirstOrDefault(c => c.Id == customer.Id);
                editCustomer.Name = customer.Name;
                editCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                editCustomer.MembershipTypeId = customer.MembershipTypeId;
                editCustomer.BirthDate = customer.BirthDate;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}