using GestionAerolineas.src.Modules.Continents;
using GestionAerolineas.src.shared.Helpers;
using GestionAerolineas.src.shared.Ui;

try
{
    var context = DbContextFactory.Create();
    
    var continentMenu = ContinentModule.Build(context);
 
    var modules = new List<IModuleUI>
    {
        continentMenu
    };

    if (context.Database.CanConnect())
    {
        Console.WriteLine("Conexion exitosa");
        await RunMainMenuAsync(modules);
    }
    else
    {
        Console.WriteLine("No se pudo conectar a la base de datos");
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

static async Task RunMainMenuAsync(IReadOnlyCollection<IModuleUI> modules)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("=== MENU PRINCIPAL ===");
        foreach (var menuModule in modules.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{menuModule.Key}. {menuModule.Title}");
        }
        Console.WriteLine("0. Salir");
        Console.Write("Selecciona una opción: ");
 
        var option = Console.ReadLine()?.Trim();
        Console.WriteLine();
 
        if (option == "0")
        {
            Console.WriteLine("Saliendo...");
            return;
        }
 
        var module = modules.FirstOrDefault(x => x.Key == option);
        if (module is null)
        {
            Console.WriteLine("Opción inválida.");
            continue;
        }
 
        await module.RunAsync();
    }
}
