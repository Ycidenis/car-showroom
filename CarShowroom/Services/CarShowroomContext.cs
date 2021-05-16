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
    }
}