using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDProject.Models
{
	public class Customer
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[Display(Name ="First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}