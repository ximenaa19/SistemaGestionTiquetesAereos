using GestionAerolineas.src.Modules.Permissions.Application.UseCases;
using GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

namespace GestionAerolineas.src.Modules.RolePermissions.UI;

public class RolePermissionMenu
{
    private readonly CreateRolePermissionUseCase _create;
    private readonly GetAllRolePermissionsUseCase _getAll;
    private readonly GetRolePermissionByIdUseCase _getById;
    private readonly UpdateRolePermissionUseCase _update;
    private readonly DeleteRolePermissionUseCase _delete;

    private readonly GetAllSystemRolesUseCase _getAllSystemRoles;
    private readonly GetAllPermissionsUseCase _getAllPermissions;

    public RolePermissionMenu(
        CreateRolePermissionUseCase create,
        GetAllRolePermissionsUseCase getAll,
        GetRolePermissionByIdUseCase getById,
        UpdateRolePermissionUseCase update,
        DeleteRolePermissionUseCase delete,
        GetAllSystemRolesUseCase getAllSystemRoles,
        GetAllPermissionsUseCase getAllPermissions)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _update = update;
        _delete = delete;
        _getAllSystemRoles = getAllSystemRoles;
        _getAllPermissions = getAllPermissions;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new role permission",
            "List all role permissions",
            "Get role permission by ID",
            "Update a role permission",
            "Delete a role permission",
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
                        await PrintSystemRolesAndPermissionsAsync();

                        Console.Write("\nIngrese el ID del rol: ");
                        int roleId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el ID del permiso: ");
                        int permissionId = int.Parse(Console.ReadLine()!);

                        await _create.ExecuteAsync(roleId, permissionId);
                        Console.WriteLine("✔ Creado");
                        break;

                    case 1:
                        var list = await _getAll.ExecuteAsync();

                        foreach (var item in list)
                            Console.WriteLine($"{item.Id.Value} - rol_id={item.RoleId.Value} - permiso_id={item.PermissionId.Value}");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var result = await _getById.ExecuteAsync(searchId);

                        Console.WriteLine(result == null
                            ? "No encontrado"
                            : $"{result.Id.Value} - rol_id={result.RoleId.Value} - permiso_id={result.PermissionId.Value}");
                        break;

                    case 3:
                        await PrintSystemRolesAndPermissionsAsync();

                        Console.Write("\nIngrese el ID de la asignación: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del rol: ");
                        int newRoleId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese el nuevo ID del permiso: ");
                        int newPermissionId = int.Parse(Console.ReadLine()!);

                        await _update.ExecuteAsync(updateId, newRoleId, newPermissionId);
                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 4:
                        Console.Write("Ingrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 5:
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

    private async Task PrintSystemRolesAndPermissionsAsync()
    {
        Console.WriteLine("Roles del sistema disponibles:");
        var roles = await _getAllSystemRoles.ExecuteAsync();
        foreach (var r in roles)
            Console.WriteLine($"{r.Id.Value} - {r.Name.Value}");

        Console.WriteLine("\nPermisos disponibles:");
        var permissions = await _getAllPermissions.ExecuteAsync();
        foreach (var p in permissions)
            Console.WriteLine($"{p.Id.Value} - {p.Name.Value}");
    }
}

