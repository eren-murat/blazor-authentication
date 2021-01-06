using Dapper;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

		public async Task<List<int>> GetComboboxList(int id)
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName);
			IEnumerable<int> elems = new List<int>();

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				var parameters = new DynamicParameters();
				parameters.Add("ID", id, DbType.Int32);

				elems = await connection.QueryAsync<int>("Selectie_RecordSource", parameters, commandType: CommandType.StoredProcedure);
			}

			return elems.ToList();
		}

		public async Task<Properties> GetControlPropertyByID(int id)
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName);
			Properties properties = new Properties();

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				const string sql = "SELECT * FROM ProprietatiControl WHERE ID = @ID";

				properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
			}

			return properties;
		}

		public async Task<ObjModel> GetDataById(int id)
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName);
			ObjModel objectResult = new ObjModel();

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				const string sql = "SELECT * FROM Obiecte WHERE ID = @ID";

				objectResult = await connection.QueryFirstOrDefaultAsync<ObjModel>(sql, new { id });
			}

			return objectResult;
		}

		public async Task<Properties> GetLabelPropertyByID(int id)
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName);
			Properties properties = new Properties();

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				const string sql = "SELECT * FROM ProprietatiLabel WHERE ID = @ID";

				properties = await connection.QueryFirstOrDefaultAsync<Properties>(sql, new { id });
			}

			return properties;
		}

		public async Task<List<ObjModel>> LoadData()
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName);
			IEnumerable<ObjModel> objects;

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				const string sql = "SELECT * FROM Obiecte WHERE grupare=574252 ORDER BY ordine ASC";

				objects = await connection.QueryAsync<ObjModel>(sql, new { });
			}

			return objects.ToList();
		}

		public void UpdateControlProperty(Properties properties, int id)
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
		}

		public void UpdateLabelProperty(Properties properties, int id)
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
		}

		public async Task<bool> UpdateData(ObjModel objModel)
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

			return true;
		}
	}
}
