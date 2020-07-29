using Microsoft.EntityFrameworkCore;
using WebApp_JWT.Entities;

namespace WebApp_JWT.Helpers
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; }

    public DbSet<SheduleTask> Tasks { get; set; }
  }
}
