using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		// GET: Customers
		public ActionResult Index()
		{
			var customers = GetCustomers();
			return View(customers);
		}

		// GET: Customers/Details/Id
		public ActionResult Details(int id)
		{
			var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			var customer1 = new Customer() { Id = 1, Name = "John Smith" };
			var customer2 = new Customer() { Id = 2, Name = "Mary Williams" };
			var customers = new List<Customer>();
			customers.Add(customer1);
			customers.Add(customer2);
			return customers;
		}
	}
}