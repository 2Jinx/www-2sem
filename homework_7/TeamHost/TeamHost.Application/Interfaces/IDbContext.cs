using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Interfaces;

public interface IDbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<StaticFile> StaticFiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<GamePlatform> GamePlatforms { get; set; }
}