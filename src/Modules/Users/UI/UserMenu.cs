using System.Globalization;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Domain.Aggregate;

namespace GestionAerolineas.src.Modules.Users.UI;

public class UserMenu
{
    private readonly CreateUserUseCase _create;
    private readonly GetAllUsersUseCase _getAll;
    private readonly GetUserByIdUseCase _getById;
    private readonly GetUserByUsernameUseCase _getByUsername;
    private readonly GetUserByPersonIdUseCase _getByPersonId;
    private readonly GetUsersByRoleIdUseCase _getByRoleId;
    private readonly SearchUsersByPersonNameUseCase _searchByPersonName;
    private readonly GetActiveUsersUseCase _getActive;
    private readonly GetInactiveUsersUseCase _getInactive;
    private readonly UpdateUserUseCase _update;
    private readonly DeleteUserUseCase _delete;

    private readonly GetAllPeopleUseCase _getAllPeople;
    private readonly GetAllSystemRolesUseCase _getAllRoles;

    public UserMenu(
        CreateUserUseCase create,
        GetAllUsersUseCase getAll,
        GetUserByIdUseCase getById,
        GetUserByUsernameUseCase getByUsername,
        GetUserByPersonIdUseCase getByPersonId,
        GetUsersByRoleIdUseCase getByRoleId,
        SearchUsersByPersonNameUseCase searchByPersonName,
        GetActiveUsersUseCase getActive,
        GetInactiveUsersUseCase getInactive,
        UpdateUserUseCase update,
        DeleteUserUseCase delete,
        GetAllPeopleUseCase getAllPeople,
        GetAllSystemRolesUseCase getAllRoles)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _getByUsername = getByUsername;
        _getByPersonId = getByPersonId;
        _getByRoleId = getByRoleId;
        _searchByPersonName = searchByPersonName;
        _getActive = getActive;
        _getInactive = getInactive;
        _update = update;
        _delete = delete;
        _getAllPeople = getAllPeople;
        _getAllRoles = getAllRoles;
    }

    public async Task StartAsync()
    {
        var menu = new ConsoleMenu(new[]
        {
            "Create a new user",
            "List all users",
            "Get user by ID",
            "Get user by username",
            "Get user by person_id",
            "Get users by role_id",
            "Search users by person name",
            "Get active users",
            "Get inactive users",
            "Update a user",
            "Delete a user",
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
                        await PrintPeopleAsync();
                        await PrintRolesAsync();

                        Console.Write("\nIngrese username: ");
                        string username = Console.ReadLine()!;

                        Console.Write("Ingrese password: ");
                        string password = Console.ReadLine()!;

                        Console.Write("Ingrese person_id [opcional]: ");
                        int? personId = ReadNullableInt(Console.ReadLine());

                        Console.Write("Ingrese role_id: ");
                        int roleId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese activo (true/false) [default=true]: ");
                        var activeInput = Console.ReadLine();
                        bool isActive = string.IsNullOrWhiteSpace(activeInput) ? true : bool.Parse(activeInput!);

                        Console.Write("Ingrese last_access (yyyy-MM-dd HH:mm:ss) [opcional]: ");
                        DateTime? lastAccess = ReadNullableDateTime(Console.ReadLine());

                        await _create.ExecuteAsync(username, password, personId, roleId, isActive, lastAccess);
                        Console.WriteLine("✔ Creado");
                        break;

                    case 1:
                        await PrintListAsync(await _getAll.ExecuteAsync());
                        break;

                    case 2:
                        await PrintUsersForSelectionAsync();

                        Console.Write("\nIngrese el ID: ");
                        int searchId = int.Parse(Console.ReadLine()!);

                        var byId = await _getById.ExecuteAsync(searchId);
                        if (byId is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        await PrintOneAsync(byId);
                        break;

                    case 3:
                        Console.Write("Ingrese username: ");
                        string searchUsername = Console.ReadLine()!;

                        var byUsername = await _getByUsername.ExecuteAsync(searchUsername);
                        if (byUsername is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        await PrintOneAsync(byUsername);
                        break;

                    case 4:
                        await PrintPeopleAsync();

                        Console.Write("\nIngrese person_id: ");
                        int searchPersonId = int.Parse(Console.ReadLine()!);

                        var byPersonId = await _getByPersonId.ExecuteAsync(searchPersonId);
                        if (byPersonId is null)
                        {
                            Console.WriteLine("No encontrado");
                            break;
                        }

                        await PrintOneAsync(byPersonId);
                        break;

                    case 5:
                        await PrintRolesAsync();

                        Console.Write("\nIngrese role_id: ");
                        int searchRoleId = int.Parse(Console.ReadLine()!);

                        var byRole = await _getByRoleId.ExecuteAsync(searchRoleId);
                        await PrintListAsync(byRole);
                        break;

                    case 6:
                        Console.Write("Ingrese texto (nombre o apellido): ");
                        string searchText = Console.ReadLine() ?? string.Empty;

                        var byName = await _searchByPersonName.ExecuteAsync(searchText);
                        await PrintListAsync(byName);
                        break;

                    case 7:
                        await PrintListAsync(await _getActive.ExecuteAsync());
                        break;

                    case 8:
                        await PrintListAsync(await _getInactive.ExecuteAsync());
                        break;

                    case 9:
                        await PrintUsersForSelectionAsync();
                        await PrintPeopleAsync();
                        await PrintRolesAsync();

                        Console.Write("\nIngrese el ID: ");
                        int updateId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese username: ");
                        string newUsername = Console.ReadLine()!;

                        Console.Write("Ingrese nuevo password [opcional]: ");
                        string? newPassword = Console.ReadLine();

                        Console.Write("Ingrese person_id [opcional]: ");
                        int? newPersonId = ReadNullableInt(Console.ReadLine());

                        Console.Write("Ingrese role_id: ");
                        int newRoleId = int.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese activo (true/false): ");
                        bool newIsActive = bool.Parse(Console.ReadLine()!);

                        Console.Write("Ingrese last_access (yyyy-MM-dd HH:mm:ss) [opcional]: ");
                        DateTime? newLastAccess = ReadNullableDateTime(Console.ReadLine());

                        string? actingUsername = null;
                        if (!newIsActive)
                        {
                            Console.Write("Ingrese su username actual para validar la desactivacion: ");
                            actingUsername = Console.ReadLine();
                        }

                        await _update.ExecuteAsync(
                            updateId,
                            newUsername,
                            newPassword,
                            newPersonId,
                            newRoleId,
                            newIsActive,
                            newLastAccess,
                            actingUsername);
                        Console.WriteLine("✔ Actualizado");
                        break;

                    case 10:
                        await PrintUsersForSelectionAsync();

                        Console.Write("\nIngrese el ID: ");
                        int deleteId = int.Parse(Console.ReadLine()!);

                        await _delete.ExecuteAsync(deleteId);
                        Console.WriteLine("✔ Eliminado");
                        break;

                    case 11:
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

    private async Task PrintUsersForSelectionAsync()
    {
        Console.WriteLine("Users disponibles (primeros 30):");
        var list = (await _getAll.ExecuteAsync()).Take(30).ToList();
        if (list.Count == 0)
        {
            Console.WriteLine("(sin registros)");
            return;
        }

        var personMap = await GetPersonDisplayMapAsync();
        var roleMap = await GetRoleDisplayMapAsync();

        foreach (var item in list)
            Console.WriteLine(Format(item, personMap, roleMap));
    }

    private async Task PrintListAsync(IEnumerable<User> list)
    {
        var items = list.ToList();
        if (items.Count == 0)
        {
            Console.WriteLine("(sin resultados)");
            return;
        }

        var personMap = await GetPersonDisplayMapAsync();
        var roleMap = await GetRoleDisplayMapAsync();

        foreach (var item in items)
            Console.WriteLine(Format(item, personMap, roleMap));
    }

    private async Task PrintOneAsync(User item)
    {
        var personMap = await GetPersonDisplayMapAsync();
        var roleMap = await GetRoleDisplayMapAsync();
        Console.WriteLine(Format(item, personMap, roleMap));
    }

    private async Task PrintPeopleAsync()
    {
        Console.WriteLine("People disponibles:");
        var people = (await _getAllPeople.ExecuteAsync()).ToList();

        foreach (var person in people.Take(30))
            Console.WriteLine($"{person.Id.Value} - {person.FirstNames.Value} {person.LastNames.Value} - doc={person.DocumentNumber.Value}");

        if (people.Count > 30)
            Console.WriteLine("(Mostrando solo las primeras 30)");

        Console.WriteLine("(Dejar vacio permite crear un superadmin sin persona)");
    }

    private async Task PrintRolesAsync()
    {
        Console.WriteLine("\nRoles disponibles:");
        var roles = (await _getAllRoles.ExecuteAsync()).ToList();

        foreach (var role in roles.Take(30))
            Console.WriteLine($"{role.Id.Value} - {role.Name.Value}");

        if (roles.Count > 30)
            Console.WriteLine("(Mostrando solo los primeros 30)");
    }

    private async Task<Dictionary<int, string>> GetPersonDisplayMapAsync()
    {
        var people = await _getAllPeople.ExecuteAsync();
        return people.ToDictionary(p => p.Id.Value, p => $"{p.FirstNames.Value} {p.LastNames.Value}");
    }

    private async Task<Dictionary<int, string>> GetRoleDisplayMapAsync()
    {
        var roles = await _getAllRoles.ExecuteAsync();
        return roles.ToDictionary(r => r.Id.Value, r => r.Name.Value);
    }

    private static string Format(User item, Dictionary<int, string> personMap, Dictionary<int, string> roleMap)
    {
        string personDisplay = item.PersonId.Value.HasValue
            ? GetDisplay(personMap, item.PersonId.Value.Value)
            : "NULL";
        string roleDisplay = GetDisplay(roleMap, item.RoleId.Value);
        var lastAccessDisplay = item.LastAccess.Value?.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) ?? "NULL";
        var activeDisplay = item.IsActive.Value ? "active" : "inactive";

        return $"{item.Id.Value} - username={item.Username.Value} - person={personDisplay} - role={roleDisplay} - {activeDisplay} - lastAccess={lastAccessDisplay} - createdAt={item.CreatedAt.Value:yyyy-MM-dd HH:mm:ss} - updatedAt={item.UpdatedAt.Value:yyyy-MM-dd HH:mm:ss}";
    }

    private static string GetDisplay(Dictionary<int, string> map, int id)
    {
        return map.TryGetValue(id, out var display) ? $"{display} [{id}]" : $"#{id}";
    }

    private static int? ReadNullableInt(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        return int.Parse(input);
    }

    private static DateTime? ReadNullableDateTime(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        return DateTime.Parse(input, CultureInfo.InvariantCulture);
    }
}
