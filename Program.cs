using FirstConsoleApp.Models;

namespace FirstConsoleteApp
{
	internal class Program
	{
		
		static void Main(string[] args)
		{
			Computer myComputer = new Computer()
			{
				Motherboard = "Z690",
				HasLTE = false,
				HasWiFi = true,
				ReleaseDate = DateTime.Now,
				Price = 65000.00m,
				VideoCard = "RTX 2060"
			};

			System.Console.WriteLine(myComputer.Motherboard);
		}
	}
}