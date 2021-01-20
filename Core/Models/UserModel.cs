using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public DateTime LoginTime { get; set; }
	}
}
