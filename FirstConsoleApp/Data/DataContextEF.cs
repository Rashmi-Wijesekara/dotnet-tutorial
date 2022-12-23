using FirstConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FirstConsoleApp.Data
{
	public class DataContextEF : DbContext
	{
		// private IConfiguration _config;
		private string _connectionString;

		public DataContextEF(IConfiguration config)
		{
			// _config = config;
			_connectionString = config.GetConnectionString("DefaultConnection");
		}

		public DbSet<Computer>? Computer { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			// avoid configuring over and over again
			if(!options.IsConfigured)
			{
				options.UseSqlServer(_connectionString,
					options => options.EnableRetryOnFailure()
					// if failed, try to connect again
				);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// map the models into the tables in the SQL server

			// by default modelBuilder will look for tables in the default schema
			// modelBuilder.Entity<Computer>().ToTable("Computer", "TutorialAppSchema");
			// modelBuilder.Entity<Computer>().ToTable("table name", "schema name");

			// changing the default schema
			modelBuilder.HasDefaultSchema("TutorialAppSchema");

			modelBuilder.Entity<Computer>().HasKey(computer => computer.ComputerId);
			// do not have to mention the table name bcz it similar to the model name

			// if the table doesn't have a primary key
			// modelBuilder.Entity<Computer>().HasNoKey();
		}
	}
}