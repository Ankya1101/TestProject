using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Customer> Customer { get; set; }
    }
}
