using System.Linq;
using System.Threading.Tasks;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Services
{
	public sealed class EmployeeContext : DbContext
	{
		public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
		{
		}
		
		public DbSet<Worker> Workers { get; set; }

		public async Task MigrateAsync()
		{
			var pendingMigrations = await Database.GetPendingMigrationsAsync();
			if (!pendingMigrations.Any())
				return;

			await Database.MigrateAsync();
		}
	}
}