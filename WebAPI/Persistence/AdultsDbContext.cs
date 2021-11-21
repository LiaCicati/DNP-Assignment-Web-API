using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public class AdultsDbContext : DbContext 
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Loredana Cicati\DNP-Assignment-Web-API\WebAPI\adults.db");
        }
    }
}