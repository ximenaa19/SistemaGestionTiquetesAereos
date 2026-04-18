using System;
using System.Threading.Tasks;
using GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;
namespace GestionAerolineas.src.Modules.ReservationStatuses.UI;

public class ReservationStatusMenu
{
    private readonly CreateReservationStatusUseCase _create;
    private readonly GetAllReservationStatusesUseCase _getAll;
    private readonly GetReservationStatusByIdUseCase _getById;
    private readonly GetReservationStatusByNameUseCase _getByName;
    private readonly UpdateReservationStatusUseCase _update;
    private readonly DeleteReservationStatusUseCase _delete;

    public ReservationStatusMenu(
        CreateReservationStatusUseCase create,
        GetAllReservationStatusesUseCase getAll,
        GetReservationStatusByIdUseCase getById,
        GetReservationStatusByNameUseCase getByName,
        UpdateReservationStatusUseCase update,
        DeleteReservationStatusUseCase delete)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByName = getByName;
        _update = update;
        _delete = delete;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new reservation status",
            "List all reservation statuses",
            "Get reservation status by ID",
            "Get reservation status by name",
            "Update a reservation status",
            "Delete a reservation status",
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
                        Console.Write("Ingrese el nombre: ");
                        string name = Console.ReadLine()!;

                        await _create.ExecuteAsync(name);
                        Console.WriteLine("âœ” Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - {item.Name.Value}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - {result.Name.Value}");
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre: ");
                        string searchName = Console.ReadLine()!;

                        var resultByName = await _getByName.ExecuteAsync(searchName);

                        Console.WriteLine(resultByName == null
                            ? "No encontrado"
                            : $"{resultByName.Id.Value} - {resultByName.Name.Value}");
                        break;

                    case 4:
                        Console.Write("Ingrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo nombre: ");
                        string newName = Console.ReadLine()!;

                        await _update.ExecuteAsync(updateId, newName);
                        Console.WriteLine("âœ” Actualizado");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("âœ” Eliminado");
                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"âŒ Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
