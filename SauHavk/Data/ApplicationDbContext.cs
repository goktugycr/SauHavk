using Microsoft.EntityFrameworkCore;
using SauHavk.Models;

namespace SauHavk.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet tanımları (Tablolar)
        public DbSet<Events> Events { get; set; }
    }
}

