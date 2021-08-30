using System.Linq;
using System.Threading.Tasks;
using LibraryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryStore.Services
{
    public sealed class LibraryStoreContext : DbContext
    {
        public LibraryStoreContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }

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