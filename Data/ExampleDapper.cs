using FirstConsoleApp.Models;
using Microsoft.Extensions.Configuration;

namespace FirstConsoleApp.Data
{
	public class ExampleDapper
	{
		private IConfiguration _config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
		private DataContextDapper _dapper;

		public ExampleDapper()
		{
			_dapper = new DataContextDapper(_config);
		}

		public void GetTimeNowInDapper()
		{
			DateTime rightNow = _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
			System.Console.WriteLine(rightNow);
		}

		public void AddComputerInDapper()
		{
			Computer myComputer = new Computer()
			{
				Motherboard = "Z8880",
				HasLTE = true,
				HasWiFi = false,
				ReleaseDate = DateTime.Now,
				Price = 22500.00m,
				VideoCard = "RTX 60"
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

			int result = _dapper.ExecuteSql(sql);
			System.Console.WriteLine("no of rows affected = " + result);
		}

		public void LoadComputersInDapper()
		{
			string sqlSelect = @"
				SELECT
					Computer.Motherboard ,
					Computer.HasLTE ,
					Computer.HasWiFi ,
					Computer.ReleaseDate ,
					Computer.Price ,
					Computer.VideoCard FROM TutorialAppSchema.Computer";

			IEnumerable<Computer> computers = _dapper.LoadData<Computer>(sqlSelect);

			// convert IENumerable into a List
			// List<Computer> computerList = dbConnection.Query<Computer>(sqlSelect).ToList<Computer>();

			System.Console.WriteLine("Motherboard, HasLTE, HasWiFi, ReleaseDate, Price, VideoCard");
			foreach (Computer computer in computers)
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