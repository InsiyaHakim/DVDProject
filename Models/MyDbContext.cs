using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDProject.Models
{
	public class MyDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

	}
}