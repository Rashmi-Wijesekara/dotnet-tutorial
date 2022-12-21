using System.Data;
using Dapper;
using FirstConsoleApp.Data;
using FirstConsoleApp.Models;
using Microsoft.Data.SqlClient;

namespace FirstConsoleteApp
{
	internal class Program
	{
		
		static void Main(string[] args)
		{
			DataContextDapper dapper = new DataContextDapper();

			DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
			System.Console.WriteLine(rightNow.ToString());

			Computer myComputer = new Computer()
			{
				Motherboard = "Z699",
				HasLTE = true,
				HasWiFi = false,
				ReleaseDate = DateTime.Now,
				Price = 78000.00m,
				VideoCard = "RTX 1060"
			};

			string sql = @"INSERT INTO TutorialAppSchema.Computer (
				Motherboard ,
				HasLTE ,
				HasWiFi ,
				ReleaseDate ,
				Price ,
				VideoCard 
			) VALUES ('" + myComputer.Motherboard + "','" + 
										myComputer.HasLTE + "','" + 
										myComputer.HasWiFi + "','" +
										myComputer.ReleaseDate + "','" +
										myComputer.Price + "','" +
										myComputer.VideoCard + "')";

			int result = dapper.ExecuteSql(sql);
			System.Console.WriteLine("no of rows affected = "+ result);

			string sqlSelect = @"
				SELECT
					Computer.Motherboard ,
					Computer.HasLTE ,
					Computer.HasWiFi ,
					Computer.ReleaseDate ,
					Computer.Price ,
					Computer.VideoCard FROM TutorialAppSchema.Computer";

			IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

			// convert IENumerable into a List
			// List<Computer> computerList = dbConnection.Query<Computer>(sqlSelect).ToList<Computer>();

			System.Console.WriteLine("Motherboard, HasLTE, HasWiFi, ReleaseDate, Price, VideoCard");
			foreach(Computer computer in computers)
			{
				System.Console.WriteLine("'" + 
					computer.Motherboard + "','" +
					computer.HasLTE + "','" +
					computer.HasWiFi + "','" +
					computer.ReleaseDate + "','Rs." +
					computer.Price + "','" +
					computer.VideoCard + "'");
			}
		}
	}
}