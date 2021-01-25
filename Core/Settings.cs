using Microsoft.Extensions.Configuration;
using System.Security.Principal;
using System.Security;
using System;
using Core.Models;
using System.Collections.Generic;

namespace Core
{
	public class Settings
	{
		private readonly IConfiguration config;
		private string connectionStringName { get; set; } = "BasicLogin";
		public WindowsIdentity WindowsIdentity { get; set; }

		private List<UserModel> activeUsers { get; set; }

		public Settings(IConfiguration configuration)
		{
			config = configuration;
			activeUsers = new List<UserModel>();
		}

		public int FindUser(string username)
		{
			return activeUsers.FindIndex(user => user.Name == username);
		}

		public void LoginUser(WindowsIdentity windowsId)
		{
			WindowsIdentity = windowsId;
		}

		public void LoginUser(string name, string password, DateTime loginTime)
		{
			activeUsers.Add(new UserModel
			{
				Name = name,
				Password = password,
				IsLoggedIn = true,
				LoginTime = loginTime
			});
		}

		public void LogoutUser(string username)
		{
			var index = activeUsers.FindIndex(user => user.Name == username);

			if (index != -1)
			{
				activeUsers.RemoveAt(index);
			}
		}

		public bool IsUserActiveOnAnotherDevice(string username)
		{
			return FindUser(username) >= 0;
		}

		public WindowsIdentity GetWindowsIdentity()
		{
			return WindowsIdentity;
		}

		public string GetConnectionString(string uid, string  pwsd)
		{
			string connectionString = config.GetConnectionString(connectionStringName);

			connectionString = connectionString.Replace("placeholderName", uid);
			connectionString = connectionString.Replace("placeholderPass", pwsd);

			return connectionString;
		}

		public string GetWindowsConnectionString()
		{
			return config.GetConnectionString(connectionStringName);
		}

		public bool UseWindowsAuthentication()
		{
			return connectionStringName == "Default";
		}
	}
}
