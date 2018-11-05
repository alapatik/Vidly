using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
    }
}