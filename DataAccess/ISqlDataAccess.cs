using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
	public interface ISqlDataAccess
	{
		string ConnectionStringName { get; set; }

		Task<List<ObjModel>> LoadData();

		Task<ObjModel> GetDataById(int id);

		Task<bool> UpdateData(ObjModel objModel);

		Task<List<int>> GetComboboxList(int id);

		Task<Properties> GetLabelPropertyByID(int id);

		void UpdateLabelProperty(Properties properties, int id);

		Task<Properties> GetControlPropertyByID(int id);

		void UpdateControlProperty(Properties properties, int id);

		Task<User> GetSqlUsername();
	}
}
