using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotNetAPI
{
	class DataContextDapper
	{
		private readonly IConfiguration _config;

		public DataContextDapper(IConfiguration config)
		{
			_config = config;
		}

		public IEnumerable<T> LoadData<T>(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			return dbConnection.Query<T>(query);
		}

		public T LoadDataSingle<T>(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			return dbConnection.QuerySingle<T>(query);
		}

		public bool ExecuteSql(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			return dbConnection.Execute(query) > 0;
		}

		public int ExecuteSqlWithRowCount(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			return dbConnection.Execute(query);
		}
	}
}