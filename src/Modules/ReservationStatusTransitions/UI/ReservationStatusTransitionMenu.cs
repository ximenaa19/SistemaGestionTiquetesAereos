using GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.UseCases;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.UI;

public class ReservationStatusTransitionMenu
{
    private readonly CreateReservationStatusTransitionUseCase _create;
    private readonly GetAllReservationStatusTransitionsUseCase _getAll;
    private readonly GetReservationStatusTransitionByIdUseCase _getById;
    private readonly GetReservationStatusTransitionByPairUseCase _getByPair;
    private readonly UpdateReservationStatusTransitionUseCase _update;
    private readonly DeleteReservationStatusTransitionUseCase _delete;

    public ReservationStatusTransitionMenu(
        CreateReservationStatusTransitionUseCase create,
        GetAllReservationStatusTransitionsUseCase getAll,
        GetReservationStatusTransitionByIdUseCase getById,
        GetReservationStatusTransitionByPairUseCase getByPair,
        UpdateReservationStatusTransitionUseCase update,
        DeleteReservationStatusTransitionUseCase delete)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByPair = getByPair;
        _update = update;
        _delete = delete;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new reservation status transition",
            "List all reservation status transitions",
            "Get transition by ID",
            "Get transition by origin/destination (IDs)",
            "Update a transition",
            "Delete a transition",
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
                        Console.Write("Ingrese el ID del estado ORIGEN: ");
                        int originId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el ID del estado DESTINO: ");
                        int destinationId = int.Parse(Console.ReadLine()!);

                        await _create.ExecuteAsync(originId, destinationId);
                        Console.WriteLine("✔ Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - origen={item.OriginStatusId.Value} -> destino={item.DestinationStatusId.Value}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - origen={result.OriginStatusId.Value} -> destino={result.DestinationStatusId.Value}");
                        break;

                    case 3:
                        Console.Write("Ingrese el ID del estado ORIGEN: ");
                        int searchOriginId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el ID del estado DESTINO: ");
                        int searchDestinationId = int.Parse(Console.ReadLine()!);

                        var resultByPair = await _getByPair.ExecuteAsync(searchOriginId, searchDestinationId);

                        Console.WriteLine(resultByPair == null
                            ? "No encontrado"
                            : $"{resultByPair.Id.Value} - origen={resultByPair.OriginStatusId.Value} -> destino={resultByPair.DestinationStatusId.Value}");
                        break;

                    case 4:
                        Console.Write("Ingrese el ID de la transición: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del estado ORIGEN: ");
                        int newOriginId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del estado DESTINO: ");
                        int newDestinationId = int.Parse(Console.ReadLine()!);

                        await _update.ExecuteAsync(updateId, newOriginId, newDestinationId);
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
}
