namespace FirstConsoleApp.Models
{
	public class Computer
	{
		public string Motherboard { get; set; }
		public int CPUCores { get; set; }
		public bool HasWiFi { get; set; }
		public bool HasLTE { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
		public string VideoCard { get; set; }

		// to handle non-nullable string values
		public Computer()
		{
			if (VideoCard == null) VideoCard = "";
			if (Motherboard == null) Motherboard = "";
		}
	}
}