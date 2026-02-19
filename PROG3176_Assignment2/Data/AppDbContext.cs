using Microsoft.EntityFrameworkCore;
using PROG3176_Assignment2.Entities;

namespace PROG3176_Assignment2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
    }
}
