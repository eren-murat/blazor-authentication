using Microsoft.Extensions.Configuration;
using System.Security.Principal;
using System.Security;
using System;
using Core.Models;

namespace Core
{
	public class Settings
	{
		private readonly IConfiguration config;
		private string connectionStringName { get; set; } = "BasicLogin";
		private WindowsIdentity windowsIdentity { get; set; }
		private UserModel user { get; set; }

		public bool isLoggedIn = false;

		public Settings(IConfiguration configuration)
		{
			config = configuration;
			user = new UserModel();
		}

		public string GetUserName()
		{
			return user.Name;
		}

		public void SetUserName(string name)
		{
			user.Name = name;
		}

		public void SetPassword(string password)
		{
			user.Password = password;
		}

		public DateTime GetLoginTime()
		{
			return user.LoginTime;
		}

		public void SetLoginTime(DateTime time)
		{
			user.LoginTime = time;
		}

		public string GetConnectionString()
		{
			string connectionString = config.GetConnectionString(connectionStringName);

			Console.WriteLine(connectionString);

			if (connectionStringName == "BasicLogin")
			{
				Console.WriteLine(user.Name);
				Console.WriteLine(user.Password);
				connectionString = connectionString.Replace("placeholderName", user.Name);
				connectionString = connectionString.Replace("placeholderPass", user.Password);
			}

			Console.WriteLine(connectionString);

			return connectionString;
		}

		public WindowsIdentity GetWindowsIdentity()
		{
			return windowsIdentity;
		}

		public void SetWindowsIdentity(WindowsIdentity newWindowsIdentity)
		{
			windowsIdentity = newWindowsIdentity;
		}

		public bool UseWindowsAuthentication()
		{
			if (connectionStringName == "Default")
			{
				return true;
			}

			return false;
		}
	}
}
