using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Configurations;

namespace TeamHost.Persistence.Contexts;

public class ApplicationDbContext: DbContext, IDbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<StaticFile> StaticFiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<GamePlatform> GamePlatforms { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    
    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=3416;Username=postgres;Password=teamhost;Database=postgres;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GameCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new GamePlatformConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        
        modelBuilder.Entity<Country>().HasData(DatabaseSeeder.Countries());
        modelBuilder.Entity<Platform>().HasData(DatabaseSeeder.Platforms());
        modelBuilder.Entity<Category>().HasData(DatabaseSeeder.Categories());
        modelBuilder.Entity<Company>().HasData(DatabaseSeeder.Companies());
        modelBuilder.Entity<StaticFile>().HasData(DatabaseSeeder.StaticFiles());
        modelBuilder.Entity<GameCategory>().HasData(DatabaseSeeder.GameCategories());
        modelBuilder.Entity<GamePlatform>().HasData(DatabaseSeeder.GamePlatforms());
        modelBuilder.Entity<Game>().HasData(DatabaseSeeder.Games());
    }
}