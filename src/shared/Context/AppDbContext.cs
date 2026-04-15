using Microsoft.EntityFrameworkCore;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Regions.Infrastructure.Entity;

namespace GestionAerolineas.src.Shared.Context;

public class AppDbContext : DbContext
{
    public DbSet<ContinentEntity> Continents { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }

    public DbSet<RegionEntity> Regions { get; set; }
    public DbSet<CityEntity> Cities { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

