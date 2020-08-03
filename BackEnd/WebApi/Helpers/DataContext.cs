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
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDetail> CarDetails { get; set; }
    public DbSet<BrandCar> BrandCars { get; set; }
    public DbSet<BrandDetail> Details { get; set; }
    public DbSet<ScheduleTask> Tasks { get; set; }
  }
}
