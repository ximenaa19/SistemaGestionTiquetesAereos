using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.Modules.DocumentTypes;
using GestionAerolineas.src.Modules.EmailDomains;
using GestionAerolineas.src.Modules.FlightRoles;
using GestionAerolineas.src.Modules.PhoneCodes;
using GestionAerolineas.src.Modules.RoadTypes;
using GestionAerolineas.src.shared.Helpers;

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
    var emailDomainMenu = EmailDomainModule.Build(context);
    var roadTypeMenu = RoadTypeModule.Build(context);
    var documentTypeMenu = DocumentTypeModule.Build(context);
    var flightRoleMenu = FlightRoleModule.Build(context);
    var phoneCodeMenu = PhoneCodeModule.Build(context);

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA ===");
        Console.WriteLine("1. Continents");
        Console.WriteLine("2. EmailDomains");
        Console.WriteLine("3. FlightRoles");
        Console.WriteLine("4. PhoneCodes");
        Console.WriteLine("5. RoadTypes");
        Console.WriteLine("6. DocumenTypes");
        Console.WriteLine("0. Salir");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await continentMenu.StartAsync();
                break;

            case "2":
                await emailDomainMenu.StartAsync();
                break;

            case "3":
                await flightRoleMenu.StartAsync();
                break;

            case "4":
                await phoneCodeMenu.StartAsync();
                break;

            case "5":
                await roadTypeMenu.StartAsync();
                break;

            case "6":
                await documentTypeMenu.StartAsync();
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
