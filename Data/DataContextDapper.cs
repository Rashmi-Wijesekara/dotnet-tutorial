using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FirstConsoleApp.Data
{
	public class DataContextDapper
	{
		private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=true;TrustServerCertificate=true;";

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