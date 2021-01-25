using Dapper;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Core;

namespace DataAccess
{
	public class SqlDataAccess : ISqlDataAccess
	{
		private readonly Settings _settings;

		public SqlDataAccess(Settings settings)
		{
			_settings = settings;
		}

		public bool VerifySqlConnection(string uid, string pswd)
		{
			string connectionString = _settings.GetConnectionString(uid, pswd);

			SqlConnection connection = new SqlConnection(connectionString);

			try
			{
				connection.Open();
			} catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return connection.State == ConnectionState.Open;
		}

		public async Task<List<int>> GetComboboxList(string uid, string pswd, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<List<int>>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
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
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				IEnumerable<int> elems = new List<int>();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					var parameters = new DynamicParameters();
					parameters.Add("ID", id, DbType.Int32);

					elems = await connection.QueryAsync<int>("Selectie_RecordSource", parameters, commandType: CommandType.StoredProcedure);
				}

				return (List<int>)elems;
			}

		}

		public async Task<Properties> GetControlPropertyByID(string uid, string pswd, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<Properties>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
					Properties properties = new Properties();

					using (IDbConnection connection = new SqlConnection(connectionString))
					{
						const string sql = "SELECT * FROM ProprietatiControl WHERE ID = @ID";

						properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
					}

					return properties;
				});
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				Properties properties = new Properties();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM ProprietatiControl WHERE ID = @ID";

					properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
				}

				return properties;
			}
		}

		public async Task<ObjModel> GetDataById(string uid, string pswd, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<ObjModel>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
					ObjModel objectResult = new ObjModel();

					using (IDbConnection connection = new SqlConnection(connectionString))
					{
						const string sql = "SELECT * FROM Obiecte WHERE ID = @ID";

						objectResult = await connection.QueryFirstOrDefaultAsync<ObjModel>(sql, new { id });
					}

					return objectResult;
				});
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				ObjModel objectResult = new ObjModel();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM Obiecte WHERE ID = @ID";

					objectResult = await connection.QueryFirstOrDefaultAsync<ObjModel>(sql, new { id });
				}

				return objectResult;
			}

		}

		public async Task<Properties> GetLabelPropertyByID(string uid, string pswd, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<Properties>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
					Properties properties = new Properties();

					using (IDbConnection connection = new SqlConnection(connectionString))
					{
						const string sql = "SELECT * FROM ProprietatiLabel WHERE ID = @ID";

						properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
					}

					return properties;
				});
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				Properties properties = new Properties();

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM ProprietatiLabel WHERE ID = @ID";

					properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
				}

				return properties;
			}
			
		}

		public async Task<List<ObjModel>> LoadData(string uid, string pswd)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<List<ObjModel>>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
					IEnumerable<ObjModel> objects;

					using (IDbConnection connection = new SqlConnection(connectionString))
					{
						const string sql = "SELECT * FROM Obiecte WHERE grupare=574252 ORDER BY ordine ASC";

						objects = await connection.QueryAsync<ObjModel>(sql, new { });
					}

					return (List<ObjModel>)objects;
				});
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				IEnumerable<ObjModel> objects;

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT * FROM Obiecte WHERE grupare=574252 ORDER BY ordine ASC";

					objects = await connection.QueryAsync<ObjModel>(sql, new { });
				}

				return (List<ObjModel>)objects;
			}
		}

		public void UpdateControlProperty(string uid, string pswd, Properties properties, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				WindowsIdentity.RunImpersonated(windowsIdentityToken, () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();

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
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);

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
			}
			
		}

		public void UpdateLabelProperty(string uid, string pswd, Properties properties, int id)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				WindowsIdentity.RunImpersonated(windowsIdentityToken, () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();

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
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);

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
			}
			
		}

		public async Task<bool> UpdateData(string uid, string pswd, ObjModel objModel)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				await WindowsIdentity.RunImpersonated(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();

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
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);

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
			}

			return true;
		}

		public async Task<UserSqlTesting> GetSqlUsername(string uid, string pswd)
		{
			if (_settings.UseWindowsAuthentication())
			{
				var windowsIdentityToken = _settings.GetWindowsIdentity().AccessToken;

				return await RunImpersonatedAsync<UserSqlTesting>(windowsIdentityToken, async () =>
				{
					string connectionString = _settings.GetWindowsConnectionString();
					IEnumerable<UserSqlTesting> users;

					using (IDbConnection connection = new SqlConnection(connectionString))
					{
						const string sql = "SELECT SUSER_NAME() as Username";
						users = await connection.QueryAsync<UserSqlTesting>(sql, new { });
					}

					return users.ToList().ElementAt(0);
				});
			}
			else
			{
				string connectionString = _settings.GetConnectionString(uid, pswd);
				IEnumerable<UserSqlTesting> users;

				using (IDbConnection connection = new SqlConnection(connectionString))
				{
					const string sql = "SELECT SUSER_NAME() as Username";
					users = await connection.QueryAsync<UserSqlTesting>(sql, new { });
				}

				return users.ToList().ElementAt(0);
			}
		}

		public static Task<T> RunImpersonatedAsync<T>(SafeAccessTokenHandle safeAccessTokenHandle, Func<Task<T>> func) =>
			WindowsIdentity.RunImpersonated(safeAccessTokenHandle, func);
	}
}
