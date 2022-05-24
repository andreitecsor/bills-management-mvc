using EnterpriseBillsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBillsManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
