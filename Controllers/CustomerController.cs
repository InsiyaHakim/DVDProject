using DVDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DVDProject.Controllers
{
	public class CustomerController : Controller
	{

		private MyDbContext myDbContext;
		public CustomerController()
		{
			myDbContext = new MyDbContext();
		}

		public ActionResult Index()
		{
			return View();
		}

		[Route("CreateCustomer")]
		public ActionResult CreateCustomer(Customer customer)
		{
			if (ModelState.IsValid) {
				if(myDbContext.Customers.Any(o => o.ID == customer.ID))
				{
					var customerInDb = myDbContext.Customers.FirstOrDefault(o => o.ID == customer.ID);

					customerInDb.FirstName = customer.FirstName;
					customerInDb.LastName = customer.LastName;
					customerInDb.Email = customer.Email;
				}
				else
				{
					if (myDbContext.Customers.Any(o => o.Email == customer.Email))
					{
						ModelState.AddModelError("Email", "Please try another Email");
						return View("Index");
					}
					myDbContext.Customers.Add(customer);
				}
				myDbContext.SaveChanges();

				return RedirectToAction("ListOfCustomer");
			}

			return View("Index");
		}
		public ActionResult ListOfCustomer()
		{
			var customer = myDbContext.Customers.ToList();
			return View(customer);
		}

		public ActionResult EditCustomer(int id)
		{
			var customer = myDbContext.Customers.FirstOrDefault(o => o.ID == id);

			return View("Index", customer);
		}

		
	}
}