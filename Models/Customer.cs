using System;
using System.Collections.Generic;
using System.Text;

namespace LLIntroducingEntityFramework.Models
{
	public class Customer
	{

		public int Id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
#nullable enable
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
#nullable disable
		public ICollection<Order> Orders { get; set; }
	}
}
