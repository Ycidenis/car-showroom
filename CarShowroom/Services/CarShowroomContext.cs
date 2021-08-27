using System.Linq;
using System.Threading.Tasks;
using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Services
{
    public sealed class CarShowroomContext : DbContext
    {
        public CarShowroomContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Car> Cars { get; set; }

        public async Task MigrateAsync()
        {
            var pendingMigrations = await Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await Database.MigrateAsync();
            }
        }
    }
}