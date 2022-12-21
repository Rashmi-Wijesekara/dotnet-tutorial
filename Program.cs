using System.Data;
using Dapper;
using FirstConsoleApp.Data;
using FirstConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FirstConsoleteApp
{
	internal class Program
	{

		static void Main(string[] args)
		{
			
			ExampleDapper dapper = new ExampleDapper();
			dapper.GetTimeNowInDapper();
			dapper.AddComputerInDapper();
			dapper.LoadComputersInDapper();

			ExampleEF entityFramework = new ExampleEF();
			entityFramework.AddComputerInEF();
			entityFramework.LoadComputersInEF();
		}
	}
}