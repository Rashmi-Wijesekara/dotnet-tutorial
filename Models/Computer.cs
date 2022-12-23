using System.Text.Json.Serialization;

namespace FirstConsoleApp.Models
{
	public class Computer
	{
		[JsonPropertyName("computer_id")]
		public int ComputerId { get; set; }
		[JsonPropertyName("motherboard")]
		public string Motherboard { get; set; }
		[JsonPropertyName("cpu_cores")]
		public int? CPUCores { get; set; }
		[JsonPropertyName("has_wifi")]
		public bool HasWiFi { get; set; }
		[JsonPropertyName("has_lte")]
		public bool HasLTE { get; set; }
		[JsonPropertyName("release_date")]
		public DateTime? ReleaseDate { get; set; }
		[JsonPropertyName("price")]
		public decimal Price { get; set; }
		[JsonPropertyName("video_card")]
		public string VideoCard { get; set; }

		// to handle non-nullable string values
		public Computer()
		{
			if (VideoCard == null) VideoCard = "";
			if (Motherboard == null) Motherboard = "";
			if(CPUCores == null) CPUCores = 0;
		}
	}
}