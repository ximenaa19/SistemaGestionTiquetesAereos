using Microsoft.EntityFrameworkCore;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.EmailDomains.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Regions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Entity;

namespace GestionAerolineas.src.shared.Context;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet for continents.
    /// </summary>
    public DbSet<ContinentEntity> Continents { get; set; }
    public DbSet<EmailDomainEntity> EmailDomains { get; set; }
    public DbSet<FlightRoleEntity> FlightRoles { get; set; }
    public DbSet<PhoneCodeEntity> PhoneCodes { get; set; }
    //public DbSet<CountryEntity> Countries { get; set; }

    //public DbSet<RegionEntity> Regions { get; set; }
    //public DbSet<CityEntity> Cities { get; set; }
    public DbSet<RoadTypeEntity> RoadTypes { get; set; }
    public DbSet<DocumentTypeEntity> DocumentTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}


