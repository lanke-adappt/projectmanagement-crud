using Microsoft.EntityFrameworkCore;
using Task1.Shared.Models;
namespace Task1.Api.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        
        public DbSet<User> Users => Set<User>();
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<UserDetails> UserDetails { get; set; } = null!;
        public DbSet<ProjectMapping> ProjectMapping => Set<ProjectMapping>();

    }
}
