using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Principal;
using System;
using Microsoft.Win32.SafeHandles;

namespace DataAccess
{
	public interface ISqlDataAccess
	{
		bool VerifySqlConnection(string uid, string pswd);

		Task<List<ObjModel>> LoadData(string uid, string pswd);

		Task<ObjModel> GetDataById(string uid, string pswd, int id);

		Task<bool> UpdateData(string uid, string pswd, ObjModel objModel);

		Task<List<int>> GetComboboxList(string uid, string pswd, int id);

		Task<Properties> GetLabelPropertyByID(string uid, string pswd, int id);

		void UpdateLabelProperty(string uid, string pswd, Properties properties, int id);

		Task<Properties> GetControlPropertyByID(string uid, string pswd, int id);

		void UpdateControlProperty(string uid, string pswd, Properties properties, int id);

		Task<UserSqlTesting> GetSqlUsername(string uid, string pswd);

		static Task<T> RunImpersonatedAsync<T>(SafeAccessTokenHandle safeAccessTokenHandle, Func<Task<T>> func) =>
			WindowsIdentity.RunImpersonated(safeAccessTokenHandle, func);
	}
}
