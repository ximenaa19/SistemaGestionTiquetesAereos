using GestionAerolineas.src.Modules.CabinTypes;
using GestionAerolineas.src.Modules.CardTypes;
using GestionAerolineas.src.Modules.CheckinStatuses;
using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.Modules.DocumentTypes;
using GestionAerolineas.src.Modules.EmailDomains;
using GestionAerolineas.src.Modules.FlightRoles;
using GestionAerolineas.src.Modules.FlightStates;
using GestionAerolineas.src.Modules.PhoneCodes;
using GestionAerolineas.src.Modules.PaymentStates;
using GestionAerolineas.src.Modules.ReservationStatuses;
using GestionAerolineas.src.Modules.RoadTypes;
using GestionAerolineas.src.Modules.SeatLocationTypes;
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
    var cardTypeMenu = CardTypeModule.Build(context);
    var checkinStatusMenu = CheckinStatusModule.Build(context);
    var emailDomainMenu = EmailDomainModule.Build(context);
    var roadTypeMenu = RoadTypeModule.Build(context);
    var documentTypeMenu = DocumentTypeModule.Build(context);
    var flightRoleMenu = FlightRoleModule.Build(context);
    var flightStateMenu = FlightStateModule.Build(context);
    var paymentStateMenu = PaymentStateModule.Build(context);
    var phoneCodeMenu = PhoneCodeModule.Build(context);
    var reservationStatusMenu = ReservationStatusModule.Build(context);
    var seatLocationTypeMenu = SeatLocationTypeModule.Build(context);
    var ticketStatusMenu = TicketStatusModule.Build(context);
    var CabinTypeMenu = CabinTypeModule.Build(context);
    var PassengerTypeMenu = PassengerTypeModule.Build(context);

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA ===");
        Console.WriteLine("1. Continents");
        Console.WriteLine("2. CardTypes");
        Console.WriteLine("3. CheckinStatuses");
        Console.WriteLine("4. EmailDomains");
        Console.WriteLine("5. FlightRoles");
        Console.WriteLine("6. ReservationStatuses");
        Console.WriteLine("7. PhoneCodes");
        Console.WriteLine("8. SeatLocationTypes");
        Console.WriteLine("9. RoadTypes");
        Console.WriteLine("10. DocumenTypes");
        Console.WriteLine("11. CabinTypes");
        Console.WriteLine("12. PassengerTypes");
        Console.WriteLine("13. FlightStates");
        Console.WriteLine("14. PaymentStates");
        Console.WriteLine("15. TicketStatuses");
        Console.WriteLine("0. Salir");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await continentMenu.StartAsync();
                break;

            case "2":
                await cardTypeMenu.StartAsync();
                break;

            case "3":
                await checkinStatusMenu.StartAsync();
                break;

            case "4":
                await emailDomainMenu.StartAsync();
                break;

            case "5":
                await flightRoleMenu.StartAsync();
                break;

            case "6":
                await reservationStatusMenu.StartAsync();
                break;

            case "7":
                await phoneCodeMenu.StartAsync();
                break;

            case "8":
                await seatLocationTypeMenu.StartAsync();
                break;

            case "9":
                await roadTypeMenu.StartAsync();
                break;

            case "10":
                await documentTypeMenu.StartAsync();
                break;

            case "11":
                await CabinTypeMenu.StartAsync();
                break;
            case "12":
                await PassengerTypeMenu.StartAsync();
                break;
            case "13":
                await flightStateMenu.StartAsync();
                break;
            case "14":
                await paymentStateMenu.StartAsync();
                break;
            case "15":
                await ticketStatusMenu.StartAsync();
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
