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
		private UserModel currentUser { get; set; }

		public Settings(IConfiguration configuration)
		{
			config = configuration;
			currentUser = new UserModel();
		}

		public void LoginUser(WindowsIdentity windowsId)
		{
			currentUser.WindowsIdentity = windowsId;
			currentUser.Name = windowsId.Name;
			currentUser.IsLoggedIn = true;
		}

		public void LoginUser(string name, string password, DateTime loginTime)
		{
			currentUser = new UserModel
			{
				Name = name,
				Password = password,
				IsLoggedIn = true,
				LoginTime = loginTime
			};
		}

		public void LogoutUser()
		{
			currentUser = new UserModel
			{
				IsLoggedIn = false
			};
		}

		public bool IsUserLoggedIn()
		{
			if (UseWindowsAuthentication())
			{
				return currentUser.IsLoggedIn;
			}
			else
			{
				return (currentUser.IsLoggedIn && (DateTime.Now - currentUser.LoginTime).Hours < 8);
			}
		}

		public string GetUserName()
		{
			return currentUser.Name;
		}

		public DateTime GetLoginTime()
		{
			return currentUser.LoginTime;
		}

		public WindowsIdentity GetWindowsIdentity()
		{
			return currentUser.WindowsIdentity;
		}

		public string GetConnectionString()
		{
			string connectionString = config.GetConnectionString(connectionStringName);

			if (connectionStringName == "BasicLogin")
			{
				connectionString = connectionString.Replace("placeholderName", currentUser.Name);
				connectionString = connectionString.Replace("placeholderPass", currentUser.Password);
			}

			return connectionString;
		}

		public string GetTestConnectionString(string uid, string  pwsd)
		{
			string connectionString = config.GetConnectionString(connectionStringName);

			if (connectionStringName == "BasicLogin")
			{
				connectionString = connectionString.Replace("placeholderName", uid);
				connectionString = connectionString.Replace("placeholderPass", pwsd);
			}

			return connectionString;
		}

		public bool UseWindowsAuthentication()
		{
			return connectionStringName == "Default";
		}
	}
}
