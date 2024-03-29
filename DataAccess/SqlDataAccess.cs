﻿using Dapper;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DataAccess
{
	public class SqlDataAccess : ISqlDataAccess
	{
		private readonly IConfiguration _config;

		public string ConnectionStringName { get; set; } = "Default";

		public SqlDataAccess(IConfiguration config)
		{
			_config = config;
		}

		public async Task<List<int>> GetComboboxList(WindowsIdentity windowsIdentity, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<List<int>>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				IEnumerable<int> elems = new List<int>();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					var parameters = new DynamicParameters();
					parameters.Add("ID", id, DbType.Int32);

					elems = await connection.QueryAsync<int>("Selectie_RecordSource", parameters, commandType: CommandType.StoredProcedure);
				}

				return (List<int>)elems;
			});
		}

		public async Task<Properties> GetControlPropertyByID(WindowsIdentity windowsIdentity, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<Properties>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				Properties properties = new Properties();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM ProprietatiControl WHERE ID = @ID";

					properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
				}

				return properties;
			});
		}

		public async Task<ObjModel> GetDataById(WindowsIdentity windowsIdentity, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<ObjModel>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				ObjModel objectResult = new ObjModel();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM Obiecte WHERE ID = @ID";

					objectResult = await connection.QueryFirstOrDefaultAsync<ObjModel>(sql, new { id });
				}

				return objectResult;
			});
		}

		public async Task<Properties> GetLabelPropertyByID(WindowsIdentity windowsIdentity, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<Properties>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				Properties properties = new Properties();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM ProprietatiLabel WHERE ID = @ID";

					properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
				}

				return properties;
			});
		}

		public async Task<List<ObjModel>> LoadData(WindowsIdentity windowsIdentity)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<List<ObjModel>>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				IEnumerable<ObjModel> objects;

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM Obiecte WHERE grupare=574252 ORDER BY ordine ASC";

					objects = await connection.QueryAsync<ObjModel>(sql, new { });
				}

				return (List<ObjModel>)objects;
			});


		}

		public void UpdateControlProperty(WindowsIdentity windowsIdentity, Properties properties, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			WindowsIdentity.RunImpersonated(windowsIdentityToken, () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);

				try
				{
					using (var connection = new SqlConnection(connectionString))
					{
						const string sql = @"UPDATE ProprietatiControl SET TopOffset=@TopOffset, LeftOffset=@LeftOffset, Width=@Width, Height=@Height, Color=@Color, Border=@Border, FontSize=@FontSize WHERE (ID=@ID)";

						using (var command = new SqlCommand(sql, connection))
						{
							command.Parameters.AddWithValue("@ID", id);
							command.Parameters.AddWithValue("@TopOffset", properties.TopOffset);
							command.Parameters.AddWithValue("@LeftOffset", properties.LeftOffset);
							command.Parameters.AddWithValue("@Width", properties.Width);
							command.Parameters.AddWithValue("@Height", properties.Height);
							command.Parameters.AddWithValue("@Color", properties.Color);
							command.Parameters.AddWithValue("@Border", properties.Border);
							command.Parameters.AddWithValue("@FontSize", properties.FontSize);

							connection.Open();
							command.ExecuteNonQuery();
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Failed to update: " + e.Message);
				}
			});
		}

		public void UpdateLabelProperty(WindowsIdentity windowsIdentity, Properties properties, int id)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			WindowsIdentity.RunImpersonated(windowsIdentityToken, () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);

				try
				{
					using (var connection = new SqlConnection(connectionString))
					{
						const string sql = @"UPDATE ProprietatiLabel SET TopOffset=@TopOffset, LeftOffset=@LeftOffset, Width=@Width, Height=@Height, Color=@Color, Border=@Border, FontSize=@FontSize WHERE (ID=@ID)";

						using (var command = new SqlCommand(sql, connection))
						{
							command.Parameters.AddWithValue("@ID", id);
							command.Parameters.AddWithValue("@TopOffset", properties.TopOffset);
							command.Parameters.AddWithValue("@LeftOffset", properties.LeftOffset);
							command.Parameters.AddWithValue("@Width", properties.Width);
							command.Parameters.AddWithValue("@Height", properties.Height);
							command.Parameters.AddWithValue("@Color", properties.Color);
							command.Parameters.AddWithValue("@Border", properties.Border);
							command.Parameters.AddWithValue("@FontSize", properties.FontSize);

							connection.Open();
							command.ExecuteNonQuery();

							Console.WriteLine("Update Label: " + properties.Width);
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Failed to update: " + e.Message);
				}
			});
		}

		public async Task<bool> UpdateData(WindowsIdentity windowsIdentity, ObjModel objModel)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			await WindowsIdentity.RunImpersonated(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = @"UPDATE Obiecte SET Grupare=@Grupare, Tip=@Tip, Activ=@Activ, Ordine=@Ordine, " +
						"Simbol=@Simbol, Data=@Data, Valoare=@Valoare, Referinta=@Referinta WHERE (ID=@ID)";

					await connection.ExecuteAsync(sql, new
					{
						objModel.Grupare,
						objModel.Tip,
						objModel.Activ,
						objModel.Ordine,
						objModel.Simbol,
						objModel.Data,
						objModel.Valoare,
						objModel.Referinta
					});
				}
			});

			return true;
		}

		public async Task<UserModel> GetSqlUsername(WindowsIdentity windowsIdentity)
		{
			var windowsIdentityToken = windowsIdentity.AccessToken;

			return await RunImpersonatedAsync<UserModel>(windowsIdentityToken, async () =>
			{
				string connectionString = _config.GetConnectionString(ConnectionStringName);
				IEnumerable<UserModel> users;

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT SUSER_NAME() as Username";
					users = await connection.QueryAsync<UserModel>(sql, new { });
				}

				return users.ToList().ElementAt(0);
			});

			// not scalable
			/*
			var credentials = new UserCredentials("PS", "WFLservice", "@prosoft1");
			Impersonation.RunAsUser(credentials, LogonType.Interactive, () =>
			{
				mockUser.Username = WindowsIdentity.GetCurrent().Name;

				Console.WriteLine(mockUser.Username);
			});
			*/
		}

		public static Task<T> RunImpersonatedAsync<T>(SafeAccessTokenHandle safeAccessTokenHandle, Func<Task<T>> func) =>
			WindowsIdentity.RunImpersonated(safeAccessTokenHandle, func);
	}
}
