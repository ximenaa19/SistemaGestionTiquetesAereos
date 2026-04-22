using System.Globalization;
using GestionAerolineas.src.Modules.Addresses.Application.UseCases;
using GestionAerolineas.src.Modules.Cities.Application.UseCases;
using GestionAerolineas.src.Modules.DocumentTypes.Application.UseCases;
using GestionAerolineas.src.Modules.EmailDomains.Application.UseCases;
using GestionAerolineas.src.Modules.People.Application.UseCases;
using GestionAerolineas.src.Modules.PersonEmails.Application.UseCases;
using GestionAerolineas.src.Modules.RoadTypes.Application.UseCases;
using GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;
using GestionAerolineas.src.Modules.Users.Application.UseCases;

namespace GestionAerolineas.src.Modules.People.UI;

public sealed class AdminCreatePersonFlow
{
    private const string CancelToken = "000000";
    private static readonly DateTime CancelledDate = DateTime.MinValue;

    private readonly CreatePersonUseCase _createPerson;
    private readonly GetPersonByDocumentUseCase _getPersonByDocument;
    private readonly CreatePersonEmailUseCase _createPersonEmail;
    private readonly GetAllDocumentTypesUseCase _getAllDocumentTypes;
    private readonly GetAllEmailDomainsUseCase _getAllEmailDomains;
    private readonly CreateAddressUseCase _createAddress;
    private readonly GetAllAddressesUseCase _getAllAddresses;
    private readonly GetAllRoadTypesUseCase _getAllRoadTypes;
    private readonly GetAllCitiesUseCase _getAllCities;
    private readonly GetAllSystemRolesUseCase _getAllSystemRoles;
    private readonly CreateUserUseCase _createUser;

    public AdminCreatePersonFlow(
        CreatePersonUseCase createPerson,
        GetPersonByDocumentUseCase getPersonByDocument,
        CreatePersonEmailUseCase createPersonEmail,
        GetAllDocumentTypesUseCase getAllDocumentTypes,
        GetAllEmailDomainsUseCase getAllEmailDomains,
        CreateAddressUseCase createAddress,
        GetAllAddressesUseCase getAllAddresses,
        GetAllRoadTypesUseCase getAllRoadTypes,
        GetAllCitiesUseCase getAllCities,
        GetAllSystemRolesUseCase getAllSystemRoles,
        CreateUserUseCase createUser)
    {
        _createPerson = createPerson;
        _getPersonByDocument = getPersonByDocument;
        _createPersonEmail = createPersonEmail;
        _getAllDocumentTypes = getAllDocumentTypes;
        _getAllEmailDomains = getAllEmailDomains;
        _createAddress = createAddress;
        _getAllAddresses = getAllAddresses;
        _getAllRoadTypes = getAllRoadTypes;
        _getAllCities = getAllCities;
        _getAllSystemRoles = getAllSystemRoles;
        _createUser = createUser;
    }

