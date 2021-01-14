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
		string ConnectionStringName { get; set; }

		Task<List<ObjModel>> LoadData(WindowsIdentity windowsIdentity);

		Task<ObjModel> GetDataById(WindowsIdentity windowsIdentity, int id);

		Task<bool> UpdateData(WindowsIdentity windowsIdentity, ObjModel objModel);

		Task<List<int>> GetComboboxList(WindowsIdentity windowsIdentity, int id);

		Task<Properties> GetLabelPropertyByID(WindowsIdentity windowsIdentity, int id);

		void UpdateLabelProperty(WindowsIdentity windowsIdentity, Properties properties, int id);

		Task<Properties> GetControlPropertyByID(WindowsIdentity windowsIdentity, int id);

		void UpdateControlProperty(WindowsIdentity windowsIdentity, Properties properties, int id);

		Task<UserModel> GetSqlUsername(WindowsIdentity windowsIdentity);

		static Task<T> RunImpersonatedAsync<T>(SafeAccessTokenHandle safeAccessTokenHandle, Func<Task<T>> func) =>
			WindowsIdentity.RunImpersonated(safeAccessTokenHandle, func);
	}
}
