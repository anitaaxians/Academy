using Academy.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
    }
}
