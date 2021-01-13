using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class UserModel
	{
		public string Username { get; set; }

		public UserModel()
		{
			Username = "debug";
		}
	}
}
