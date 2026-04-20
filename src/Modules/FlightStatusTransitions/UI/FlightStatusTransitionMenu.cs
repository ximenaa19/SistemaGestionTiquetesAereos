using GestionAerolineas.src.Modules.FlightStates.Application.UseCases;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.UI;

public class FlightStatusTransitionMenu
{
    private readonly CreateFlightStatusTransitionUseCase _create;
    private readonly GetAllFlightStatusTransitionsUseCase _getAll;
    private readonly GetFlightStatusTransitionByIdUseCase _getById;
    private readonly GetFlightStatusTransitionByPairUseCase _getByPair;
    private readonly UpdateFlightStatusTransitionUseCase _update;
    private readonly DeleteFlightStatusTransitionUseCase _delete;

    private readonly GetAllFlightStatesUseCase _getAllFlightStates;
    private readonly GetFlightStateByNameUseCase _getFlightStateByName;

    public FlightStatusTransitionMenu(
        CreateFlightStatusTransitionUseCase create,
        GetAllFlightStatusTransitionsUseCase getAll,
        GetFlightStatusTransitionByIdUseCase getById,
        GetFlightStatusTransitionByPairUseCase getByPair,
        UpdateFlightStatusTransitionUseCase update,
        DeleteFlightStatusTransitionUseCase delete,
        GetAllFlightStatesUseCase getAllFlightStates,
        GetFlightStateByNameUseCase getFlightStateByName)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByPair = getByPair;
        _update = update;
        _delete = delete;
        _getAllFlightStates = getAllFlightStates;
        _getFlightStateByName = getFlightStateByName;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new flight status transition",
            "List all flight status transitions",
            "Get transition by ID",
            "Get transition by origin/destination (IDs)",
            "Get transition by origin/destination (Names)",
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
                            Console.WriteLine($"{item.Id.Value} - origen={item.OriginStateId.Value} -> destino={item.DestinationStateId.Value}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - origen={result.OriginStateId.Value} -> destino={result.DestinationStateId.Value}");
                        break;

                    case 3:
                        Console.WriteLine("Estados de vuelo disponibles:");
                        var states = await _getAllFlightStates.ExecuteAsync();
                        foreach (var s in states)
                            Console.WriteLine($"{s.Id.Value} - {s.Name.Value}");

                        Console.Write("\nIngrese el ID del estado ORIGEN: ");
                        int searchOriginId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el ID del estado DESTINO: ");
                        int searchDestinationId = int.Parse(Console.ReadLine()!);

                        var resultByPair = await _getByPair.ExecuteAsync(searchOriginId, searchDestinationId);

                        Console.WriteLine(resultByPair == null
                            ? "No encontrado"
                            : $"{resultByPair.Id.Value} - origen={resultByPair.OriginStateId.Value} -> destino={resultByPair.DestinationStateId.Value}");
                        break;

                    case 4:
                        Console.Write("Ingrese el nombre del estado ORIGEN: ");
                        string originName = Console.ReadLine()!;

                        Console.Write("Ingrese el nombre del estado DESTINO: ");
                        string destinationName = Console.ReadLine()!;

                        var origin = await _getFlightStateByName.ExecuteAsync(originName);
                        var destination = await _getFlightStateByName.ExecuteAsync(destinationName);

                        if (origin is null || destination is null)
                        {
                            Console.WriteLine("No encontrado (origen o destino inválido)");
                            break;
                        }

                        var resultByPairName = await _getByPair.ExecuteAsync(origin.Id.Value, destination.Id.Value);

                        Console.WriteLine(resultByPairName == null
                            ? "No encontrado"
                            : $"{resultByPairName.Id.Value} - origen={resultByPairName.OriginStateId.Value} -> destino={resultByPairName.DestinationStateId.Value}");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID de la transición: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del estado ORIGEN: ");
                        int newOriginId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del estado DESTINO: ");
                        int newDestinationId = int.Parse(Console.ReadLine()!);

                        await _update.ExecuteAsync(updateId, newOriginId, newDestinationId);
                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 6:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 7:
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

