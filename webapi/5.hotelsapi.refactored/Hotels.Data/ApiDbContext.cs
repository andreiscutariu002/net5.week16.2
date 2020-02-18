using Hotels.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}