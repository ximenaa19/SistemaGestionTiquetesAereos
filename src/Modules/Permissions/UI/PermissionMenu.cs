using GestionAerolineas.src.Modules.Permissions.Application.UseCases;

namespace GestionAerolineas.src.Modules.Permissions.UI;

public class PermissionMenu
{
    private readonly CreatePermissionUseCase _create;
    private readonly GetAllPermissionsUseCase _getAll;
    private readonly GetPermissionByIdUseCase _getById;
    private readonly GetPermissionByNameUseCase _getByName;
    private readonly UpdatePermissionUseCase _update;
    private readonly DeletePermissionUseCase _delete;

    public PermissionMenu(
        CreatePermissionUseCase create,
        GetAllPermissionsUseCase getAll,
        GetPermissionByIdUseCase getById,
        GetPermissionByNameUseCase getByName,
        UpdatePermissionUseCase update,
        DeletePermissionUseCase delete)
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
            "Create a new permission",
            "List all permissions",
            "Get permission by ID",
            "Get permission by name",
            "Update a permission",
            "Delete a permission",
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

                        Console.Write("Ingrese la descripcion (opcional): ");
                        string? description = Console.ReadLine();

                        await _create.ExecuteAsync(name, description);
                        Console.WriteLine("Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - {item.Name.Value} - descripcion={item.Description.Value ?? "null"}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - {result.Name.Value} - descripcion={result.Description.Value ?? "null"}");
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre: ");
                        string searchName = Console.ReadLine()!;

                        var resultByName = await _getByName.ExecuteAsync(searchName);

                        Console.WriteLine(resultByName == null
                            ? "No encontrado"
                            : $"{resultByName.Id.Value} - {resultByName.Name.Value} - descripcion={resultByName.Description.Value ?? "null"}");
                        break;

                    case 4:
                        Console.Write("Ingrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo nombre: ");
                        string newName = Console.ReadLine()!;

                        Console.Write("Ingrese la nueva descripcion (opcional): ");
                        string? newDescription = Console.ReadLine();

                        await _update.ExecuteAsync(updateId, newName, newDescription);
                        Console.WriteLine("Actualizado");
                        break;

                    case 5:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("Eliminado");
                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.GetBaseException().Message}");
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
