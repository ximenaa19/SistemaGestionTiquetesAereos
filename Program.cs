using GestionAerolineas.src.Modules.Addresses;
using GestionAerolineas.src.Modules.Aircraft;
using GestionAerolineas.src.Modules.AircraftManufacturers;
using GestionAerolineas.src.Modules.AircraftModels;
using GestionAerolineas.src.Modules.Airlines;
using GestionAerolineas.src.Modules.AirportAirline;
using GestionAerolineas.src.Modules.Airports;
using GestionAerolineas.src.Modules.Auth;
using GestionAerolineas.src.Modules.AvailabilityStatuses;
using GestionAerolineas.src.Modules.CabinConfiguration;
using GestionAerolineas.src.Modules.CabinTypes;
using GestionAerolineas.src.Modules.CardIssuers;
using GestionAerolineas.src.Modules.CardTypes;
using GestionAerolineas.src.Modules.Checkins;
using GestionAerolineas.src.Modules.CheckinStatuses;
using GestionAerolineas.src.Modules.Cities;
using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.Modules.Countries;
using GestionAerolineas.src.Modules.Customers;
using GestionAerolineas.src.Modules.DocumentTypes;
using GestionAerolineas.src.Modules.EmailDomains;
using GestionAerolineas.src.Modules.Fares;
using GestionAerolineas.src.Modules.FlightAssignments;
using GestionAerolineas.src.Modules.FlightRoles;
using GestionAerolineas.src.Modules.Flights;
using GestionAerolineas.src.Modules.FlightSeats;
using GestionAerolineas.src.Modules.FlightStates;
using GestionAerolineas.src.Modules.FlightStatusTransitions;
using GestionAerolineas.src.Modules.InvoiceItems;
using GestionAerolineas.src.Modules.InvoiceItemTypes;
using GestionAerolineas.src.Modules.Invoices;
using GestionAerolineas.src.Modules.Passengers;
using GestionAerolineas.src.Modules.PassengerTypes;
using GestionAerolineas.src.Modules.PaymentMethods;
using GestionAerolineas.src.Modules.PaymentMethodTypes;
using GestionAerolineas.src.Modules.Payments;
using GestionAerolineas.src.Modules.PaymentStates;
using GestionAerolineas.src.Modules.People;
using GestionAerolineas.src.Modules.Permissions;
using GestionAerolineas.src.Modules.PersonEmails;
using GestionAerolineas.src.Modules.PersonPhones;
using GestionAerolineas.src.Modules.PhoneCodes;
using GestionAerolineas.src.Modules.Regions;
using GestionAerolineas.src.Modules.Reservations;
using GestionAerolineas.src.Modules.ReservationFlights;
using GestionAerolineas.src.Modules.ReservationPassengers;
using GestionAerolineas.src.Modules.ReservationStatuses;
using GestionAerolineas.src.Modules.ReservationStatusTransitions;
using GestionAerolineas.src.Modules.RoadTypes;
using GestionAerolineas.src.Modules.RolePermissions;
using GestionAerolineas.src.Modules.Routes;
using GestionAerolineas.src.Modules.RouteStops;
using GestionAerolineas.src.Modules.Seasons;
using GestionAerolineas.src.Modules.SeatLocationTypes;
using GestionAerolineas.src.Modules.Sessions;
using GestionAerolineas.src.Modules.Staff;
using GestionAerolineas.src.Modules.StaffAvailability;
using GestionAerolineas.src.Modules.StaffRoles;
using GestionAerolineas.src.Modules.SystemRoles;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Tickets;
using GestionAerolineas.src.Modules.TicketStatuses;
using GestionAerolineas.src.Modules.Users;
using GestionAerolineas.src.shared.Helpers;
using GestionAerolineas.src.shared.Seed;
using GestionAerolineas.src.shared.Ui.RoleMenus;