    public async Task StartAsync()
    {
        while (true)
        {
            Console.Clear();
            PrintHeader();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Escribe {CancelToken} para cancelar en cualquier momento.\n");
            Console.ResetColor();

            var draft = await CollectDraftAsync();
            if (draft is null)
                return;

            var choice = ConfirmChoice(draft);
            if (choice == 2)
                continue;
            if (choice == 3)
                return;

            try
            {
                int? addressId = null;
                if (draft.Address is not null)
                {
                    addressId = await CreateAddressAndGetIdAsync(draft.Address);
                }

                await _createPerson.ExecuteAsync(
                    draft.DocumentTypeId,
                    draft.DocumentNumber,
                    draft.FirstNames,
                    draft.LastNames,
                    draft.BirthDate,
                    draft.Gender,
                    addressId);

                var createdPerson = await _getPersonByDocument.ExecuteAsync(draft.DocumentTypeId, draft.DocumentNumber);
                if (createdPerson is null)
                    throw new Exception("No fue posible recuperar la persona creada.");

                if (!string.IsNullOrWhiteSpace(draft.EmailUser) && draft.EmailDomainId.HasValue)
                {
                    await _createPersonEmail.ExecuteAsync(
                        createdPerson.Id.Value,
                        draft.EmailUser!,
                        draft.EmailDomainId.Value,
                        true);
                }

                await _createUser.ExecuteAsync(
                    draft.Username,
                    draft.Password,
                    createdPerson.Id.Value,
                    draft.RoleId);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✔ Persona, correo y usuario creados correctamente.");
                Console.ResetColor();
                Console.WriteLine($"Persona ID: {createdPerson.Id.Value}");
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                return;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Error: {ex.GetBaseException().Message}");
                Console.ResetColor();
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private async Task<PersonDraft?> CollectDraftAsync()
    {
        var documentType = await SelectDocumentTypeAsync();
        if (documentType is null) return null;

        var documentNumber = ReadRequiredText("Numero de documento");
        if (documentNumber is null) return null;

        var firstNames = ReadRequiredText("Nombres");
        if (firstNames is null) return null;

        var lastNames = ReadRequiredText("Apellidos");
        if (lastNames is null) return null;

        var birthDate = ReadOptionalDate("Fecha de nacimiento (yyyy-MM-dd) [opcional]");
        if (birthDate == CancelledDate) return null;

        var gender = ReadOptionalGender("Genero (M/F/N) [opcional]");
        if (gender == CancelToken) return null;
        if (string.IsNullOrWhiteSpace(gender))
            gender = null;

        AddressDraft? address = null;
        var registerAddress = ReadYesNo("Desea registrar una direccion nueva? (S/N)");
        if (registerAddress is null) return null;
        if (registerAddress.Value)
        {
            address = await CollectAddressDraftAsync();
            if (address is null) return null;
        }

        string? emailUser = null;
        int? emailDomainId = null;
        string? emailDomainName = null;
        var registerEmail = ReadYesNo("Desea registrar correo principal? (S/N)");
        if (registerEmail is null) return null;
        if (registerEmail.Value)
        {
            emailUser = ReadRequiredText("Correo principal (usuario sin @)");
            if (emailUser is null) return null;

            var emailDomain = await SelectEmailDomainAsync();
            if (emailDomain is null) return null;
            emailDomainId = emailDomain.Value.id;
            emailDomainName = emailDomain.Value.name;
        }

        var role = await SelectRoleAsync();
        if (role is null) return null;

        var username = ReadRequiredText("Username para acceso");
        if (username is null) return null;

        var password = ReadRequiredPassword("Contrasena (minimo 8)");
        if (password is null) return null;

        return new PersonDraft(
            documentType.Value.id,
            documentType.Value.name,
            documentNumber,
            firstNames,
            lastNames,
            birthDate,
            gender,
            address,
            emailUser,
            emailDomainId,
            emailDomainName,
            role.Value.id,
            role.Value.name,
            username,
            password
        );
    }

    private async Task<AddressDraft?> CollectAddressDraftAsync()
    {
        var roadType = await SelectRoadTypeAsync();
        if (roadType is null) return null;

        var city = await SelectCityAsync();
        if (city is null) return null;

        var roadName = ReadRequiredText("Nombre de via");
        if (roadName is null) return null;

        var number = ReadOptionalText("Numero [opcional]");
        if (number == CancelToken) return null;

        var complement = ReadOptionalText("Complemento [opcional]");
        if (complement == CancelToken) return null;

        var postal = ReadOptionalText("Codigo postal [opcional]");
        if (postal == CancelToken) return null;

        return new AddressDraft(
            roadType.Value.id,
            roadType.Value.name,
            roadName,
            string.IsNullOrWhiteSpace(number) ? null : number,
            string.IsNullOrWhiteSpace(complement) ? null : complement,
            city.Value.id,
            city.Value.name,
            string.IsNullOrWhiteSpace(postal) ? null : postal
        );
    }

    private async Task<int?> CreateAddressAndGetIdAsync(AddressDraft address)
    {
        var before = (await _getAllAddresses.ExecuteAsync()).Select(x => x.Id.Value).DefaultIfEmpty(0).Max();

        await _createAddress.ExecuteAsync(
            address.RoadTypeId,
            address.RoadName,
            address.Number,
            address.Complement,
            address.CityId,
            address.PostalCode);

        var afterList = (await _getAllAddresses.ExecuteAsync()).Select(x => x.Id.Value).ToList();
        var createdId = afterList.Where(x => x > before).DefaultIfEmpty(afterList.DefaultIfEmpty(0).Max()).Max();
        return createdId == 0 ? null : createdId;
    }

    private async Task<(int id, string name)?> SelectDocumentTypeAsync()
    {
        var items = (await _getAllDocumentTypes.ExecuteAsync())
            .Select(x => (id: x.Id.Value, name: $"{x.Name.Value} ({x.Code.Value})"))
            .OrderBy(x => x.id)
            .ToList();
        return SelectById("TIPO DE DOCUMENTO", "Seleccione tipo_documento_id", items);
    }

    private async Task<(int id, string name)?> SelectEmailDomainAsync()
    {
        var items = (await _getAllEmailDomains.ExecuteAsync())
            .Select(x => (id: x.Id.Value, name: x.Domain.Value))
            .OrderBy(x => x.id)
            .ToList();
        return SelectById("DOMINIO EMAIL", "Seleccione dominio_email_id", items);
    }

    private async Task<(int id, string name)?> SelectRoadTypeAsync()
    {
        var items = (await _getAllRoadTypes.ExecuteAsync())
            .Select(x => (id: x.Id.Value, name: x.Name.Value))
            .OrderBy(x => x.id)
            .ToList();
        return SelectById("TIPO DE VIA", "Seleccione tipo_via_id", items);
    }

    private async Task<(int id, string name)?> SelectCityAsync()
    {
        var items = (await _getAllCities.ExecuteAsync())
            .Select(x => (id: x.Id.Value, name: $"{x.Name.Value} (region:{x.RegionId.Value})"))
            .OrderBy(x => x.id)
            .ToList();
        return SelectById("CIUDAD", "Seleccione ciudad_id", items);
    }

    private async Task<(int id, string name)?> SelectRoleAsync()
    {
        var items = (await _getAllSystemRoles.ExecuteAsync())
            .Select(x => (id: x.Id.Value, name: x.Name.Value))
            .OrderBy(x => x.id)
            .ToList();
        return SelectById("ROL DE USUARIO", "Seleccione rol_id", items);
    }

    private static (int id, string name)? SelectById(string title, string prompt, List<(int id, string name)> items)
    {
        while (true)
        {
            PrintMenuBox(title, items.Select(x => $"[{x.id}] {x.name}").ToList());
            var raw = ReadRaw(prompt);
            if (raw == CancelToken) return null;

            if (!int.TryParse(raw, out var id))
            {
                PrintFieldError("Debes ingresar un numero valido.");
                continue;
            }

            var found = items.FirstOrDefault(x => x.id == id);
            if (found == default)
            {
                PrintFieldError("El ID no existe en las opciones.");
                continue;
            }

            return found;
        }
    }

    private static int ConfirmChoice(PersonDraft draft)
    {
        while (true)
        {
            Console.Clear();
            PrintHeader();
            PrintMenuBox("RESUMEN", new List<string>
            {
                $"Tipo documento: {draft.DocumentTypeName}",
                $"Numero documento: {draft.DocumentNumber}",
                $"Nombres: {draft.FirstNames}",
                $"Apellidos: {draft.LastNames}",
                $"Fecha nacimiento: {(draft.BirthDate?.ToString("yyyy-MM-dd") ?? "NULL")}",
                $"Genero: {draft.Gender ?? "NULL"}",
                $"Direccion nueva: {(draft.Address is null ? "NO" : $"{draft.Address.RoadTypeName} {draft.Address.RoadName} {draft.Address.Number}")}",
                $"Correo principal: {GetEmailDisplay(draft)}",
                $"Rol: {draft.RoleName}",
                $"Username: {draft.Username}"
            });

            PrintMenuBox("SELECCIONE UNA OPCION", new List<string>
            {
                "[1] Confirmar",
                "[2] Editar",
                "[3] Cancelar"
            });

            var raw = ReadRaw("Opcion");
            if (raw == CancelToken || raw == "3") return 3;
            if (raw == "2") return 2;
            if (raw == "1") return 1;

            PrintFieldError("Debes ingresar 1, 2 o 3.");
        }
    }

    private static string GetEmailDisplay(PersonDraft draft)
    {
        if (string.IsNullOrWhiteSpace(draft.EmailUser) || !draft.EmailDomainId.HasValue || string.IsNullOrWhiteSpace(draft.EmailDomainName))
            return "NULL";

        return $"{draft.EmailUser}@{draft.EmailDomainName}";
    }

    private static string? ReadRequiredText(string label)
    {
        while (true)
        {
            var value = ReadRaw(label);
            if (value == CancelToken) return null;
            if (string.IsNullOrWhiteSpace(value))
            {
                PrintFieldError("Este campo es obligatorio.");
                continue;
            }

            return value.Trim();
        }
    }

    private static string ReadOptionalText(string label)
    {
        return ReadRaw(label);
    }

    private static string? ReadRequiredPassword(string label)
    {
        while (true)
        {
            var first = ReadHiddenRequired(label);
            if (first is null) return null;
            if (first.Length < 8)
            {
                PrintFieldError("La contrasena debe tener minimo 8 caracteres.");
                continue;
            }

            var confirm = ReadHiddenRequired("Confirmar contrasena");
            if (confirm is null) return null;
            if (first != confirm)
            {
                PrintFieldError("Las contrasenas no coinciden.");
                continue;
            }

            return first;
        }
    }

    private static string? ReadHiddenRequired(string label)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\n{label}: ");
        Console.ResetColor();

        var buffer = new List<char>();
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                var text = new string(buffer.ToArray()).Trim();
                if (text == CancelToken)
                    return null;

                if (string.IsNullOrWhiteSpace(text))
                {
                    PrintFieldError("Este campo es obligatorio.");
                    return string.Empty;
                }
                return text;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (buffer.Count == 0) continue;
                buffer.RemoveAt(buffer.Count - 1);
                Console.Write("\b \b");
                continue;
            }

            if (!char.IsControl(key.KeyChar))
            {
                buffer.Add(key.KeyChar);
                Console.Write("*");
            }
        }
    }

