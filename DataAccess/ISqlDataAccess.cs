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
		bool VerifySqlConnection(string uid, string pwsd);

		Task<List<ObjModel>> LoadData();

		Task<ObjModel> GetDataById(int id);

		Task<bool> UpdateData(ObjModel objModel);

		Task<List<int>> GetComboboxList(int id);

		Task<Properties> GetLabelPropertyByID(int id);

		void UpdateLabelProperty(Properties properties, int id);

		Task<Properties> GetControlPropertyByID(int id);

		void UpdateControlProperty(Properties properties, int id);

		Task<UserSqlTesting> GetSqlUsername();

		static Task<T> RunImpersonatedAsync<T>(SafeAccessTokenHandle safeAccessTokenHandle, Func<Task<T>> func) =>
			WindowsIdentity.RunImpersonated(safeAccessTokenHandle, func);
	}
}
