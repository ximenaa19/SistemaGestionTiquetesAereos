using GestionAerolineas.src.Modules.AircraftManufacturers.Application.UseCases;
using GestionAerolineas.src.Modules.Countries.Application.UseCases;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.UI;

public class AircraftManufacturerMenu
{
    private readonly CreateAircraftManufacturerUseCase _create;
    private readonly GetAllAircraftManufacturersUseCase _getAll;
    private readonly GetAircraftManufacturerByIdUseCase _getById;
    private readonly GetAircraftManufacturerByNameUseCase _getByName;
    private readonly UpdateAircraftManufacturerUseCase _update;
    private readonly DeleteAircraftManufacturerUseCase _delete;

    private readonly GetAllCountriesUseCase _getAllCountries;

    public AircraftManufacturerMenu(
        CreateAircraftManufacturerUseCase create,
        GetAllAircraftManufacturersUseCase getAll,
        GetAircraftManufacturerByIdUseCase getById,
        GetAircraftManufacturerByNameUseCase getByName,
        UpdateAircraftManufacturerUseCase update,
        DeleteAircraftManufacturerUseCase delete,
        GetAllCountriesUseCase getAllCountries)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByName = getByName;
        _update = update;
        _delete = delete;
        _getAllCountries = getAllCountries;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new aircraft manufacturer",
            "List all aircraft manufacturers",
            "Get aircraft manufacturer by ID",
            "Get aircraft manufacturer by name",
            "Update an aircraft manufacturer",
            "Delete an aircraft manufacturer",
            "Exit"
        });

        while (true)
        {
            int option = menu.Show();

            try
            {
                switch (option)
                {
                    case 0:
                        await PrintCountriesAsync();

                        Console.Write("\nIngrese el nombre: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Ingrese el ID del país: ");
                        int countryId = int.Parse(Console.ReadLine()!);

                        await _create.ExecuteAsync(name, countryId);
                        Console.WriteLine("✔ Creado");
                        break;

                    case 1:
                        var countryMap = await GetCountryDisplayMapAsync();
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - {item.Name.Value} - País = {GetDisplay(countryMap, item.CountryId.Value)}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var byId = await _getById.ExecuteAsync(searchId);
                        if (byId is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        var countryMapById = await GetCountryDisplayMapAsync();
                        Console.WriteLine($"{byId.Id.Value} - {byId.Name.Value} - País ={GetDisplay(countryMapById, byId.CountryId.Value)}");
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre: ");
                        string searchName = Console.ReadLine()!;

                        var byName = await _getByName.ExecuteAsync(searchName);
                        if (byName is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        var countryMapByName = await GetCountryDisplayMapAsync();
                        Console.WriteLine($"{byName.Id.Value} - {byName.Name.Value} - País = {GetDisplay(countryMapByName, byName.CountryId.Value)}");
                        break;

                    case 4:
                        await PrintCountriesAsync();

                        Console.Write("\nIngrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo nombre: ");
                        string newName = Console.ReadLine()!;

                        Console.Write("Ingrese el nuevo ID del país: ");
                        int newCountryId = int.Parse(Console.ReadLine()!);

                        await _update.ExecuteAsync(updateId, newName, newCountryId);
                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private async Task PrintCountriesAsync()
    {
        Console.WriteLine("Países disponibles:");
        var countries = await _getAllCountries.ExecuteAsync();
        foreach (var c in countries)
            Console.WriteLine($"{c.Id.Value} - {c.Name.Value} - ISO={c.IsoCode.Value}");
    }

    private async Task<Dictionary<int, string>> GetCountryDisplayMapAsync()
    {
        var countries = await _getAllCountries.ExecuteAsync();
        return countries.ToDictionary(c => c.Id.Value, c => $"{c.Name.Value} ({c.IsoCode.Value})");
    }

    private static string GetDisplay(Dictionary<int, string> map, int id)
    {
        return map.TryGetValue(id, out var display) ? $"{display} [{id}]" : $"#{id}";
    }
}

