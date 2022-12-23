using System.Data;
using System.Text.Json;
using AutoMapper;
using Dapper;
using FirstConsoleApp.Data;
using FirstConsoleApp.FileHandle;
using FirstConsoleApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FirstConsoleteApp
{
	internal class Program
	{

		static void Main(string[] args)
		{
			IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			DataContextDapper dapper = new DataContextDapper(config);


			Computer computer = new Computer()
			{
				Motherboard = "ER339",
				HasLTE = false,
				HasWiFi = true,
				ReleaseDate = DateTime.Now,
				Price = 150000.00m,
				VideoCard = "RTX 64"
			};

			string computerLog = @"'" +
						computer.Motherboard + "','" +
						computer.HasLTE + "','" +
						computer.HasWiFi + "','" +
						computer.ReleaseDate + "','Rs." +
						computer.Price + "','" +
						computer.VideoCard + "'";

			// string computersJson = File.ReadAllText("Computers.json");

			// JsonSerializerOptions options = new JsonSerializerOptions()
			// {
			// 	PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			// };

			// IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

			// IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

			// if (computers != null)
			// {
			// 	foreach (Computer c in computers)
			// 	{
			// 		string sql = @"INSERT INTO TutorialAppSchema.Computer (
			// 				Motherboard ,
			// 				HasLTE ,
			// 				HasWiFi ,
			// 				ReleaseDate ,
			// 				Price ,
			// 				VideoCard 
			// 			) VALUES ('"
			// 			 + EscapeSingleQuote(c.Motherboard) + "','" +
			// 				c.HasLTE + "','" +
			// 				c.HasWiFi + "','" +
			// 				c.ReleaseDate + "','" +
			// 				c.Price + "','" +
			// 				EscapeSingleQuote(c.VideoCard) + "')";

			// 		dapper.ExecuteSql(sql);
			// 	}
			// }

			// string computersCopyNewtonsoft = JsonConvert.SerializeObject(computers);
			// File.WriteAllText("ComputersCopyNewton.json", computersCopyNewtonsoft);

			// string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computers);
			// File.WriteAllText("ComputersCopySystem.json", computersCopySystem);

			// **********************************************************
			// mapping by using AutoMapper package
			// **********************************************************
			string computerJson = File.ReadAllText("ComputersSnake.json");
			Mapper mapper = new Mapper(new MapperConfiguration((config) =>
			{
				config.CreateMap<ComputerSnake, Computer>()
					.ForMember(
						destination => destination.ComputerId,
						options => options.MapFrom(
							source => source.computer_id
						)
					)
					.ForMember(
						destination => destination.Motherboard,
						options => options.MapFrom(
							source => source.motherboard
						)
					)
					.ForMember(
						destination => destination.CPUCores,
						options => options.MapFrom(
							source => source.cpu_cores
						)
					)
					.ForMember(
						destination => destination.HasWiFi,
						options => options.MapFrom(
							source => source.has_wifi
						)
					)
					.ForMember(
						destination => destination.HasLTE,
						options => options.MapFrom(
							source => source.has_lte
						)
					)
					.ForMember(
						destination => destination.ReleaseDate,
						options => options.MapFrom(
							source => source.release_date
						)
					)
					.ForMember(
						destination => destination.Price,
						options => options.MapFrom(
							source => source.price
						)
					)
					.ForMember(
						destination => destination.VideoCard,
						options => options.MapFrom(
							source => source.video_card
						)
					);
			}));

			IEnumerable<ComputerSnake>? computerSnakes = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computerJson);

			if(computerSnakes != null){
				IEnumerable<Computer> computers = mapper.Map<IEnumerable<Computer>>(computerSnakes);

				foreach(Computer c in computers)
				{
					// pass computers into the database
					System.Console.WriteLine(c.Motherboard);
				}
			}

			// **********************************************************
			// mapping by using built-in JsonPropertyName mapping
			// **********************************************************
			IEnumerable<Computer>? computersWithJsonProperty = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerJson);

			if (computersWithJsonProperty != null)
			{
				IEnumerable<Computer> computers = mapper.Map<IEnumerable<Computer>>(computersWithJsonProperty);
				System.Console.WriteLine("**************************");
				foreach (Computer c in computers)
				{
					// pass computers into the database
					System.Console.WriteLine(c.Motherboard);
				}
			}

		}

		static string EscapeSingleQuote(string input)
		{
			string output = input.Replace("'", "''");
			return output;
		}
	}
}