using Microsoft.EntityFrameworkCore;

namespace EF.UOW.Inftrastructure.ContextOne;

public class FirstDbContext : DbContext
{
    private readonly string connectionString;

    public DbSet<EntityOne> T1 { get; set; }
    public DbSet<EntityTwo> T2 { get; set; }

    public FirstDbContext(string connectionString)
    {
        this.connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
    }
}
