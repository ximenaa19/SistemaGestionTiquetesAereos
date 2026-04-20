using Microsoft.EntityFrameworkCore;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CheckinStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CardTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Cities.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Countries.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Airlines.Infrastructure.Entity;
using GestionAerolineas.src.Modules.AircraftManufacturers.Infrastructure.Entity;
using GestionAerolineas.src.Modules.AircraftModels.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Airports.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Addresses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.DocumentTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.EmailDomains.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightStates.Infrastructure.Entity;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.InvoiceItemTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PassengerTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PaymentMethodTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PaymentStates.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PaymentMethods.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Permissions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.PhoneCodes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.ReservationStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Regions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.RoadTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CabinTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.CardIssuers.Infrastructure.Entity;
using GestionAerolineas.src.Modules.Seasons.Infrastructure.Entity;
using GestionAerolineas.src.Modules.SeatLocationTypes.Infrastructure.Entity;
using GestionAerolineas.src.Modules.StaffRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Entity;
using GestionAerolineas.src.Modules.TicketStatuses.Infrastructure.Entity;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.RolePermissions.Infrastructure.Entity;
using GestionAerolineas.src.Modules.People.Infrastructure.Entity;


namespace GestionAerolineas.src.shared.Context;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet for continents.
    /// </summary>
    public DbSet<ContinentEntity> Continents { get; set; }
    public DbSet<AvailabilityStatusEntity> AvailabilityStatuses { get; set; }
    public DbSet<CardTypeEntity> CardTypes { get; set; }
    public DbSet<CardIssuerEntity> CardIssuers { get; set; }
    public DbSet<CheckinStatusEntity> CheckinStatuses { get; set; }
    public DbSet<EmailDomainEntity> EmailDomains { get; set; }
    public DbSet<FlightRoleEntity> FlightRoles { get; set; }
    public DbSet<FlightStateEntity> FlightStates { get; set; }
    public DbSet<FlightStatusTransitionEntity> FlightStatusTransitions { get; set; }
    public DbSet<InvoiceItemTypeEntity> InvoiceItemTypes { get; set; }
    public DbSet<PassengerTypeEntity> PassengerTypes { get; set; }
    public DbSet<PaymentMethodTypeEntity> PaymentMethodTypes { get; set; }
    public DbSet<PaymentStateEntity> PaymentStates { get; set; }
    public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<PhoneCodeEntity> PhoneCodes { get; set; }
    public DbSet<ReservationStatusEntity> ReservationStatuses { get; set; }
    public DbSet<SeasonEntity> Seasons { get; set; }
    public DbSet<SeatLocationTypeEntity> SeatLocationTypes { get; set; }
    public DbSet<StaffRoleEntity> StaffRoles { get; set; }
    public DbSet<SystemRoleEntity> SystemRoles { get; set; }
    public DbSet<TicketStatusEntity> TicketStatuses { get; set; }
    public DbSet<ReservationStatusTransitionEntity> ReservationStatusTransitions { get; set; }
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }

    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<AircraftManufacturerEntity> AircraftManufacturers { get; set; }
    public DbSet<AircraftModelEntity> AircraftModels { get; set; }
    public DbSet<AirportEntity> Airports { get; set; }
    public DbSet<AirlineEntity> Airlines { get; set; }
    public DbSet<PersonEntity> People { get; set; }

    public DbSet<RegionEntity> Regions { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
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


