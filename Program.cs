using GestionAerolineas.src.Modules.CabinTypes;
using GestionAerolineas.src.Modules.CabinConfiguration;
using GestionAerolineas.src.Modules.Cities;
using GestionAerolineas.src.Modules.Airlines;
using GestionAerolineas.src.Modules.AvailabilityStatuses;
using GestionAerolineas.src.Modules.CardTypes;
using GestionAerolineas.src.Modules.CardIssuers;
using GestionAerolineas.src.Modules.CheckinStatuses;
using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.Modules.Countries;
using GestionAerolineas.src.Modules.Customers;
using GestionAerolineas.src.Modules.AircraftManufacturers;
using GestionAerolineas.src.Modules.AircraftModels;
using GestionAerolineas.src.Modules.Aircraft;
using GestionAerolineas.src.Modules.Airports;
using GestionAerolineas.src.Modules.AirportAirline;
using GestionAerolineas.src.Modules.Addresses;
using GestionAerolineas.src.Modules.Regions;
using GestionAerolineas.src.Modules.DocumentTypes;
using GestionAerolineas.src.Modules.EmailDomains;
using GestionAerolineas.src.Modules.Routes;
using GestionAerolineas.src.Modules.RouteStops;
using GestionAerolineas.src.Modules.Fares;
using GestionAerolineas.src.Modules.Staff;
using GestionAerolineas.src.Modules.StaffAvailability;
using GestionAerolineas.src.Modules.FlightRoles;
using GestionAerolineas.src.Modules.FlightStates;
using GestionAerolineas.src.Modules.Flights;
using GestionAerolineas.src.Modules.FlightSeats;
using GestionAerolineas.src.Modules.FlightAssignments;
using GestionAerolineas.src.Modules.Reservations;
using GestionAerolineas.src.Modules.ReservationFlights;
using GestionAerolineas.src.Modules.ReservationPassengers;
using GestionAerolineas.src.Modules.FlightStatusTransitions;
using GestionAerolineas.src.Modules.InvoiceItemTypes;
using GestionAerolineas.src.Modules.PaymentMethodTypes;
using GestionAerolineas.src.Modules.PaymentMethods;
using GestionAerolineas.src.Modules.PhoneCodes;
using GestionAerolineas.src.Modules.PaymentStates;
using GestionAerolineas.src.Modules.Permissions;
using GestionAerolineas.src.Modules.ReservationStatuses;
using GestionAerolineas.src.Modules.RoadTypes;
using GestionAerolineas.src.Modules.Seasons;
using GestionAerolineas.src.Modules.SeatLocationTypes;
using GestionAerolineas.src.Modules.StaffRoles;
using GestionAerolineas.src.Modules.SystemRoles;
using GestionAerolineas.src.Modules.TicketStatuses;
using GestionAerolineas.src.Modules.Users;
using GestionAerolineas.src.shared.Helpers;
using GestionAerolineas.src.Modules.PassengerTypes;
using GestionAerolineas.src.Modules.ReservationStatusTransitions;
using GestionAerolineas.src.Modules.RolePermissions;
using GestionAerolineas.src.Modules.People;
using GestionAerolineas.src.Modules.Passengers;
using GestionAerolineas.src.Modules.PersonEmails;
using GestionAerolineas.src.Modules.PersonPhones;
using GestionAerolineas.src.Modules.Payments;


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
    var paymentMenu = PaymentModule.Build(context);
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
    var staffRoleMenu = StaffRoleModule.Build(context);
    var systemRoleMenu = SystemRoleModule.Build(context);
    var ticketStatusMenu = TicketStatusModule.Build(context);
    var userMenu = UserModule.Build(context);
    var personMenu = PersonModule.Build(context);
    var passengerMenu = PassengerModule.Build(context);
    var CabinTypeMenu = CabinTypeModule.Build(context);
    var cabinConfigurationMenu = CabinConfigurationModule.Build(context);
    var PassengerTypeMenu = PassengerTypeModule.Build(context);
    var reservationStatusTransitionMenu = ReservationStatusTransitionModule.Build(context);
    var rolePermissionMenu = RolePermissionModule.Build(context);


    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA ===");
        Console.WriteLine("1. Continents");
        Console.WriteLine("2. AvailabilityStatuses");
        Console.WriteLine("3. CardTypes");
        Console.WriteLine("4. CheckinStatuses");
        Console.WriteLine("5. CardIssuers");
        Console.WriteLine("6. EmailDomains");
        Console.WriteLine("7. FlightRoles");
        Console.WriteLine("8. ReservationStatuses");
        Console.WriteLine("9. PhoneCodes");
        Console.WriteLine("10. SeatLocationTypes");
        Console.WriteLine("11. RoadTypes");
        Console.WriteLine("12. DocumenTypes");
        Console.WriteLine("13. CabinTypes");
        Console.WriteLine("14. PassengerTypes");
        Console.WriteLine("15. FlightStates");
        Console.WriteLine("16. FlightStatusTransitions");
        Console.WriteLine("17. PaymentStates");
        Console.WriteLine("18. TicketStatuses");
        Console.WriteLine("19. SystemRoles");
        Console.WriteLine("20. Permissions");
        Console.WriteLine("21. StaffRoles");
        Console.WriteLine("22. Seasons");
        Console.WriteLine("23. InvoiceItemTypes");
        Console.WriteLine("24. PaymentMethodTypes");
        Console.WriteLine("25. ReservationStatusTransitions");
        Console.WriteLine("26. RolePermissions");
        Console.WriteLine("27. PaymentMethods");
        Console.WriteLine("28. Countries");
        Console.WriteLine("29. AircraftManufacturers");
        Console.WriteLine("30. AircraftModels");
        Console.WriteLine("31. Regions");
        Console.WriteLine("32. Cities");
        Console.WriteLine("33. Addresses");
        Console.WriteLine("34. Airports");
        Console.WriteLine("35. Airlines");
        Console.WriteLine("36. People");
        Console.WriteLine("37. Aircraft");
        Console.WriteLine("38. AirportAirline");
        Console.WriteLine("39. Routes");
        Console.WriteLine("40. PersonEmails");
        Console.WriteLine("41. PersonPhones");
        Console.WriteLine("42. Customers");
        Console.WriteLine("43. Passengers");
        Console.WriteLine("44. RouteStops");
        Console.WriteLine("45. CabinConfiguration");
        Console.WriteLine("46. Fares");
        Console.WriteLine("47. Staff");
        Console.WriteLine("48. StaffAvailability");
        Console.WriteLine("49. Flights");
        Console.WriteLine("50. FlightSeats");
        Console.WriteLine("51. FlightAssignments");
        Console.WriteLine("52. Reservations");
        Console.WriteLine("53. ReservationFlights");
        Console.WriteLine("54. ReservationPassengers");
        Console.WriteLine("55. Payments");
        Console.WriteLine("56. Users");
        Console.WriteLine("0. Salir");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await continentMenu.StartAsync();
                break;

            case "2":
                await availabilityStatusMenu.StartAsync();
                break;

            case "3":
                await cardTypeMenu.StartAsync();
                break;

            case "4":
                await checkinStatusMenu.StartAsync();
                break;

            case "5":
                await cardIssuerMenu.StartAsync();
                break;

            case "6":
                await emailDomainMenu.StartAsync();
                break;

            case "7":
                await flightRoleMenu.StartAsync();
                break;

            case "8":
                await reservationStatusMenu.StartAsync();
                break;

            case "9":
                await phoneCodeMenu.StartAsync();
                break;

            case "10":
                await seatLocationTypeMenu.StartAsync();
                break;

            case "11":
                await roadTypeMenu.StartAsync();
                break;

            case "12":
                await documentTypeMenu.StartAsync();
                break;

            case "13":
                await CabinTypeMenu.StartAsync();
                break;
            case "14":
                await PassengerTypeMenu.StartAsync();
                break;
            case "15":
                await flightStateMenu.StartAsync();
                break;
            case "16":
                await flightStatusTransitionMenu.StartAsync();
                break;
            case "17":
                await paymentStateMenu.StartAsync();
                break;
            case "18":
                await ticketStatusMenu.StartAsync();
                break;
            case "19":
                await systemRoleMenu.StartAsync();
                break;
            case "20":
                await permissionMenu.StartAsync();
                break;
            case "21":
                await staffRoleMenu.StartAsync();
                break;
            case "22":
                await seasonMenu.StartAsync();
                break;
            case "23":
                await invoiceItemTypeMenu.StartAsync();
                break;

            case "24":
                await paymentMethodTypeMenu.StartAsync();
                break;
            case "25":
                await reservationStatusTransitionMenu.StartAsync();
                break;
            case "26":
                await rolePermissionMenu.StartAsync();
                break;
            case "27":
                await paymentMethodMenu.StartAsync();
                break;
            case "28":
                await countryMenu.StartAsync();
                break;
            case "29":
                await aircraftManufacturerMenu.StartAsync();
                break;
            case "30":
                await aircraftModelMenu.StartAsync();
                break;
            case "31":
                await regionMenu.StartAsync();
                break;
            case "32":
                await cityMenu.StartAsync();
                break;
            case "33":
                await addressMenu.StartAsync();
                break;
            case "34":
                await airportMenu.StartAsync();
                break;

            case "35":
                await airlineMenu.StartAsync();
                break;

            case "36":
                await personMenu.StartAsync();
                break;

            case "37":
                await aircraftMenu.StartAsync();
                break;

            case "38":
                await airportAirlineMenu.StartAsync();
                break;

            case "39":
                await routeMenu.StartAsync();
                break;

            case "44":
                await routeStopMenu.StartAsync();
                break;

            case "40":
                await personEmailMenu.StartAsync();
                break;

            case "41":
                await personPhoneMenu.StartAsync();
                break;
            case "42":
                await customerMenu.StartAsync();
                break;

            case "43":
                await passengerMenu.StartAsync();
                break;

            case "45":
                await cabinConfigurationMenu.StartAsync();
                break;

            case "46":
                await fareMenu.StartAsync();
                break;

            case "47":
                await staffMenu.StartAsync();
                break;

            case "48":
                await staffAvailabilityMenu.StartAsync();
                break;

            case "49":
                await flightMenu.StartAsync();
                break;

            case "50":
                await flightSeatMenu.StartAsync();
                break;

            case "51":
                await flightAssignmentMenu.StartAsync();
                break;

            case "52":
                await reservationMenu.StartAsync();
                break;

            case "53":
                await reservationFlightMenu.StartAsync();
                break;

            case "54":
                await reservationPassengerMenu.StartAsync();
                break;

            case "55":
                await paymentMenu.StartAsync();
                break;

            case "56":
                await userMenu.StartAsync();
                break;

            case "0":
                return;
        }
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
