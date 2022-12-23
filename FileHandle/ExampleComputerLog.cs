using FirstConsoleApp.Models;

namespace FirstConsoleApp.FileHandle
{
	public class ExampleComputerLog
	{
		private string computerLog;

		public ExampleComputerLog()
		{
			Computer computer = new Computer()
			{
				Motherboard = "ER339",
				HasLTE = false,
				HasWiFi = true,
				ReleaseDate = DateTime.Now,
				Price = 150000.00m,
				VideoCard = "RTX 64"
			};

			computerLog = @"'" +
						computer.Motherboard + "','" +
						computer.HasLTE + "','" +
						computer.HasWiFi + "','" +
						computer.ReleaseDate + "','Rs." +
						computer.Price + "','" +
						computer.VideoCard + "'";
		}

		public void WriteOneLine()
		{
			File.WriteAllText("ComputerLog.txt", "ComputerId, Motherboard, HasLTE, HasWiFi, ReleaseDate, Price, VideoCard");
			File.WriteAllText("ComputerLog.txt", computerLog);
			// clear all the data and write only the given line
		}

		public void WriteOnFile()
		{
			using StreamWriter openFile = new("ComputerLog.txt", append: true);
			openFile.WriteLine("ComputerId, Motherboard, HasLTE, HasWiFi, ReleaseDate, Price, VideoCard\n");
			openFile.WriteLine(computerLog);
			openFile.WriteLine(computerLog);
			openFile.WriteLine(computerLog);
			openFile.Close();
		}

	}
}