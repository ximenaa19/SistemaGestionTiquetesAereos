using GestionAerolineas.src.shared.Helpers;
using GestionAerolineas.src.Modules.RoadTypes;

try
{
    var context = DbContextFactory.Create();

    if (!context.Database.CanConnect())
    {
        Console.WriteLine("No se pudo conectar a la base de datos");
        return;
    }

    Console.WriteLine("Conexion exitosa\n");

    // 🔥 SOLO ESTO
    var roadTypeMenu = RoadTypeModule.Build(context);

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA ===");
        Console.WriteLine("1. RoadTypes");
        Console.WriteLine("0. Salir");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await roadTypeMenu.StartAsync();
                break;

            case "0":
                return;
        }
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
}