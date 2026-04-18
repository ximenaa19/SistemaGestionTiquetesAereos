using Microsoft.EntityFrameworkCore;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CheckinStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CardTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.EmailDomains.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightStates.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PassengerTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PaymentStates.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.ReservationStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Regions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CabinTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.SeatLocationTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.TicketStatuses.Infrastructure.Entity;

namespace GestionAerolineas.src.shared.Context;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet for continents.
    /// </summary>
    public DbSet<ContinentEntity> Continents { get; set; }
    public DbSet<AvailabilityStatusEntity> AvailabilityStatuses { get; set; }
    public DbSet<CardTypeEntity> CardTypes { get; set; }
    public DbSet<CheckinStatusEntity> CheckinStatuses { get; set; }
    public DbSet<EmailDomainEntity> EmailDomains { get; set; }
    public DbSet<FlightRoleEntity> FlightRoles { get; set; }
    public DbSet<FlightStateEntity> FlightStates { get; set; }
    public DbSet<PassengerTypeEntity> PassengerTypes { get; set; }
    public DbSet<PaymentStateEntity> PaymentStates { get; set; }
    public DbSet<PhoneCodeEntity> PhoneCodes { get; set; }
    public DbSet<ReservationStatusEntity> ReservationStatuses { get; set; }
    public DbSet<SeatLocationTypeEntity> SeatLocationTypes { get; set; }
    public DbSet<SystemRoleEntity> SystemRoles { get; set; }
    public DbSet<TicketStatusEntity> TicketStatuses { get; set; }
    //public DbSet<CountryEntity> Countries { get; set; }

    //public DbSet<RegionEntity> Regions { get; set; }
    //public DbSet<CityEntity> Cities { get; set; }
    public DbSet<RoadTypeEntity> RoadTypes { get; set; }
    public DbSet<DocumentTypeEntity> DocumentTypes { get; set; }
    public DbSet<CabinTypeEntity> CabinTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}


