using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FirstConsoleApp.Data
{
	public class DataContextDapper
	{
		// private IConfiguration _config;
		private string _connectionString;

		public DataContextDapper(IConfiguration config)
		{
			// _config = config;
			_connectionString = config.GetConnectionString("DefaultConnection");
		}

		public IEnumerable<T> LoadData<T>(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			IEnumerable<T> result = dbConnection.Query<T>(query);
			return result;
		}

		public T LoadDataSingle<T>(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			T result = dbConnection.QuerySingle<T>(query);
			return result;
		}

		public int ExecuteSql(string query)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			return dbConnection.Execute(query);
		}
	}
}