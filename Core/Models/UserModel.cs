using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;


namespace Core.Models
{
	public class UserModel
	{
		public WindowsIdentity WindowsIdentity { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public bool IsLoggedIn { get; set; }

		public DateTime LoginTime { get; set; }
	}
}
