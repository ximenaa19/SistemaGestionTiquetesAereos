using GestionAerolineas.src.Modules.CabinTypes;
using GestionAerolineas.src.Modules.AvailabilityStatuses;
using GestionAerolineas.src.Modules.CardTypes;
using GestionAerolineas.src.Modules.CheckinStatuses;
using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.Modules.DocumentTypes;
using GestionAerolineas.src.Modules.EmailDomains;
using GestionAerolineas.src.Modules.FlightRoles;
using GestionAerolineas.src.Modules.FlightStates;
using GestionAerolineas.src.Modules.PhoneCodes;
using GestionAerolineas.src.Modules.PaymentStates;
using GestionAerolineas.src.Modules.Permissions;
using GestionAerolineas.src.Modules.ReservationStatuses;
using GestionAerolineas.src.Modules.RoadTypes;
using GestionAerolineas.src.Modules.SeatLocationTypes;
using GestionAerolineas.src.Modules.SystemRoles;
using GestionAerolineas.src.Modules.TicketStatuses;
using GestionAerolineas.src.shared.Helpers;
using GestionAerolineas.src.Modules.PassengerTypes;

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
    var availabilityStatusMenu = AvailabilityStatusModule.Build(context);
    var cardTypeMenu = CardTypeModule.Build(context);
    var checkinStatusMenu = CheckinStatusModule.Build(context);
    var emailDomainMenu = EmailDomainModule.Build(context);
    var roadTypeMenu = RoadTypeModule.Build(context);
    var documentTypeMenu = DocumentTypeModule.Build(context);
    var flightRoleMenu = FlightRoleModule.Build(context);
    var flightStateMenu = FlightStateModule.Build(context);
    var paymentStateMenu = PaymentStateModule.Build(context);
    var permissionMenu = PermissionModule.Build(context);
    var phoneCodeMenu = PhoneCodeModule.Build(context);
    var reservationStatusMenu = ReservationStatusModule.Build(context);
    var seatLocationTypeMenu = SeatLocationTypeModule.Build(context);
    var systemRoleMenu = SystemRoleModule.Build(context);
    var ticketStatusMenu = TicketStatusModule.Build(context);
    var CabinTypeMenu = CabinTypeModule.Build(context);
    var PassengerTypeMenu = PassengerTypeModule.Build(context);

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA ===");
        Console.WriteLine("1. Continents");
        Console.WriteLine("2. AvailabilityStatuses");
        Console.WriteLine("3. CardTypes");
        Console.WriteLine("4. CheckinStatuses");
        Console.WriteLine("5. EmailDomains");
        Console.WriteLine("6. FlightRoles");
        Console.WriteLine("7. ReservationStatuses");
        Console.WriteLine("8. PhoneCodes");
        Console.WriteLine("9. SeatLocationTypes");
        Console.WriteLine("10. RoadTypes");
        Console.WriteLine("11. DocumenTypes");
        Console.WriteLine("12. CabinTypes");
        Console.WriteLine("13. PassengerTypes");
        Console.WriteLine("14. FlightStates");
        Console.WriteLine("15. PaymentStates");
        Console.WriteLine("16. TicketStatuses");
        Console.WriteLine("17. SystemRoles");
        Console.WriteLine("18. Permissions");
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
                await emailDomainMenu.StartAsync();
                break;

            case "6":
                await flightRoleMenu.StartAsync();
                break;

            case "7":
                await reservationStatusMenu.StartAsync();
                break;

            case "8":
                await phoneCodeMenu.StartAsync();
                break;

            case "9":
                await seatLocationTypeMenu.StartAsync();
                break;

            case "10":
                await roadTypeMenu.StartAsync();
                break;

            case "11":
                await documentTypeMenu.StartAsync();
                break;

            case "12":
                await CabinTypeMenu.StartAsync();
                break;
            case "13":
                await PassengerTypeMenu.StartAsync();
                break;
            case "14":
                await flightStateMenu.StartAsync();
                break;
            case "15":
                await paymentStateMenu.StartAsync();
                break;
            case "16":
                await ticketStatusMenu.StartAsync();
                break;
            case "17":
                await systemRoleMenu.StartAsync();
                break;
            case "18":
                await permissionMenu.StartAsync();
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
