using System;
using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.shared.Ui;

namespace GestionAerolineas.src.Modules.Continents.UI;

public class ContinentConsoleUI : IModuleUI
{
    private readonly IContinentService _service;

    public string Key => "2";
    public string Title => "Continentes";

    public ContinentConsoleUI(IContinentService service) => _service = service;

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        while (true)
        {
            Console.WriteLine("\n=== CRUD CONTINENTES ===");
            Console.WriteLine("1. Crear continente");
            Console.WriteLine("2. Listar continentes");
            Console.WriteLine("3. Buscar por id");
            Console.WriteLine("4. Actualizar continente");
            Console.WriteLine("5. Eliminar continente");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            var option = Console.ReadLine()?.Trim();
            Console.WriteLine();

            try
            {
                switch (option)
                {
                    case "1": await CreateAsync(cancellationToken); break;
                    case "2": await ListAllAsync(cancellationToken); break;
                    case "3": await GetByIdAsync(cancellationToken); break;
                    case "4": await UpdateAsync(cancellationToken); break;
                    case "5": await DeleteAsync(cancellationToken); break;
                    case "0": return;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }

    private async Task CreateAsync(CancellationToken ct)
    {
        Console.Write("Nombre: ");
        var name = Console.ReadLine() ?? string.Empty;
        var result = await _service.CreateAsync(name, ct);
        Console.WriteLine($"Continente creado. Id: {result.Id.Value}, Nombre: {result.Name.Value}");
    }

    private async Task ListAllAsync(CancellationToken ct)
    {
        var list = await _service.GetAllAsync(ct);
        if (list.Count == 0) { Console.WriteLine("No hay continentes registrados."); return; }
        foreach (var c in list)
            Console.WriteLine($"- Id: {c.Id.Value} | Nombre: {c.Name.Value}");
    }

    private async Task GetByIdAsync(CancellationToken ct)
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Id inválido."); return; }
        var c = await _service.GetByIdAsync(id, ct);
        if (c is null) { Console.WriteLine("No encontrado."); return; }
        Console.WriteLine($"Id: {c.Id.Value} | Nombre: {c.Name.Value}");
    }

    private async Task UpdateAsync(CancellationToken ct)
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Id inválido."); return; }
        Console.Write("Nuevo nombre: ");
        var name = Console.ReadLine() ?? string.Empty;
        var result = await _service.UpdateAsync(id, name, ct);
        Console.WriteLine($"Actualizado. Id: {result.Id.Value}, Nombre: {result.Name.Value}");
    }

    private async Task DeleteAsync(CancellationToken ct)
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Id inválido."); return; }
        var deleted = await _service.DeleteAsync(id, ct);
        Console.WriteLine(deleted ? "Eliminado." : "No encontrado.");
    }


}