try
{
    var context = DbContextFactory.Create();

    if (!context.Database.CanConnect())
    {
        Console.WriteLine("No se pudo conectar a la base de datos");
        return;
    }

    Console.WriteLine("Conexion exitosa\n");

    var continentMenu = ContinentModule.Build(context);
    var countryMenu = CountryModule.Build(context);
    var customerMenu = CustomerModule.Build(context);
    var aircraftManufacturerMenu = AircraftManufacturerModule.Build(context);
    var aircraftModelMenu = AircraftModelModule.Build(context);
    var aircraftMenu = AircraftModule.Build(context);
    var airportMenu = AirportModule.Build(context);
    var airportAirlineMenu = AirportAirlineModule.Build(context);
    var airlineMenu = AirlineModule.Build(context);
    var routeMenu = RouteModule.Build(context);
    var routeStopMenu = RouteStopModule.Build(context);
    var fareMenu = FareModule.Build(context);
    var staffMenu = StaffModule.Build(context);
    var staffAvailabilityMenu = StaffAvailabilityModule.Build(context);
    var flightMenu = FlightModule.Build(context);
    var flightSeatMenu = FlightSeatModule.Build(context);
    var flightAssignmentMenu = FlightAssignmentModule.Build(context);
    var reservationMenu = ReservationModule.Build(context);
    var reservationFlightMenu = ReservationFlightModule.Build(context);
    var reservationPassengerMenu = ReservationPassengerModule.Build(context);
    var ticketMenu = TicketModule.Build(context);
    var checkinMenu = CheckinModule.Build(context);
    var paymentMenu = PaymentModule.Build(context);
    var invoiceMenu = InvoiceModule.Build(context);
    var invoiceItemMenu = InvoiceItemModule.Build(context);
    var regionMenu = RegionModule.Build(context);
    var cityMenu = CityModule.Build(context);
    var addressMenu = AddressModule.Build(context);
    var availabilityStatusMenu = AvailabilityStatusModule.Build(context);
    var cardTypeMenu = CardTypeModule.Build(context);
    var cardIssuerMenu = CardIssuerModule.Build(context);
    var checkinStatusMenu = CheckinStatusModule.Build(context);
    var emailDomainMenu = EmailDomainModule.Build(context);
    var personEmailMenu = PersonEmailModule.Build(context);
    var personPhoneMenu = PersonPhoneModule.Build(context);
    var roadTypeMenu = RoadTypeModule.Build(context);
    var documentTypeMenu = DocumentTypeModule.Build(context);
    var flightRoleMenu = FlightRoleModule.Build(context);
    var flightStateMenu = FlightStateModule.Build(context);
    var flightStatusTransitionMenu = FlightStatusTransitionModule.Build(context);
    var invoiceItemTypeMenu = InvoiceItemTypeModule.Build(context);
    var paymentMethodTypeMenu = PaymentMethodTypeModule.Build(context);
    var paymentMethodMenu = PaymentMethodModule.Build(context);
    var paymentStateMenu = PaymentStateModule.Build(context);
    var permissionMenu = PermissionModule.Build(context);
    var phoneCodeMenu = PhoneCodeModule.Build(context);
    var reservationStatusMenu = ReservationStatusModule.Build(context);
    var seasonMenu = SeasonModule.Build(context);
    var seatLocationTypeMenu = SeatLocationTypeModule.Build(context);
    var sessionMenu = SessionModule.Build(context);
    var staffRoleMenu = StaffRoleModule.Build(context);
    var systemRoleMenu = SystemRoleModule.Build(context);
    var ticketStatusMenu = TicketStatusModule.Build(context);
    var userMenu = UserModule.Build(context);
    var authMenu = AuthModule.Build(context);
    var personMenu = PersonModule.Build(context);
    var adminCreatePersonFlow = PersonModule.BuildAdminCreateFlow(context);
    var passengerMenu = PassengerModule.Build(context);
    var cabinTypeMenu = CabinTypeModule.Build(context);
    var cabinConfigurationMenu = CabinConfigurationModule.Build(context);
    var passengerTypeMenu = PassengerTypeModule.Build(context);
    var reservationStatusTransitionMenu = ReservationStatusTransitionModule.Build(context);
    var rolePermissionMenu = RolePermissionModule.Build(context);

    var authResult = await authMenu.StartAsync();
    if (authResult is null)
        return;

    var roleRepository = new SystemRoleRepository(context);
    var getRoleById = new GetSystemRoleByIdUseCase(roleRepository);
    var role = await getRoleById.ExecuteAsync(authResult.RoleId);
    var roleName = role?.Name.Value?.Trim() ?? string.Empty;

    var adminAirOperationMenu = new RoleMenu("ADMIN · OPERACION AEREA", new List<RoleMenuOption>
    {
        new("Flights", () => flightMenu.StartAsync()),
        new("FlightAssignments", () => flightAssignmentMenu.StartAsync()),
        new("FlightSeats", () => flightSeatMenu.StartAsync()),
        new("Routes", () => routeMenu.StartAsync()),
        new("RouteStops", () => routeStopMenu.StartAsync()),
        new("Airports", () => airportMenu.StartAsync()),
        new("AirportAirline", () => airportAirlineMenu.StartAsync()),
        new("Airlines", () => airlineMenu.StartAsync()),
        new("Aircraft", () => aircraftMenu.StartAsync()),
        new("AircraftModels", () => aircraftModelMenu.StartAsync()),
        new("AircraftManufacturers", () => aircraftManufacturerMenu.StartAsync()),
        new("CabinConfiguration", () => cabinConfigurationMenu.StartAsync()),
        new("Fares", () => fareMenu.StartAsync())
    }, "Volver");

    var adminCommercialMenu = new RoleMenu("ADMIN · COMERCIAL Y VENTAS", new List<RoleMenuOption>
    {
        new("Reservations", () => reservationMenu.StartAsync()),
        new("ReservationFlights", () => reservationFlightMenu.StartAsync()),
        new("ReservationPassengers", () => reservationPassengerMenu.StartAsync()),
        new("Payments", () => paymentMenu.StartAsync()),
        new("Invoices", () => invoiceMenu.StartAsync()),
        new("InvoiceItems", () => invoiceItemMenu.StartAsync()),
        new("Tickets", () => ticketMenu.StartAsync()),
        new("Checkins", () => checkinMenu.StartAsync())
    }, "Volver");

    var adminPeopleMenu = new RoleMenu("ADMIN · PERSONAS Y ORGANIZACION", new List<RoleMenuOption>
    {
        new("People", () => personMenu.StartAsync()),
        new("Customers", () => customerMenu.StartAsync()),
        new("Passengers", () => passengerMenu.StartAsync()),
        new("Staff", () => staffMenu.StartAsync()),
        new("StaffAvailability", () => staffAvailabilityMenu.StartAsync()),
        new("PersonEmails", () => personEmailMenu.StartAsync()),
        new("PersonPhones", () => personPhoneMenu.StartAsync()),
        new("Users", () => userMenu.StartAsync()),
        new("Sessions", () => sessionMenu.StartAsync())
    }, "Volver");

    var adminSecurityMenu = new RoleMenu("ADMIN · SEGURIDAD Y PERMISOS", new List<RoleMenuOption>
    {
        new("SystemRoles", () => systemRoleMenu.StartAsync()),
        new("Permissions", () => permissionMenu.StartAsync()),
        new("RolePermissions", () => rolePermissionMenu.StartAsync()),
        new("StaffRoles", () => staffRoleMenu.StartAsync()),
        new("FlightRoles", () => flightRoleMenu.StartAsync())
    }, "Volver");

    var adminCatalogMenu = new RoleMenu("ADMIN · CATALOGOS MAESTROS", new List<RoleMenuOption>
    {
        new("Continents", () => continentMenu.StartAsync()),
        new("Countries", () => countryMenu.StartAsync()),
        new("Regions", () => regionMenu.StartAsync()),
        new("Cities", () => cityMenu.StartAsync()),
        new("Addresses", () => addressMenu.StartAsync()),
        new("RoadTypes", () => roadTypeMenu.StartAsync()),
        new("DocumentTypes", () => documentTypeMenu.StartAsync()),
        new("PhoneCodes", () => phoneCodeMenu.StartAsync()),
        new("EmailDomains", () => emailDomainMenu.StartAsync()),
        new("PassengerTypes", () => passengerTypeMenu.StartAsync()),
        new("CabinTypes", () => cabinTypeMenu.StartAsync()),
        new("SeatLocationTypes", () => seatLocationTypeMenu.StartAsync()),
        new("AvailabilityStatuses", () => availabilityStatusMenu.StartAsync()),
        new("ReservationStatuses", () => reservationStatusMenu.StartAsync()),
        new("ReservationStatusTransitions", () => reservationStatusTransitionMenu.StartAsync()),
        new("FlightStates", () => flightStateMenu.StartAsync()),
        new("FlightStatusTransitions", () => flightStatusTransitionMenu.StartAsync()),
        new("TicketStatuses", () => ticketStatusMenu.StartAsync()),
        new("CheckinStatuses", () => checkinStatusMenu.StartAsync()),
        new("PaymentStates", () => paymentStateMenu.StartAsync()),
        new("PaymentMethodTypes", () => paymentMethodTypeMenu.StartAsync()),
        new("PaymentMethods", () => paymentMethodMenu.StartAsync()),
        new("CardTypes", () => cardTypeMenu.StartAsync()),
        new("CardIssuers", () => cardIssuerMenu.StartAsync()),
        new("InvoiceItemTypes", () => invoiceItemTypeMenu.StartAsync()),
        new("Seasons", () => seasonMenu.StartAsync())
    }, "Volver");

    var adminSystemMenu = new RoleMenu("ADMIN · SISTEMA", new List<RoleMenuOption>
    {
        new("Seed master + catalogs", async () =>
        {
            await SeedRunner.SeedMasterAndCatalogsAsync(context);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✔ Seed completado");
            Console.ResetColor();
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        })
    }, "Volver");

    var adminMenu = new AdminRoleMenu(new List<RoleMenuOption>
    {
        new("Crear persona", () => adminCreatePersonFlow.StartAsync()),
        new("Operacion aerea", () => adminAirOperationMenu.StartAsync()),
        new("Comercial y ventas", () => adminCommercialMenu.StartAsync()),
        new("Personas y organizacion", () => adminPeopleMenu.StartAsync()),
        new("Seguridad y permisos", () => adminSecurityMenu.StartAsync()),
        new("Catalogos maestros", () => adminCatalogMenu.StartAsync()),
        new("Sistema", () => adminSystemMenu.StartAsync())
    });

    var staffRoleMenuUi = new StaffRoleMenu(new List<RoleMenuOption>
    {
        new("Flights", () => flightMenu.StartAsync()),
        new("Reservations", () => reservationMenu.StartAsync()),
        new("ReservationFlights", () => reservationFlightMenu.StartAsync()),
        new("ReservationPassengers", () => reservationPassengerMenu.StartAsync()),
        new("Checkins", () => checkinMenu.StartAsync()),
        new("Payments", () => paymentMenu.StartAsync()),
        new("Tickets", () => ticketMenu.StartAsync()),
        new("Sessions", () => sessionMenu.StartAsync())
    });

    var customerRoleMenuUi = new CustomerRoleMenu(new List<RoleMenuOption>
    {
        new("Flights", () => flightMenu.StartAsync()),
        new("Reservations", () => reservationMenu.StartAsync()),
        new("ReservationFlights", () => reservationFlightMenu.StartAsync()),
        new("ReservationPassengers", () => reservationPassengerMenu.StartAsync()),
        new("Tickets", () => ticketMenu.StartAsync()),
        new("Payments", () => paymentMenu.StartAsync())
    });

    if (roleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
    {
        await adminMenu.StartAsync();
    }
    else if (roleName.Equals("Agente", StringComparison.OrdinalIgnoreCase) ||
             roleName.Equals("Staff", StringComparison.OrdinalIgnoreCase))
    {
        await staffRoleMenuUi.StartAsync();
    }
    else if (roleName.Equals("Cliente", StringComparison.OrdinalIgnoreCase) ||
             roleName.Equals("Customer", StringComparison.OrdinalIgnoreCase))
    {
        await customerRoleMenuUi.StartAsync();
    }
    else
    {
        Console.WriteLine($"Rol no mapeado para menu principal: '{roleName}'.");
        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.Error.WriteLine($"Detalle: {ex.InnerException.Message}");
    }
}
