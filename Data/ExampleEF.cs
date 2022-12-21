using FirstConsoleApp.Models;
using Microsoft.Extensions.Configuration;

namespace FirstConsoleApp.Data
{
	public class ExampleEF
	{
		private IConfiguration _config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
		private DataContextEF _entityFramework;

		public ExampleEF()
		{
			_entityFramework = new DataContextEF(_config);
		}

		public void AddComputerInEF()
		{
			Computer myComputer = new Computer()
			{
				Motherboard = "Z9999",
				HasLTE = true,
				HasWiFi = true,
				ReleaseDate = DateTime.Now,
				Price = 125000.00m,
				VideoCard = "RTX 64"
			};

			_entityFramework.Add(myComputer);
			_entityFramework.SaveChanges();
		}

		public void LoadComputersInEF()
		{
			IEnumerable<Computer>? computersEf = _entityFramework.Computer?.ToList<Computer>();

			if (computersEf != null)
			{
				System.Console.WriteLine("ComputerId, Motherboard, HasLTE, HasWiFi, ReleaseDate, Price, VideoCard");
				foreach (Computer computer in computersEf)
				{
					System.Console.WriteLine("'" +
						computer.ComputerId + "','" +
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
}