    private static DateTime? ReadOptionalDate(string label)
    {
        while (true)
        {
            var raw = ReadRaw(label);
            if (raw == CancelToken) return CancelledDate;
            if (string.IsNullOrWhiteSpace(raw)) return null;

            if (DateTime.TryParseExact(raw, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return date;

            PrintFieldError("Formato invalido. Usa yyyy-MM-dd.");
        }
    }

    private static string? ReadOptionalGender(string label)
    {
        while (true)
        {
            var raw = ReadRaw(label);
            if (raw == CancelToken) return CancelToken;
            if (string.IsNullOrWhiteSpace(raw)) return string.Empty;

            var normalized = raw.Trim().ToUpperInvariant();
            if (normalized is "M" or "F" or "N")
                return normalized;

            PrintFieldError("Genero invalido. Usa M, F o N.");
        }
    }

    private static bool? ReadYesNo(string label)
    {
        while (true)
        {
            var raw = ReadRaw(label);
            if (raw == CancelToken) return null;
            var normalized = raw.Trim().ToUpperInvariant();
            if (normalized is "S" or "SI" or "Y" or "YES") return true;
            if (normalized is "N" or "NO") return false;
            PrintFieldError("Debes ingresar S o N.");
        }
    }

    private static string ReadRaw(string label)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\n{label}: ");
        Console.ResetColor();
        return (Console.ReadLine() ?? string.Empty).Trim();
    }

    private static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine("          CREACION DE PERSONA           ");
        Console.WriteLine("========================================");
        Console.ResetColor();
    }

    private static void PrintMenuBox(string title, IReadOnlyList<string> lines)
    {
        var width = Math.Max(36, lines.DefaultIfEmpty(string.Empty).Max(x => x.Length) + 4);
        var horizontal = new string('═', width);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"\n╔{horizontal}╗");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"║ {title.PadRight(width - 1)}║");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"╠{horizontal}╣");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var line in lines)
            Console.WriteLine($"║ {line.PadRight(width - 1)}║");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"╚{horizontal}╝");
        Console.ResetColor();
    }

    private static void PrintFieldError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ {message}");
        Console.ResetColor();
    }

    private sealed record AddressDraft(
        int RoadTypeId,
        string RoadTypeName,
        string RoadName,
        string? Number,
        string? Complement,
        int CityId,
        string CityName,
        string? PostalCode
    );

    private sealed record PersonDraft(
        int DocumentTypeId,
        string DocumentTypeName,
        string DocumentNumber,
        string FirstNames,
        string LastNames,
        DateTime? BirthDate,
        string? Gender,
        AddressDraft? Address,
        string? EmailUser,
        int? EmailDomainId,
        string? EmailDomainName,
        int RoleId,
        string RoleName,
        string Username,
        string Password
    );
}

